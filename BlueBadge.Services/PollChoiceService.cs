using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class PollChoiceService
    {
        private readonly Guid _userId;
        public PollChoiceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePollChoice(PollChoiceCreate model)
        {
            var entity =
                new PollChoice()
                {
                    QuestionId = model.QuestionId,
                    Choices = model.Choices,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PollChoices.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
