using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage
{
    internal class GreenBlueSideYellowCrossMiddleSquare : IYellowCrossMiddleSquareFactory
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public GreenBlueSideYellowCrossMiddleSquare(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void solve()
        {
            Movement movement = new Movement(MovementType.L, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.L_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.L, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.L_PRIM, rubicCubeSides, steps);
            

        }
    }
}