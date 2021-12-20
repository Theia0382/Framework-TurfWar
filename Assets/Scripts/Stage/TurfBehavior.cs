using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurfBehavior : MonoBehaviour
{
    StageInfo stageInfo;
    SpriteRenderer spriteRenderer;
    PlayerMovement player1;
    PlayerMovement player2;

    public int myX;
    public int myY;

    void Start( )
    {
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        player1 = GameObject.Find( "Player1" ).GetComponent<PlayerMovement>( );
        player2 = GameObject.Find( "Player2" ).GetComponent<PlayerMovement>( );
        spriteRenderer = GetComponent<SpriteRenderer>( );
    }

    void Update( )
    {
        if ( stageInfo.objectStatus[ myX - 1, myY ] == player1.playerNumber && stageInfo.objectStatus[ myX + 1, myY ] == player1.playerNumber && stageInfo.objectStatus[ myX, myY + 1 ] == player1.playerNumber && stageInfo.objectStatus[ myX, myY - 1 ] == player1.playerNumber )
        {
            stageInfo.objectStatus[ myX, myY ] = player1.playerNumber;
            spriteRenderer.color = new Color( 1.0f, 0.0f, 0.0f, 1.0f );
        }
        else if ( stageInfo.objectStatus[ myX - 1, myY ] == player2.playerNumber && stageInfo.objectStatus[ myX + 1, myY ] == player2.playerNumber && stageInfo.objectStatus[ myX, myY + 1 ] == player2.playerNumber && stageInfo.objectStatus[ myX, myY - 1 ] == player2.playerNumber )
        {
            stageInfo.objectStatus[ myX, myY ] = player2.playerNumber;
            spriteRenderer.color = new Color( 0.0f, 0.0f, 1.0f, 1.0f );
        }
        else
        {
            stageInfo.objectStatus[ myX, myY ] = 0;
            spriteRenderer.color = new Color( 1.0f, 1.0f, 1.0f, 1.0f );
        }
    }
}
