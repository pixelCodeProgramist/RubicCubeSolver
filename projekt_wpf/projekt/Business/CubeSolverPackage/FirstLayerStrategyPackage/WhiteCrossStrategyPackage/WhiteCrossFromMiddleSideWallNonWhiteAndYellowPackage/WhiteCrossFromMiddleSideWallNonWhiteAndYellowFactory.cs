using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromMiddleSideWallNonWhiteAndYellowPackage
{
    class WhiteCrossFromMiddleSideWallNonWhiteAndYellowFactory
    {
        public IWhiteCrossFromMiddleSideWallNonWhiteAndYellow create(Color color, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            IWhiteCrossFromMiddleSideWallNonWhiteAndYellow whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl = null;

            switch (color)
            {
                case Color.BLUE:
                    whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl = new WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromBlue(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl = new WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromRed(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl = new WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromOrange(rubicCubeSides, steps);
                    break;
                case Color.GREEN:
                    whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl = new WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromGreen(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return whiteCrossFromMiddleSideWallNonWhiteAndYellowImpl;
        }
    }
}
