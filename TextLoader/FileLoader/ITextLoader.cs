using System;

namespace TextLoader.FileLoader
{
    /// <summary>
    /// Provides interface of text loaders from any sources
    /// </summary>
    public interface ITextLoader
    {
        /// <summary>
        /// Load file with specified path
        /// </summary>
        /// <param name="path">File path</param>
        void LoadFile(String path);

        /// <summary>
        /// Get unformatted text from file
        /// </summary>
        /// <returns>Unformatted text</returns>
        String ExtractText();
    }
}
