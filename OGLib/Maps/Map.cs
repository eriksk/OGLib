using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OGLib.Maps
{
    public class Map
    {
        protected List<MapLayer> layers;
        protected string[] scripts;

        public Map()
        {
            layers = new List<MapLayer>();
            scripts = new string[0];
        }

        public void Load(ContentManager Content)
        {
        }

        public void Update(float time)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
