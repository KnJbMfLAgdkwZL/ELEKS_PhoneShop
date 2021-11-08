﻿using System.Collections.Generic;
using Database.Interfaces;

#nullable disable

namespace Database.Models
{
    public partial class Phone : IEntity
    {
        public Phone()
        {
            WishLists = new HashSet<WishList>();
        }

        public int Id { get; set; }
        public string BrandSlug { get; set; }
        public string PhoneSlug { get; set; }
        public string PhoneName { get; set; }
        public string Dimension { get; set; }
        public string Os { get; set; }
        public string Storage { get; set; }
        public string Thumbnail { get; set; }
        public string ReleaseDate { get; set; }
        public string Images { get; set; }
        public string Specifications { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }
        public bool? Hided { get; set; }

        public virtual ICollection<WishList> WishLists { get; set; }
    }
}