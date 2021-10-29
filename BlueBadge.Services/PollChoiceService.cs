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
     

        //Create Poll Choice Service 
        public bool CreatePollChoice(PollChoiceCreate model)
        {
            var entity =
                new PollChoice()
                {
                    QuestionId = model.QuestionId,
                    Choice = model.Choice,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PollChoices.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //Get All Poll Choices Service
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
                               Choice = e.Choice
                           }

                        );
                return query.ToList();
            }
        }

        //Get Poll Choice By Id Service
        public PollChoiceDetail GetPollChoiceById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    PollChoices.
                    Single(e => e.PollId == Id);
                return
                    new PollChoiceDetail
                    {
                        PollId = entity.PollId,
                        Choice = entity.Choice,
                    };
            }
        }

        //Update Poll Choice Service
        public bool UpdatePollChoice(PollChoiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    PollChoices.
                    Single(e => e.QuestionId == model.QuestionId);
                entity.Choice = model.Choice;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Poll Choice Service
        public bool DeletePollChoice(int pollId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PollChoices
                    .Single(e => e.PollId == pollId);
                ctx.PollChoices.Remove(entity);

                return ctx.SaveChanges() == 1;

                    
            }
        }
    }
}









