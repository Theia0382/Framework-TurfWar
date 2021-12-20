using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    StageInfo stageInfo;

    public int startGridX;
    public int startGridY;

    public string upKey;
    public string downKey;
    public string leftKey;
    public string rightKey;

    public float movingTime;

    public int playerNumber;

    int gridX;
    int gridY;
    int targetGridX;
    int targetGridY;

    float startX;
    float startY;
    float targetX;
    float targetY;
    float travelX;
    float travelY;

    bool moving;
    float timer;
    float progress;

    void Start( )
    {
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );

        gridX = startGridX;
        gridY = startGridY;
        targetGridX = startGridX;
        targetGridY = startGridY;
        
        float X = startGridX * stageInfo.travelPerGridX + stageInfo.gridOffsetX;
        float Y = startGridY * stageInfo.travelPerGridY + stageInfo.gridOffsetY;
        transform.position = new Vector2( X, Y );

        moving = false;
    }

    void Update( )
    {
        if ( Input.GetKey( upKey ) && gridY < stageInfo.gridYMax && !moving )
        {
            Debug.Log( "Move Up" );
            targetGridY += 1;
        }
        else if ( Input.GetKey( downKey ) && gridY > stageInfo.gridYMin && !moving )
        {
            Debug.Log( "Move Down" );
            targetGridY += -1;
        }
        else if ( Input.GetKey( leftKey ) && gridX > stageInfo.gridXMin && !moving )
        {
            Debug.Log( "Move Left" );
            targetGridX += -1;
        }
        else if ( Input.GetKey( rightKey ) && gridX < stageInfo.gridXMax && !moving )
        {
            Debug.Log( "Move Right");
            targetGridX += 1;
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
                timer = 0.0f;
                progress = 0.0f;
                moving = true;
                Debug.Log( "Moving" );
            }
            else if ( progress < 1 )
            {
                timer += Time.deltaTime;
                progress = timer / movingTime;
                float X = startX + ( travelX * progress );
                float Y = startY + ( travelY * progress );
                transform.position = new Vector2( X, Y );
            }
            else
            {
                Debug.Log( "End Moving");
                moving = false;
                stageInfo.objectStatus[ gridX + targetGridX, gridY + targetGridY ] = playerNumber;
                Debug.Log( $"Line( {gridX + targetGridX}, {gridY + targetGridY} ) : {playerNumber}P" );
                gridX = targetGridX;
                gridY = targetGridY;
            }
        }
    }
}
