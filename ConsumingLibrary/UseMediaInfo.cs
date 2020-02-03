using MediaInfo;
using System.Text;

namespace ConsumingLibrary
{
    public class UseMediaInfo
    {
        private readonly ILogger logger;

        public UseMediaInfo(StringBuilder log)
        {
            // Build this here instead of passing in DI to avoid dependency on MediaInfo in the root console.
            logger = new MediaInfoLogger(log);
        }

        public bool TryLoading(string filePath)
        {
            return !new MediaInfoWrapper(filePath, logger).MediaInfoNotloaded;
        }
    }
}
