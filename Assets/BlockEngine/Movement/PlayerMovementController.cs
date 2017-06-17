using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour {

    public float speed = 1.2f;

    public Vector3 gravity = new Vector3(0, -4.8f, 0);

    private Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(16, Screen.height - 400, 200, 32), "SPEED=" + rigidbody.velocity);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * 3.4f, ForceMode.VelocityChange);
            //rigidbody.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(transform.TransformDirection(Vector3.back) * 3.4f, ForceMode.VelocityChange);
            //rigidbody.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(transform.TransformDirection(Vector3.left) * 3.4f, ForceMode.VelocityChange);
            //rigidbody.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(transform.TransformDirection(Vector3.right) * 3.4f, ForceMode.VelocityChange);
            //rigidbody.position += transform.forward * Time.deltaTime;
        }

        rigidbody.velocity += gravity;

        if(detectDirection(rigidbody.velocity))
        {
            Ray r = new Ray(transform.position, rigidbody.velocity * 4f);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                rigidbody.velocity -= hit.point - transform.position;
            }
        }
	}

    void LateUpdate()
    {
        rigidbody.velocity /= 1.4f;
    }

    bool detectDirection(Vector3 direction)
    {
        Vector3 pos = transform.position + (rigidbody.velocity.normalized);
        int bx = Mathf.RoundToInt(pos.x);
        int by = Mathf.RoundToInt(pos.y - 1);
        int bz = Mathf.RoundToInt(pos.z);
        if (ClientComponent.INSTANCE.chunkManager.getBlockAt(bx, by, bz) != 0)
        {
            return true;
        }

        Ray r = new Ray(pos, direction.normalized * 2f);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, 4f))
        {
            return true;
        }

        return false;
    }
}
