using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    PlayerMovement playerMovement;
    StageInfo stageInfo;
    ItemEvent itemEvent;
    BoostEvent boostEvent;

    public int playerNumber;

    public void getLine( )
    {
        stageInfo.objectStatus[ playerMovement.gridX + playerMovement.targetGridX - stageInfo.gridXMin * 2, playerMovement.gridY + playerMovement.targetGridY - stageInfo.gridYMin * 2 ] = playerNumber;
        Debug.Log( $"Line ( {playerMovement.gridX + playerMovement.targetGridX - stageInfo.gridXMin * 2}, {playerMovement.gridY + playerMovement.targetGridY - stageInfo.gridXMin * 2} ) : {playerNumber}P" );
    }

    public void itemCheck( )
    {
        if ( stageInfo.objectStatus[ ( playerMovement.targetGridX - stageInfo.gridXMin ) * 2, ( playerMovement.targetGridY - stageInfo.gridYMin ) * 2 ] == itemEvent.boostItemNumber )
        {
            stageInfo.objectStatus[ playerMovement.targetGridX * 2, playerMovement.targetGridY * 2 ] = 0;
            boostEvent.getBoost( );
        }
    }

    void Start( )
    {
        playerMovement = GetComponent<PlayerMovement>( );
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
        boostEvent = GetComponent<BoostEvent>( );
    }
}
