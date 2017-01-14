﻿using Gremlin.Net.Process.Traversal;

namespace Gremlin.Net.Process.Remote
{
    public class RemoteStrategy : ITraversalStrategy
    {
        private readonly IRemoteConnection _remoteConnection;

        public RemoteStrategy(IRemoteConnection remoteConnection)
        {
            _remoteConnection = remoteConnection;
        }

        public void Apply(Traversal.Traversal traversal)
        {
            if (traversal.Traversers != null) return;
            var remoteTraversal = _remoteConnection.Submit(traversal.Bytecode);
            traversal.SideEffects = remoteTraversal.SideEffects;
            traversal.Traversers = remoteTraversal.Traversers;
        }
    }
}