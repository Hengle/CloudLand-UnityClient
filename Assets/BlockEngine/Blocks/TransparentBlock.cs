namespace BlockEngine.Blocks
{
    abstract class TransparentBlock : Block
    {
        public override bool IsSolid(Block target, Direction direction)
        {
            if (target.id == this.id) return true;
			return false;
        }
    }
}
