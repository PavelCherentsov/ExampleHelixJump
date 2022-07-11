using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private bool isBreak;

    public void Break()
    {
        if (isBreak)
            return;

        isBreak = true;
        
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();

        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
}
