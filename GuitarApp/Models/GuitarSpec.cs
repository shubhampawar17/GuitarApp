using GuitarApp.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Models
{
    public class GuitarSpec
    {
        public BuilderType Builder { get; set; }    
        public string Model { get; set; }
        public GuitarType Type { get; set; }
        public WoodType BackWood { get; set; }
        public WoodType TopWood { get; set; }
        public int NumStrings { get; set; }
        public GuitarSpec(BuilderType builder , string model , GuitarType type , WoodType backWood , WoodType topWood , int numStrings) 
        {
            Builder = builder;
            Model = model;
            Type = type;
            BackWood = backWood;
            TopWood = topWood;
            NumStrings = numStrings;
        }
        public bool Matches(GuitarSpec otherSpec)
        {
            if (Builder != otherSpec.Builder) return false;
            if (!string.IsNullOrEmpty(Model) && !Model.Equals(otherSpec.Model)) return false;
            if (Type != otherSpec.Type) return false;
            if (BackWood != otherSpec.BackWood) return false;
            if (TopWood != otherSpec.TopWood) return false;

            return true;
        }
    }
}
