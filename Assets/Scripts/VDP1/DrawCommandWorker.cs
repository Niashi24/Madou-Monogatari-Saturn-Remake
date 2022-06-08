using System.Collections;
using System.Collections.Generic;

namespace LS.VDP1.Commands.Editor
{
    public abstract class DrawCommandWorker
    {
        public abstract bool Applies(string title);

        public abstract DrawCommand ParseCommand(string[] info, int begin, int end);
    }
}