using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BlockEngine.Blocks
{
    class MeshBlock : Block
    {

        public override int GetTexturePosition(Direction direction)
        {
            return -1;
        }

        public override bool IsBlockAnimated()
        {
            return false;
        }

        protected override void InitTextures(TextureManager textureManager)
        {
        }

        public override MeshData GetBlockMeshData(Chunk chunk, Chunk[] relations, int x, int y, int z, MeshData meshData)
        {
            // There is nothing
            return meshData;
        }

        public override bool IsSolid(Block target, Direction direction)
        {
            return false;
        }
    }
}
