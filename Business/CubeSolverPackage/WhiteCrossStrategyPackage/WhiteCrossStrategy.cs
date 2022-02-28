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
        public void solve(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
            Console.WriteLine("Initial");
            Logger logger = new Logger(rubicCubeSides);
            logger.display();
            
            WhiteCrossWhiteWallConfiguration whiteCrossWhiteWallCofiguration = new WhiteCrossWhiteWallConfiguration(rubicCubeSides);

            while (true)
            {
                WhiteCrossFromYellowSideCreator whiteCrossFromYellowSideCreator = new WhiteCrossFromYellowSideCreator(rubicCubeSides);

                WhiteCrossFromBottomSideWallLayerCreator whiteCrossFromBottomSideWallLayerCreator =
                    new WhiteCrossFromBottomSideWallLayerCreator(rubicCubeSides);

                WhiteCrossFromMiddleSideWallLayerCreator whiteCrossFromMiddleSideWallLayerCreator =
                    new WhiteCrossFromMiddleSideWallLayerCreator(rubicCubeSides);

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
