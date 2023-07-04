using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshelfMVC.Domain.Model
{
    public class PublisherContactDetail
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
