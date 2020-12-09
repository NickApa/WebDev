using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expeditions.Models
{
    public class Mountain
    {
        public IEnumerable<Peak> mtn { get; set; }

        public IEnumerable<Expedition> expeditions { get; set; }


    }
}
