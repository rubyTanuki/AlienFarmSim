using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisterController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private float lastPlay;

    void OnEnable()
    {
        lastPlay = Time.time- ((Time.time - lastPlay)%60);
    }

    void Update()
    {
        if (Time.time - lastPlay > 60)
        {
            PlayEffect();
            
        }
    }
    public void PlayEffect()
    {
        if (particleSystem != null)
        {
            // The Play() command handles starting the effect.
            // If called on an already playing system, it effectively restarts it.
            particleSystem.Play();
        }
        lastPlay = Time.time;
    }
}
