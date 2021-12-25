using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    StageInfo stageInfo;
    ItemEvent itemEvent;

    public int parentNumber;

    void OnTriggerEnter2D( Collider2D target )
    {
        if ( target.tag == "Player" )
        {
            PlayerEvent targetPlayerEvent = target.GetComponent<PlayerEvent>( );
            int targetPlayerNumber = targetPlayerEvent.playerNumber;
            
            if ( targetPlayerNumber != parentNumber )
            {
                Debug.Log( $"{targetPlayerNumber}P Hit" );
                targetPlayerEvent.getHurt( );
                Destroy( gameObject );
            }
        }
    }

    void Start( )
    {
        stageInfo = GameObject.Find( "Stage" ).GetComponent<StageInfo>( );
        itemEvent = GameObject.Find( "Stage" ).GetComponent<ItemEvent>( );
    }

    void Update( )
    {
        float currentX = transform.position.x;
        float currentY = transform.position.y;

        if ( currentX > stageInfo.stageXMax || currentX < stageInfo.stageXMin || currentY > stageInfo.stageYMax || currentY < stageInfo.stageYMin )
        {
            Destroy( gameObject );
        }

        transform.Translate( new Vector3( 0.0f, itemEvent.bulletSpeed * Time.deltaTime, 0.0f) );
    }
}
