namespace LS.VDP1.Commands.Editor
{
    public class ScaledSpriteCommandWorker : DrawCommandWorker
    {
        public override bool Applies(string title)
        {
            return title.Contains("Scaled Sprite");
        }

        public override DrawCommand ParseCommand(string[] info, int begin, int end)
        {
            string fullText = string.Join('\n', info, begin, end - begin + 1);

            string zoomPoint = info[begin + 1].Replace("Zoom Point: ", "");
            
            ScaledSpriteZoomPoint zoomP = ScaledSpriteZoomPoint.Unknown;
            if (zoomPoint.Contains("Center-center"))
                zoomP = ScaledSpriteZoomPoint.Centercenter;
            
            string location = info[begin + 2]
                .Replace(  "xa = ", "")
                .Replace(", ya = ", " ")
                .Replace(", xb = ", " ")
                .Replace(", yb = ", " ");

            int[] locationValues = new int[4];
            var locationsplit = location.Split(" ");
            for (int i = 0; i < locationsplit.Length; i++)
                locationValues[i] = int.Parse(locationsplit[i]);

            string textureAddress = info[begin + 3]
                .Replace("Texture address = ", "");

            string textureDimensions = info[begin + 4]
                .Replace("Texture width = ", "")
                .Replace(", height = ", " ");

            var textDimSplit = textureDimensions.Split(" ");
            int width = int.Parse(textDimSplit[0]);
            int height = int.Parse(textDimSplit[1]);

            string textureDirection = info[begin + 5]
                .Replace("Texture read direction: ", "");

            TextureReadDirection dir = TextureReadDirection.Unknown;
            if (textureDimensions.Contains("Normal"))
                dir = TextureReadDirection.Normal;

            bool preClipEnabled = false;
            if (fullText.Contains("Pre-clipping Enabled"))
                preClipEnabled = true;

            bool transparentPixelEnabled = false;
            if (fullText.Contains("Transparent Pixel Enabled"))
                transparentPixelEnabled = true;

            // string colorMode = info[begin + 9]
            //     .Replace("Color mode: ", "");

            // string colorBank = info[begin + 10]
            //     .Replace("Color bank: ", "");

            // string colorCalc = info[begin + 11]
            //     .Replace("Color Calc. mode: ", "");

            return new ScaledSpriteCommand()
            {
                zoomPoint = zoomP,
                xa = locationValues[0],
                ya = locationValues[1],
                xb = locationValues[2],
                yb = locationValues[3],
                textureAddress = textureAddress,
                textureWidth = width,
                textureHeight = height,
                textureReadDirection = dir,
                preclippingEnabled = preClipEnabled,
                transparentPixelEnabled = transparentPixelEnabled,
                colorMode = ColorMode.BPP4,
                colorCalcMode = ColorCalcMode.Replace
            };
        }
    }
}