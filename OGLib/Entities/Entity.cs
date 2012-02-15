using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace OGLib.Entities
{
    public class Entity
    {
        public Vector2 position, origin;
        public Color color;
        public float rotation, scale;
        public int source;

        public Entity()
        {
            scale = 1f;
            color = Color.White;
        }
    }
}
