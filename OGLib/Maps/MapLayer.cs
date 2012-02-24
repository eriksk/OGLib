using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OGLib.Maps
{
    public class MapLayer
    {
        protected List<MapPart> parts;
        protected Color color;
        protected Dictionary<string, Texture2D> textures;
        protected float parallax;

        //TODO: scripts

        public MapLayer()
        {
            parallax = 1f;
            parts = new List<MapPart>();
            textures = new Dictionary<string, Texture2D>();
        }

        public void Load(ContentManager content)
        {

        }

        public void Update(float time)
        {

        }

        public void Draw(SpriteBatch sb)
        {
        }
    }
}
