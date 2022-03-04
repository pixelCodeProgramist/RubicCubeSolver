using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage
{
    class StraightFactory : YellowCrossMiddleSquareFactory
    {
        public override IYellowCrossMiddleSquareFactory getAlgorithm(Color colorType, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            IYellowCrossMiddleSquareFactory yellowCrossMiddleSquare = null;
            switch (colorType)
            {
                case Color.GREEN:
                    yellowCrossMiddleSquare = new GreenBlueSideYellowCrossMiddleSquare(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    yellowCrossMiddleSquare = new OrangeRedSideYellowCrossMiddleSquare(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    yellowCrossMiddleSquare = new GreenBlueSideYellowCrossMiddleSquare(rubicCubeSides, steps);
                    break;
                case Color.BLUE:
                    yellowCrossMiddleSquare = new OrangeRedSideYellowCrossMiddleSquare(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return yellowCrossMiddleSquare;
        }
    }
    
}
