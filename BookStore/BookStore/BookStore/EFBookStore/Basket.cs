﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EFBookStore
{
    public class Basket
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
