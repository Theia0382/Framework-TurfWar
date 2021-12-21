using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostEvent : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerEvent playerEvent;
    StageInfo stageInfo;
    ItemEvent itemEvent;
    Image boostIndecator;

    bool boost;
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
        playerNumber = playerEvent.playerNumber;
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
        boostIndecator = GameObject.Find( $"{playerNumber}P Boost Indecator" ).GetComponent<Image>( );

        playerMovingTime = playerMovement.movingTime;

        boost = false;
        boostTimer = 0.0f;
    }

    void Update( )
    {
        boostTimer += Time.deltaTime;

        if ( boost && boostTimer < itemEvent.boostTime )
        {
            playerMovement.movingTime = playerMovingTime * itemEvent.boostMovingTimeRatio;
        }
        else if ( boost )
        {
            boost = false;
            playerMovement.movingTime = playerMovingTime;
            Debug.Log( $"{playerNumber}P Boost End" );
        }

        if ( boost )
        {
            boostIndecator.color = new Color( 1.0f, 1.0f, 1.0f, 1.0f );
        }
        else
        {
            boostIndecator.color = new Color( 1.0f, 1.0f, 1.0f, 0.0f );
        }
    }
}
