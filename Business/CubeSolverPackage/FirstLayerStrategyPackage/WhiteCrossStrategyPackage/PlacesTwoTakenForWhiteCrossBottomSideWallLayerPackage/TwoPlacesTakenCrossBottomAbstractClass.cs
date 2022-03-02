using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    abstract class TwoPlacesTakenCrossBottomAbstractClass
    {
        public abstract void create();

        protected Color getColorFromYellowSide(Color otherCentroid, Dictionary<Color, Side> rubicCubeSides)
        {
            Color color = Color.NONE;
            if (otherCentroid == Color.GREEN)
            {
                color = rubicCubeSides[Color.YELLOW].fields[0][1];
            }

            if (otherCentroid == Color.ORANGE)
            {
                color = rubicCubeSides[Color.YELLOW].fields[1][0];
            }

            if (otherCentroid == Color.RED)
            {
                color = rubicCubeSides[Color.YELLOW].fields[1][2];
            }

            if (otherCentroid == Color.BLUE)
            {
                color = rubicCubeSides[Color.YELLOW].fields[2][1];
            }

            return color;
        }

        protected void comleteSettingSquare(Color colorOnYellowSide, Color centroidColorOfWhiteSquare, Dictionary<Color, Side> rubicCubeSides, bool isStraightLine)
        {
            MovementType up = getMovementType(centroidColorOfWhiteSquare);
            if (isStraightLine)
            {
                if (colorOnYellowSide == centroidColorOfWhiteSquare)
                {
                    Movement movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                    movement = new Movement(up, rubicCubeSides);
                    movement = new Movement(MovementType.U, rubicCubeSides);
                }
                else
                {
                    Movement movement = new Movement(MovementType.U, rubicCubeSides);
                    movement = new Movement(up, rubicCubeSides);
                    movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                }
            } else
            {
                if(checkIfWhiteSquareIsNearCorner(centroidColorOfWhiteSquare, rubicCubeSides))
                {
                    if (colorOnYellowSide == centroidColorOfWhiteSquare)
                    {
                        Movement movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                        movement = new Movement(up, rubicCubeSides);
                        movement = new Movement(MovementType.U, rubicCubeSides);
                    }
                    else
                    {
                        Movement movement = new Movement(MovementType.L, rubicCubeSides);
                    }
                } else
                {
                    if (colorOnYellowSide == centroidColorOfWhiteSquare)
                    {
                        Movement movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                        movement = new Movement(up, rubicCubeSides);
                        movement = new Movement(MovementType.U, rubicCubeSides);
                    }
                    else
                    {
                        Movement movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                        movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
                        movement = new Movement(up, rubicCubeSides);
                        movement = new Movement(MovementType.U, rubicCubeSides);
                        movement = new Movement(MovementType.U, rubicCubeSides);
                    }
                }
            }
        }

        private MovementType getMovementType(Color centroidColorOfWhiteSquare)
        {
            switch(centroidColorOfWhiteSquare)
            {
                case Color.RED:
                    return MovementType.B;
                case Color.BLUE:
                    return MovementType.L;
                case Color.ORANGE:
                    return MovementType.F;
                case Color.GREEN:
                    return MovementType.R;
                default:
                    return MovementType.NONE;

            }
        }

        private bool checkIfWhiteSquareIsNearCorner(Color centroidColorOfWhiteSquare, Dictionary<Color, Side> rubicCubeSides)
        {
            Color neighbourColor = Color.NONE;
            if (centroidColorOfWhiteSquare == Color.ORANGE) neighbourColor = rubicCubeSides[Color.WHITE].fields[2][1];
            if (centroidColorOfWhiteSquare == Color.GREEN) neighbourColor = rubicCubeSides[Color.WHITE].fields[1][2];
            if (centroidColorOfWhiteSquare == Color.RED) neighbourColor = rubicCubeSides[Color.WHITE].fields[0][1];
            if (centroidColorOfWhiteSquare == Color.BLUE) neighbourColor = rubicCubeSides[Color.WHITE].fields[1][0];

            return neighbourColor != Color.WHITE;
        }

    }
}
