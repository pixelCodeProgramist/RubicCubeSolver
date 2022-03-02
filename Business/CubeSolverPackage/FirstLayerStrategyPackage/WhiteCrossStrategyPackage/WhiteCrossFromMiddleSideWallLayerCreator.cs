using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage
{
    class WhiteCrossFromMiddleSideWallLayerCreator
    {
        Dictionary<Color, Side> rubicCubeSides;

        public WhiteCrossFromMiddleSideWallLayerCreator(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.create();
        }

        private void create()
        {
            while(true)
            {
                bool isWhiteSquareInOrangeGreenSideCube = isWhiteInNeighbourWalls(Color.ORANGE, Color.GREEN);

                bool isWhiteSquareInGreenRedSideCube = isWhiteInNeighbourWalls(Color.GREEN, Color.RED);

                bool isWhiteSquareInRedBlueSideCube = isWhiteInNeighbourWalls(Color.RED, Color.BLUE);

                bool isWhiteSquareInBlueOrangeSideCube = isWhiteInNeighbourWalls(Color.BLUE, Color.ORANGE);

                if (!isWhiteSquareInOrangeGreenSideCube && !isWhiteSquareInGreenRedSideCube &&
                    !isWhiteSquareInRedBlueSideCube && !isWhiteSquareInBlueOrangeSideCube) break;
                
                if (isWhiteSquareInOrangeGreenSideCube)
                {
                    Movement movement = new Movement(MovementType.F_PRIM, rubicCubeSides);
                    movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                    movement = new Movement(MovementType.F, rubicCubeSides);
                }

                if (isWhiteSquareInGreenRedSideCube)
                {
                    Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides);
                    movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                    movement = new Movement(MovementType.R, rubicCubeSides);
                }

                if (isWhiteSquareInRedBlueSideCube)
                {
                    Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
                    movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                    movement = new Movement(MovementType.B, rubicCubeSides);
                }

                if (isWhiteSquareInBlueOrangeSideCube)
                {
                    Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
                    movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                    movement = new Movement(MovementType.L, rubicCubeSides);
                }
            }
            
        }

        private bool isWhiteInNeighbourWalls(Color color1, Color color2)
        {
            return rubicCubeSides[color1].fields[1][2] == Color.WHITE || rubicCubeSides[color2].fields[1][0] == Color.WHITE;
        }

    }
}
