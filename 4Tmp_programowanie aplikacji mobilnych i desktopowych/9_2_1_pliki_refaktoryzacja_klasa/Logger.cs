using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_2_1_pliki
{
    internal class Logger
    {
        private readonly string _file;

        public enum LogType { Info, Success, Error, Edit, Filter }

        public Logger(string file)
        {
            _file = file;
        }

        public void Log(string message, LogType type = LogType.Info, bool showOnConsole = true)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string typeStr = type.ToString().PadRight(7);
            string entry = $"[{timestamp}] [{typeStr}] {message}";

            // zapis do pliku
            try
            {
                File.AppendAllText(_file, entry + Environment.NewLine, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"NIE UDAŁO SIĘ ZAPISAĆ LOGU: {ex.Message}");
            }

            if (showOnConsole)
            {
                ConsoleColor original = Console.ForegroundColor;

                Console.ForegroundColor = type switch
                {
                    LogType.Success => ConsoleColor.Green,
                    LogType.Error => ConsoleColor.Red,
                    LogType.Info => ConsoleColor.Cyan,
                    LogType.Edit => ConsoleColor.Yellow,
                    LogType.Filter => ConsoleColor.Magenta,
                    _ => ConsoleColor.Gray
                };

                Console.WriteLine(message);
                Console.ForegroundColor = original;
            }
        }

        public void ShowLogs()
        {
            if (!File.Exists(_file))
            {
                Console.WriteLine("Brak pliku logów");
                return;
            }

            Console.WriteLine("\n=== LOGI SYSTEMOWE ===\n");
            foreach (string line in File.ReadAllLines(_file, Encoding.UTF8))
                Console.WriteLine(line);
        }
    }
}
