using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerPermutationPackage.YellowCornerPermutationFactoryPackage
{
    class YellowCornerPermutationFromGreen : IYellowCornerPermutation
    {
        //
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public YellowCornerPermutationFromGreen(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void solve()
        {
            while (true)
            {
                bool isCorrectCorner = rubicCubeSides[Color.YELLOW].fields[0][0] == Color.YELLOW && rubicCubeSides[Color.GREEN].fields[2][0] == rubicCubeSides[Color.GREEN].fields[2][1];
                if (isCorrectCorner) break;
                Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.L, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.U, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }

        }
    }
}