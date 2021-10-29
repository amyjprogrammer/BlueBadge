using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class EmailService
    {
        private readonly Guid _userId;


        public EmailService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmail(EmailCreate model)
        {
            var entity = new Email()
            {
                CustomerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Emails.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmailListItem> GetEmails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Emails
                        .Select(
                            e =>
                            new EmailListItem
                            {
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                EmailId = e.EmailId,
                                EmailAddress = e.EmailAddress
                            }
                        );
                return query.ToArray();
            }
        }

        public EmailDetail GetEmailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emails
                        .Single(e => e.EmailId == id && e.CustomerId == _userId);
                return
                    new EmailDetail
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        EmailAddress = entity.EmailAddress,
                    };
            }
        }

        public bool UpdateEmail(EmailEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emails         //Finding them                  //Access?
                        .Single(e => e.EmailId == model.EmailId && e.CustomerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName; 
                entity.EmailAddress = model.EmailAddress;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmail(int emailId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Emails
                        .Single(e => e.EmailId == emailId && e.CustomerId == _userId);

                ctx.Emails.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
