using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletManager
{
    /************************SINGLETON SECTION***************************/
    //Step 1. Private Static Instance
    private static BulletManager instance;

    //Step 2. Make the Constructor Private
    private BulletManager()
    {
        Setup();
    }

    //Step 3. Public Static Creational Method
    public static BulletManager Instance()
    {
        if(instance == null)
        {
            instance = new BulletManager();
        }
        return instance;
    }


    /************************SINGLETON SECTION***************************/




    [SerializeField]
    private int _playerBulletTotal = 10;

    [SerializeField]
    private int _enemyBulletTotal = 50;

    List<Queue<GameObject>> _bulletPools;

/*    Queue<GameObject> _playerBulletPool = new Queue<GameObject>();
    Queue<GameObject> _enemyBulletPool = new Queue<GameObject>();*/


    // Start is called before the first frame update
    void Setup()
    {
        _bulletPools = new List<Queue<GameObject>>();

        // Creates conteiners of each pool into list of bullet pools
        for(int numberOfBulletTypes = 0; numberOfBulletTypes < (int)BulletType.NUMBER_OF_BULLET_TYPES; numberOfBulletTypes++)
        {
            _bulletPools.Add(new Queue<GameObject>());
        }
        
        PoolBuilder();
    }

    void PoolBuilder()
    {
        // take how many bullet we want
        // Create that amount of bullet

        for(int i = 0; i < _bulletPools.Count; i++)
        {
            for(int bulletAmount = 0; bulletAmount < 50; bulletAmount++)
            {
                _bulletPools[i].Enqueue(BulletFactory.Instance().CreateBullet((BulletType)i));
            }
        }
    }

    public GameObject GetBullet(BulletType type)
    {
        if (_bulletPools[(int)type].Count < 1)
            _bulletPools[(int)type].Enqueue(BulletFactory.Instance().CreateBullet(type));

        GameObject bullet = _bulletPools[(int)type].Dequeue();

        bullet.SetActive(true);
        return bullet;

    }

    public void ReturnBullet(GameObject bullet)
    {

        _bulletPools[(int)bullet.GetComponent<BulletBehavior>()._type].Enqueue(bullet);
        bullet.SetActive(false);

    }
}
