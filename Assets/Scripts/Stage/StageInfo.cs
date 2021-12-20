using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInfo : MonoBehaviour
{
    PlayerMovement player1;
    PlayerMovement player2;
    Text player1ScoreText;
    Text player2ScoreText;

    public int gridXMin;
    public int gridXMax;
    public int gridYMin;
    public int gridYMax;
    public float gridOffsetX;
    public float gridOffsetY;
    public float travelPerGridX;
    public float travelPerGridY;

    public int[ , ] objectStatus;
    
    void Start( )
    {
        player1 = GameObject.Find( "Player1" ).GetComponent<PlayerMovement>( );
        player2 = GameObject.Find( "Player2" ).GetComponent<PlayerMovement>( );
        player1ScoreText = GameObject.Find( "1P Score" ).GetComponent<Text>( );
        player2ScoreText = GameObject.Find( "2P Score" ).GetComponent<Text>( );

        objectStatus = new int[ ( gridXMax - gridXMin ) * 2 + 1, ( gridYMax - gridXMin ) * 2 + 1 ];
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
                        if( objectStatus[ x, y ] == player1.playerNumber )
                        {
                            player1Score += 1;
                        }
                        if( objectStatus[ x, y ] == player2.playerNumber )
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
