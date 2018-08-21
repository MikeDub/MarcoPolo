using System.IO;
using System.IO.Compression;
using Brotli;
using Microsoft.AspNetCore.ResponseCompression;

namespace KnockKnock.Web.Providers
{
    public class BrotliCompressionProvider : ICompressionProvider
    {
        public string EncodingName => "br";
        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream)
        {
            return new BrotliStream(
                outputStream,
                CompressionMode.Compress,
                false);
        }
    }
}
