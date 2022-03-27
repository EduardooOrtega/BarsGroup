using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class LocalFileLogger<T> : ILogger
    {
        private readonly string Path;

        public string GenericTypeName = typeof(T).Name;

        public LocalFileLogger(string _path)
        {
            Path = _path;
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(Path, $"[Info]: [{GenericTypeName}] : {message}" + Environment.NewLine);
        }

        public void LogWarning(string message)
        {
            File.AppendAllText(Path, $"[Warning] : [{GenericTypeName}] : {message}" + Environment.NewLine);
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(Path, $"[Error] : [{GenericTypeName}] : {message}. {ex.Message}" + Environment.NewLine);
        }
    }

}
