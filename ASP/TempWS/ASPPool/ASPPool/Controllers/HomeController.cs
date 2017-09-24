using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPPool.Extentions;
using ASPPool.Models;
using ASPPools.Models;

namespace ASPPool.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View(new User());
        }

        public ActionResult GetReadyResults()
        {
            var userID = (short)TempData["UserID"];
            var resultsModel = GetResultsModel(userID);
            return View(resultsModel);
        }

        [HttpPost]
        public ActionResult GetResults(FormCollection collection)
        {
            var col = collection;
            var userID = (short)TempData["UserID"];
            var db = new PoolEntities();
            foreach (string key in col.Keys)
            {
                if (key.EndsWith("CheckAnswer"))
                {
                    bool v = col[key] == "on";
                    if (v)
                    {
                        var cha = new UserCheckAnswer();
                        cha.User_ID = userID;
                        cha.CheckAnswer_ID = GetCheckAnswerID(key);
                        db.UserCheckAnswers.Add(cha);
                    }
                }
                if (key.EndsWith("TextAnswer"))
                {
                    string v = col[key];
                    var oa = new UserOpenAnswer();
                    oa.User_ID = userID;
                    oa.Question_ID = GetQuestionID(key);
                    oa.Answer = v;
                    db.UserOpenAnswers.Add(oa);
                }
            }
            db.SaveChanges();
            return RedirectToAction("GetReadyResults");
        }

        private ResultsModel GetResultsModel(short userId)
        {
            var db = new PoolEntities();
            var u = db.Users.Single(x => x.ID == userId);
            ResultsModel m = new ResultsModel();
            m.User = u;
            var p = db.Pools.Single();

            foreach (var q in p.Questions)
            {

                if (q.QuestionType_ID == 1)
                {
                    //открытый
                    var answers = q.UserOpenAnswers.Where(x => x.User_ID == u.ID);
                    var am = new OpenAnswerModel();
                    m.Answers.Add(am);
                    am.QuestionID = q.ID;
                    am.Question = q.Question1;
                    am.QuestionType = q.QuestionType_ID;
                    am.Answer = answers.Single().Answer;

                }
                if (q.QuestionType_ID == 2)
                {
                    //checked
                    var answers = db.UserCheckAnswers.Where(x => x.CheckAnswer.Question_ID == q.ID).Select(x => x.CheckAnswer);
                    var am = new CheckAnswerModel();
                    m.Answers.Add(am);
                    am.QuestionType = q.QuestionType_ID;
                    am.QuestionID = q.ID;
                    am.Question = q.Question1;
                    foreach (var a in answers.OrderBy(x => x.ID))
                    {
                        am.Answers.Add(a.Answer);
                    }
                }
            }
            return m;
        }

        private int GetCheckAnswerID(string key)
        {
            return int.Parse(key.Between("[", "]", 1));
        }

        private int GetQuestionID(string key)
        {
            return int.Parse(key.Between("[", "]"));
        }



        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            PoolEntities db = new PoolEntities();
            var u = db.Users.SingleOrDefault(x => x.Name == user.Name);
            if (u == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            else
            {
                user = u;
            }
            var userPassPoolAlready = db.UserOpenAnswers.Any(x => x.User_ID == user.ID);
            TempData["UserID"] = user.ID;
            if (userPassPoolAlready)
            {
                return RedirectToAction("GetReadyResults");
            }
            var pool = db.Pools.FirstOrDefault();
            return View(new UserPool(user, pool));
        }
    }
}