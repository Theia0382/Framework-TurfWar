using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEvent : MonoBehaviour
{
    PlayerEvent playerEvent;
    ItemEvent itemEvent;
    AlphaForImage gunIndecator;

    public GameObject bulletPrefab;

    public string gunKey;

    public bool gun;

    float gunTimer;
    float reloadTimer;
    int remainBullets;

    int playerNumber;

    bool indecatorBlink;

    public void getGun( )
    {
        if ( !gun )
        {
            gun = true;
            gunIndecator.fade( 0.0f, 1.0f, 0.3f );
        }
        gunTimer = 0.0f;
        remainBullets = itemEvent.magazineSize;
        Debug.Log( $"{playerNumber}P Gun" );
    }

    void Start( )
    {
        playerEvent = GetComponent<PlayerEvent>( );
        playerNumber = playerEvent.playerNumber;
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
        gunIndecator = GameObject.Find( $"{playerNumber}P Gun Indecator" ).GetComponent<AlphaForImage>( );

        gun = false;
        gunTimer = 0.0f;
        reloadTimer = 0.0f;
        gunIndecator.modifyAlpha( 0.0f );
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
                    remainBullets -= 1;
                    reloadTimer = 0.0f;
                }
                if ( remainBullets == 0 )
                {
                    gun = false;
                    gunIndecator.fade( 1.0f, 0.0f, 0.3f );
                    Debug.Log( $"{playerNumber}P Gun End" );
                }
            }
            else
            {
                gun = false;
                Debug.Log( $"{playerNumber}P Gun End" );
            }

            if ( !indecatorBlink )
            {
                if ( gunTimer > itemEvent.gunTime - 1.0f && remainBullets > 0 )
                {
                    gunIndecator.blink( 1.0f, 0.2f, 1.0f, 0.2f, true );
                    indecatorBlink = true;
                }
                else
                {
                    gunIndecator.isBlink = false;
                }
            }
        }
        
    }
}