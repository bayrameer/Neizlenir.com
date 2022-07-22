using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Core.BLL.Logger
{
    public static class SarLog
    {
        public static void LogWrite(string message, WriteLogType logType)
        {
            FileStream fileStream = new FileStream("Logger.txt", FileMode.Append);
            StreamWriter writer
                = new StreamWriter(fileStream);
            writer.WriteLine(message);
            writer.Flush();
            writer.Close();

        }
    }

    public enum WriteLogType
    {
        Insert,
        Update,
        Delete
    }
}
