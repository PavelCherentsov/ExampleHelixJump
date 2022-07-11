using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlatformSegment platformSegment))
        {
            var platform = platformSegment.GetComponentInParent<Platform>();
            if (platform is null)
                return;
            platformSegment.GetComponentInParent<Platform>().Break();
        }
    }
}
