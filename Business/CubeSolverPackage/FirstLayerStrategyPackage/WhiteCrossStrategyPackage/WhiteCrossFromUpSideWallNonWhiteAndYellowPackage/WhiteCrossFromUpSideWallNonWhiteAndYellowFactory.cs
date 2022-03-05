using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromUpSideWallNonWhiteAndYellowPackage
{
    class WhiteCrossFromUpSideWallNonWhiteAndYellowFactory
    {
        public IWhiteCrossFromUpSideWallNonWhiteAndYellow create(Color color, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            IWhiteCrossFromUpSideWallNonWhiteAndYellow whiteCrossFromUpSideWallNonWhiteAndYellowImpl = null;

            switch (color)
            {
                case Color.BLUE:
                    whiteCrossFromUpSideWallNonWhiteAndYellowImpl = new WhiteCrossFromUpSideWallNonWhiteAndYellowFromBlue(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    whiteCrossFromUpSideWallNonWhiteAndYellowImpl = new WhiteCrossFromUpSideWallNonWhiteAndYellowFromRed(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    whiteCrossFromUpSideWallNonWhiteAndYellowImpl = new WhiteCrossFromUpSideWallNonWhiteAndYellowFromOrange(rubicCubeSides, steps);
                    break;
                case Color.GREEN:
                    whiteCrossFromUpSideWallNonWhiteAndYellowImpl = new WhiteCrossFromUpSideWallNonWhiteAndYellowFromGreen(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return whiteCrossFromUpSideWallNonWhiteAndYellowImpl;
        }
    }
}
