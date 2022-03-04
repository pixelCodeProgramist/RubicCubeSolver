using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerPermutationPackage.YellowCornerPermutationFactoryPackage
{
    class YellowCornerPermutationFromBlue : IYellowCornerPermutation
    {
        //
        private Dictionary<Color, Side> rubicCubeSides;

        private List<Step> steps;
        public YellowCornerPermutationFromBlue(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void solve()
        {
            while(true)
            {
                bool isCorrectCorner = rubicCubeSides[Color.YELLOW].fields[2][2] == Color.YELLOW && rubicCubeSides[Color.BLUE].fields[2][0] == rubicCubeSides[Color.BLUE].fields[2][1];
                if (isCorrectCorner) break;
                Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.R, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.U, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }
            
        }
    }
}