using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Models
{
    class Side
    {
        public List<Color[]> fields{ get; set; }
        public Side(List<Color[]> fields) {
            this.fields = fields;
        }

        public Side clone()
        {
            List<Color[]> copyFields = new List<Color[]>();

            for (int i=0; i < this.fields.Count; i++)
            {
                Color[] array = new Color[this.fields[i].Length];
                this.fields[i].CopyTo(array, 0);
                copyFields.Add(array);
            }
           
            return new Side(copyFields);
        }
    }

    enum Color
    {
        GREEN, YELLOW, ORANGE, WHITE, BLUE, RED, NONE=-1
    }
}
