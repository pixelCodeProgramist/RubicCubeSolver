using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossPackage.YellowCrossColorFactoryPackage
{
    class YellowCrossColorFromBlue : IYellowCrossColor
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public YellowCrossColorFromBlue(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void move()
        {
            Movement movement = new Movement(MovementType.B, rubicCubeSides);
            movement = new Movement(MovementType.R, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.R_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
        }
    }
}