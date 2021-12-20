using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehavior : MonoBehaviour
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
        spriteRenderer = GetComponent<SpriteRenderer>( );
        player1 = GameObject.Find( "Player1" ).GetComponent<PlayerMovement>( );
        player2 = GameObject.Find( "Player2" ).GetComponent<PlayerMovement>( );

        spriteRenderer.color = new Color( 0.55f, 0.55f, 0.55f, 0.0f );
    }

    void Update( )
    {
        if ( stageInfo.objectStatus[ myX, myY ] == player1.playerNumber )
        {
            spriteRenderer.color = new Color( 1.0f, 0.0f, 0.0f, 1.0f );
        }
        if ( stageInfo.objectStatus[ myX, myY ] == player2.playerNumber )
        {
            spriteRenderer.color = new Color( 0.0f, 0.0f, 1.0f, 1.0f );
        }
    }
}
