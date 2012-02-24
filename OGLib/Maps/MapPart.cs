using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace OGLib.Maps
{
    public class MapPart
    {  
        public Vector2 position, origin;
        public Color color;
        public Rectangle source;
        public string texture;
        public float rotation, scale;

        public MapPart()
        {
            scale = 1f;
            color = Color.White;
        }
    }
}
