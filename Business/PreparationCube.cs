using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business
{

    class PreparationCube
    {
        public Dictionary<Color, Side> sides { get; }

        public PreparationCube()
        {
            this.sides = new Dictionary<Color, Side>();
            this.prepare();
        }

        private void prepare()
        {
            /*this.sides[Color.ORANGE] = new Side(new List<Color[]>{
                new Color[]{ Color.ORANGE, Color.ORANGE, Color.ORANGE },
                new Color[]{ Color.ORANGE, Color.ORANGE, Color.ORANGE },
                new Color[]{ Color.ORANGE, Color.ORANGE, Color.ORANGE }
            });

            this.sides[Color.GREEN] = new Side(new List<Color[]>{
                new Color[]{ Color.GREEN, Color.GREEN, Color.GREEN },
                new Color[]{ Color.GREEN, Color.GREEN, Color.GREEN },
                new Color[]{ Color.GREEN, Color.GREEN, Color.GREEN }
            });

            this.sides[Color.WHITE] = new Side(new List<Color[]>{
                new Color[]{ Color.WHITE, Color.WHITE, Color.WHITE },
                new Color[]{ Color.WHITE, Color.WHITE, Color.WHITE },
                new Color[]{ Color.WHITE, Color.WHITE, Color.WHITE }
            });

            this.sides[Color.YELLOW] = new Side(new List<Color[]>{
                new Color[]{ Color.YELLOW, Color.YELLOW, Color.YELLOW },
                new Color[]{ Color.YELLOW, Color.YELLOW, Color.YELLOW },
                new Color[]{ Color.YELLOW, Color.YELLOW, Color.YELLOW }
            });

            this.sides[Color.RED] = new Side(new List<Color[]>{
                new Color[]{ Color.RED, Color.RED, Color.RED },
                new Color[]{ Color.RED, Color.RED, Color.RED },
                new Color[]{ Color.RED, Color.RED, Color.RED }
            });

            this.sides[Color.BLUE] = new Side(new List<Color[]>{
                new Color[]{ Color.BLUE, Color.BLUE, Color.BLUE },
                new Color[]{ Color.BLUE, Color.BLUE, Color.BLUE },
                new Color[]{ Color.BLUE, Color.BLUE, Color.BLUE }
            });*/

            this.sides[Color.ORANGE] = new Side(new List<Color[]>{
                new Color[]{ Color.ORANGE, Color.BLUE, Color.GREEN },
                new Color[]{ Color.GREEN, Color.ORANGE, Color.BLUE },
                new Color[]{ Color.GREEN, Color.YELLOW, Color.YELLOW }
            });

            this.sides[Color.GREEN] = new Side(new List<Color[]>{
                new Color[]{ Color.RED, Color.YELLOW, Color.WHITE },
                new Color[]{ Color.ORANGE, Color.GREEN, Color.ORANGE },
                new Color[]{ Color.RED, Color.RED, Color.ORANGE }
            });

            this.sides[Color.WHITE] = new Side(new List<Color[]>{
                new Color[]{ Color.YELLOW, Color.YELLOW, Color.ORANGE },
                new Color[]{ Color.WHITE, Color.WHITE, Color.RED },
                new Color[]{ Color.WHITE, Color.BLUE, Color.GREEN }
            });

            this.sides[Color.YELLOW] = new Side(new List<Color[]>{
                new Color[]{ Color.BLUE, Color.GREEN, Color.BLUE },
                new Color[]{ Color.GREEN, Color.YELLOW, Color.RED },
                new Color[]{ Color.RED, Color.YELLOW, Color.RED }
            });

            this.sides[Color.RED] = new Side(new List<Color[]>{
                new Color[]{ Color.ORANGE, Color.BLUE, Color.BLUE },
                new Color[]{ Color.WHITE, Color.RED, Color.ORANGE },
                new Color[]{ Color.BLUE, Color.WHITE, Color.WHITE }
            });

            this.sides[Color.BLUE] = new Side(new List<Color[]>{
                new Color[]{ Color.YELLOW, Color.ORANGE, Color.GREEN },
                new Color[]{ Color.GREEN, Color.BLUE, Color.WHITE },
                new Color[]{ Color.BLUE, Color.RED, Color.YELLOW }
            });
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
