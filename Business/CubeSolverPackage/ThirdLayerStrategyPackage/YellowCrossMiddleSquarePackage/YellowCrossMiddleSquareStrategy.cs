using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage
{
    class YellowCrossMiddleSquareStrategy : ICubeSolverStrategy
    {
        Dictionary<Color, Side> rubicCubeSides;
        public void solve(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
            while (true)
            {
                if(countCorrectSquare() > 1) break;

            }
        }

        public int countCorrectSquare()
        {
            int number = 0;

            number = rubicCubeSides[Color.GREEN].fields[0][1] == Color.GREEN ? number + 1 : number;
            number = rubicCubeSides[Color.GREEN].fields[1][0] == Color.ORANGE ? number + 1 : number;
            number = rubicCubeSides[Color.GREEN].fields[1][2] == Color.RED ? number + 1 : number;
            number = rubicCubeSides[Color.GREEN].fields[2][1] == Color.BLUE ? number + 1 : number;

            return number;
        }
    }
}
