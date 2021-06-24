using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    PluginConfig config = new PluginConfig("Discord for Zeus", "Provides Rich Presence integration inside the GMS 2 IDE.", false);
                    config.AddCommand("discord_zpl_init", "ide_loaded", "Gets executed when the IDE is loaded.", "create", typeof(ZplDiscordPluginCommand));
                    return config;
                }
            }
        }
    }
}
