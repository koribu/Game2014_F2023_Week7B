using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory
{
    /************************SINGLETON SECTION***************************/
    private static BulletFactory instance;

    private BulletFactory()
    {
        // The stuff that we want to do at start of the project
        Setup();
    }

    public static BulletFactory Instance()
    {
        return instance ??= new BulletFactory();
    }


    /************************SINGLETON SECTION***************************/



    GameObject _bulletPrefab;
   /* [SerializeField]
    Sprite _playerBulletSprite, _enemyBulletSprite;*/
    // Start is called before the first frame update
    void Setup()
    {
        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateBullet(BulletType type)
    {

        GameObject bullet = MonoBehaviour.Instantiate(_bulletPrefab);
        bullet.SetActive(false);

        switch(type)
        {
            case BulletType.PLAYERBULLET:
                //Customize bullet for player bullet
              //  bullet.GetComponent<SpriteRenderer>().sprite = _playerBulletSprite;
                bullet.GetComponent<BulletBehavior>().SetDirection(Vector3.up);
                bullet.GetComponent<BulletBehavior>()._type = BulletType.PLAYERBULLET;

                bullet.name = "PlayerBullet";
                break;
            case BulletType.ENEMYBULLET:
                //Customize bullet for enemy bullet
              //  bullet.GetComponent<SpriteRenderer>().sprite = _enemyBulletSprite;
                bullet.GetComponent<BulletBehavior>().SetDirection(Vector3.down);
                bullet.GetComponent<BulletBehavior>()._type = BulletType.ENEMYBULLET;

                bullet.name = "EnemyBullet";
                break;
            default:
                Debug.Log("Bullet factory doesn't recognize the type of bullet");
                    return null;
                break;
        }

        return bullet;
    }
}
