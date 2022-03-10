using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerPermutationPackage.YellowCornerPermutationFactoryPackage
{
    class YellowCornerPermutationFromRed : IYellowCornerPermutation
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public YellowCornerPermutationFromRed(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void solve()
        {
            while (true)
            {
                bool isCorrectCorner = rubicCubeSides[Color.YELLOW].fields[0][2] == Color.YELLOW && rubicCubeSides[Color.RED].fields[2][0] == rubicCubeSides[Color.RED].fields[2][1];
                if (isCorrectCorner) break;
                Movement movement = new Movement(MovementType.F_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.U_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.F, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.U, rubicCubeSides, steps);
                
            }
        }
    }
}