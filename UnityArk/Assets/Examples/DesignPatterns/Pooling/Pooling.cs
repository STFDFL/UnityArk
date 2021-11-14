using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooling : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private IObjectPool<Bullet> _bulletsPool;


    private void Awake()
    {
        _bulletsPool = new ObjectPool<Bullet>(CreateBullet, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, maxSize:5);
    }

    private void OnDestroyPoolObject(Bullet bullet)
    {
        Destroy(bullet.gameObject);   
    }

    private void OnTakeFromPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = this.transform.position;
    }

    private void OnReturnedToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           _bulletsPool.Get();
        }
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.SetPool(_bulletsPool);
        return bullet;
    }

}
