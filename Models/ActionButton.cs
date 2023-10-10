using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmos.Models
{
    public struct ActionButton
    {
        public string Controller {get;set;}
        public string Action {get;set;}
        public string Icon {get;set;}
        public int Id {get; set;}
        public string Color{get;set;}
    }
}