using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInfo : MonoBehaviour
{
    Text player1ScoreText;
    Text player2ScoreText;
    PlayerEvent player1Event;
    PlayerEvent player2Event;

    public int gridXMin;
    public int gridXMax;
    public int gridYMin;
    public int gridYMax;
    public float gridOffsetX;
    public float gridOffsetY;
    public float travelPerGridX;
    public float travelPerGridY;
    public float stageXMax;
    public float stageXMin;
    public float stageYMax;
    public float stageYMin;

    public int[ , ] objectStatus;
    
    void Start( )
    {
        player1ScoreText = GameObject.Find( "1P Score" ).GetComponent<Text>( );
        player2ScoreText = GameObject.Find( "2P Score" ).GetComponent<Text>( );
        player1Event = GameObject.Find( "Player1" ).GetComponent<PlayerEvent>( );
        player2Event = GameObject.Find( "Player2" ).GetComponent<PlayerEvent>( );

        objectStatus = new int[ ( gridXMax - gridXMin + 1 ) * 2 - 1, ( gridYMax - gridYMin + 1 ) * 2 - 1 ];
        for ( int x = 0; x < objectStatus.GetLength( 0 ); x++ )
        {
            for ( int y = 0; y < objectStatus.GetLength( 1 ); y++ )
            {
                objectStatus[ x, y ] = 0;
            }
        }
    }

    void Update( )
    {
        int player1Score = 0;
        int player2Score = 0;
        for ( int x = 0; x < objectStatus.GetLength( 0 ); x++ )
        {
            if ( x % 2 == 1 )
            {
                for ( int y = 0; y < objectStatus.GetLength( 1 ); y++ )
                {
                    if ( y % 2 == 1)
                    {
                        if( objectStatus[ x, y ] == player1Event.playerNumber )
                        {
                            player1Score += 1;
                        }
                        if( objectStatus[ x, y ] == player2Event.playerNumber )
                        {
                            player2Score += 1;
                        }
                    }
                }
            }
            
        }
        player1ScoreText.text = player1Score.ToString( );
        player2ScoreText.text = player2Score.ToString( );
    }
}
