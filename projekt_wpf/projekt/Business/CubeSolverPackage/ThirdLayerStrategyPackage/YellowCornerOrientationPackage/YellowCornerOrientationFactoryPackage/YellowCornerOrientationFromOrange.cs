using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerOrientationPackage.YellowCornerOrientationFactoryPackage
{
    class YellowCornerOrientationFromOrange : IYellowCornerOrientation
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public YellowCornerOrientationFromOrange(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void solve()
        {
            Movement movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.B, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.F_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.B_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.F, rubicCubeSides, steps);
            
        }
    }
}