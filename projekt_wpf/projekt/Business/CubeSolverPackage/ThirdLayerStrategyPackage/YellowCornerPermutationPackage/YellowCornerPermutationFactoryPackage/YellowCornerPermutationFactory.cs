using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerPermutationPackage.YellowCornerPermutationFactoryPackage
{
    class YellowCornerPermutationFactory
    {
        public IYellowCornerPermutation create(Color color, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            IYellowCornerPermutation yellowCornerPermutationImpl = null;

            switch (color)
            {
                case Color.BLUE:
                    yellowCornerPermutationImpl = new YellowCornerPermutationFromBlue(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    yellowCornerPermutationImpl = new YellowCornerPermutationFromRed(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    yellowCornerPermutationImpl = new YellowCornerPermutationFromOrange(rubicCubeSides, steps);
                    break;
                case Color.GREEN:
                    yellowCornerPermutationImpl = new YellowCornerPermutationFromGreen(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return yellowCornerPermutationImpl;
        }
    }
}
