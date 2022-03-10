using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerPermutationPackage.YellowCornerPermutationFactoryPackage
{
    class YellowCornerPermutationFromOrange : IYellowCornerPermutation
    {
        //
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public YellowCornerPermutationFromOrange(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void solve()
        {
            while (true)
            {
                bool isYellow = rubicCubeSides[Color.YELLOW].fields[2][0] == Color.YELLOW && rubicCubeSides[Color.ORANGE].fields[2][0] == rubicCubeSides[Color.ORANGE].fields[2][1];
                if (isYellow) break;
                Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.U_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.B, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.U, rubicCubeSides, steps);
                
            }

        }
    }
}