//PoCo with LazyLoader Support created by Template on 25.10.2018 06:39:05
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class FunctionTemplateValue
    {
        protected readonly Action<object, string> _lazyLoader;

        public FunctionTemplateValue()
        {}

        public FunctionTemplateValue(Action<object,string> lazyLoader)
        {
            _lazyLoader=lazyLoader;
        }

        [Required]
        [Key]
        public int ID { get; set; }

        public int FunctionTemplateRefID { get; set; }
        private FunctionTemplate functionTemplate;

        [ForeignKey("FunctionTemplateRefID")]
        public virtual FunctionTemplate FunctionTemplate
        {
            get
            {
                System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(FunctionTemplate)}");
                _lazyLoader?.Load(this,ref functionTemplate);
                return functionTemplate;
            }
            set
            {
               functionTemplate = value;
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

    }
}