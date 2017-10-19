using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockEngine.Blocks
{
    class BlockLog : Block
    {

        private int oakSide;
        private int oakVert;

        public override int GetTexturePosition(Direction direction)
        {
            if (direction == Direction.up || direction == Direction.down) return oakVert;
            return oakSide;
        }

        public override long GetBreakTime(int toolId)
        {
            string name = CloudLand.Items.toName(toolId);
            if (name != null && name.EndsWith("_axe"))
            {
                if(name.Equals("cloudland:wood_axe"))
                {
                    return 1000L;
                }
            }
            return 2000L;
        }

        public override bool IsBlockAnimated()
        {
            return false;
        }

        protected override void InitTextures(TextureManager textureManager)
        {
            oakVert = textureManager.RegisterTexture("log_oak_vertical");
            oakSide = textureManager.RegisterTexture("log_oak");
        }
    }
}
