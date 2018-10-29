using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class FunctionTemplate
    {
        protected readonly Action<object, string> _lazyLoader;

        private ControllerFunction _controllerFunction;

        public FunctionTemplate()
        {}
        public FunctionTemplate(Action<object,string> lazyLoader)
        {
            _lazyLoader=lazyLoader;
        }

        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        /// This is a Property that uses Lazy Loading
        /// 2 things are needed 
        /// 1. a Constructor that takes a Parameter Action<object,string> lazyLoader 
        /// this will save the given Instance in a private variable _lazyLoader
        /// 2. a full Property with a get method like below to fire the lazy loader on access 
        public virtual ControllerFunction ControllerFunction
        {
            get 
            {   
                if(_controllerFunction== null)
                {
                    System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(ControllerFunction)}");
                    _lazyLoader?.Load(this,ref _controllerFunction);
                }
                return _controllerFunction;
            }
            set { _controllerFunction = value;}
        }
        
        public int ControllerFunctionID {get;set;}
        [Required]
        public string Description { get; set; }

        private bool multiChannel=false;
        [Required]
        public bool MultiChannel
        {
            get { return multiChannel;}
            set { multiChannel = value;}
        }
        
        //public virtual ControllerFunction ControllerFunction{get;set;}
        //public virtual ICollection<FunctionTemplateData> TemplateData {get;set;}

        private ICollection<FunctionTemplateChannel> _templateChannel;
        public virtual ICollection<FunctionTemplateChannel> TemplateChannel
        {
            get 
            { 
                if(_templateChannel==null)
                {
                    System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(TemplateChannel)}");
                    _lazyLoader?.Load(this,ref _templateChannel);
                }
                return _templateChannel;
            }
            set { _templateChannel = value;}
        }

        private ICollection<FunctionTemplateValue> _templateValue;
        public virtual ICollection<FunctionTemplateValue> TemplateValue
        {
            get
            {
                 System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(TemplateValue)}");
                 _lazyLoader?.Load(this,ref _templateValue);
                 return _templateValue;
            }
            set
            {
                 _templateValue = value;
            }
        }
    }
}