using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class LocalFileLogger<T> : ILogger
    {
        private string Path;

        public string GenericTypeName = typeof(T).Name;

        public LocalFileLogger(string _path)
        {
            Path = _path;
        }

        public void LogInfo(string message)
        {
            File.WriteAllText(Path, $"[Info]: [{GenericTypeName}] : {message}");
        }

        public void LogWarning(string message)
        {
            File.WriteAllText(Path, $"[Warning] : [{GenericTypeName}] : {message}");
        }

        public void LogError(string message, Exception ex)
        {
            File.WriteAllText(Path, $"[Error] : [{GenericTypeName}] : {message}. {ex.Message}");
        }
    }

}
