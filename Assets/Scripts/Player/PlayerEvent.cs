using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEvent : MonoBehaviour
{
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    BoxCollider2D playerCollider;
    Alpha alpha;
    StageInfo stageInfo;
    ItemEvent itemEvent;
    BoostEvent boostEvent;
    GunEvent gunEvent;
    AlphaForImage life1Indecator;
    AlphaForImage life2Indecator;
    AlphaForImage life3Indecator;

    public int playerNumber;
    public int Maxlife;
    public float respawnTime;

    public int life;
    float respawnTimer;
    
    public void getLine( )
    {
        int targetLineX = playerMovement.gridX + playerMovement.targetGridX - stageInfo.gridXMin * 2;
        int targetLineY = playerMovement.gridY + playerMovement.targetGridY - stageInfo.gridYMin * 2;

        stageInfo.objectStatus[ targetLineX, targetLineY ] = playerNumber;
        Debug.Log( $"Line ( {targetLineX}, {targetLineY} ) : {playerNumber}P" );
    }

    public void itemCheck( )
    {
        int targetItemX = ( playerMovement.targetGridX - stageInfo.gridXMin ) * 2;
        int targetItemY = ( playerMovement.targetGridY - stageInfo.gridYMin ) * 2;

        if ( stageInfo.objectStatus[ targetItemX, targetItemY ] == itemEvent.boostItemNumber )
        {
            stageInfo.objectStatus[ targetItemX, targetItemY ] = 0;
            boostEvent.getBoost( );
        }

        if ( stageInfo.objectStatus[ targetItemX, targetItemY ] == itemEvent.gunItemNumber )
        {
            stageInfo.objectStatus[ targetItemX, targetItemY ] = 0;
            gunEvent.getGun( );
        }
    }

    public void getHurt( )
    {
        if ( life == 3 )
        {
            life3Indecator.blink( 1.0f, 0.0f, 0.3f, 0.1f, true );
        }
        if ( life == 2 )
        {
            life2Indecator.blink( 1.0f, 0.0f, 0.3f, 0.1f, true );
        }
        if ( life == 1 )
        {
            life1Indecator.blink( 1.0f, 0.0f, 0.3f, 0.1f, true );
        }
        
        life -= 1;

        if ( life == 0 )
        {
            Debug.Log( $"{playerNumber}P dead" );
            respawnTimer = 0.0f;
            alpha.fade( 1.0f, 0.0f, 1.0f );
        }
        else
        {
            alpha.blink( 1.0f, 0.5f, 1.0f, 0.1f );
        }
    }

    void Start( )
    {
        playerMovement = GetComponent<PlayerMovement>( );
        spriteRenderer = GetComponent<SpriteRenderer>( );
        playerCollider = GetComponent<BoxCollider2D>( );
        alpha = GetComponent<Alpha>( );
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
        boostEvent = GetComponent<BoostEvent>( );
        gunEvent = GetComponent<GunEvent>( );
        life1Indecator = GameObject.Find( $"{playerNumber}P Life 1" ).GetComponent<AlphaForImage>( );
        life2Indecator = GameObject.Find( $"{playerNumber}P Life 2" ).GetComponent<AlphaForImage>( );
        life3Indecator = GameObject.Find( $"{playerNumber}P Life 3" ).GetComponent<AlphaForImage>( );

        life = Maxlife;
    }

    void Update( )
    {
        if ( life > 0 )
        {
            playerCollider.enabled = true;
        }
        else
        {
            playerCollider.enabled = false;

            respawnTimer += Time.deltaTime;
            
            if ( respawnTimer > respawnTime )
            {
                life = Maxlife;
                playerMovement.positionInitialize( );
                alpha.fade( 0.0f, 1.0f );
                life1Indecator.fade( 0.0f, 1.0f, 0.3f );
                life2Indecator.fade( 0.0f, 1.0f, 0.3f );
                life3Indecator.fade( 0.0f, 1.0f, 0.3f );
            }
        }
    }
}
