using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEvent : MonoBehaviour
{
    PlayerEvent playerEvent;
    ItemEvent itemEvent;

    public GameObject bulletPrefab;

    public string gunKey;

    public bool gun;

    float gunTimer;
    float reloadTimer;
    int remainBullets;

    int playerNumber;

    public void getGun( )
    {
        gun = true;
        gunTimer = 0.0f;
        remainBullets = itemEvent.magazineSize;
        Debug.Log( $"{playerNumber}P Gun" );
    }

    void Start( )
    {
        playerEvent = GetComponent<PlayerEvent>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );

        playerNumber = playerEvent.playerNumber;

        gun = false;
        gunTimer = 0.0f;
        reloadTimer = 0.0f;
    }

    void Update( )
    {
        gunTimer += Time.deltaTime;
        reloadTimer += Time.deltaTime;

        if ( gun )
        {
            if ( gunTimer < itemEvent.gunTime )
            {
                if ( Input.GetKey( gunKey ) && reloadTimer > itemEvent.reloadTime )
                {
                    GameObject Bullet = Instantiate( bulletPrefab, transform.position, transform.rotation ) as GameObject;
                    Bullet.GetComponent<BulletBehavior>( ).parentNumber = playerNumber;
                    Debug.Log( $"{playerNumber}P Shoot" );
                    remainBullets += -1;
                    reloadTimer = 0.0f;
                }
                if ( remainBullets == 0 )
                {
                    gun = false;
                    Debug.Log( $"{playerNumber}P Gun End" );
                }
            }
            else
            {
                gun = false;
                Debug.Log( $"{playerNumber}P Gun End" );
            }
        }
        
    }
}