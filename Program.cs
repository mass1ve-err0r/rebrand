using System;
using System.IO;
using System.Diagnostics;

namespace rebrand {
    class Program {

        // global vars
        public static String cDirectory;
        public static String cFileExtensionPattern;
        public static String cFileExtension;
        public static String cTag;
        public static Boolean cIsFront;

        /// <summary>
        /// Entrypoint / Main method
        /// </summary>
        static void Main() {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length != 4) {
                PrintHelp();
                ExitWithMessage(null, 0);
            }
            cFileExtension = "." + args[1].Remove(0, 1);
            cFileExtensionPattern = "*." + args[1].Remove(0, 1);
            StripPathAndMode(args[2]);
            if (cIsFront) {
                cTag = args[3] + "_";
            } else {
                cTag = "_" + args[3];
            }
            TagItems();
        }

        /// <summary>
        /// Start tagging with set (global) params. this also logs the time
        /// </summary>
        static void TagItems() {
            var watch = Stopwatch.StartNew();
            string[] matchingFiles = Directory.GetFiles(cDirectory, cFileExtensionPattern);
            if (matchingFiles.Length == 0 || matchingFiles == null) {
                watch.Stop();
                ExitWithMessage("No Files found with given extension. We are done.", 0);
            }
            Console.WriteLine("Working...");
            InitProgressBar(matchingFiles.Length);
            for (int i = 0; i < matchingFiles.Length; i++) {
                if (cIsFront) {
                    FileInfo entry = new FileInfo(matchingFiles[i]);
                    entry.Rename(cTag + Path.GetFileNameWithoutExtension(matchingFiles[i]) + cFileExtension);
                    DrawProgress();
                } else {
                    FileInfo entry = new FileInfo(matchingFiles[i]);
                    entry.Rename(Path.GetFileNameWithoutExtension(matchingFiles[i]) + cTag + cFileExtension);
                    DrawProgress();
                }
            }
            watch.Stop();
            Console.WriteLine("\nDONE | Needed Time: " + watch.ElapsedMilliseconds + "ms");
        }

        /// <summary>
        /// Strips the Path and the tagging style from the parameter
        /// </summary>
        /// <param name="str">The parameter string for tagging type & path</param>
        static void StripPathAndMode(string str) {
            if (str.Equals("-lf")) {
                cDirectory = Environment.CurrentDirectory;
                cIsFront = true;
            } else if (str.Equals("-lb")) {
                cDirectory = Environment.CurrentDirectory;
                cIsFront = false;
            } else if (Directory.Exists(str.Substring(2))) {
                cDirectory = str.Substring(2);
                if (str.Substring(0, 2).Equals("-f")) {
                    cIsFront = true;
                } else if (str.Substring(0, 2).Equals("-b")) {
                    cIsFront = false;
                } else {
                    throw new ArgumentException("The positional argument could NOT be parsed! Aborting...");
                }
            } else {
                throw new DirectoryNotFoundException("Directory was NOT found! Aborting...");
            }
        }

        /// <summary>
        /// Initializes a ProgressBar on the commandline dynamically
        /// </summary>
        /// <param name="max">The max. amount of files</param>
        static void InitProgressBar(int max) {
            Console.Write("[");
            Console.CursorLeft = max + 1;
            Console.Write("]");
            Console.CursorLeft = 1;
        }

        /// <summary>
        /// Increment the Progress
        /// </summary>
        static void DrawProgress() {
            Console.Write("#");
        }


        /// <summary>
        /// Print the help message
        /// </summary>
        static void PrintHelp() {
            Console.WriteLine("" +
                "rebrand - A (quick) tagging utility\n" +
                "Usage:\n" +
                "rebrand -<format> -lf <tagname> : Tag all files (tag in front) of a certain format in the local folder\n" +
                "rebrand -<format> -lb <tagname> : Tag all files (tag in back) of a certain format in the local folder\n" +
                "rebrand -<format> -f<Path> <tagname> : Tag all files (tag in front) of a certain format in the specified folder\n" +
                "rebrand -<format> -b<Path> <tagname> : Tag all files (tag in back) of a certain format in the specified folder\n" +
                "rebrand -h : Show this helptext\n\n" +
                "If you need examples, look on the Wiki at GitHub (https://github.com/mass1ve-err0r/rebrand)\n");
        }

        /// <summary>
        /// Exit applciation with a custom message and exit code
        /// </summary>
        /// <param name="message">The (error-) message to show</param>
        /// <param name="exitCode">The custom exit-code to use</param>
        static void ExitWithMessage(string message, int exitCode) {
            if (!String.IsNullOrEmpty(message)) {
                Console.WriteLine(message);
            }
            Environment.Exit(exitCode);
        }

        // <-- FIN -->
    }
}
