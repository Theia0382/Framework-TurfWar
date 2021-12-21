using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehavior : MonoBehaviour
{
    StageInfo stageInfo;
    SpriteRenderer spriteRenderer;

    public int myX;
    public int myY;

    void Start( )
    {
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        spriteRenderer = GetComponent<SpriteRenderer>( );

        spriteRenderer.color = new Color( 0.55f, 0.55f, 0.55f, 0.0f );
    }

    void Update( )
    {
        if ( stageInfo.objectStatus[ myX, myY ] == 1 )
        {
            spriteRenderer.color = new Color( 1.0f, 0.0f, 0.0f, 1.0f );
        }
        if ( stageInfo.objectStatus[ myX, myY ] == 2 )
        {
            spriteRenderer.color = new Color( 0.0f, 0.0f, 1.0f, 1.0f );
        }
    }
}
