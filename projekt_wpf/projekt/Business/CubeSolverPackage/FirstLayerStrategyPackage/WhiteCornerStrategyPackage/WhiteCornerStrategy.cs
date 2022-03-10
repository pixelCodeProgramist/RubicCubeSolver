using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage
{
    class WhiteCornerStrategy : ICubeSolverStrategy
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private List<Step> steps;

        List<Color> order = new List<Color>() { Color.ORANGE, Color.GREEN, Color.RED, Color.BLUE };

        public void solve(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            setCornerOnWhiteSide();
            setWhiteBottomCornersToWhiteSide();
            setCorrectOrientationOnWhiteSide();
        }

        
        
        private void setWhiteBottomCornerToWhiteSide(Color cubeFirstSideColor, Color cubeSecondSideColor, Color cubeThirdSideColor, Color currentSiteColor1, Color currentSideColor2)
        {
            if (isWhiteSquare(cubeFirstSideColor, cubeSecondSideColor, cubeThirdSideColor))
            {
                Color firstCubeColor = cubeFirstSideColor != Color.WHITE ? cubeFirstSideColor : cubeSecondSideColor;
                Color secondCubeColor = cubeSecondSideColor != Color.WHITE && cubeSecondSideColor != firstCubeColor ? cubeSecondSideColor : cubeThirdSideColor;

                WhiteCornerMovementFactory whiteCornerMovementFactory = new WhiteCornerMovementFactory();
                IWhiteCornerMovement whiteCornerMovementImpl = null;
                if (!((firstCubeColor == currentSiteColor1 || firstCubeColor == currentSideColor2) 
                    && (secondCubeColor == currentSiteColor1 || secondCubeColor == currentSideColor2)))
                {
                    if (cubeFirstSideColor == Color.WHITE || cubeThirdSideColor == Color.WHITE) firstCubeColor = secondCubeColor;
                    int currentSideIndex = order.FindIndex(color => color == currentSiteColor1);
                    int futureSideIndex = order.FindIndex(color => color == firstCubeColor);
                    int movements = futureSideIndex - currentSideIndex;
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

                    whiteCornerMovementImpl = whiteCornerMovementFactory.create(firstCubeColor, rubicCubeSides, steps);
                }
                else
                {
                    whiteCornerMovementImpl = whiteCornerMovementFactory.create(currentSiteColor1, rubicCubeSides, steps);
                }

                whiteCornerMovementImpl.move();
            }
        }

        private void setCorrectOrientationOnWhiteSide()
        {
            while(true)
            {
                Color color = getCurrentWhiteCornerInGoodOrderColor();
                if (color == Color.NONE) break;
                WhiteCornerMovementFactory whiteCornerMovementFactory = new WhiteCornerMovementFactory();
                IWhiteCornerMovement whiteCornerMovementImpl = whiteCornerMovementFactory.create(color, rubicCubeSides, steps);
                whiteCornerMovementImpl.move();

            }
        }

        private void setWhiteBottomCornersToWhiteSide()
        {
            while(true)
            {
               
                if (getCurrentWhiteCornerNumber() == 0) 
                    break;

                Color greenRedYellowCubeGreenSideColor = rubicCubeSides[Color.GREEN].fields[2][2];
                Color greenRedYellowCubeRedSideColor = rubicCubeSides[Color.RED].fields[2][0];
                Color greenRedYellowCubeYellowSideColor = rubicCubeSides[Color.YELLOW].fields[0][2];

                setWhiteBottomCornerToWhiteSide(greenRedYellowCubeGreenSideColor, greenRedYellowCubeRedSideColor, greenRedYellowCubeYellowSideColor, Color.GREEN, Color.RED);

                Color redBlueYellowCubeRedSideColor = rubicCubeSides[Color.RED].fields[2][2];
                Color redBlueYellowCubeBlueSideColor = rubicCubeSides[Color.BLUE].fields[2][0];
                Color redBlueYellowCubeYellowSideColor = rubicCubeSides[Color.YELLOW].fields[2][2];

                setWhiteBottomCornerToWhiteSide(redBlueYellowCubeRedSideColor, redBlueYellowCubeBlueSideColor, redBlueYellowCubeYellowSideColor, Color.RED, Color.BLUE);

                Color blueOrangeYellowCubeBlueSideColor = rubicCubeSides[Color.BLUE].fields[2][2];
                Color blueOrangeYellowCubeOrangeSideColor = rubicCubeSides[Color.ORANGE].fields[2][0];
                Color blueOrangeYellowCubeYellowSideColor = rubicCubeSides[Color.YELLOW].fields[2][0];

                setWhiteBottomCornerToWhiteSide(blueOrangeYellowCubeBlueSideColor, blueOrangeYellowCubeOrangeSideColor, blueOrangeYellowCubeYellowSideColor,
                    Color.BLUE, Color.ORANGE);

                Color orangeGreenYellowCubeOrangeSideColor = rubicCubeSides[Color.ORANGE].fields[2][2];
                Color orangeGreenYellowCubeGreenSideColor = rubicCubeSides[Color.GREEN].fields[2][0];
                Color orangeGreenYellowCubeYellowSideColor = rubicCubeSides[Color.YELLOW].fields[0][0];

                setWhiteBottomCornerToWhiteSide(orangeGreenYellowCubeOrangeSideColor, orangeGreenYellowCubeGreenSideColor, orangeGreenYellowCubeYellowSideColor,
                    Color.ORANGE, Color.GREEN);
            }
        }

        private Color getCurrentWhiteCornerInGoodOrderColor()
        {
            
            Color redBlueWhiteCubeWhiteSideColor = rubicCubeSides[Color.WHITE].fields[0][2];

            Color redGreenWhiteCubeWhiteSideColor = rubicCubeSides[Color.WHITE].fields[2][2];

            Color greenOrangeWhiteCubeWhiteSideColor = rubicCubeSides[Color.WHITE].fields[2][0];

            Color orangeBlueWhiteCubeWhiteSideColor = rubicCubeSides[Color.WHITE].fields[0][0];

            if (redBlueWhiteCubeWhiteSideColor != Color.WHITE) return Color.RED;
            if (redGreenWhiteCubeWhiteSideColor != Color.WHITE) return Color.GREEN;
            if (greenOrangeWhiteCubeWhiteSideColor != Color.WHITE) return Color.ORANGE;
            if (orangeBlueWhiteCubeWhiteSideColor != Color.WHITE) return Color.BLUE;
            
            return Color.NONE;
        }

        private int getCurrentWhiteCornerNumber()
        {
            int number = 0;

            Color greenRedYellowCubeGreenSideColor = rubicCubeSides[Color.GREEN].fields[2][2];
            Color greenRedYellowCubeRedSideColor = rubicCubeSides[Color.RED].fields[2][0];
            Color greenRedYellowCubeYellowSideColor = rubicCubeSides[Color.YELLOW].fields[0][2];

            Color redBlueYellowCubeRedSideColor = rubicCubeSides[Color.RED].fields[2][2];
            Color redBlueYellowCubeBlueSideColor = rubicCubeSides[Color.BLUE].fields[2][0];
            Color redBlueYellowCubeYellowSideColor = rubicCubeSides[Color.YELLOW].fields[2][2];

            Color blueOrangeYellowCubeBlueSideColor = rubicCubeSides[Color.BLUE].fields[2][2];
            Color blueOrangeYellowCubeOrangeSideColor = rubicCubeSides[Color.ORANGE].fields[2][0];
            Color blueOrangeYellowCubeYellowSideColor = rubicCubeSides[Color.YELLOW].fields[2][0];

            Color orangeGreenYellowCubeOrangeSideColor = rubicCubeSides[Color.ORANGE].fields[2][2];
            Color orangeGreenYellowCubeGreenSideColor = rubicCubeSides[Color.GREEN].fields[2][0];
            Color orangeGreenYellowCubeYellowSideColor = rubicCubeSides[Color.YELLOW].fields[0][0];

            if (isWhiteSquare(greenRedYellowCubeGreenSideColor, greenRedYellowCubeRedSideColor, greenRedYellowCubeYellowSideColor)) number++;
            if (isWhiteSquare(redBlueYellowCubeRedSideColor, redBlueYellowCubeBlueSideColor, redBlueYellowCubeYellowSideColor)) number++;
            if (isWhiteSquare(blueOrangeYellowCubeBlueSideColor, blueOrangeYellowCubeOrangeSideColor, blueOrangeYellowCubeYellowSideColor)) number++;
            if (isWhiteSquare(orangeGreenYellowCubeOrangeSideColor, orangeGreenYellowCubeGreenSideColor, orangeGreenYellowCubeYellowSideColor)) number++;
            return number;
        }

        private bool isWhiteSquare(Color color1, Color color2, Color color3)
        {
            return color1 == Color.WHITE || color2 == Color.WHITE || color3 == Color.WHITE;
        }

        
        public void setCornerOnWhiteSide()
        {
            List<Color> potentialWhiteOrangeBlue = new List<Color>();
            addColorsSquareToList(new Color[] { rubicCubeSides[Color.WHITE].fields[0][0], rubicCubeSides[Color.ORANGE].fields[0][0], rubicCubeSides[Color.BLUE].fields[0][2] }, 
                potentialWhiteOrangeBlue);
            bool isCorrectWhiteOrangeBlueCorner = isInColor(rubicCubeSides[Color.WHITE].fields[0][0], Color.WHITE, Color.ORANGE, Color.BLUE) &&
                isInColor(rubicCubeSides[Color.ORANGE].fields[0][0], Color.WHITE, Color.ORANGE, Color.BLUE) && isInColor(rubicCubeSides[Color.BLUE].fields[0][2], Color.WHITE, Color.ORANGE, Color.BLUE);

            List<Color> potentialWhiteBlueRed = new List<Color>();
            addColorsSquareToList(new Color[] { rubicCubeSides[Color.WHITE].fields[0][2], rubicCubeSides[Color.BLUE].fields[0][0], rubicCubeSides[Color.RED].fields[0][2] },
                potentialWhiteBlueRed);
            bool isCorrectWhiteBlueRedCorner = isInColor(rubicCubeSides[Color.WHITE].fields[0][2], Color.WHITE, Color.BLUE, Color.RED) &&
                isInColor(rubicCubeSides[Color.BLUE].fields[0][0], Color.WHITE, Color.BLUE, Color.RED) && isInColor(rubicCubeSides[Color.RED].fields[0][2], Color.WHITE, Color.BLUE, Color.RED);

            List<Color> potentialWhiteGreenOrange = new List<Color>();
            addColorsSquareToList(new Color[] { rubicCubeSides[Color.WHITE].fields[2][0], rubicCubeSides[Color.GREEN].fields[0][0], rubicCubeSides[Color.ORANGE].fields[0][2] },
               potentialWhiteGreenOrange);
            bool isCorrectWhiteGreenOrangeCorner = isInColor(rubicCubeSides[Color.WHITE].fields[2][0], Color.WHITE, Color.GREEN, Color.ORANGE) &&
                isInColor(rubicCubeSides[Color.GREEN].fields[0][0], Color.WHITE, Color.GREEN, Color.ORANGE) && isInColor(rubicCubeSides[Color.ORANGE].fields[0][2], Color.WHITE, Color.GREEN, Color.ORANGE);

            List<Color> potentialWhiteRedGreen = new List<Color>();
            addColorsSquareToList(new Color[] { rubicCubeSides[Color.WHITE].fields[2][2], rubicCubeSides[Color.RED].fields[0][0], rubicCubeSides[Color.GREEN].fields[0][2] },
               potentialWhiteRedGreen);
            bool isCorrectWhiteRedGreenCorner = isInColor(rubicCubeSides[Color.WHITE].fields[2][2], Color.WHITE, Color.RED, Color.GREEN) &&
                isInColor(rubicCubeSides[Color.RED].fields[0][0], Color.WHITE, Color.RED, Color.GREEN) && isInColor(rubicCubeSides[Color.GREEN].fields[0][2], Color.WHITE, Color.RED, Color.GREEN);

            WhiteCornerMovementFactory whiteCornerMovementFactory = new WhiteCornerMovementFactory();

            IWhiteCornerMovement whiteCornerMovementImpl = null;

            if(isCorrectWhiteOrangeBlueCorner && !checkGoodOrder(potentialWhiteOrangeBlue, Color.WHITE, Color.ORANGE, Color.BLUE))
            {
                whiteCornerMovementImpl = whiteCornerMovementFactory.create(Color.BLUE, rubicCubeSides, steps);
                whiteCornerMovementImpl.move();
            }

            if (isCorrectWhiteBlueRedCorner && !checkGoodOrder(potentialWhiteBlueRed, Color.WHITE, Color.BLUE, Color.RED))
            {
                whiteCornerMovementImpl = whiteCornerMovementFactory.create(Color.RED, rubicCubeSides, steps);
                whiteCornerMovementImpl.move();
            }

            if (isCorrectWhiteGreenOrangeCorner && !checkGoodOrder(potentialWhiteGreenOrange, Color.WHITE, Color.GREEN, Color.ORANGE))
            {
                whiteCornerMovementImpl = whiteCornerMovementFactory.create(Color.ORANGE, rubicCubeSides, steps);
                whiteCornerMovementImpl.move();
            }

            if (isCorrectWhiteRedGreenCorner && !checkGoodOrder(potentialWhiteRedGreen, Color.WHITE, Color.RED, Color.GREEN))
            {
                whiteCornerMovementImpl = whiteCornerMovementFactory.create(Color.GREEN, rubicCubeSides, steps);
                whiteCornerMovementImpl.move();
            }

            removeWrongWhiteCorner();

        }

        private void removeWrongWhiteCorner()
        {
            while (true)
            {
                Color color1 = rubicCubeSides[Color.WHITE].fields[0][0];
                Color color2 = rubicCubeSides[Color.ORANGE].fields[0][0];
                Color color3 = rubicCubeSides[Color.BLUE].fields[0][2];

                bool isCorrectWhiteOrangeBlueCorner =
                    isInColor(color1, Color.WHITE, Color.ORANGE, Color.BLUE) &&
                    isInColor(color2, Color.WHITE, Color.ORANGE, Color.BLUE) &&
                    isInColor(color3, Color.WHITE, Color.ORANGE, Color.BLUE) || !isWhiteSquare(color1, color2, color3);

                if (isCorrectWhiteOrangeBlueCorner) break;

                Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.L, rubicCubeSides, steps);
                
            }

            while (true)
            {
                Color color1 = rubicCubeSides[Color.WHITE].fields[0][2];
                Color color2 = rubicCubeSides[Color.BLUE].fields[0][0];
                Color color3 = rubicCubeSides[Color.RED].fields[0][2];

                bool isCorrectWhiteBlueRedCorner =
                    isInColor(color1, Color.WHITE, Color.BLUE, Color.RED) &&
                    isInColor(color2, Color.WHITE, Color.BLUE, Color.RED) &&
                    isInColor(color3, Color.WHITE, Color.BLUE, Color.RED) || !isWhiteSquare(color1, color2, color3);

                if (isCorrectWhiteBlueRedCorner) break;

                Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.B, rubicCubeSides, steps);
                
            }

            while (true)
            {
                Color color1 = rubicCubeSides[Color.WHITE].fields[2][0];
                Color color2 = rubicCubeSides[Color.GREEN].fields[0][0];
                Color color3 = rubicCubeSides[Color.ORANGE].fields[0][2];

                bool isCorrectWhiteGreenOrangeCorner =
                    isInColor(color1, Color.WHITE, Color.GREEN, Color.ORANGE) &&
                    isInColor(color2, Color.WHITE, Color.GREEN, Color.ORANGE) &&
                    isInColor(color3, Color.WHITE, Color.GREEN, Color.ORANGE) || !isWhiteSquare(color1, color2, color3);

                if (isCorrectWhiteGreenOrangeCorner) break;

                Movement movement = new Movement(MovementType.F_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.F, rubicCubeSides, steps);
                
            }

            while (true)
            {
                Color color1 = rubicCubeSides[Color.WHITE].fields[2][2];
                Color color2 = rubicCubeSides[Color.RED].fields[0][0];
                Color color3 = rubicCubeSides[Color.GREEN].fields[0][2];

                bool isCorrectWhiteRedGreenCorner =
                    isInColor(color1, Color.WHITE, Color.RED, Color.GREEN) &&
                    isInColor(color2, Color.WHITE, Color.RED, Color.GREEN) &&
                    isInColor(color3, Color.WHITE, Color.RED, Color.GREEN) || !isWhiteSquare(color1, color2, color3);

                if (isCorrectWhiteRedGreenCorner) break;

                Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                
                movement = new Movement(MovementType.R, rubicCubeSides, steps);
                
            }
        }

        public void addColorsSquareToList(Color[] squareColor, List<Color> list)
        {
            for(int i = 0; i < squareColor.Length; i++) 
              list.Add(squareColor[i]);
        }

        public bool isInColor(Color squareColor, Color first, Color second, Color thrid)
        {

            return squareColor == first || squareColor == second || squareColor == thrid;
        }

        public bool checkGoodOrder(List<Color> colors, Color first, Color second, Color third)
        {
            return colors[0] == first && colors[1] == second && colors[2] == third;
        }
    }
}
