namespace GameTrackLib.Extensions
{
    public static class ConsoleExtension
    {

        private static readonly object _lock = new object();

        /// <summary>
        /// A better Write method (handle comprehension for color in the string)<br/>
        /// <br/>
        /// Color code (Maj is for dark and Min is for light):<br/>
        /// - ^W : black<br/>
        /// - ^w : white<br/>
        /// - ^r : red <br/>
        /// - ^v : green<br/>
        /// - ^b : blue<br/>
        /// - ^c : cyan<br/>
        /// - ^m : magenta<br/>
        /// - ^j : yellow<br/>
        /// - ^g : gray
        /// </summary>
        /// <param name="str"></param>
        public static void Write(string str)
        {
            lock (_lock)
            {
                bool isColorChange = false;
                foreach (char c in str)
                {
                    if (c == '^')
                    {
                        isColorChange = true;
                        continue;
                    }
                    if (isColorChange)
                    {
                        switch (c)
                        {
                            case 'W':
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            case 'w':
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 'B':
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 'b':
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 'V':
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 'v':
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 'C':
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 'c':
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 'R':
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 'r':
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 'M':
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 'm':
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 'J':
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 'j':
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 'G':
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                break;
                            case 'g':
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;

                            default:
                                Console.Write('^');
                                Console.Write(c);
                                break;
                        }
                        isColorChange = false;
                    }
                    else Console.Write(c);
                }
                Console.ResetColor();
            }
        }

        /// <summary>
        /// A better Writeline method (handle comprehension for color in the string)<br/>
        /// <br/>
        /// Color code (Maj is for dark and Min is for light):<br/>
        /// - ^W : black<br/>
        /// - ^w : white<br/>
        /// - ^r : red <br/>
        /// - ^v : green<br/>
        /// - ^b : blue<br/>
        /// - ^c : cyan<br/>
        /// - ^m : magenta<br/>
        /// - ^j : yellow<br/>
        /// - ^g : gray
        /// </summary>
        /// <param name="str"></param>
        public static void WriteLine(string str)
        {
            Write(str);
            Console.WriteLine();
        }
    }
}
