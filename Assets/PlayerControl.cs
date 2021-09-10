using UnityEngine;
using Mirror;

public class PlayerControl : NetworkBehaviour
{
    [SyncVar]
    public Vector3 Control; //This is a sync var, mirror automatically shares and syncs this variable across all of the scripts on objects with the same network identity, but it can only be set by the server.

    public Color c;//color to change to if we are controlling this one

    void Update()
    {
        // movement for local player only because this is NetworkBehaviour
        if (!isLocalPlayer) return;

       // if (GetComponent<NetworkIdentity>().hasAuthority)//make sure this is an object that we ae controlling
        {
            
            Control = new Vector3(Input.GetAxis("Horizontal") * .2f, 0, Input.GetAxis("Vertical") * .2f);//update our controll varible


            if (this.GetComponent<Rigidbody>().velocity.magnitude < 2f)
            {
                GetComponent<PhysicsLink>().ApplyForce(Control, ForceMode.VelocityChange);//Use our custom force function
            }


            
            if (Input.GetAxis("Cancel") == 1)//if we press the esc button
            {
                GetComponent<PhysicsLink>().CmdResetPose();//reset our position
            }
        }
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
        GetComponent<Renderer>().material.color = c;  //change color
    }
}