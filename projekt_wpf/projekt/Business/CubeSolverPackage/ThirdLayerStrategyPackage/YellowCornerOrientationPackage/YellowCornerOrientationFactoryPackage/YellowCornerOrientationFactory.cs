using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCornerOrientationPackage.YellowCornerOrientationFactoryPackage
{
    class YellowCornerOrientationFactory
    {
        public IYellowCornerOrientation create(Color color, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            IYellowCornerOrientation yellowCornerOrientationImpl = null;

            switch (color)
            {
                case Color.BLUE:
                    yellowCornerOrientationImpl = new YellowCornerOrientationFromBlue(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    yellowCornerOrientationImpl = new YellowCornerOrientationFromRed(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    yellowCornerOrientationImpl = new YellowCornerOrientationFromOrange(rubicCubeSides, steps);
                    break;
                case Color.GREEN:
                    yellowCornerOrientationImpl = new YellowCornerOrientationFromGreen(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return yellowCornerOrientationImpl;
        }
    }
}
