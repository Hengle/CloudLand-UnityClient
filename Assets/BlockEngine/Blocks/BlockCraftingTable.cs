using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockEngine.Blocks
{
    class BlockCraftingTable : BlockPlank
    {

        private int tex_up;
        private int tex_down;
        private int tex_side;

        public override int GetTexturePosition(Direction direction)
        {
            if (direction == Direction.up) return tex_up;
            if (direction == Direction.down) return tex_down;
            return tex_side;
        }

        public override bool IsBlockAnimated()
        {
            return false;
        }

        protected override void InitTextures(TextureManager textureManager)
        {
            tex_up = textureManager.RegisterTexture("crafting_table_top");
            tex_down = textureManager.RegisterTexture("crafting_table_bottom");
            tex_side = textureManager.RegisterTexture("crafting_table_side");
        }
    }
}
