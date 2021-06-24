using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoYoStudio.Core.Utils;

namespace YoYoStudio
{
    namespace Plugins
    {
        namespace ZplDiscordPlugin
        {
            /// <summary>
            /// Provides a way for Discord RPC to log inside the ui.log file.
            /// </summary>
            public class ZplDiscordPluginLogger : ILogger
            {
                public LogLevel Level { get; set; }

                public void Error(string message, params object[] args)
                {
                    if (Level <= LogLevel.Error)   Log.WriteLine(eLog.Default, "[ZplDiscord|Error  ]: " + message, args);
                }

                public void Info(string message, params object[] args)
                {
                    if (Level <= LogLevel.Info)    Log.WriteLine(eLog.Default, "[ZplDiscord|Info   ]: " + message, args);
                }

                public void Trace(string message, params object[] args)
                {
                    if (Level <= LogLevel.Trace)   Log.WriteLine(eLog.Default, "[ZplDiscord|Trace  ]: " + message, args);
                }

                public void Warning(string message, params object[] args)
                {
                    if (Level <= LogLevel.Warning) Log.WriteLine(eLog.Default, "[ZplDiscord|Warning]: " + message, args);
                }
            }
        }
    }
}