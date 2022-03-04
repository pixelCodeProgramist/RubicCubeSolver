using RubicCube.Business;
using RubicCube.Business.LoggerPackage;
using RubicCube.Business.MovementUpdaterPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubicCube.Models
{
    class Movement
    {
        static int iter = 0;
        public MovementType movementType { get; set; }
        public Dictionary<Color, Side> rubicCubeSides { get; set; }
        public bool isReverse { get; set; }

        public Movement(MovementType movementType, Dictionary<Color, Side> rubicCubeSides)
        {
            this.movementType = movementType;
            this.rubicCubeSides = rubicCubeSides;
            string type = movementType
                .GetType()
                .GetMember(movementType.ToString())
                .First().Name;
            this.isReverse = type.Contains("_PRIM");
            
            if(movementType != MovementType.NONE) this.updateCube();
            iter += 1;
            Console.WriteLine(iter + "++++++++++++++++ " + type + "++++++++++++++");
            Logger logger = new Logger(rubicCubeSides);
            logger.display();
        }

        private void updateCube()
        {
            MovementUpdaterFactory movementUpdaterFactory = new MovementUpdaterFactory();
            MovementUpdaterAbstractClass movementUpdater = movementUpdaterFactory
                .createMovementUpdater(this.rubicCubeSides, this.movementType, this.isReverse);
            movementUpdater.update();
        }
    }

    enum MovementType
    {
        F, R, U, B, L, D, F_PRIM, R_PRIM, U_PRIM, B_PRIM, L_PRIM, D_PRIM, NONE
    }
}
