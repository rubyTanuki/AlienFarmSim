using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class util_AnimationHelper
{
    public enum ZoomType{
        Lerp,
        Flat
    }
    public enum FadeType{
        Fade,
        Grow
    }


    public static float FadeIn(GameObject obj, FadeType type, float speed){
        //float result = 0.0f;
        switch(type){
            case FadeType.Fade:
                SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
                Color color = renderer.material.color;
                float opacity = color.a;
                opacity = Mathf.Max(1, opacity+=speed*Time.deltaTime);
                color = new Color(color.r, color.g, color.b, opacity);
                renderer.material.color = color;

                return Mathf.Max(0, renderer.material.color.a);
                break;
            case FadeType.Grow:
                
                break;
        }
        return 0.0f;
    }
}
