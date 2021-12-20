using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int gridXMin = 0;
    public int gridXMax = 5;
    public int gridYMin = 0;
    public int gridYMax = 4;
    public float gridOffsetX = -5f;
    public float gridOffsetY = -4.5f;
    public float travelPerGridX = 2f;
    public float travelPerGridY = 2f;

    public int startGridX = 0;
    public int startGridY = 0;

    public string upKey = "w";
    public string downKey = "s";
    public string leftKey = "a";
    public string rightKey = "d";

    public float movingTime = 1.0f;

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
        gridX = startGridX;
        gridY = startGridY;
        targetGridX = startGridX;
        targetGridY = startGridY;

        moving = false;
    }

    void Update( )
    {
        if( Input.GetKey( upKey ) && gridY < gridYMax && !moving )
        {
            Debug.Log( "Move Up" );
            targetGridY += 1;
        }
        else if( Input.GetKey( downKey ) && gridY > gridYMin && !moving )
        {
            Debug.Log( "Move Down" );
            targetGridY += -1;
        }
        else if( Input.GetKey( leftKey ) && gridX > gridXMin && !moving )
        {
            Debug.Log( "Move Left" );
            targetGridX += -1;
        }
        else if( Input.GetKey( rightKey ) && gridX < gridXMax && !moving )
        {
            Debug.Log( "Move Right");
            targetGridX += 1;
        }

        if( gridX != targetGridX || gridY != targetGridY )
        {
            if( !moving )
            {
                startX = transform.position.x;
                startY = transform.position.y;
                targetX = targetGridX * travelPerGridX + gridOffsetX;
                targetY = targetGridY * travelPerGridY + gridOffsetY;
                travelX = targetX - startX;
                travelY = targetY - startY;
                timer = 0f;
                progress = 0f;
                moving = true;
                Debug.Log( "Moving" );
            }
            else if( progress < 1 )
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
                gridX = targetGridX;
                gridY = targetGridY;
            }
        }
    }
}
