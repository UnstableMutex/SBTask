using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPPool.Models;
namespace ASPPools.Models
{
    public class ResultsModel
    {
        public User User { get; set; }
        public List<AnswerModel> Answers { get; } = new List<AnswerModel>();
    }
    public class AnswerModel
    {
        public byte QuestionType { get; set; }
        public int QuestionID { get; set; }
        public string Question { get; set; }
    }
    public class OpenAnswerModel : AnswerModel
    {

        public string Answer { get; set; }

    }
    public class CheckAnswerModel : AnswerModel
    {
        public List<string> Answers { get; } = new List<string>();
    }
    public class UserPool
    {

        public User User { get; }
        public UserPool(User user, Pool pool)
        {
            User = user;
            Pool = pool;

        }
        public Pool Pool { get; }
    }
}