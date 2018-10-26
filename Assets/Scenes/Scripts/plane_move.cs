using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class plane_move : MonoBehaviour {
    /*public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        //offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = player.transform.position + offset;
    }*/

    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject player;
    

    void FixedUpdate()
        {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        var locSpace = transform.InverseTransformDirection(player.GetComponent<Rigidbody>().velocity);
        locSpace = movement * speed;
        var wSpace = transform.TransformDirection(locSpace);

        player.GetComponent<Rigidbody>().velocity = new Vector3(wSpace.x, 0, wSpace.z);
    }

    /*// Position camera to follow behind player's head.
    private void Follow()
    {

        // orientation as an angle when projected onto the XZ plane
        // this functionality is modularise into a separate method because
        // I use it elsewhere
        float playerAngle = AngleOnXZPlane(player);
        float cameraAngle = AngleOnXZPlane(transform);

        // difference in orientations
        float rotationDiff = Mathf.DeltaAngle(cameraAngle, playerAngle);

        // rotate around target by time-sensitive difference between these angles
        transform.RotateAround(GetTarget(), Vector3.up, rotationDiff * Time.deltaTime);
    }

    // Find the angle made when projecting the rotation onto the xz plane.
    // You could pass in the rotation as a parameter instead of the transform.
    private float AngleOnXZPlane(Transform item)
    {

        // get rotation as vector (relative to parent)
        Vector3 direction = item.rotation * item.parent.forward;

        // return angle in degrees when projected onto xz plane
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }*/
}
