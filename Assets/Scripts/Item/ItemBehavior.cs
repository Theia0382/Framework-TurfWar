using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    StageInfo stageInfo;
    ItemEvent itemEvent;
    Alpha alpha;

    public int myX;
    public int myY;

    float destroyTimer;

    static float fadeOutTime = 0.3f;
    bool destroying;

    void Start( )
    {
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
        alpha = GetComponent<Alpha>( );
        destroyTimer = 0.0f;
        destroying = false;
    }

    void Update( )
    {
        destroyTimer += Time.deltaTime;

        if ( ( stageInfo.objectStatus[ ( myX - stageInfo.gridXMin ) * 2, ( myY - stageInfo.gridYMin ) * 2 ] == 0 || destroyTimer > itemEvent.itemDestroyTime ) && !destroying )
        {
            stageInfo.objectStatus[ ( myX - stageInfo.gridXMin ) * 2, ( myY - stageInfo.gridYMin ) * 2 ] = 0;
            destroying = true;
            Destroy( gameObject, fadeOutTime );
            alpha.fade( 1.0f, 0.0f, fadeOutTime );
        }
    }
}
