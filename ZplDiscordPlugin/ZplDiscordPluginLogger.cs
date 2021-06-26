using DiscordRPC.Logging;
using YoYoStudio.Core.Utils;

namespace YoYoStudio
{
    namespace Plugins
    {
        namespace ZplDiscordPlugin
        {
            /// <summary>
            /// Provides a way for Discord RPC to log inside the ui.log file.
            /// Sure is a good thing that the Log.WriteLine function in the IDE
            /// *is* thread-safe, so no need to worry about that.
            /// All lines are written with the '[ZplDiscord|' prefix and the log level after the pipe char.
            /// </summary>
            public class ZplDiscordPluginLogger : ILogger
            {
                /// <summary>
                /// The level of logging to apply to this logger.
                /// </summary>
                public LogLevel Level { get; set; }

                /// <summary>
                /// Error log messsages
                /// </summary>
                /// <param name="message">Message to log or a CSharp format string</param>
                /// <param name="args">Format args</param>
                public void Error(string message, params object[] args)
                {
                    if (Level <= LogLevel.Error)   Log.WriteLine(eLog.Default, "[ZplDiscord|Error  ]: " + message, args);
                }

                /// <summary>
                /// Informative log messages
                /// </summary>
                /// <param name="message">Message to log or a CSharp format string</param>
                /// <param name="args">Format args</param>
                public void Info(string message, params object[] args)
                {
                    if (Level <= LogLevel.Info)    Log.WriteLine(eLog.Default, "[ZplDiscord|Info   ]: " + message, args);
                }

                /// <summary>
                /// Debug trace messeages used for debugging internal elements.
                /// </summary>
                /// <param name="message">Message to log or a CSharp format string</param>
                /// <param name="args">Format args</param>
                public void Trace(string message, params object[] args)
                {
                    if (Level <= LogLevel.Trace)   Log.WriteLine(eLog.Default, "[ZplDiscord|Trace  ]: " + message, args);
                }

                /// <summary>
                /// Warning log messages
                /// </summary>
                /// <param name="message">Message to log or a CSharp format string</param>
                /// <param name="args">Format args</param>
                public void Warning(string message, params object[] args)
                {
                    if (Level <= LogLevel.Warning) Log.WriteLine(eLog.Default, "[ZplDiscord|Warning]: " + message, args);
                }
            }
        }
    }
}
