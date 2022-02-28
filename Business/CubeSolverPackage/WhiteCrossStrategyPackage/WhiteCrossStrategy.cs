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
            WhiteCrossWhiteWallConfiguration whiteCrossWhiteWallCofiguration = new WhiteCrossWhiteWallConfiguration(rubicCubeSides);
            WhiteCrossFromYellowSideCreator whiteCrossFromYellowSideCreator = new WhiteCrossFromYellowSideCreator(rubicCubeSides);
            whiteCrossFromYellowSideCreator.create();
            WhiteCrossFromBottomSideWallLayerCreator whiteCrossFromBottomSideWallLayerCreator = 
                new WhiteCrossFromBottomSideWallLayerCreator(rubicCubeSides); 
        }

       
    }


}
