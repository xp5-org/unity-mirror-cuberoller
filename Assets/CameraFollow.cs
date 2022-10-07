using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public int depth = -3;

    //new stuff
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // should this run for only localplayer? or both server and player?  or does it not matter bc we arae in MonoBehaviour? 
        // do mouse update always
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


        //do movement update only if cube moves
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0, 2, depth);
        }
    }

    public void setTarget(Transform target)
    {
        playerTransform = target;
    }
}