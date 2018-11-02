//PoCo with LazyLoader Support created by Template on 02.11.2018 09:44:24
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class Category
    {
        private readonly Action<object, string> _lazyLoader;

        public Category()
        {}

        public Category(Action<object,string> lazyLoader)
        {
            _lazyLoader=lazyLoader;
        }

        [Required]
        [Key]
        public int ID { get; set; }

        private ICollection<Fixture> _fixture;
        public virtual ICollection<Fixture> Fixture
        {
            get
            {
                System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(Fixture)}");
                _lazyLoader?.Load(this,ref _fixture);
                return _fixture;
            }
            set
            {
               _fixture = value;
            }
        }

        [StringLength(20)]
        [Required]
        public string Description { get; set; }
    }
}