using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerOrientationPackage.YellowCornerOrientationFactoryPackage
{
    class YellowCornerOrientationFromBlue : IYellowCornerOrientation
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public YellowCornerOrientationFromBlue(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void solve()
        {
            Movement movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.R, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.L_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.R_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.L, rubicCubeSides, steps);
            
        }
    }
}