﻿using System.Collections;
using SuperMarketApp.Models;

namespace SuperMarketApp.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
