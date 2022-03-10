using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage
{
    class WhiteCrossFromMiddleSideWallLayerCreator
    {
        Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public WhiteCrossFromMiddleSideWallLayerCreator(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
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
                    bool greenSideColor = rubicCubeSides[Color.GREEN].fields[1][0] == Color.GREEN;
                    if(greenSideColor)
                    {
                        Movement movement = new Movement(MovementType.F, rubicCubeSides, steps);
                        
                    } else
                    {
                        Movement movement = new Movement(MovementType.F_PRIM, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.F, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.D, rubicCubeSides, steps);
                        
                    }
                    
                }

                if (isWhiteSquareInGreenRedSideCube)
                {
                    bool redSideColor = rubicCubeSides[Color.RED].fields[1][0] == Color.GREEN;
                    if (redSideColor)
                    {
                        Movement movement = new Movement(MovementType.R, rubicCubeSides, steps);
                        
                    }
                    else
                    {
                        Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.R, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.D, rubicCubeSides, steps);
                        
                    }
                    
                }

                if (isWhiteSquareInRedBlueSideCube)
                {
                    bool blueSideColor = rubicCubeSides[Color.BLUE].fields[1][0] == Color.GREEN;
                    if (blueSideColor)
                    {
                        Movement movement = new Movement(MovementType.B, rubicCubeSides, steps);
                        
                    }
                    else
                    {
                        Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.B, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.D, rubicCubeSides, steps);
                        
                    }
                   
                }

                if (isWhiteSquareInBlueOrangeSideCube)
                {
                    bool orangeSideColor = rubicCubeSides[Color.ORANGE].fields[1][0] == Color.GREEN;
                    if (orangeSideColor)
                    {
                        Movement movement = new Movement(MovementType.L, rubicCubeSides, steps);
                        
                    }
                    else
                    {
                        Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.L, rubicCubeSides, steps);
                        
                        movement = new Movement(MovementType.D, rubicCubeSides, steps);
                        
                    }
                   
                }
            }
            
        }

        private bool isWhiteInNeighbourWalls(Color color1, Color color2)
        {
            return rubicCubeSides[color1].fields[1][2] == Color.WHITE || rubicCubeSides[color2].fields[1][0] == Color.WHITE;
        }

    }
}
