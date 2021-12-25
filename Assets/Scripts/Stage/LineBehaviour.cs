using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehavior : MonoBehaviour
{
    StageInfo stageInfo;
    SpriteRenderer spriteRenderer;
    PlayerEvent player1Event;
    PlayerEvent player2Event;

    public int myX;
    public int myY;

    void Start( )
    {
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        spriteRenderer = GetComponent<SpriteRenderer>( );
        player1Event = GameObject.Find( "Player1" ).GetComponent<PlayerEvent>( );
        player2Event = GameObject.Find( "Player2" ).GetComponent<PlayerEvent>( );

        spriteRenderer.color = new Color( 0.55f, 0.55f, 0.55f, 0.0f );
    }

    void Update( )
    {
        if ( stageInfo.objectStatus[ myX, myY ] == player1Event.playerNumber )
        {
            spriteRenderer.color = new Color( 1.0f, 0.0f, 0.0f, 1.0f );
        }
        if ( stageInfo.objectStatus[ myX, myY ] == player2Event.playerNumber )
        {
            spriteRenderer.color = new Color( 0.0f, 0.0f, 1.0f, 1.0f );
        }
    }
}
