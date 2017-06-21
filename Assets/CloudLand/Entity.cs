using UnityEngine;

using Org.Dragonet.Cloudland.Net.Protocol;

public abstract class Entity : MonoBehaviour {

    public ulong entityId;

    public SerializedMetadata meta;

    public bool updateMeta = true;

    public Entity parent;
    public int slotTaken = -1;

    protected void checkUpdateMeta()
    {
        if (updateMeta)
        {
            updateMeta = false;
            ApplyMeta(meta.Entries);
        }
    }

    protected abstract void ApplyMeta(Google.Protobuf.Collections.MapField<uint, SerializedMetadata.Types.MetadataEntry> meta);

    protected abstract int GetSlotCount();

    protected abstract Vector3 GetSlotRelativePosition(int slot);

    public void setParent(Entity entity)
    {
        if(parent == null)
        {
            parent = null;
            if(slotTaken != -1)
            {
                slotTaken = -1;
                // TODO: release the constraint to the 'seat'
                // ...
            }
            transform.parent = ClientComponent.INSTANCE.entitiesParent; // reset to the entities root
        } else
        {
            if(parent != null && slotTaken != -1)
            {
                parent = null;
                // TODO: release the constraint to the 'seat'
                // ...
            }
            transform.parent = entity.transform;
        }
    }

    public string summaryString()
    {
        string b = "Entity #" + entityId + "\n";
        b += "Type: " + GetType().Name + "\n";
        b += "Meta count: " + meta.Entries.Count + "\n";
        return b;
    }
}
