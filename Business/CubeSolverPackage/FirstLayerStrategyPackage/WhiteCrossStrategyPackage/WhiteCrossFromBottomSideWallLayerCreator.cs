using RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage;
using RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage;
using RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage
{
    class WhiteCrossFromBottomSideWallLayerCreator
    {
        private List<Color> order = new List<Color> { Color.GREEN, Color.RED, Color.BLUE, Color.ORANGE };
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public WhiteCrossFromBottomSideWallLayerCreator(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
            Color centroidColorOfWhiteSquare = this.findWhiteSquareCrossOnBottom();
            this.setBottomSquareRelativeToFreeRow(ref centroidColorOfWhiteSquare);
            List<Color> currentSquaresOnWhiteSide = getSquaresOnCross();
            int numberOfTakenPlaces = currentSquaresOnWhiteSide.FindAll(e => e == Color.WHITE).Count;
            if(centroidColorOfWhiteSquare!= Color.NONE)
            {
                if (numberOfTakenPlaces == 0)
                {
                    EmptyPlacesCrossBottomFactory placesCrossBottomFactory = new EmptyPlacesCrossBottomFactory();
                    EmptyPlacesCrossBottomAbstractClass emptyPlacesCrossBottomImpl =
                        placesCrossBottomFactory.createMovementUpdater(rubicCubeSides, centroidColorOfWhiteSquare, steps);
                    emptyPlacesCrossBottomImpl.create();
                }

                if (numberOfTakenPlaces == 1)
                {
                    OnePlaceTakenCrossBottomFactory placeTakenCrossBottomFactory = new OnePlaceTakenCrossBottomFactory();
                    OnePlaceTakenCrossBottomAbstractClass onePlaceTakenCrossBottomAbstractClass =
                        placeTakenCrossBottomFactory.createMovementUpdater(rubicCubeSides, centroidColorOfWhiteSquare, steps);
                    Color returendColor = onePlaceTakenCrossBottomAbstractClass.create();
                    if (returendColor != centroidColorOfWhiteSquare)
                    {
                        onePlaceTakenCrossBottomAbstractClass =
                        placeTakenCrossBottomFactory.createMovementUpdater(rubicCubeSides, returendColor, steps);
                        onePlaceTakenCrossBottomAbstractClass.create();
                    }
                }

                if (currentSquaresOnWhiteSide.FindAll(e => e == Color.WHITE).Count >= 2)
                {
                    TwoPlacesTakenCrossBottomFactory placesCrossBottomFactory = new TwoPlacesTakenCrossBottomFactory();
                    TwoPlacesTakenCrossBottomAbstractClass twoPlacesCrossBottomImpl = null;
                    if (currentSquaresOnWhiteSide[0] == Color.WHITE && currentSquaresOnWhiteSide[3] == Color.WHITE ||
                        currentSquaresOnWhiteSide[1] == Color.WHITE && currentSquaresOnWhiteSide[2] == Color.WHITE
                        )
                    {
                        twoPlacesCrossBottomImpl =
                            placesCrossBottomFactory.createMovementUpdater(rubicCubeSides, centroidColorOfWhiteSquare, true, steps);

                    }
                    else
                    {
                        twoPlacesCrossBottomImpl =
                           placesCrossBottomFactory.createMovementUpdater(rubicCubeSides, centroidColorOfWhiteSquare, false, steps);
                    }

                    if (twoPlacesCrossBottomImpl != null) twoPlacesCrossBottomImpl.create();
                }
            }
            
        }

        public bool isNotTakenWhiteWallByWhiteSquareOnCross(Color centroidColorOfWhiteSquare)
        {
            Color crossColorOnWhiteSide = Color.NONE;

            if (centroidColorOfWhiteSquare == Color.GREEN)
            {
                crossColorOnWhiteSide = rubicCubeSides[Color.WHITE].fields[2][1];
            }

            if (centroidColorOfWhiteSquare == Color.ORANGE)
            {
                crossColorOnWhiteSide = rubicCubeSides[Color.WHITE].fields[1][0];
            }

            if (centroidColorOfWhiteSquare == Color.RED)
            {
                crossColorOnWhiteSide = rubicCubeSides[Color.WHITE].fields[1][2];
            }

            if (centroidColorOfWhiteSquare == Color.BLUE)
            {
                crossColorOnWhiteSide = rubicCubeSides[Color.WHITE].fields[0][1];
            }

            if (crossColorOnWhiteSide != Color.WHITE) return true;

            return false;
        }
    

    public void setBottomSquareRelativeToFreeRow(ref Color centroidColorOfWhiteSquare)
        {
            while (true)
            {
                Color centroidColorOfWhiteSquareCopy = centroidColorOfWhiteSquare;
                if (this.isNotTakenWhiteWallByWhiteSquareOnCross(centroidColorOfWhiteSquare)) break;
                int indexOfPrevCentroid = order.FindIndex(color => color == centroidColorOfWhiteSquareCopy) - 1;
                if (indexOfPrevCentroid < 0) indexOfPrevCentroid = order.Count - 1;
                Movement movement = null;
                if (this.isNotTakenWhiteWallByWhiteSquareOnCross(order[indexOfPrevCentroid]))
                {
                    movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                    steps.Add(new Step(movement, rubicCubeSides));
                    centroidColorOfWhiteSquare = order[indexOfPrevCentroid];
                    break;
                }
                else
                {
                    movement = new Movement(MovementType.D, rubicCubeSides);
                    steps.Add(new Step(movement, rubicCubeSides));
                    int indexOfNextCentroid = ((order.FindIndex(color => color == centroidColorOfWhiteSquareCopy) + 1) % order.Count);
                    centroidColorOfWhiteSquare = order[indexOfNextCentroid];
                }
               
                
            }
        }

        private List<Color> getSquaresOnCross()
        {
            List<Color> colors = new List<Color> { rubicCubeSides[Color.WHITE].fields[0][1], rubicCubeSides[Color.WHITE].fields[1][0], rubicCubeSides[Color.WHITE].fields[1][2], rubicCubeSides[Color.WHITE].fields[2][1] };
            return colors;
        }

        private Color findWhiteSquareCrossOnBottom()
        {
            Color squareFromOrangeSide = this.rubicCubeSides[Color.ORANGE].fields[2][1];
            Color squareFromGreenSide = this.rubicCubeSides[Color.GREEN].fields[2][1];
            Color squareFromRedSide = this.rubicCubeSides[Color.RED].fields[2][1];
            Color squareFromBlueSide = this.rubicCubeSides[Color.BLUE].fields[2][1];

            if (squareFromOrangeSide == Color.WHITE) return Color.ORANGE;
            if (squareFromGreenSide == Color.WHITE) return Color.GREEN;
            if (squareFromRedSide == Color.WHITE) return Color.RED;
            if (squareFromBlueSide == Color.WHITE) return Color.BLUE;

            return Color.NONE;
        }
    }
}
