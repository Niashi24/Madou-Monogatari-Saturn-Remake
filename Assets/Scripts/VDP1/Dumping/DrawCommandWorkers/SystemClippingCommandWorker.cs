using UnityEngine;

namespace LS.VDP1.Commands.Editor
{
    public class SystemClippingCommandWorker : DrawCommandWorker
    {
        public override bool Applies(string title)
        {
            return title.Contains("System Clipping");
        }

        public override DrawCommand ParseCommand(string[] info, int begin, int end)
        {
            string infoString = info[begin + 1];
            infoString = infoString
                .Replace(  "x1 = ", "")
                .Replace(", y1 = ", " ")
                .Replace(", x2 = ", " ")
                .Replace(", y2 = ", " ");

            int[] values = new int[4];

            var infoSplit = infoString.Split(" ");
            for (int i = 0; i < infoSplit.Length; i++)
                values[i] = int.Parse(infoSplit[i]);

            // Debug.Log(infoString);

            return new SystemClippingCommand()
            {
                x1 = values[0], 
                y1 = values[1],
                x2 = values[2],
                y2 = values[3]
            };
        }
    }
}