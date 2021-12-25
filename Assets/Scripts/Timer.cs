using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;
    Outline outline;
    StageInfo stageInfo;

    public string startKey;

    public float timeValue;
    
    bool start;

    void Start( )
    {
        text = GetComponent<Text>( );
        outline = GetComponent<Outline>( );
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        Time.timeScale = 0.0f;
        outline.enabled = false;
        text.text = "Press Space";
    }

    void Update( )
    {
        if ( stageInfo.start )
        {
            if ( !stageInfo.end )
            {
                if ( timeValue > 0 )
                {
                    timeValue -= Time.deltaTime;
                }
                else
                {
                    timeValue = 0;
                    stageInfo.end = true;
                    Time.timeScale = 0.0f;
                    outline.enabled = true;
                }

                DisplayTime( timeValue );
            }
            else
            {
                if ( stageInfo.player1Score > stageInfo.player2Score )
                {
                    text.text = "1P WIN!";
                    text.color = new Color( 1.0f, 0.0f, 0.0f, 1.0f );
                }
                else if ( stageInfo.player1Score < stageInfo.player2Score )
                {
                    text.text = "2P WIN!";
                    text.color = new Color( 0.0f, 0.0f, 1.0f, 1.0f );
                }
                else
                {
                    text.text = "DRAW";
                }
            }
        }
        else if ( Input.GetKey( startKey ) )
        {
            Time.timeScale = 1.0f;
            stageInfo.start = true;
        }   
    }

    void DisplayTime( float timeToDisplay )
    {
        float minutes = Mathf.FloorToInt( timeToDisplay / 60 );
        float seconds = Mathf.FloorToInt( timeToDisplay % 60 );
        float milliseconds = timeToDisplay % 1 * 1000;

        text.text = string.Format( "{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds );
    }
}
