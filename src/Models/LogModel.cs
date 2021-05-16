﻿using System;

namespace NiuX.LogPanel.Models
{
    public class LogModel : ILogModel
    {
        public int Id { get; set; }

        public DateTime LongDate { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }

        public string Logger { get; set; }

        public string Exception { get; set; }
    }
}