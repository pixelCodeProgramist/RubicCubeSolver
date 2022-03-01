using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage
{
    class WhiteCornerMovementFactory
    {
        public IWhiteCornerMovement create(Color color, Dictionary<Color, Side> rubicCubeSides)
        {
            IWhiteCornerMovement whiteCornerMovementImpl = null;
            
            switch(color)
            {
                case Color.BLUE:
                    whiteCornerMovementImpl = new WhiteCornerMovementFromBlue(rubicCubeSides);
                    break;
                case Color.RED:
                    whiteCornerMovementImpl = new WhiteCornerMovementFromRed(rubicCubeSides);
                    break;
                case Color.ORANGE:
                    whiteCornerMovementImpl = new WhiteCornerMovementFromOrange(rubicCubeSides);
                    break;
                case Color.GREEN:
                    whiteCornerMovementImpl = new WhiteCornerMovementFromGreen(rubicCubeSides);
                    break;
                default:
                    break;
            }

            return whiteCornerMovementImpl;
        }
    }
}
