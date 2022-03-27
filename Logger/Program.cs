using Logger;

LocalFileLogger<int> localFileLoggerInt = new LocalFileLogger<int>("testInt.txt");

localFileLoggerInt.LogInfo("123");
localFileLoggerInt.LogWarning("123");
localFileLoggerInt.LogError("123", new NullReferenceException());


LocalFileLogger<char[]> localFileLoggerCharArray = new LocalFileLogger<char[]>("testCharArray.txt");

localFileLoggerCharArray.LogInfo("123");
localFileLoggerCharArray.LogWarning("123");
localFileLoggerCharArray.LogError("123", new NullReferenceException());
