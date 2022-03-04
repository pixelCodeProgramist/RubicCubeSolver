using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage.LFormationPackage
{
    class LFactory : YellowCrossMiddleSquareFactory
    {
        public override IYellowCrossMiddleSquareFactory getAlgorithm(Color colorType, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            IYellowCrossMiddleSquareFactory yellowCrossMiddleSquare = null;
            switch (colorType)
            {
                case Color.GREEN:
                    yellowCrossMiddleSquare = new GreenSideYellowCrossMiddleSquare(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    yellowCrossMiddleSquare = new OrangeSideYellowCrossMiddleSquare(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    yellowCrossMiddleSquare = new RedSideYellowCrossMiddleSquare(rubicCubeSides, steps);
                    break;
                case Color.BLUE:
                    yellowCrossMiddleSquare = new BlueSideYellowCrossMiddleSquare(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return yellowCrossMiddleSquare;
        }
    }
}
