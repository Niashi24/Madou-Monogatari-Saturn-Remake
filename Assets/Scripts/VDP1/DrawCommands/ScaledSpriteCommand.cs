namespace LS.VDP1.Commands
{
    public class ScaledSpriteCommand : DrawCommand
    {
        public ScaledSpriteZoomPoint zoomPoint;

        public int xa, ya, xb, yb;

        public string textureAddress;

        public int textureWidth, textureHeight;
        
        public TextureReadDirection textureReadDirection;

        public bool preclippingEnabled;

        public bool transparentPixelEnabled;

        public ColorMode colorMode;

        public int colorBank;

        public ColorCalcMode colorCalcMode;
    }
}