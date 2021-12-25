using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    bool isFade;
    bool isBlink;
    float timer;
    float blinkTimer;
    float progress;

    float fadeTime;
    float startAlpha;
    float targetAlpha;

    float blinkTime;
    float blinkRate;
    float targetAlphaHigh;
    float targetAlphaLow;
    bool hide;

    public void fade( float _startAlpha, float _targetAlpha, float _fadeTime = 1.0f )
    {
        isFade = true;
        isBlink = false;
        timer = 0.0f;
        progress = 0.0f;

        fadeTime = _fadeTime;
        startAlpha = _startAlpha;
        targetAlpha = _targetAlpha;
    }

    public void blink( float _targetAlphaHigh = 1.0f, float _targetAlphaLow = 0.0f, float _blinkTime = 1.0f, float _blinkRate = 0.2f, bool _hide = false )
    {
        isFade = false;
        isBlink = true;
        timer = 0.0f;
        blinkTimer = 0.0f;
        progress = 0.0f;

        blinkTime = _blinkTime;
        blinkRate = _blinkRate;
        targetAlphaHigh = _targetAlphaHigh;
        targetAlphaLow = _targetAlphaLow;
        hide = _hide;
    }

    void modifyAlpha( float alpha )
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    void Start( )
    {
        spriteRenderer = GetComponent<SpriteRenderer>( );
    }

    void Update( )
    {
        if ( isFade )
        {
            if ( progress < 1 )
            {
                timer += Time.deltaTime;
                progress = timer / fadeTime;

                modifyAlpha( startAlpha + ( ( targetAlpha - startAlpha ) * progress ) );
            }
            else
            {
                modifyAlpha( targetAlpha );
                isFade = false;
            }
        }

        if ( isBlink )
        {
            if ( progress < 1 )
            {
                timer += Time.deltaTime;
                blinkTimer += Time.deltaTime;
                progress = timer / blinkTime;

                if ( blinkTimer < blinkRate / 2 )
                {
                    modifyAlpha( targetAlphaLow );
                }
                else if ( blinkTimer < blinkRate )
                {
                    modifyAlpha( targetAlphaHigh );
                }
                else
                {
                    modifyAlpha( targetAlphaLow );
                    blinkTimer = 0.0f;
                }
            }
            else
            {
                if ( hide )
                {
                    modifyAlpha( 0.0f );
                }
                else
                {
                    modifyAlpha( targetAlphaHigh );
                }
            }
        }
    }
}
