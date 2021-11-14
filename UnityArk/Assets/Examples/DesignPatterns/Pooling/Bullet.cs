using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 _speed;

    private IObjectPool<Bullet> _bulletPool;

    public void SetPool(IObjectPool<Bullet> bulletPool)
    {
        _bulletPool = bulletPool;
    }

    void Update()
    {
        transform.position += _speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        _bulletPool.Release(this);
    }

}
