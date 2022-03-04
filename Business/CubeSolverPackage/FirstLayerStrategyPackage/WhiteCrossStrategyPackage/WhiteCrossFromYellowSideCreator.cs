using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage
{
    class WhiteCrossFromYellowSideCreator
    {
        Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public WhiteCrossFromYellowSideCreator(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            this.create();
        }

        private void create()
        {
            
            while (true)
            {
                List<Color> whiteSquareOnYellowSideList = this.findWhiteSquareOnCrossYellowSide();

                if (whiteSquareOnYellowSideList.Count == 0) break;

                if (!isColorSameAsCentroidOfSidesOutherWhiteAndYellow(whiteSquareOnYellowSideList[0]))
                {
                    Color newCentroidColor = this
                        .moveNearestSquareTheSameColorOnCentroidForWhiteSquareOnYellowSide(whiteSquareOnYellowSideList[0]);
                    this.turnToCentroidAndSquareWhite(newCentroidColor);
                }
                else
                    this.turnToCentroidAndSquareWhite(whiteSquareOnYellowSideList[0]);
            }
        }

        private Color moveNearestSquareTheSameColorOnCentroidForWhiteSquareOnYellowSide(Color centroidSideColor)
        {
            Side side = rubicCubeSides[centroidSideColor];
            Color colorOnOtherSide = side.fields[2][1];
            if (colorOnOtherSide == Color.GREEN && centroidSideColor == Color.BLUE ||
                colorOnOtherSide == Color.BLUE && centroidSideColor == Color.GREEN ||
                colorOnOtherSide == Color.RED && centroidSideColor == Color.ORANGE ||
                colorOnOtherSide == Color.ORANGE && centroidSideColor == Color.RED)
            {
                Movement movement = new Movement(MovementType.D, rubicCubeSides);
                movement = new Movement(MovementType.D, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }
            else
            {
                List<Color> order = new List<Color> { Color.GREEN, Color.RED, Color.BLUE, Color.ORANGE, };
                int indexOfCentroid = order.FindIndex(color => color == centroidSideColor);
                int indexOfColorOnOtherSide = order.FindIndex(color => color == colorOnOtherSide);
                if (indexOfCentroid < indexOfColorOnOtherSide && !(indexOfCentroid == 0 && indexOfColorOnOtherSide == 3) || (indexOfCentroid == 3 && indexOfColorOnOtherSide == 0))
                {
                    Movement movement = new Movement(MovementType.D, rubicCubeSides);
                    steps.Add(new Step(movement, rubicCubeSides));
                }
                else
                {
                    Movement movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                    steps.Add(new Step(movement, rubicCubeSides));
                }
            }

            return colorOnOtherSide;
        }

        private List<Color> findWhiteSquareOnCrossYellowSide()
        {
            List<Color> models = new List<Color>();
            Side yellowSide = rubicCubeSides[Color.YELLOW];
            Color squareFromGreenSide = yellowSide.fields[0][1];
            Color squareFromOrangeSide = yellowSide.fields[1][0];
            Color squareFromRedSide = yellowSide.fields[1][2];
            Color squareFromBlueSide = yellowSide.fields[2][1];

            if (squareFromGreenSide == Color.WHITE) models.Add(Color.GREEN);
            if (squareFromOrangeSide == Color.WHITE) models.Add(Color.ORANGE);
            if (squareFromRedSide == Color.WHITE) models.Add(Color.RED);
            if (squareFromBlueSide == Color.WHITE) models.Add(Color.BLUE);

            return models;
        }

        private bool isColorSameAsCentroidOfSidesOutherWhiteAndYellow(Color centroidColorOfWhiteSquareOnYellowSide)
        {
            Side side = rubicCubeSides[centroidColorOfWhiteSquareOnYellowSide];
            return side.fields[2][1] == centroidColorOfWhiteSquareOnYellowSide;
        }

        private void turnToCentroidAndSquareWhite(Color newCentroidColor)
        {
            if (newCentroidColor == Color.GREEN)
            {
                Movement movement = new Movement(MovementType.F, rubicCubeSides);
                movement = new Movement(MovementType.F, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }

            if (newCentroidColor == Color.BLUE)
            {
                Movement movement = new Movement(MovementType.B, rubicCubeSides);
                movement = new Movement(MovementType.B, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }

            if (newCentroidColor == Color.RED)
            {
                Movement movement = new Movement(MovementType.R, rubicCubeSides);
                movement = new Movement(MovementType.R, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }

            if (newCentroidColor == Color.ORANGE)
            {
                Movement movement = new Movement(MovementType.L, rubicCubeSides);
                movement = new Movement(MovementType.L, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }
        }
    }
}
