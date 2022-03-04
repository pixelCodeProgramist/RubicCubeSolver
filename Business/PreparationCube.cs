using RubicCube.Models;
using System;
using System.Collections.Generic;


namespace RubicCube.Business
{

    class PreparationCube
    {
        public Dictionary<Color, Side> sides { get; }

        public PreparationCube()
        {
            this.sides = new Dictionary<Color, Side>();
           
        }

        private void prepare()
        {
            this.sides[Color.ORANGE] = new Side(new List<Color[]>{
                new Color[]{ Color.BLUE, Color.YELLOW, Color.RED },
                new Color[]{ Color.ORANGE, Color.ORANGE, Color.ORANGE },
                new Color[]{ Color.YELLOW, Color.BLUE, Color.WHITE }
            });

            this.sides[Color.GREEN] = new Side(new List<Color[]>{
                new Color[]{ Color.WHITE, Color.RED, Color.YELLOW },
                new Color[]{ Color.BLUE, Color.GREEN, Color.YELLOW },
                new Color[]{ Color.ORANGE, Color.GREEN, Color.YELLOW }
            });

            this.sides[Color.WHITE] = new Side(new List<Color[]>{
                new Color[]{ Color.WHITE, Color.WHITE, Color.RED },
                new Color[]{ Color.ORANGE, Color.WHITE, Color.BLUE },
                new Color[]{ Color.GREEN, Color.WHITE, Color.BLUE }
            });

            this.sides[Color.YELLOW] = new Side(new List<Color[]>{
                new Color[]{ Color.BLUE, Color.YELLOW, Color.RED },
                new Color[]{ Color.RED, Color.YELLOW, Color.GREEN },
                new Color[]{ Color.ORANGE, Color.GREEN, Color.WHITE }
            });

            this.sides[Color.RED] = new Side(new List<Color[]>{
                new Color[]{ Color.ORANGE, Color.WHITE, Color.YELLOW },
                new Color[]{ Color.BLUE, Color.RED, Color.YELLOW },
                new Color[]{ Color.GREEN, Color.ORANGE, Color.GREEN }
            });

            this.sides[Color.BLUE] = new Side(new List<Color[]>{
                new Color[]{ Color.BLUE, Color.GREEN, Color.RED },
                new Color[]{ Color.RED, Color.BLUE, Color.WHITE },
                new Color[]{ Color.ORANGE, Color.RED, Color.GREEN }
            });

        }

        public void shuffle()
        {
            this.prepare();
            /*for(int i = 0; i<1000; i++)
            {
                Array values = Enum.GetValues(typeof(MovementType));
                Random random = new Random();
                MovementType randomMovement = (MovementType)values.GetValue(random.Next(values.Length-1));
                Movement movement = new Movement(randomMovement, this.sides);
            }*/
            
        }

        public Dictionary<Color, Side> copySides() 
        {
            Dictionary<Color, Side> ret = new Dictionary<Color, Side>(this.sides.Count,
                                                            this.sides.Comparer);
            foreach (KeyValuePair<Color, Side> entry in this.sides)
            {
                Side newSide = entry.Value.clone();
                ret.Add(entry.Key, newSide);
            }

            return ret;
        }

    }
}
