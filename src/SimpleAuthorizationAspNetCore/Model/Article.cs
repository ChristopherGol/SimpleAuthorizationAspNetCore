using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAuthorizationAspNetCore.Model
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public User Author { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
