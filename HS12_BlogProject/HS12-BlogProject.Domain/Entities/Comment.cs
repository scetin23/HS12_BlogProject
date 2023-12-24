using HS12_BlogProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Domain.Entities
{
    public class Comment : IBaseEntity
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        //IBaseEntity
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

        //Navigation
        public string AppUserID { get; set; } 
        public AppUser AppUser { get; set; } 

        public int PostID { get; set; }

        public Post Post { get; set; }
    }
}
