﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DABanDan.OutPutModels
{
    public class CartOPModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Quatity { get; set; }
        public int Price { get; set; }
        public decimal Total { get; set; }
    }
}