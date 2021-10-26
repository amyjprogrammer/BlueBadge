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

        public IEnumerable<PollChoiceListItem> GetPollChoice()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.
                    PollChoices.Select
                    (e =>
                           new PollChoiceListItem
                           {
                               PollId = e.PollId,
                               QuestionId = e.QuestionId,
                               Choices = e.Choices
                           }

                        );
                return query.ToArray();
            }
        }
    }
}
