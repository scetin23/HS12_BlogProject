using HS12_BlogProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Domain.Entities
{
    public class Genre : IBaseEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        //IBaseEntity
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

        //Navigation
        public List<Post> Posts { get; set; }


    }
}
