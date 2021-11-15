using System;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    class MessagePayload
    {
        public MonoBehaviour sender { get; private set; }
        public System.Object data { get; private set; }


    }
}
