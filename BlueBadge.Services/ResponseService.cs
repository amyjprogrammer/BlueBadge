using BlueBadge.Data;
using BlueBadge.Models;
using BlueBadge.Models.Response.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class ResponseService
    {
        public bool CreateResponse(ResponseCreate model)
        {
            var entity = new Response()
            {
                PollId = model.PollId,
                //Selected = model.Selected
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Responses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ResponseListItem> GetResponses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Responses
                        .Select(
                        e =>
                            new ResponseListItem
                            {
                                ResponseId = e.ResponseId,
                                PollId = e.PollId,
                                Selected = e.Selected
                            }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateResponse(ResponseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Responses
                        .Single(e => e.ResponseId == model.ResponseId);
                entity.PollId = model.PollId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteResponse(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Responses
                        .Single(e => e.ResponseId == id);
                ctx.Responses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        /*public ResponseDetail GetResponseCount(int amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Responses
                        .Single(e => e.QuestionId == amount);

                var response = new ResponseDetail
                {
                    ResponseId = entity.ResponseId,
                    PollId = entity.PollId,
                    Selected = entity.Selected
                };
                foreach (var choice in entity.Choice)
                {
                    response.Choice.Add(new PollChoiceListItem { Choice = choice.Choice, PollId = choice.PollId });
                }
                return response;
            }
        }*/

        public ResponseDetail GetResponseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Responses
                        .Single(e => e.ResponseId == id);
                return
                    new ResponseDetail
                    {
                        ResponseId = entity.ResponseId,
                        PollId = entity.PollId,
                        Selected = entity.Selected
                    };
            }
        }
    }
}
