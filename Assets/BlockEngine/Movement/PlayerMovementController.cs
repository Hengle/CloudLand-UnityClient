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
            rigidbody.AddForce(detectAndReturn(transform.TransformDirection(Vector3.forward)) * 3.4f, ForceMode.VelocityChange);
            //rigidbody.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(detectAndReturn(transform.TransformDirection(Vector3.back)) * 3.4f, ForceMode.VelocityChange);
            //rigidbody.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(detectAndReturn(transform.TransformDirection(Vector3.left)) * 3.4f, ForceMode.VelocityChange);
            //rigidbody.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(detectAndReturn(transform.TransformDirection(Vector3.right)) * 3.4f, ForceMode.VelocityChange);
            //rigidbody.position += transform.forward * Time.deltaTime;
        }

        rigidbody.velocity += gravity;

        if(detectDirection(rigidbody.velocity))
        {
            Ray r = new Ray(transform.position, rigidbody.velocity.normalized * 3f);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                rigidbody.velocity -= hit.point - transform.position;

                if(Vector3.Distance(transform.position, hit.point) <= 1.7f)
                {
                    rigidbody.velocity = Vector3.zero;
                }
            }
        }
	}

    Vector3 detectAndReturn(Vector3 dir)
    {
        if (detectDirection(dir))
        {
            Vector3 n = new Vector3(dir.x, dir.y, dir.z);
            Ray r = new Ray(transform.position, rigidbody.velocity.normalized * 3f);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                n -= hit.point - transform.position;
            }
            return n;
        }
        return dir;
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

        Ray r = new Ray(pos, direction.normalized);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, 3f))
        {
            return true;
        }

        return false;
    }
}
