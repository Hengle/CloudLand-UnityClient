using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockEngine.Blocks
{
    class BlockPlank : Block
    {
        private int tex;

        public override int GetTexturePosition(Direction direction)
        {
            return tex;
        }

        public override bool IsBlockAnimated()
        {
            return false;
        }

        public override long GetBreakTime(int toolId)
        {
            return 1200L;
        }

        protected override void InitTextures(TextureManager textureManager)
        {
            tex = textureManager.RegisterTexture("planks_oak");
        }
    }
}
