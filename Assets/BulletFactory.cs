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



    GameObject _playerBulletPrefab, _enemyBulletPrefab;
   /* [SerializeField]
    Sprite _playerBulletSprite, _enemyBulletSprite;*/
    // Start is called before the first frame update
    void Setup()
    {
        _playerBulletPrefab = Resources.Load<GameObject>("Prefabs/PlayerBullet");
        _enemyBulletPrefab = Resources.Load<GameObject>("Prefabs/EnemyBullet");

    }


    public GameObject CreateBullet(BulletType type)
    {

        GameObject bullet ;


        switch(type)
        {
            case BulletType.PLAYERBULLET:
                //Customize bullet for player bullet
                bullet = MonoBehaviour.Instantiate(_playerBulletPrefab);

                bullet.GetComponent<BulletBehavior>().SetDirection(Vector3.up);
                bullet.GetComponent<BulletBehavior>()._type = BulletType.PLAYERBULLET;

                bullet.name = "PlayerBullet";
                break;
            case BulletType.ENEMYBULLET:
                //Customize bullet for enemy bullet
                bullet = MonoBehaviour.Instantiate(_enemyBulletPrefab);

                bullet.GetComponent<BulletBehavior>().SetDirection(Vector3.down);
                bullet.GetComponent<BulletBehavior>()._type = BulletType.ENEMYBULLET;

                bullet.name = "EnemyBullet";
                break;
            default:
                Debug.Log("Bullet factory doesn't recognize the type of bullet");
                    return null;
                break;
        }

        bullet.SetActive(false);
        return bullet;
    }
}
