using UnityEngine;
using System.Collections;
using System;

namespace BlockEngine.Blocks
{
    public class BlockDirt : Block
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
            return 600L;
        }

        protected override void InitTextures(TextureManager textureManager)
        {
            tex = textureManager.RegisterTexture("dirt");
        }

        public override bool IsSolid(Block target, Direction direction)
        {
            return true;
        }
    }
}
