//PoCo with LazyLoader Support created by Template on 25.10.2018 07:05:13
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class Fixture
    {
        private readonly Action<object, string> _lazyLoader;

        public Fixture()
        {}

        public Fixture(Action<object,string> lazyLoader)
        {
            _lazyLoader=lazyLoader;
        }

        [Required]
        [Key]
        public int ID { get; set; }

        private ICollection<FixtureFunction> fixtureFunction;
        public virtual ICollection<FixtureFunction> FixtureFunction
        {
            get
            {
                System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(FixtureFunction)}");
                _lazyLoader?.Load(this,ref fixtureFunction);
                return fixtureFunction;
            }
            set
            {
               fixtureFunction = value;
            }
        }

        [StringLength(50)]
        public string Vendor { get; set; }
        [StringLength(50)]
        public string PartNr { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ManualUrl { get; set; }
        [Required]
        [Display(Name="Channels / Mode")]
        public int MaxChannels { get; set; }

        private Category _category;
        public virtual Category Category
        {
            get
            {
                 System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(Category)}");
                 _lazyLoader?.Load(this,ref _category);
                 return _category;
            }
            set
            {
                 _category = value;
            }
        }

    }
}