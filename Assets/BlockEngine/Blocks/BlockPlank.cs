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
            string name = CloudLand.Items.toName(toolId);
            if (name != null && name.EndsWith("_axe"))
            {
                if (name.Equals("cloudland:wood_axe"))
                {
                    return 800L;
                }
            }
            return 1500L;
        }

        protected override void InitTextures(TextureManager textureManager)
        {
            tex = textureManager.RegisterTexture("planks_oak");
        }
    }
}
