using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostEvent : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerEvent playerEvent;
    ItemEvent itemEvent;

    public bool boost;
    float boostTimer;
    float playerMovingTime;

    int playerNumber;

    public void getBoost( )
    {
        boost = true;
        boostTimer = 0.0f;
        Debug.Log( $"{playerNumber}P Boost" );
    }

    void Start( )
    {
        playerMovement = GetComponent<PlayerMovement>( );
        playerEvent = GetComponent<PlayerEvent>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );

        playerNumber = playerEvent.playerNumber;
        playerMovingTime = playerMovement.movingTime;

        boost = false;
        boostTimer = 0.0f;
    }

    void Update( )
    {
        boostTimer += Time.deltaTime;

        if ( boost )
        {
            if ( boostTimer < itemEvent.boostTime )
            {
                playerMovement.movingTime = playerMovingTime * itemEvent.boostMovingTimeRatio;
            }
            else
            {
                boost = false;
                playerMovement.movingTime = playerMovingTime;
                Debug.Log( $"{playerNumber}P Boost End" );
            }
        }
    }
}
