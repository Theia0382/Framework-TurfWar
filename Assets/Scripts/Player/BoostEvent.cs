using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostEvent : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerEvent playerEvent;
    ItemEvent itemEvent;
    AlphaForImage boostIndecator;

    public bool boost;
    float boostTimer;
    float playerMovingTime;

    int playerNumber;

    bool indecatorBlink;

    public void getBoost( )
    {
        if ( !boost )
        {
            boost = true;
            boostIndecator.fade( 0.0f, 1.0f, 0.3f );
        }
        boostTimer = 0.0f;
        indecatorBlink = false;
        Debug.Log( $"{playerNumber}P Boost" );
    }

    void Start( )
    {
        playerMovement = GetComponent<PlayerMovement>( );
        playerEvent = GetComponent<PlayerEvent>( );
        playerNumber = playerEvent.playerNumber;
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
        boostIndecator = GameObject.Find( $"{playerNumber}P Boost Indecator" ).GetComponent<AlphaForImage>( );


        boost = false;
        boostTimer = 0.0f;
        playerMovingTime = playerMovement.movingTime;
        boostIndecator.modifyAlpha( 0.0f );
    }

    void Update( )
    {
        boostTimer += Time.deltaTime;

        if ( boost )
        {
            if ( boostTimer < itemEvent.boostTime )
            {
                playerMovement.speedRatio = itemEvent.boostRatio;
            }
            else
            {
                boost = false;
                playerMovement.speedRatio = 1.0f;
                Debug.Log( $"{playerNumber}P Boost End" );
            }

            if ( !indecatorBlink )
            {
                if ( boostTimer > itemEvent.boostTime - 1.0f )
                {
                    boostIndecator.blink( 1.0f, 0.2f, 1.0f, 0.2f, true );
                    indecatorBlink = true;
                }
                else
                {
                    boostIndecator.isBlink = false;
                }
            }
        }
    }
}
