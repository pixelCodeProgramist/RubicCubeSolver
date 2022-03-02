using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossPackage.YellowCrossColorFactoryPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossPackage
{
    class YellowCrossStrategy : ICubeSolverStrategy
    {
        private Dictionary<Color, Side> rubicCubeSides;
        public void solve(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
            int numberThanLessOf2 = 0;
            
            
            YellowCrossColorFactory yellowCrossColorFactory = new YellowCrossColorFactory();
            IYellowCrossColor yellowCrossColorImpl = null;
            while(true)
            {
                int numberOfYellowSquare = this.countYellowSquare();

                if (numberOfYellowSquare == 4) break;

                if (numberOfYellowSquare < 2)
                {
                    if ((numberThanLessOf2%4) == 0) yellowCrossColorImpl = yellowCrossColorFactory.create(Color.BLUE, rubicCubeSides);
                    if ((numberThanLessOf2%4) == 1) yellowCrossColorImpl = yellowCrossColorFactory.create(Color.GREEN, rubicCubeSides);
                    if ((numberThanLessOf2%4) == 2) yellowCrossColorImpl = yellowCrossColorFactory.create(Color.ORANGE, rubicCubeSides);
                    if ((numberThanLessOf2%4) == 3) yellowCrossColorImpl = yellowCrossColorFactory.create(Color.RED, rubicCubeSides);

                    numberThanLessOf2++;
                }

                if(numberOfYellowSquare == 2 && isOppositeSameYellowColor())
                {
                    if (rubicCubeSides[Color.YELLOW].fields[0][1] == Color.YELLOW) 
                        yellowCrossColorImpl = yellowCrossColorFactory.create(Color.RED, rubicCubeSides);
                    else
                        yellowCrossColorImpl = yellowCrossColorFactory.create(Color.GREEN, rubicCubeSides);
                }

                if (numberOfYellowSquare == 2 && !isOppositeSameYellowColor())
                {
                    Color relativeColor = getRelativeColor();
                    yellowCrossColorImpl = yellowCrossColorFactory.create(relativeColor, rubicCubeSides);
                }

                if (numberOfYellowSquare == 3)
                {
                    Color relativeColor = findNotYellowSquare();
                    yellowCrossColorImpl = yellowCrossColorFactory.create(relativeColor, rubicCubeSides);
                }

                yellowCrossColorImpl.move();
            }
            
        }

        private Color findNotYellowSquare()
        {
            if (rubicCubeSides[Color.YELLOW].fields[0][1] != Color.YELLOW) return Color.GREEN;
            if (rubicCubeSides[Color.YELLOW].fields[1][0] != Color.YELLOW) return Color.ORANGE;
            if (rubicCubeSides[Color.YELLOW].fields[1][2] != Color.YELLOW) return Color.RED;
            if (rubicCubeSides[Color.YELLOW].fields[2][1] != Color.YELLOW) return Color.BLUE;
            return Color.NONE;
        }

        private Color getRelativeColor()
        {
            if (rubicCubeSides[Color.YELLOW].fields[1][0] == Color.YELLOW && rubicCubeSides[Color.YELLOW].fields[0][1] == Color.YELLOW) return Color.BLUE;
            if (rubicCubeSides[Color.YELLOW].fields[0][1] == Color.YELLOW && rubicCubeSides[Color.YELLOW].fields[1][2] == Color.YELLOW) return Color.ORANGE;
            if (rubicCubeSides[Color.YELLOW].fields[1][2] == Color.YELLOW && rubicCubeSides[Color.YELLOW].fields[2][1] == Color.YELLOW) return Color.GREEN;
            if (rubicCubeSides[Color.YELLOW].fields[2][1] == Color.YELLOW && rubicCubeSides[Color.YELLOW].fields[1][0] == Color.YELLOW) return Color.RED;
            return Color.NONE;
        }

        private bool isOppositeSameYellowColor()
        {
            return rubicCubeSides[Color.YELLOW].fields[0][1] == Color.YELLOW && rubicCubeSides[Color.YELLOW].fields[2][1] == Color.YELLOW ||
                rubicCubeSides[Color.YELLOW].fields[1][0] == Color.YELLOW && rubicCubeSides[Color.YELLOW].fields[1][2] == Color.YELLOW;
        }

        private int countYellowSquare()
        {
            int number = 0;
            number = rubicCubeSides[Color.YELLOW].fields[0][1] == Color.YELLOW ? number+1 : number;
            number = rubicCubeSides[Color.YELLOW].fields[1][0] == Color.YELLOW ? number+1 : number;
            number = rubicCubeSides[Color.YELLOW].fields[1][2] == Color.YELLOW ? number+1 : number;
            number = rubicCubeSides[Color.YELLOW].fields[2][1] == Color.YELLOW ? number+1 : number;
            return number;
        }
    }
}
