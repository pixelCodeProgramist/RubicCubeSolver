using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage.LFormationPackage
{
    class RedSideYellowCrossMiddleSquare : IYellowCrossMiddleSquareFactory
    {

        private Dictionary<Color, Side> rubicCubeSides;

        private List<Step> steps;
        public RedSideYellowCrossMiddleSquare(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }
        public void solve()
        {
            Movement movement = new Movement(MovementType.F, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.F_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.F, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.F_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
        }
    }
}
