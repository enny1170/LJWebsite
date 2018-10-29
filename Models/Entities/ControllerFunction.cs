using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class ControllerFunction
    {
        private readonly Action<object, string> _lazyLoader;
        
        public ControllerFunction()
        {}
        public ControllerFunction(Action<object,string> lazyLoader)
        {
            _lazyLoader=lazyLoader;
        }

        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Function")]
        public string Name { get; set; }
        public string Description {get;set;}

        private ICollection<FunctionTemplate> _functionTemplates;
        public virtual ICollection<FunctionTemplate> FunctionTemplates
        {
            get
            {
                 System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(FunctionTemplates)}");
                 _lazyLoader?.Load(this,ref _functionTemplates);
                 return _functionTemplates;
            }
            set
            {
                 _functionTemplates = value;
            }
        }
        
    }
}