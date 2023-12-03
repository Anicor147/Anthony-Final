using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Runtime.Player.Bullet;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private List<BulletScript> children;
    private int poolIndex;

    private void Awake()
    {
        children = GetComponentsInChildren<BulletScript>(includeInactive:true).ToList();
        Debug.Log(children.Count);
    }

    void Start()
    {
        Debug.Log(children.Count);
    }

    internal BulletScript GetObject()
    {
        poolIndex %= children.Count;
        var next = children[poolIndex++];
        next.Reset();
        return next;
    }
}