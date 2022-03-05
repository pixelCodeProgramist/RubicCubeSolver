using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    abstract class OnePlaceTakenCrossBottomAbstractClass
    {
        public abstract Color create();

        protected void rotateLastLayerRelativeCentroidAndYellowNaighbourSquare(Dictionary<Color, Side> rubicCubeSides, ref Color centroidColor, List<Step> steps)
        {
            Color squareYellowSideColor = getColorSquareFromYellowSide(centroidColor, rubicCubeSides);
            
            List<Color> order = new List<Color>() { Color.ORANGE, Color.GREEN, Color.RED, Color.BLUE };
            
            if(centroidColor != squareYellowSideColor)
            {
                while (true)
                {
                    Color centroidColorCopy = centroidColor;
                    int indexOfPrevCentroid = order.FindIndex(color => color == centroidColorCopy) - 1;
                    if (indexOfPrevCentroid < 0) indexOfPrevCentroid = order.Count - 1;
                    Color prevCentroidColor = order[indexOfPrevCentroid];
                    if (squareYellowSideColor == prevCentroidColor)
                    {
                        Movement movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                        steps.Add(new Step(movement, rubicCubeSides));
                        break;
                    }
                    else
                    {
                        Movement movement = new Movement(MovementType.D, rubicCubeSides);
                        steps.Add(new Step(movement, rubicCubeSides));
                        centroidColor = order[(indexOfPrevCentroid + 2) % order.Count];
                        if (centroidColor == squareYellowSideColor) break;
                    }

                }
            }
            
        }

        private Color getColorSquareFromYellowSide(Color centroidColor, Dictionary<Color, Side> rubicCubeSides)
        {
            Color yellowSideSquareColor = Color.NONE;
            
            if (centroidColor == Color.GREEN) yellowSideSquareColor = rubicCubeSides[Color.YELLOW].fields[0][1];
            if (centroidColor == Color.ORANGE) yellowSideSquareColor = rubicCubeSides[Color.YELLOW].fields[1][0];
            if (centroidColor == Color.RED) yellowSideSquareColor = rubicCubeSides[Color.YELLOW].fields[1][2];
            if (centroidColor == Color.BLUE) yellowSideSquareColor = rubicCubeSides[Color.YELLOW].fields[2][1];

            
            return yellowSideSquareColor;
        }
    }
}
