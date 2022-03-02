using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage
{
    class WhiteCrossFromThirdSideWallLayerCreator
    {
        Dictionary<Color, Side> rubicCubeSides;

        public WhiteCrossFromThirdSideWallLayerCreator(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.create();
        }

        private void create()
        {
            bool isWhiteOnBlueSide = isWhiteInNeighbourWall(Color.BLUE);
            bool isWhiteOnOrangeSide = isWhiteInNeighbourWall(Color.ORANGE);
            bool isWhiteOnRedSide = isWhiteInNeighbourWall(Color.RED);
            bool isWhiteOnGreenSide = isWhiteInNeighbourWall(Color.GREEN);
            
            if(isWhiteOnBlueSide)
            {
                Movement movement = new Movement(MovementType.B, rubicCubeSides);
                movement = new Movement(MovementType.B, rubicCubeSides);
            }

            if (isWhiteOnOrangeSide)
            {
                Movement movement = new Movement(MovementType.L, rubicCubeSides);
                movement = new Movement(MovementType.L, rubicCubeSides);
            }

            if (isWhiteOnRedSide)
            {
                Movement movement = new Movement(MovementType.R, rubicCubeSides);
                movement = new Movement(MovementType.R, rubicCubeSides);
            }

            if (isWhiteOnBlueSide)
            {
                Movement movement = new Movement(MovementType.R, rubicCubeSides);
                movement = new Movement(MovementType.R, rubicCubeSides);
            }

        }

        private bool isWhiteInNeighbourWall(Color color)
        {
            return rubicCubeSides[color].fields[0][1] == Color.WHITE;
        }
    }
}
