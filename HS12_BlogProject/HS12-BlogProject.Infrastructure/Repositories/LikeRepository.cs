﻿using HS12_BlogProject.Domain.Entities;
using HS12_BlogProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Infrastructure.Repositories
{
    public class LikeRepository : BaseRepository<Like>,ILikeRepository
    {
        public LikeRepository(AppDbContext context) : base(context) 
        {

        }

    }
}
