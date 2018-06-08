﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Models.Request
{
    public class LogEntry
    {
        public DateTime EntryDate { get; set; }
        public string Message { get; set; }
        public LogLevel Level { get; set; }
        public object[] ExtraInfo { get; set; }
    }
}
