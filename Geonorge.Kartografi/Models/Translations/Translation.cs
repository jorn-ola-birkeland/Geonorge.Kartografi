﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geonorge.Kartografi.Models.Translations
{
    public abstract class Translation<T> where T : Translation<T>, new()
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CultureName { get; set; }

        protected Translation()
        {
            Id = Guid.NewGuid();
        }
    }
}