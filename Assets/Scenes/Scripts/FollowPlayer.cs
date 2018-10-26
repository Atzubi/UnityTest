using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.TransformDirection(transform.position) - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        var locSpace = transform.InverseTransformDirection(player.GetComponent<Rigidbody>().transform.position);
        locSpace += offset;
        transform.position = transform.TransformDirection(locSpace);
        //transform.rotation.eulerAngles.Set(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z);
        transform.rotation = player.transform.rotation;
    }
}