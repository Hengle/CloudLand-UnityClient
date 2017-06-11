using UnityEngine;

public abstract class StandaloneEntity : Entity
{

    protected override int GetSlotCount()
    {
        return 0;
    }

    protected override Vector3 GetSlotRelativePosition(int slot)
    {
        return Vector3.zero;
    }
}
