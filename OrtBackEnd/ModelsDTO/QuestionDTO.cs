﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrtBackEnd.ModelsDTO
{
    public class QuestionDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? AnswerA { get; set; }
        public string? AnswerB { get; set; }
        public string? AnswerC { get; set; }
        public string? AnswerD { get; set; }
    }
}
