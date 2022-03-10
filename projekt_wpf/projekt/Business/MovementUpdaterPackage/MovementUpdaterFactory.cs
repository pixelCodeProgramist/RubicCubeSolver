using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.MovementUpdaterPackage
{
    class MovementUpdaterFactory
    {
        public virtual MovementUpdaterAbstractClass createMovementUpdater(Dictionary<Color, Side> rubicCubeSides, MovementType movementType, bool isReverse)
        {
            MovementUpdaterAbstractClass movementUpdater = null;
            switch (movementType)
            {
                case MovementType.F:
                case MovementType.F_PRIM:
                    movementUpdater = new FRotation(rubicCubeSides, isReverse);
                    break;
                case MovementType.B:
                case MovementType.B_PRIM:
                    movementUpdater = new BRotation(rubicCubeSides, isReverse);
                    break;
                case MovementType.D:
                case MovementType.D_PRIM:
                    movementUpdater = new DRotation(rubicCubeSides, isReverse);
                    break;
                case MovementType.L:
                case MovementType.L_PRIM:
                    movementUpdater = new LRotation(rubicCubeSides, isReverse);
                    break;
                case MovementType.R:
                case MovementType.R_PRIM:
                    movementUpdater = new RRotation(rubicCubeSides, isReverse);
                    break;
                case MovementType.U:
                case MovementType.U_PRIM:
                    movementUpdater = new URotation(rubicCubeSides, isReverse);
                    break;
                default:
                    break;
            }
            return movementUpdater;
        }
    }
}
