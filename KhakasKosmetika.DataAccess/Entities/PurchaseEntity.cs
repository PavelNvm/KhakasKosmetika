﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Entities
{
    public class PurchaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }
        public DateOnly PurchaseDate { get; set; }

    }
}
