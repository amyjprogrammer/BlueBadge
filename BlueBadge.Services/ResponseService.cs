using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class ResponseService
    {
        private readonly Guid _userId;

        public ResponseService(Guid userId)
        {
            _userId = userId;
        }


    }
}
