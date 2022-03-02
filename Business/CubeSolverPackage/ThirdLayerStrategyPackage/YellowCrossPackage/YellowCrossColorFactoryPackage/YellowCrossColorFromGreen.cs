using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossPackage.YellowCrossColorFactoryPackage
{
    class YellowCrossColorFromGreen : IYellowCrossColor
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public YellowCrossColorFromGreen(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void move()
        {
            Movement movement = new Movement(MovementType.F, rubicCubeSides);
            movement = new Movement(MovementType.L, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.F_PRIM, rubicCubeSides);
        }
    }
}