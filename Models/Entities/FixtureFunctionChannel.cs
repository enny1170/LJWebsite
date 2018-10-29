//PoCo with LazyLoader Support created by Template on 26.10.2018 07:03:16
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LJWebsite.Models.Entities
{
    public class FixtureFunctionChannel:FixtureFunctionValue
    {
        private int channel=0;
        public int Channel
        {
            get { return channel;}
            set { channel = value;}
        }

    }
}