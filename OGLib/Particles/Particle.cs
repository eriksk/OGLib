using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGLib.Entities;
using Microsoft.Xna.Framework;

namespace OGLib.Particles
{
    public class Particle : Entity
    {
        public float current, duration;
        public Vector2 velocity;
        public ParticleType type = ParticleType.Normal;
    }
}
