using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEvent : MonoBehaviour
{
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    BoxCollider2D playerCollider;
    Blink blink;
    StageInfo stageInfo;
    ItemEvent itemEvent;
    BoostEvent boostEvent;
    Image boostIndecator;
    GunEvent gunEvent;
    Image gunIndecator;
    Image life1Indecator;
    Image life2Indecator;
    Image life3Indecator;

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
        life += -1;

        if ( life == 0 )
        {
            Debug.Log( $"{playerNumber}P dead" );
            respawnTimer = 0.0f;
            blink.fade( 1.0f, 0.0f );
        }
        else
        {
            blink.blink( 1.0f, 0.5f, 1.0f, 0.1f );
        }
    }

    void Start( )
    {
        playerMovement = GetComponent<PlayerMovement>( );
        spriteRenderer = GetComponent<SpriteRenderer>( );
        playerCollider = GetComponent<BoxCollider2D>( );
        blink = GetComponent<Blink>( );
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
        boostEvent = GetComponent<BoostEvent>( );
        boostIndecator = GameObject.Find( $"{playerNumber}P Boost Indecator" ).GetComponent<Image>( );
        gunEvent = GetComponent<GunEvent>( );
        gunIndecator = GameObject.Find( $"{playerNumber}P Gun Indecator" ).GetComponent<Image>( );
        life1Indecator = GameObject.Find( $"{playerNumber}P Life 1" ).GetComponent<Image>( );
        life2Indecator = GameObject.Find( $"{playerNumber}P Life 2" ).GetComponent<Image>( );
        life3Indecator = GameObject.Find( $"{playerNumber}P Life 3" ).GetComponent<Image>( );

        life = Maxlife;
    }

    void Update( )
    {
        if ( boostEvent.boost )
        {
            boostIndecator.enabled = true;
        }
        else
        {
            boostIndecator.enabled = false;
        }

        if ( gunEvent.gun )
        {
            gunIndecator.enabled = true;
        }
        else
        {
            gunIndecator.enabled = false;
        }

        if ( life == 3 )
        {
            life1Indecator.enabled = true;
            life2Indecator.enabled = true;
            life3Indecator.enabled = true;
        }
        else if ( life == 2 )
        {
            life1Indecator.enabled = true;
            life2Indecator.enabled = true;
            life3Indecator.enabled = false;
        }
        else if ( life == 1 )
        {
            life1Indecator.enabled = true;
            life2Indecator.enabled = false;
            life3Indecator.enabled = false;
        }
        else if ( life == 0 )
        {
            life1Indecator.enabled = false;
            life2Indecator.enabled = false;
            life3Indecator.enabled = false;
        }

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
                blink.fade( 0.0f, 1.0f );
            }
        }
    }
}
