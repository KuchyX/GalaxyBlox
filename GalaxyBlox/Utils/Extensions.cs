﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyBlox.Utils
{
    /// <summary>
    /// Extensions for existing objects. 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Fisher-Yates shuffle. From https://stackoverflow.com/questions/273313/randomize-a-listt - thanks
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Game1.Random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Get rectangle of Texture2D with x = 0 and y = 0.
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public static Rectangle GetRectangle(this Texture2D texture)
        {
            return new Rectangle(0, 0, texture.Width, texture.Height);
        }
    }
}