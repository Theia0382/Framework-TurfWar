using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    StageInfo stageInfo;

    public int itemsTotal;

    public GameObject boostPrefab;
    public int boostItemNumber;
    public float boostMovingTimeRatio;
    public float boostTime;
    public float itemCreateCycle;
    public float itemDestroyTime;

    float itemTimer;

    void Start( )
    {
        stageInfo = GetComponent<StageInfo>( );

        itemTimer = 0.0f;
    }

    void Update( )
    {
        itemTimer += Time.deltaTime;

        if ( itemTimer > itemCreateCycle )
        {
            int clone1GridX = Random.Range( stageInfo.gridXMin, stageInfo.gridXMax + 1 );
            int clone1GridY = Random.Range( stageInfo.gridYMin, stageInfo.gridYMax + 1 );
            int clone2GridX = ( stageInfo.gridXMax - ( clone1GridX - stageInfo.gridXMin ) );
            int clone2GridY = ( stageInfo.gridYMax - ( clone1GridY - stageInfo.gridYMin ) );
            float clone1X = clone1GridX * stageInfo.travelPerGridX + stageInfo.gridOffsetX;
            float clone1Y = clone1GridY * stageInfo.travelPerGridY + stageInfo.gridOffsetY;
            float clone2X = clone2GridX * stageInfo.travelPerGridX + stageInfo.gridOffsetX;
            float clone2Y = clone2GridY * stageInfo.travelPerGridY + stageInfo.gridOffsetY;
            GameObject Boost1 = Instantiate( boostPrefab, new Vector3( clone1X, clone1Y, 1 ), Quaternion.identity, transform ) as GameObject;
            GameObject Boost2 = Instantiate( boostPrefab, new Vector3( clone2X, clone2Y, 1 ), Quaternion.identity, transform ) as GameObject;
            BoostItemBehavior boost1Behavior = Boost1.GetComponent<BoostItemBehavior>( );
            BoostItemBehavior boost2Behavior = Boost2.GetComponent<BoostItemBehavior>( );
            stageInfo.objectStatus[ ( clone1GridX - stageInfo.gridXMin ) * 2, ( clone1GridY - stageInfo.gridYMin ) * 2 ] = boostItemNumber;
            stageInfo.objectStatus[ ( clone2GridX - stageInfo.gridXMin ) * 2, ( clone2GridY - stageInfo.gridYMin ) * 2 ] = boostItemNumber;
            boost1Behavior.myX = clone1GridX;
            boost1Behavior.myY = clone1GridY;
            boost2Behavior.myX = clone2GridX;
            boost2Behavior.myY = clone2GridY;
            itemTimer = 0.0f;
            Debug.Log( "Create Boost" );
        }
    }
}
