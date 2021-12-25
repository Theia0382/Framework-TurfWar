using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    StageInfo stageInfo;

    public int itemsTotal;

    public GameObject boostPrefab;
    public int boostItemNumber;
    public float boostRatio;
    public float boostTime;

    public GameObject gunPrefab;
    public int gunItemNumber;
    public int magazineSize;
    public float bulletSpeed;
    public float reloadTime;
    public float gunTime;
    
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
            int itemNumber = Random.Range( 1, itemsTotal + 1);
            int clone1GridX = Random.Range( stageInfo.gridXMin, stageInfo.gridXMax + 1 );
            int clone1GridY = Random.Range( stageInfo.gridYMin, stageInfo.gridYMax + 1 );
            int clone2GridX = ( stageInfo.gridXMax - ( clone1GridX - stageInfo.gridXMin ) );
            int clone2GridY = ( stageInfo.gridYMax - ( clone1GridY - stageInfo.gridYMin ) );
            float clone1X = clone1GridX * stageInfo.travelPerGridX + stageInfo.gridOffsetX;
            float clone1Y = clone1GridY * stageInfo.travelPerGridY + stageInfo.gridOffsetY;
            float clone2X = clone2GridX * stageInfo.travelPerGridX + stageInfo.gridOffsetX;
            float clone2Y = clone2GridY * stageInfo.travelPerGridY + stageInfo.gridOffsetY;

            if ( itemNumber == boostItemNumber )
            {
                GameObject Boost1 = Instantiate( boostPrefab, new Vector3( clone1X, clone1Y, 1 ), Quaternion.identity, transform ) as GameObject;
                GameObject Boost2 = Instantiate( boostPrefab, new Vector3( clone2X, clone2Y, 1 ), Quaternion.identity, transform ) as GameObject;
                ItemBehavior boost1Behavior = Boost1.GetComponent<ItemBehavior>( );
                ItemBehavior boost2Behavior = Boost2.GetComponent<ItemBehavior>( );
                Alpha boost1Alpha = Boost1.GetComponent<Alpha>( );
                Alpha boost2Alpha = Boost2.GetComponent<Alpha>( );
                stageInfo.objectStatus[ ( clone1GridX - stageInfo.gridXMin ) * 2, ( clone1GridY - stageInfo.gridYMin ) * 2 ] = boostItemNumber;
                stageInfo.objectStatus[ ( clone2GridX - stageInfo.gridXMin ) * 2, ( clone2GridY - stageInfo.gridYMin ) * 2 ] = boostItemNumber;
                boost1Behavior.myX = clone1GridX;
                boost1Behavior.myY = clone1GridY;
                boost2Behavior.myX = clone2GridX;
                boost2Behavior.myY = clone2GridY;
                boost1Alpha.fade( 0.0f, 1.0f, 0.3f );
                boost2Alpha.fade( 0.0f, 1.0f, 0.3f );
                Debug.Log( "Create Boost" );
            }

            if ( itemNumber == gunItemNumber )
            {
                GameObject Gun1 = Instantiate( gunPrefab, new Vector3( clone1X, clone1Y, 1 ), Quaternion.identity, transform ) as GameObject;
                GameObject Gun2 = Instantiate( gunPrefab, new Vector3( clone2X, clone2Y, 1 ), Quaternion.identity, transform ) as GameObject;
                ItemBehavior gun1Behavior = Gun1.GetComponent<ItemBehavior>( );
                ItemBehavior gun2Behavior = Gun2.GetComponent<ItemBehavior>( );
                Alpha gun1Alpha = Gun1.GetComponent<Alpha>( );
                Alpha gun2Alpha = Gun2.GetComponent<Alpha>( );
                stageInfo.objectStatus[ ( clone1GridX - stageInfo.gridXMin ) * 2, ( clone1GridY - stageInfo.gridYMin ) * 2 ] = gunItemNumber;
                stageInfo.objectStatus[ ( clone2GridX - stageInfo.gridXMin ) * 2, ( clone2GridY - stageInfo.gridYMin ) * 2 ] = gunItemNumber;
                gun1Behavior.myX = clone1GridX;
                gun1Behavior.myY = clone1GridY;
                gun2Behavior.myX = clone2GridX;
                gun2Behavior.myY = clone2GridY;
                gun1Alpha.fade( 0.0f, 1.0f, 0.3f );
                gun2Alpha.fade( 0.0f, 1.0f, 0.3f );
                Debug.Log( "Create Gun" );
            }

            itemTimer = 0.0f;
        }
    }
}
