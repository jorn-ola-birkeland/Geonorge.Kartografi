﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Geonorge.Kartografi.Models.Translations
{
    public class TranslationCollection<T> : Collection<T> where T : Translation<T>, new()
    {

        public T this[string culture]
        {
            get
            {
                var translation = this.FirstOrDefault(x => x.CultureName == culture);
                if (translation == null)
                {
                    translation = new T();
                    translation.CultureName = culture;
                    Add(translation);
                }

                return translation;
            }
            set
            {
                var translation = this.FirstOrDefault(x => x.CultureName == culture);
                if (translation != null)
                {
                    Remove(translation);
                }

                value.CultureName = culture;
                Add(value);
            }
        }

        public bool HasCulture(string culture)
        {
            return this.Any(x => x.CultureName == culture);
        }

        public void AddMissingTranslations()
        {
            foreach (var language in Culture.Languages)
            {
                if (!this.HasCulture(language.Key))
                    Add(new T { CultureName = language.Key });
            }
        }

    }
}