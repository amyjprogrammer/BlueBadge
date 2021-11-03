using BlueBadge.Data;
using BlueBadge.Models.Group.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class GroupService
    {
        private readonly Guid _userId;

        public GroupService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGroup(GroupCreate model)
        {
            var entity =
                new Group()
                {
                    CustomerId = _userId,
                    GroupName = model.GroupName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Groups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GroupListItem> GetGroups()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Groups
                        .Where(e => e.CustomerId == _userId)
                        .Select(
                            e =>
                            new GroupListItem
                            {
                                GroupId = e.GroupId,
                                GroupName = e.GroupName 
                            }
                        );
                return query.ToArray();
            }
        }

        public GroupDetail GetGroupById(int groupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Groups
                        .Single(e => e.GroupId == groupId && e.CustomerId == _userId);
                
                    var group = new GroupDetail
                    {
                        GroupId = entity.GroupId,
                        GroupName = entity.GroupName
                    };

                foreach (var email in entity.Emails)
                {
                    group.Emails.Add(new Email { EmailId = email.EmailId, EmailAddress = email.EmailAddress});
                }

                foreach (var question in entity.Questions)
                {
                    group.Questions.Add(new Question { Title = question.Title, PollQuestion = question.PollQuestion, CreatedUtc = question.CreatedUtc, QuestionId = question.QuestionId });
                }
                return group;
            }
        }

        public bool UpdateGroup(GroupEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Groups
                        .Single(e => e.GroupId == model.GroupId && e.CustomerId == _userId);

                entity.GroupName = model.GroupName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Groups
                        .Single(e => e.GroupId == groupId && e.CustomerId == _userId);

                ctx.Groups.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
