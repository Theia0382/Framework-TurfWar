using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostItemBehavior : MonoBehaviour
{
    StageInfo stageInfo;
    ItemEvent itemEvent;

    public int myX;
    public int myY;

    float destroyTimer;

    void Start( )
    {
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
        destroyTimer = 0.0f;
    }

    void Update( )
    {
        destroyTimer += Time.deltaTime;

        if ( stageInfo.objectStatus[ ( myX - stageInfo.gridXMin ) * 2, ( myY - stageInfo.gridYMin ) * 2 ] == 0 || destroyTimer > itemEvent.itemDestroyTime )
        {
            stageInfo.objectStatus[ ( myX - stageInfo.gridXMin ) * 2, ( myY - stageInfo.gridYMin ) * 2 ] = 0;
            Destroy( gameObject );
        }
    }
}
