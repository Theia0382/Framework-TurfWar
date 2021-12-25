using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerEvent playerEvent;
    StageInfo stageInfo;

    public int startGridX;
    public int startGridY;

    public string upKey;
    public string downKey;
    public string leftKey;
    public string rightKey;

    public float movingTime;
    
    public int gridX;
    public int gridY;
    public int targetGridX;
    public int targetGridY;

    float startX;
    float startY;
    float targetX;
    float targetY;
    float travelX;
    float travelY;

    public bool moving;
    int playerNumber;
    float movingTimer;
    float progress;

    public void positionInitialize( )
    {
        gridX = startGridX;
        gridY = startGridY;
        targetGridX = startGridX;
        targetGridY = startGridY;
        
        float X = startGridX * stageInfo.travelPerGridX + stageInfo.gridOffsetX;
        float Y = startGridY * stageInfo.travelPerGridY + stageInfo.gridOffsetY;
        transform.position = new Vector2( X, Y );
        transform.rotation = Quaternion.Euler( 0.0f, 0.0f, 0.0f );

    }

    void Start( )
    {
        playerEvent = GetComponent<PlayerEvent>( );
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );

        positionInitialize( );

        playerNumber = playerEvent.playerNumber;
        moving = false;
    }

    void Update( )
    {
        if ( playerEvent.life > 0 )
        {
            if ( Input.GetKey( upKey ) && gridY < stageInfo.gridYMax && !moving )
            {
                Debug.Log( $"{playerNumber}P Move Up" );
                targetGridY += 1;
                transform.rotation = Quaternion.Euler( 0.0f, 0.0f, 0.0f );
            }
            else if ( Input.GetKey( downKey ) && gridY > stageInfo.gridYMin && !moving )
            {
                Debug.Log( $"{playerNumber}P Move Down" );
                targetGridY -= 1;
                transform.rotation = Quaternion.Euler( 0.0f, 0.0f, 180.0f );
            }
            else if ( Input.GetKey( leftKey ) && gridX > stageInfo.gridXMin && !moving )
            {
                Debug.Log( $"{playerNumber}P Move Left" );
                targetGridX -= 1;
                transform.rotation = Quaternion.Euler( 0.0f, 0.0f, 90.0f );
            }
            else if ( Input.GetKey( rightKey ) && gridX < stageInfo.gridXMax && !moving )
            {
                Debug.Log( $"{playerNumber}P Move Right");
                targetGridX += 1;
                transform.rotation = Quaternion.Euler( 0.0f, 0.0f, 270.0f );
            }

            if ( gridX != targetGridX || gridY != targetGridY )
            {
                if ( !moving )
                {
                    startX = transform.position.x;
                    startY = transform.position.y;
                    targetX = targetGridX * stageInfo.travelPerGridX + stageInfo.gridOffsetX;
                    targetY = targetGridY * stageInfo.travelPerGridY + stageInfo.gridOffsetY;
                    travelX = targetX - startX;
                    travelY = targetY - startY;
                    movingTimer = 0.0f;
                    progress = 0.0f;
                    moving = true;
                    Debug.Log( $"{playerNumber}P Moving" );
                }
                else if ( progress < 1 )
                {
                    movingTimer += Time.deltaTime;
                    progress = movingTimer / movingTime;
                    float X = startX + ( travelX * progress );
                    float Y = startY + ( travelY * progress );
                    transform.position = new Vector2( X, Y );
                }
                else
                {
                    Debug.Log( $"{playerNumber}P End Moving" );
                    moving = false;
                    playerEvent.getLine( );
                    playerEvent.itemCheck( );
                    gridX = targetGridX;
                    gridY = targetGridY;
                }
            }
        }
    }
}
