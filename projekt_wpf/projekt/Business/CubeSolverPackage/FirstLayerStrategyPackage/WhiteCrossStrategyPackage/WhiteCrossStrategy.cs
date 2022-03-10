using RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage;
using RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage;
using RubicCube.Business.LoggerPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage
{
    class WhiteCrossStrategy : ICubeSolverStrategy
    {
        Dictionary<Color, Side> rubicCubeSides;
        List<Step> steps;
        public void solve(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            
            WhiteCrossWhiteWallConfiguration whiteCrossWhiteWallCofiguration = new WhiteCrossWhiteWallConfiguration(rubicCubeSides, steps);

            while (true)
            {
                WhiteCrossFromYellowSideCreator whiteCrossFromYellowSideCreator = new WhiteCrossFromYellowSideCreator(rubicCubeSides, steps);
                whiteCrossWhiteWallCofiguration = new WhiteCrossWhiteWallConfiguration(rubicCubeSides, steps);

                WhiteCrossFromBottomSideWallLayerCreator whiteCrossFromBottomSideWallLayerCreator =
                    new WhiteCrossFromBottomSideWallLayerCreator(rubicCubeSides, steps);
                whiteCrossWhiteWallCofiguration = new WhiteCrossWhiteWallConfiguration(rubicCubeSides, steps);

                WhiteCrossFromMiddleSideWallLayerCreator whiteCrossFromMiddleSideWallLayerCreator =
                    new WhiteCrossFromMiddleSideWallLayerCreator(rubicCubeSides, steps);
                whiteCrossWhiteWallCofiguration = new WhiteCrossWhiteWallConfiguration(rubicCubeSides, steps);

                WhiteCrossFromMiddleSideWallNonWhiteAndYellowCreator whiteCrossFromMiddleSideWallNonWhiteAndYellow =
                    new WhiteCrossFromMiddleSideWallNonWhiteAndYellowCreator(rubicCubeSides, steps);
                whiteCrossWhiteWallCofiguration = new WhiteCrossWhiteWallConfiguration(rubicCubeSides, steps);

                WhiteCrossFromThirdSideWallLayerCreator thirdSideWallLayerCreator = 
                    new WhiteCrossFromThirdSideWallLayerCreator(rubicCubeSides, steps);
                whiteCrossWhiteWallCofiguration = new WhiteCrossWhiteWallConfiguration(rubicCubeSides, steps);

                if (
                     (rubicCubeSides[Color.WHITE].fields[0][1] == Color.WHITE) &&
                     (rubicCubeSides[Color.WHITE].fields[1][0] == Color.WHITE) &&
                     (rubicCubeSides[Color.WHITE].fields[1][2] == Color.WHITE) &&
                     (rubicCubeSides[Color.WHITE].fields[2][1] == Color.WHITE)
                    ) break;
            }
            

            
        }


    }


}
