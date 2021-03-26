using FabulousClone.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FabulousClone.Models
{
    [Table("users")]
    public class UserModel
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; } = 1;

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("gender")]
        public Gender Gender { get; set; }

        [Column("wake_up_time")]
        public TimeSpan WakeUpTime { get; set; } = new TimeSpan(7, 0, 0);

        [Column("send_emails")]
        public bool SendEmails { get; set; } = true;
    }
}
