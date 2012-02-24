using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGLib.Utilities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace OGLib.Particles
{
    public enum ParticleType
    {
        Normal,
        Additive,
        Refract
    }

    public class ParticleManager
    {
        protected Pool<Particle> particles;
        protected Texture2D texture;
        protected Rectangle[] sources;

        public ParticleManager()
        {
        }

        public void Load(ContentManager content)
        {
            particles = new Pool<Particle>(10240);
            sources = new Rectangle[] 
            {
                SourceRectangle.Create(0, 0, 1, 1)
            };
            texture = content.Load<Texture2D>(@"gfx/particles");
        }

        public void Spawn(Vector2 position)
        {
            for (int i = 0; i < 512; i++)
            {
                Particle p = particles.Pop();
                p.velocity.X = Util.Rand(-1f, 1f);
                p.velocity.Y = Util.Rand(-1f, 1f);
                p.velocity.Normalize();
                float angle = Util.AngleFrom(ref p.velocity);
                float distance = 100;
                p.position.X = position.X + (float)Math.Cos(angle) * distance;
                p.position.Y = position.Y + (float)Math.Sin(angle) * distance;
                p.rotation = Util.Rand(4f);
                p.current = 0f;
                p.scale = 1f;
                p.color = Color.White;
                p.duration = Util.Rand(500, 1000);
                p.type = ParticleType.Additive;
            }
        }

        public void Smash(Vector2 position, Vector2 dir)
        {
            Spawn(position);
            for (int i = 0; i < 64; i++)
            {
                Particle p = particles.Pop();
                p.velocity.X = dir.X;
                p.velocity.Y = Util.Rand(-1f, 1f);
                p.velocity.Normalize();
                float angle = Util.AngleFrom(ref p.velocity);
                float distance = 60f;
                p.position.X = position.X + (float)Math.Cos(angle) * distance;
                p.position.Y = position.Y + (float)Math.Sin(angle) * distance;
                p.rotation = Util.Rand(4f);
                p.current = 0f;
                p.duration = Util.Rand(400, 600);
                p.color = Color.Red;
                p.scale = 4f;
                p.type = ParticleType.Refract;
            }
        }

        public void Update(float time)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                Particle p = particles[i];
                p.current += time;
                if (p.current > p.duration)
                {
                    particles.Push(i--);
                }
                else
                {
                    p.position.X += p.velocity.X * time;
                    p.position.Y += p.velocity.Y * time;
                }
            }
        }

        public void Draw(SpriteBatch sb, ParticleType type)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                Particle p = particles[i];
                if (p.type == type)
                {
                    sb.Draw(texture, p.position, sources[p.source], p.color * (1f - (p.current / p.duration)), p.rotation, p.origin, p.scale, SpriteEffects.None, 1f);
                }
            }
        }
    }
}
