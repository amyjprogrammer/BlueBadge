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
                                GroupName = e.GroupName //need to figure out how to display the info for questions and emails
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
                return
                    new GroupDetail
                    {
                        GroupId = entity.GroupId,
                        GroupName = entity.GroupName
                    };
            }
        }
    }
}
