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
        Debug.Log("Entity #" + e.entityId + " registered! ");
    }

    public void destroy(Entity e)
    {
        entities.Remove(e.entityId);
        GameObject.DestroyImmediate(e.gameObject);

        Debug.Log("Entity #" + e.entityId + " unregistered! ");
    }

    public bool hasEntity(ulong entityId)
    {
        return entities.ContainsKey(entityId);
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
