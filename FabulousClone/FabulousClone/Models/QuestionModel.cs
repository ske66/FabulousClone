using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FabulousClone.Models
{
    [Table("questions")]
    public class QuestionModel
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("choices")]
        public string Choices { get; set; }
        [Column("choice")]
        public int Choice { get; set; }
    }

    public class ChoiceModel
    {
        public ChoiceModel(int id, string choice)
        {
            Id = id;
            Choice = choice;
        }

        public int Id { get; set; }
        public string Choice { get; set; }
    }

}
