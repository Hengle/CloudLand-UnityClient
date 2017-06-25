using System;
using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.Collections;
using Org.Dragonet.Cloudland.Net.Protocol;
using UnityEngine;

public class PlaneEntity : Entity {
    protected override void ApplyMeta(MapField<uint, SerializedMetadata.Types.MetadataEntry> meta)
    {
    }

    protected override int GetSlotCount()
    {
        return 0;
    }

    protected override Vector3 GetSlotRelativePosition(int slot)
    {
        return Vector3.zero;
    }
}
