using MediaInfo;
using System.Linq;
using System.Text;

namespace ConsumingLibrary
{
    public class MediaInfoLogger : ILogger
    {
        private readonly StringBuilder log;

        public MediaInfoLogger(StringBuilder log) => this.log = log;

        public void Log(LogLevel loglevel, string message, params object[] parameters)
        {
            log.Append('[').Append(loglevel).Append("] ").AppendLine(message);

            if (parameters?.Any() == true)
            {
                log.AppendLine();
                log.AppendLine("Arguments:");
                log.AppendLine();

                for (int pIndex = 0; pIndex < parameters.Length; pIndex++)
                {
                    log.Append("#").Append(pIndex + 1).Append(" [").Append(parameters[pIndex].GetType().Name).Append("] ").Append(parameters[pIndex]).AppendLine();
                }

                log.AppendLine();
            }
        }
    }
}
