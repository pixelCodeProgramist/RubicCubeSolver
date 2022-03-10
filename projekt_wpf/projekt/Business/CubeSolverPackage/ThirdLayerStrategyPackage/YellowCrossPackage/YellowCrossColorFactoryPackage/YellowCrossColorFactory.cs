using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossPackage.YellowCrossColorFactoryPackage
{
    class YellowCrossColorFactory
    {
        public IYellowCrossColor create(Color color, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            IYellowCrossColor yellowCrossColorImpl = null;

            switch (color)
            {
                case Color.BLUE:
                    yellowCrossColorImpl = new YellowCrossColorFromBlue(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    yellowCrossColorImpl = new YellowCrossColorFromRed(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    yellowCrossColorImpl = new YellowCrossColorFromOrange(rubicCubeSides, steps);
                    break;
                case Color.GREEN:
                    yellowCrossColorImpl = new YellowCrossColorFromGreen(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return yellowCrossColorImpl;
        }
    }
}
