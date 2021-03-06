using RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromUpSideWallNonWhiteAndYellowPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage
{
    class WhiteCrossWhiteWallConfiguration
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Color> crossWhiteSideSquareColors;
        private readonly List<Color> order = new List<Color>() { Color.ORANGE, Color.GREEN, Color.RED, Color.BLUE };
        private List<Step> steps;
        public WhiteCrossWhiteWallConfiguration(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            this.updateCrossWhiteSideSquareColors();
            this.moveWrongWhiteSquareFromWhiteSide();
            this.moveWrongWhiteSquareFromNonWhiteSide();
        }

        private void moveWrongWhiteSquareFromNonWhiteSide()
        {
            while(true)
            {
                Color color = getColorFromNonWhiteSide();
                
                if (color == Color.NONE) break;

                WhiteCrossFromUpSideWallNonWhiteAndYellowFactory factory = new WhiteCrossFromUpSideWallNonWhiteAndYellowFactory();
                IWhiteCrossFromUpSideWallNonWhiteAndYellow whiteCrossFromUpSideWallNonWhiteAndYellowImpl = factory.create(color, rubicCubeSides, steps);
                whiteCrossFromUpSideWallNonWhiteAndYellowImpl.move();
            }
           
            
        }

        private Color getColorFromNonWhiteSide()
        {
            if (rubicCubeSides[Color.GREEN].fields[0][1] == Color.WHITE) return Color.GREEN;
            if (rubicCubeSides[Color.ORANGE].fields[0][1] == Color.WHITE) return Color.ORANGE;
            if (rubicCubeSides[Color.RED].fields[0][1] == Color.WHITE) return Color.RED;
            if (rubicCubeSides[Color.BLUE].fields[0][1] == Color.WHITE) return Color.BLUE;
            return Color.NONE;
        }

        private void updateCrossWhiteSideSquareColors()
        {
            //initial direction orange/green/red/blue
            this.crossWhiteSideSquareColors = new List<Color>() {
                rubicCubeSides[Color.WHITE].fields[1][0],
                rubicCubeSides[Color.WHITE].fields[2][1],
                rubicCubeSides[Color.WHITE].fields[1][2],
                rubicCubeSides[Color.WHITE].fields[0][1]
            };
        }



        private void moveToCorrectCentroidOneWhiteSquareOnWall()
        {
            while (true)
            {
                int index = this.crossWhiteSideSquareColors.IndexOf(Color.WHITE);
                
                Color centroidColor = order[index];
                Color otherSideColor = rubicCubeSides[centroidColor].fields[0][1];

                if (centroidColor == otherSideColor) break;

                int indexOfPrevCentroid = order.FindIndex(color => color == centroidColor) - 1;
                if (indexOfPrevCentroid < 0) indexOfPrevCentroid = order.Count - 1;

                Movement movement = null;

                Color prevCentroidColor = order[indexOfPrevCentroid];
                if (prevCentroidColor == otherSideColor)
                {
                    movement = new Movement(MovementType.U, rubicCubeSides, steps);
                    
                    break;
                }
                else
                {
                    movement = new Movement(MovementType.U_PRIM, rubicCubeSides, steps);
                    
                    this.updateCrossWhiteSideSquareColors();
                }
            }
        }

        private void moveWrongWhiteSquareFromWhiteSide()
        {
            int numberOfWhiteSquare = this.crossWhiteSideSquareColors.FindAll(e => e == Color.WHITE).Count;
            if (numberOfWhiteSquare > 0)
            {
                if (numberOfWhiteSquare == 1)
                {
                    this.moveToCorrectCentroidOneWhiteSquareOnWall();
                }

                if(numberOfWhiteSquare > 1)
                {
                    //Color.ORANGE, Color.GREEN, Color.RED, Color.BLUE
                    for (int i = 0; i < this.crossWhiteSideSquareColors.Count; i++)
                    {
                        if (this.crossWhiteSideSquareColors[i] != Color.WHITE)
                            continue;

                        MovementType move = MovementType.NONE;
                        Color centroidColor = this.order[i];
                        Color onOtherSideColor = this.rubicCubeSides[centroidColor].fields[0][1];

                        if (centroidColor == onOtherSideColor) continue;

                        if (centroidColor == Color.ORANGE) move = MovementType.L;
                        if (centroidColor == Color.GREEN) move = MovementType.F;
                        if (centroidColor == Color.RED) move = MovementType.R;
                        if (centroidColor == Color.BLUE) move = MovementType.B;

                        while (true)
                        {
                            Movement movement = new Movement(move, rubicCubeSides, steps);
                            
                            this.updateCrossWhiteSideSquareColors();
                            int currentNumberOfWhiteSquaresOnWhiteWall = this.crossWhiteSideSquareColors.FindAll(e => e == Color.WHITE).Count;
                            if (currentNumberOfWhiteSquaresOnWhiteWall < numberOfWhiteSquare)
                            {
                                numberOfWhiteSquare = currentNumberOfWhiteSquaresOnWhiteWall;
                                break;
                            }
                        }


                    }
                }
                
            }

        }
    }
}
