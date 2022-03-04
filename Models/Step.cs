using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Models
{
    class Step
    {
        public Movement movement { get; set; }
        public Dictionary<Color, Side> rubicCubeSides { get; set; }

        public Step(Movement movement, Dictionary<Color, Side> rubicCubeSides)
        {
            this.movement = movement;
            this.rubicCubeSides = rubicCubeSides;
        }

        public Step(Dictionary<Color, Side> rubicCubeSides)
        {
            this.movement = new Movement(MovementType.NONE, rubicCubeSides);
            this.rubicCubeSides = rubicCubeSides;
        }
    }
}
