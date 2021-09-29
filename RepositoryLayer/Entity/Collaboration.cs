﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class Collaboration
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public int Id { get; set; }
        public Notes Notes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
