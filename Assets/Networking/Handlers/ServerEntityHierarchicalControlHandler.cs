using System;
using Google.Protobuf;

using Org.Dragonet.Cloudland.Net.Protocol;

namespace CloudLand.Networking.Handlers
{
    class ServerEntityHierarchicalControlHandler : MessageHandler
    {
        public void handle(CloudLandClient client, IMessage messageReceived)
        {
            ServerEntityHierarchicalControlMessage msg = (ServerEntityHierarchicalControlMessage)messageReceived;
            Loom.QueueOnMainThread(() => process(msg));
        }

        void process(ServerEntityHierarchicalControlMessage msg)
        {
            EntityManager mgr = ClientComponent.INSTANCE.entityManager;
            if(!mgr.hasEntity(msg.EntityId) || !mgr.hasEntity(msg.TargetEntityId))
            {
                // we should do something here but we shall think about this later
                return;
            }

            Entity entity = mgr.getEntity(msg.EntityId);
            Entity target = null;

            if(msg.Action == ServerEntityHierarchicalControlMessage.Types.HierarchicalAction.Enter)
            {
                target = mgr.getEntity(msg.TargetEntityId);
            }

            entity.setParent(target);
            entity.transform.localPosition = new UnityEngine.Vector3(msg.Position.X, msg.Position.Y, msg.Position.Z);
        }
    }
}
