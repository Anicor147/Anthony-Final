using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Player.Bullet
{
    public class BulletPool : MonoBehaviour
    {
        private List<BulletScript> children;
        private int poolIndex;

        private void Awake()
        {
            children = GetComponentsInChildren<BulletScript>(includeInactive: true).ToList();
        }

        internal BulletScript GetObject()
        {
            poolIndex %= children.Count;
            var next = children[poolIndex++];
            next.Reset();
            return next;
        }
    }
}