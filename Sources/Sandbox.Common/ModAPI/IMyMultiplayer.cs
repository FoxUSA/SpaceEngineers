﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI
{
    public interface IMyMultiplayer
    {
        bool MultiplayerActive { get; }
        bool IsServer { get; }
        ulong ServerId { get; }

        ulong MyId { get; }
        string MyName { get; }

        IMyPlayerCollection Players { get; }

        bool IsServerPlayer(IMyNetworkClient player);

        void SendEntitiesCreated(List<Sandbox.Common.ObjectBuilders.MyObjectBuilder_EntityBase> objectBuilders);

        bool SendMessageToServer(ushort id,byte[] message,bool reliable = true);
        bool SendMessageToOthers(ushort id, byte[] message, bool reliable = true);
        bool SendMessageTo(ushort id, byte[] message, ulong recipient, bool reliable = true);


        void RegisterMessageHandler(ushort id, Action<byte[]> messageHandler);
        void UnregisterMessageHandler(ushort id, Action<byte[]> messageHandler);
    }
}
