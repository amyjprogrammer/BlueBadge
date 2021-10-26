using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class QuestionService
    {
        private readonly Guid _userId;

        public QuestionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateQuestion(QuestionCreate model)
        {
            var entity =
                new Question()
                {
                    CustomerId = _userId,
                    Title = model.Title,
                    PollQuestion = model.PollQuestion,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Questions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<QuestionListItem> GetQuestions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Questions
                        .Where(e => e.CustomerId == _userId)
                        .Select(
                            e =>
                                new QuestionListItem
                                {
                                    QuestionId = e.QuestionId,
                                    Title = e.Title,
                                    PollQuestion = e.PollQuestion,
                                    CreatedUtc = e.CreatedUtc,
                                }
                        );
                return query.ToArray();
            }
        }
        public QuestionDetail GetQuestionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.QuestionId == id && e.CustomerId == _userId);
                return
                    new QuestionDetail
                    {
                        QuestionId = entity.QuestionId,
                        Title = entity.Title,
                        PollQuestion = entity.PollQuestion,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateQuestion(QuestionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.QuestionId == model.QuestionId && e.CustomerId == _userId);
                entity.Title = model.Title;
                entity.PollQuestion = model.Title;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteQuestion(int questionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.QuestionId == questionId && e.CustomerId == _userId);
                ctx.Questions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
