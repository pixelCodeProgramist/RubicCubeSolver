using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage
{
    class WhiteCornerMovementFactory
    {
        public IWhiteCornerMovement create(Color color, Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            IWhiteCornerMovement whiteCornerMovementImpl = null;
            
            switch(color)
            {
                case Color.BLUE:
                    whiteCornerMovementImpl = new WhiteCornerMovementFromBlue(rubicCubeSides, steps);
                    break;
                case Color.RED:
                    whiteCornerMovementImpl = new WhiteCornerMovementFromRed(rubicCubeSides, steps);
                    break;
                case Color.ORANGE:
                    whiteCornerMovementImpl = new WhiteCornerMovementFromOrange(rubicCubeSides, steps);
                    break;
                case Color.GREEN:
                    whiteCornerMovementImpl = new WhiteCornerMovementFromGreen(rubicCubeSides, steps);
                    break;
                default:
                    break;
            }

            return whiteCornerMovementImpl;
        }
    }
}
