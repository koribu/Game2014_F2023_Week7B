using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    [SerializeField]
    float _speed;

    [SerializeField]
    Boundries _boundries;

    Vector3 _direction;

    public BulletType _type;

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;

        if (transform.position.y > _boundries.max || transform.position.y < _boundries.min)
            BulletManager.Instance().ReturnBullet(gameObject);
    }

    public void SetDirection(Vector3 dir)
    {
        _direction = dir;
    }
}
