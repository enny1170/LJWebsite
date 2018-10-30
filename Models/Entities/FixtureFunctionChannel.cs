//PoCo with LazyLoader Support created by Template on 26.10.2018 07:03:16
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class FixtureFunctionChannel
    {
                protected readonly Action<object, string> _lazyLoader;

        public FixtureFunctionChannel()
        {}

        public FixtureFunctionChannel(Action<object,string> lazyLoader)
        {
            _lazyLoader=lazyLoader;
        }

        [Required]
        [Key]
        public int ID { get; set; }

        private FixtureFunction fixtureFunction;
        public virtual FixtureFunction FixtureFunction
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

                [Display(Name="Color")]
        public int? ColorKeyId { get; set; }
        //public virtual ColorKey Color {get;set;}
        private ColorKey _color;
        public virtual ColorKey Color
        {
            get
            {
                 System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(Color)}");
                 _lazyLoader?.Load(this,ref _color);
                 return _color;
            }
            set
            {
                 _color = value;
            }
        }
        
        [Display(Name="Value Range from")]
        public int ValueRangeFrom { get; set; }
        [Display(Name="Value Range to")]
        public int ValueRangeTo { get; set; }

        private int channel=0;
        public int Channel
        {
            get { return channel;}
            set { channel = value;}
        }

    }
}