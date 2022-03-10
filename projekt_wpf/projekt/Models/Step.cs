using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Models
{
    class Step
    {
        public MovementType movementType { get; set; }
        public Dictionary<Color, Side> rubicCubeSides { get; set; }

        public Step(MovementType movementType, Dictionary<Color, Side> rubicCubeSides)
        {
            this.movementType = movementType;
            this.rubicCubeSides = rubicCubeSides;
        }
    }
}
