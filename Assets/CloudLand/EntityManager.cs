using System.Collections.Generic;

using UnityEngine;

public class EntityManager
{
    public Dictionary<ulong, Entity> entities = new Dictionary<ulong, Entity>();

    public void registerCreated(Entity e)
    {
        if(entities.ContainsKey(e.entityId))
        {
            entities.Remove(e.entityId);
        }
        entities.Add(e.entityId, e);
    }

    public void destroy(Entity e)
    {
        entities.Remove(e.entityId);

        GameObject.DestroyImmediate(e.gameObject);
    }

    public Entity getEntity(ulong entityId)
    {
        Entity value = null;
        entities.TryGetValue(entityId, out value);
        return value;
    }

    public GameObject getEntityObject(ulong entityId)
    {
        Entity e = getEntity(entityId);
        if (e == null) return null;
        return e.gameObject;
    }
}
