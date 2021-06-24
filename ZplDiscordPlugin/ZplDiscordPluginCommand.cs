using DiscordRPC;
using DiscordRPC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoYoStudio.Plugins.Attributes;
using YoYoStudio.Resources;

namespace YoYoStudio
{
    namespace Plugins
    {
        namespace ZplDiscordPlugin
        {
            [ModuleName("ZPL Discord", "Handles the Rich Presence connection.")]
            public class ZplDiscordPluginCommand : IModule, IDisposable
            {
                private ModulePackage IdeInterface { get; set; }
                private DiscordRpcClient RpcClient { get; set; }
                private ZplDiscordPluginLogger UILogger { get; set; }
                private Assets RichPresenceAssets { get; set; }
                private object LockObject { get; set; }

                public void OnInitialised()
                {
                    RpcClient.SetPresence(new RichPresence()
                    {
                        State = "In the menu...",
                        Assets = RichPresenceAssets
                    });
                }

                public void OnProjectLoaded()
                {
                    RpcClient.SetPresence(new RichPresence()
                    {
                        State = ProjectInfo.Current.name,
                        Details = "Editing a project...",
                        Assets = RichPresenceAssets
                    });
                }

                public void OnProjectClosed()
                {
                    RpcClient.SetPresence(new RichPresence()
                    {
                        State = "In the menu...",
                        Assets = RichPresenceAssets
                    });
                }

                [Function("discord_zpl_tick", "ide_tick", "Dispatches the RPC events.")]
                public void Tick()
                {
                    if (!IDE.IsProjectLoadingComplete)
                        return;

                    lock (LockObject)
                    {
                        if (RpcClient != null)
                            RpcClient.Invoke();
                    }
                }

                public void OnRpcError(object sender, ErrorMessage args)
                {
                    UILogger.Trace("OnRpcError(): args -> code='{0}',message='{1}'.", args.Code, args.Message);
                }

                public void Initialise(ModulePackage _ide)
                {
                    LockObject = new object();
                    IdeInterface = _ide;
                    UILogger = new ZplDiscordPluginLogger(); // <-- this will log into ui.log
                    RichPresenceAssets = new Assets();
                    RpcClient = new DiscordRpcClient("857230153015754772", -1, UILogger, false);
                    // do not dispatch RPC events automatically
                    // they will be handled in the IDE.Tick() method on the IDE thread for consistency

                    // set assets here:
                    RichPresenceAssets.LargeImageKey = "gmsbiglogo";

                    RpcClient.OnError += OnRpcError;

                    RpcClient.Initialize();

                    // set callbacks here:
                    IDE.OnProjectLoaded += OnProjectLoaded;
                    IDE.OnProjectClosed += OnProjectClosed;
                    IDE.OnInitialised += OnInitialised;
                }

                #region IDisposable Support
                private bool disposed = false; // To detect redundant calls

                protected virtual void Dispose(bool disposing)
                {
                    if (!disposed)
                    {
                        if (disposing)
                        {
                            // TODO: dispose managed state (managed objects).
                            RpcClient.Dispose();
                        }

                        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                        // TODO: set large fields to null.
                        RpcClient = null;

                        disposed = true;
                    }
                }

                ~ZplDiscordPluginCommand() {
                    // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                    Dispose(false);
                }

                // This code added to correctly implement the disposable pattern.
                public void Dispose()
                {
                    // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                    Dispose(true);
                    // TODO: uncomment the following line if the finalizer is overridden above.
                    GC.SuppressFinalize(this);
                }
                #endregion

            }
        }
    }
}