namespace YoYoStudio
{
    namespace Plugins
    {
        namespace ZplDiscordPlugin
        {
            public class ZplDiscordPluginInit : IPlugin
            {
                public PluginConfig Initialise()
                {
                    PluginConfig config = new PluginConfig("Discord Rich Presence for Zeus", "Provides Rich Presence integration inside the GMS 2 IDE.", false);
                    config.AddCommand("zpldiscordplugin_command", "ide_loaded", "Gets executed when the IDE is loaded.", "create", typeof(ZplDiscordPluginCommand));
                    return config;
                }
            }
        }
    }
}
