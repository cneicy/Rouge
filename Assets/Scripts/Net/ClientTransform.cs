﻿using Unity.Netcode.Components;

namespace Net
{
    public class ClientTransform : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}