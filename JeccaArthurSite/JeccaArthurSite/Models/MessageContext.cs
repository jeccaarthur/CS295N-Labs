﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Winterfell.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }

        public DbSet<User> Users { get; set; }

        // public DbSet<User> Users { get; set; }


    }
}
