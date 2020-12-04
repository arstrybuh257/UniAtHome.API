﻿namespace UniAtHome.BLL.DTOs.Test
{
    public class TestEditDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DurationMinutes { get; set; }

        public bool ShuffleQuestions { get; set; }

        public bool ShuffleVariants { get; set; }

        public int AttemptsAllowed { get; set; }

        public float MaxMark { get; set; }
    }
}
