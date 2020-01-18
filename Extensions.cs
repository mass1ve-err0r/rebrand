using System.IO;

namespace rebrand {

    /// <summary>
    /// This is an auxillary class to extend File with a "Rename" functionality
    /// </summary>
    public static class Extensions {

        /// <summary>
        /// [EXTENSION] Renames the file
        /// </summary>
        /// <param name="fi">The FileInfo of the file</param>
        /// <param name="newFileName">The new filename WITH extension!</param>
        public static void Rename(this FileInfo fi, string newFileName) {
            fi.MoveTo(fi.Directory.FullName + "\\" + newFileName);
        }
    }
}
