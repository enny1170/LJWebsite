//PoCo with LazyLoader Support created by Template on 25.10.2018 06:39:05
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class FunctionTemplateChannel:FunctionTemplateValue
    {
        private int channel=0;
        public int Channel
        {
            get { return channel;}
            set { channel = value;}
        }
    }
}