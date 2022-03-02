using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage
{
    abstract class EmptyPlacesCrossBottomAbstractClass
    {
        public abstract void create();

        protected void rotateWhiteSideToOtherCentroids(Dictionary<Color, Side> rubicCubeSides)
        {
            Color possibleWhiteSquareBlueDirectionColor = rubicCubeSides[Color.WHITE].fields[0][1];
            Color possibleWhiteSquareOrangeDirectionColor = rubicCubeSides[Color.WHITE].fields[1][0];
            Color possibleWhiteSquareRedDirectionColor = rubicCubeSides[Color.WHITE].fields[1][2];
            Color possibleWhiteSquareGreenDirectionColor = rubicCubeSides[Color.WHITE].fields[2][1];

            Color squareWhiteDirectionColor = Color.NONE;

            if (possibleWhiteSquareBlueDirectionColor == Color.WHITE) squareWhiteDirectionColor = Color.BLUE;
            if (possibleWhiteSquareOrangeDirectionColor == Color.WHITE) squareWhiteDirectionColor = Color.ORANGE;
            if (possibleWhiteSquareRedDirectionColor == Color.WHITE) squareWhiteDirectionColor = Color.RED;
            if (possibleWhiteSquareGreenDirectionColor == Color.WHITE) squareWhiteDirectionColor = Color.GREEN;

            Color squareColorOnOtherSide = rubicCubeSides[squareWhiteDirectionColor].fields[0][1];

            List<Color> order = new List<Color> { Color.GREEN, Color.RED, Color.BLUE, Color.ORANGE };
            int indexOfCentroid = order.FindIndex(color => color == squareWhiteDirectionColor);
            int indexOfColorOnOtherSide = order.FindIndex(color => color == squareColorOnOtherSide);
            int moves = Math.Abs(indexOfCentroid - indexOfColorOnOtherSide);

            if (indexOfCentroid < indexOfColorOnOtherSide && !(indexOfCentroid == 0 && indexOfColorOnOtherSide == 3) || (indexOfCentroid == 3 && indexOfColorOnOtherSide == 0))
            {
                for (int i = 0; i < moves; i++)
                {
                    Movement movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                }
            }
            else
            {
                for (int i = 0; i < moves; i++)
                {
                    Movement movement = new Movement(MovementType.U, rubicCubeSides);
                }
            }
        }
    }
}
