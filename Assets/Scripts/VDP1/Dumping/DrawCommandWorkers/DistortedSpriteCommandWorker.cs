using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LS.VDP1.Commands.Editor
{
    public class DistortedSpriteCommandWorker : DrawCommandWorker
    {
        public override bool Applies(string title)
        {
            return title.Contains("Distorted Sprite");
        }

        public override DrawCommand ParseCommand(string[] info, int begin, int end)
        {
            Vector2[] vertices = new Vector2[4];
            string coord12 = info[begin + 1]
                .Replace("x1 = ", "")
                .Replace(", y1 = ", " ")
                .Replace(", x2 = ", " ")
                .Replace(", y2 = ", " ");
            string coord34 = info[begin + 2]
                .Replace("x3 = ", "")
                .Replace(", y3 = ", " ")
                .Replace(", x4 = ", " ")
                .Replace(", y4 = ", " ");
            string coords = coord12 + " " + coord34;

            string[] coordsSplit = coords.Split(' ');

            for (int i = 0; i < coordsSplit.Length; i+=2)
            {
                vertices[i/2] = new Vector2(int.Parse(coordsSplit[i]), int.Parse(coordsSplit[i+1]));
            }
            
            string textureAddress = info[begin + 3]
                .Replace("Texture address = ", "");

            return new DistortedSpriteCommand()
            {
                textureAddress = textureAddress,
                vertices = vertices
            };
        }
    }
}