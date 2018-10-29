//PoCo with LazyLoader Support created by Template on 25.10.2018 07:13:57
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class FixtureFunction
    {
        private readonly Action<object, string> _lazyLoader;
        
        public FixtureFunction(Action<object,string> lazyLoader)
        {
            _lazyLoader=lazyLoader;
        }
        
        public FixtureFunction()
        {
        }

        [Key]
        [Required]
        public int ID { get; set; }

        public int FixtureID { get; set; }
        private Fixture fixture;
        public virtual Fixture Fixture
        {
            get
            {
                System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(Fixture)}");
                _lazyLoader?.Load(this,ref fixture);
                return fixture;
            }
            set
            {
               fixture = value;
            }
        }
        private ControllerFunction _controllerFunction;
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

                public string Description { get; set; }

        private bool multiChannel=false;
        [Required]
        public bool MultiChannel
        {
            get { return multiChannel;}
            set { multiChannel = value;}
        }

        private ICollection<FixtureFunctionChannel> _fixtureFunctionChannel;
        public virtual ICollection<FixtureFunctionChannel> FixtureFunctionChannel
        {
            get 
            { 
                if(_fixtureFunctionChannel==null)
                {
                    System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(FixtureFunctionChannel)}");
                    _lazyLoader?.Load(this,ref _fixtureFunctionChannel);
                }
                return _fixtureFunctionChannel;
            }
            set { _fixtureFunctionChannel = value;}
        }

        private ICollection<FixtureFunctionValue> _fixtureFunctionValue;
        public virtual ICollection<FixtureFunctionValue> FixtureFunctionValue
        {
            get
            {
                 System.Diagnostics.Trace.WriteLine($"Warning: Lazy Loading {nameof(FixtureFunctionValue)}");
                 _lazyLoader?.Load(this,ref _fixtureFunctionValue);
                 return _fixtureFunctionValue;
            }
            set
            {
                 _fixtureFunctionValue = value;
            }
        }

    }
}