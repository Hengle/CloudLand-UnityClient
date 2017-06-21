using UnityEngine;
using Google.Protobuf;

using Org.Dragonet.Cloudland.Net.Protocol;

namespace CloudLand.Networking.Handlers
{
    class ServerEntityUpdateHandler : MessageHandler
    {
        public void handle(CloudLandClient client, IMessage messageReceived)
        {
            ServerEntityUpdateMessage message = (ServerEntityUpdateMessage)messageReceived;
            Loom.QueueOnMainThread(() =>
            {
                Transform entityTransform = client.getClientComponent().entitiesParent.Find("entity|" + message.EntityId);
                if (entityTransform == null) return;
                if (message.FlagPosition)
                {
                    entityTransform.localPosition = new Vector3((float)message.X, (float)message.Y, (float)message.Z);
                }
                if (message.FlagRotation)
                {
                    if (entityTransform.GetComponent<HeadEntity>() != null)
                    {
                        entityTransform.localRotation = Quaternion.Euler(0f, message.Yaw, 0f);
                        entityTransform.Find("Head").localRotation = Quaternion.Euler(message.Pitch, message.Yaw, 0f);
                    } else {
                        entityTransform.localRotation = Quaternion.Euler(message.Pitch, message.Yaw, 0f);
                    }
                }
                if(message.FlagMeta)
                {
                    entityTransform.GetComponent<Entity>().meta = message.Meta;
                    entityTransform.GetComponent<Entity>().updateMeta = true;
                }
            });
        }
    }
}
