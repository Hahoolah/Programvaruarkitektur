using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    private SpringJoint joint;
    private PlayerResource playerResource;
    [SerializeField]
    public float maxDistance;
    public Transform gunTip, camera, player;
    public LayerMask grappable;
   


    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        playerResource = this.GetComponentInParent<PlayerResource>();
    }


   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (playerResource.DrainMana(10))
            {
                StartGrapple();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
           StopGrapple();
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, grappable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = (distanceFromPoint * 0.8f);
            joint.minDistance = (distanceFromPoint * 0.25f);

            joint.spring = 10f;
            joint.damper = 5;
            joint.massScale = 3.5f;

            lr.positionCount = 2;
        }
            

    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        if (!joint) return; 

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }


}
