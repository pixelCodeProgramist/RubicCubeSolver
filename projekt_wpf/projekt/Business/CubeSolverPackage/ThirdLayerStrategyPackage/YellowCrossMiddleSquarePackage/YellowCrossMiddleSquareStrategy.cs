using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage
{
    class YellowCrossMiddleSquareStrategy : ICubeSolverStrategy
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public void solve(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            while(true)
            {
                int correctSquareNumber = countCorrectSquare();

                if (correctSquareNumber == 4) break;

                if (correctSquareNumber < 2)
                {
                    moveToOrder();
                }

                if (correctSquareNumber == 2)
                {
                    YellowCrossMiddleSquareFactory abstractFactory = null;

                    if (isStraightYellowLineCorrect())
                    {
                        abstractFactory = YellowCrossMiddleSquareFactoryProvider
                            .getFactory(YellowCrossMiddleSquareFactoryProvider.YellowCrossMiddleSquareFactoryMode.STRAIGHT_FORMATION);
                        if (isStraightYellowLineRedAndOrangeSideCorrect())
                        {
                            abstractFactory.getAlgorithm(Color.ORANGE, rubicCubeSides, steps).solve();
                        }
                        else
                        {
                            abstractFactory.getAlgorithm(Color.GREEN, rubicCubeSides, steps).solve();
                        }
                    }
                    else
                    {
                        abstractFactory = YellowCrossMiddleSquareFactoryProvider
                           .getFactory(YellowCrossMiddleSquareFactoryProvider.YellowCrossMiddleSquareFactoryMode.L_FORMATION);
                        Color color = getColorForLFormation();
                        abstractFactory.getAlgorithm(color, rubicCubeSides, steps).solve();
                    }
                }
            }
        }

        private Color getColorForLFormation()
        {
            if (rubicCubeSides[Color.ORANGE].fields[2][1] == Color.ORANGE &&
                rubicCubeSides[Color.GREEN].fields[2][1] == Color.GREEN) return Color.RED;
            
            if (rubicCubeSides[Color.GREEN].fields[2][1] == Color.GREEN &&
                rubicCubeSides[Color.RED].fields[2][1] == Color.RED) return Color.BLUE;
            
            if (rubicCubeSides[Color.RED].fields[2][1] == Color.RED &&
                rubicCubeSides[Color.BLUE].fields[2][1] == Color.BLUE) return Color.ORANGE;
            
            if (rubicCubeSides[Color.BLUE].fields[2][1] == Color.BLUE &&
                rubicCubeSides[Color.ORANGE].fields[2][1] == Color.ORANGE) return Color.GREEN;

            return Color.NONE;
        }

        private bool isStraightYellowLineCorrect()
        {
            return isStraightYellowLineRedAndOrangeSideCorrect() || isStraightYellowLineBlueAndGreenSideCorrect();
        }

        private bool isStraightYellowLineRedAndOrangeSideCorrect()
        {
            return rubicCubeSides[Color.RED].fields[2][1] == Color.RED && rubicCubeSides[Color.ORANGE].fields[2][1] == Color.ORANGE;
        }

        private bool isStraightYellowLineBlueAndGreenSideCorrect()
        {
            return rubicCubeSides[Color.BLUE].fields[2][1] == Color.BLUE && rubicCubeSides[Color.GREEN].fields[2][1] == Color.GREEN;
        }

        public void moveToOrder()
        {
            List<Color[]> listOfOrderCombinantion = new List<Color[]>() { 
                new Color[] { Color.ORANGE, Color.GREEN }, new Color[] { Color.GREEN, Color.RED }, new Color[] { Color.RED, Color.BLUE }, 
                new Color[] { Color.BLUE, Color.ORANGE }
            };

            List<Color[]> listOfRubicCombination = new List<Color[]>() {
                new Color[] { rubicCubeSides[Color.ORANGE].fields[2][1], rubicCubeSides[Color.GREEN].fields[2][1] }, 
                new Color[] { rubicCubeSides[Color.GREEN].fields[2][1], rubicCubeSides[Color.RED].fields[2][1] },
                new Color[] { rubicCubeSides[Color.RED].fields[2][1], rubicCubeSides[Color.BLUE].fields[2][1] },
                new Color[] { rubicCubeSides[Color.BLUE].fields[2][1], rubicCubeSides[Color.ORANGE].fields[2][1] }
            };

            while(true)
            {
                if (countCorrectSquare() == 2) break;
                int indexInOrder = -1;
                int indexInListOfRubicCombination = -1;
                for (int i = 0; i < listOfRubicCombination.Count; i++)
                {
                    int index = containColorsInListWithEqualsLength(listOfOrderCombinantion, listOfRubicCombination[i]);
                    if (index >= 0)
                    {
                        indexInListOfRubicCombination = i;
                        indexInOrder = index;
                        break;
                    }
                }

                if (indexInOrder > -1 && indexInListOfRubicCombination > -1)
                {
                    int movements = indexInOrder - indexInListOfRubicCombination;
                    if (movements == -3) movements = 1;
                    if (movements == 3) movements = -1;
                    for (int i = 0; i < Math.Abs(movements); i++)
                    {
                        if (movements < 0)
                        {
                            Movement movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                            
                        }
                        else
                        {
                            Movement movement = new Movement(MovementType.D, rubicCubeSides, steps);
                            
                        }
                    }

                    break;
                } else
                {
                    Movement movement = new Movement(MovementType.D, rubicCubeSides, steps);
                    
                }
            }

            
        }

        public int containColorsInListWithEqualsLength(List<Color[]> listOfOrderCombinantion, Color[] listOfRubicCombination)
        {
            for(int i = 0; i < listOfOrderCombinantion.Count; i++)
            {
                int number = 0;
                if (listOfOrderCombinantion[i].Length != listOfRubicCombination.Length) return -1;
                for(int j = 0; j < listOfOrderCombinantion[i].Length; j++)
                {
                    if (listOfOrderCombinantion[i][j] == listOfRubicCombination[j]) number++;
                }
                if (number == listOfOrderCombinantion[i].Length) return i;
            }
            return -1;
        }
        
        private int countCorrectSquare()
        {
            int number = 0;

            number = rubicCubeSides[Color.GREEN].fields[2][1] == Color.GREEN ? number + 1 : number;
            number = rubicCubeSides[Color.ORANGE].fields[2][1] == Color.ORANGE ? number + 1 : number;
            number = rubicCubeSides[Color.RED].fields[2][1] == Color.RED ? number + 1 : number;
            number = rubicCubeSides[Color.BLUE].fields[2][1] == Color.BLUE ? number + 1 : number;

            return number;
        }
    }
}
