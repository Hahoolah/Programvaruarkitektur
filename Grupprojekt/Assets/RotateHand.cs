using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    public GrapplingGun grappling;

   void Update()
    {
        if (grappling.isGrappling()) return;
        transform.LookAt(grappling.GetGrapplePoint());
        
    }

}
