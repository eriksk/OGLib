using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace OGLib.Input
{
    public class Input
    {
        private static Input instance = new Input();
        private Input()
        {
        }

        public static Input I
        {
            get { return instance; }
        }

        private KeyboardState oldkey, key;
        public void Update()
        {
            oldkey = key;
            key = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys k)
        {
            return key.IsKeyDown(k);
        }

        public bool KeyClicked(Keys k)
        {
            return oldkey.IsKeyUp(k) && key.IsKeyDown(k);
        }
    }
}
