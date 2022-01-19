using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControl : MonoBehaviour
{
    private Animator animator;
    public CharacterController controller;
    public Camera camera;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        var p1 = camera.transform.position;
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        camera.transform.LookAt(transform);
        //controller.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float vMan = 3.2f, vRotate = 90.2f, vScroll = 180.0f;
        bool manRotate = false;
        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }*/
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IdleToStraight",true);
            controller.Move(vMan*dt*transform.forward);
            camera.transform.SetParent(null);
            var cmaTrans = camera.transform;
            var rt = transform.position-cmaTrans.position;
            rt.y = 0;
            transform.Rotate(0,Vector3.SignedAngle(transform.forward,rt,Vector3.up),0);
            camera.transform.SetParent(transform);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IdleToLeft",true);
            controller.Move(vMan*dt*transform.forward);
            camera.transform.SetParent(null);
            var cmaTrans = camera.transform;
            var rt = transform.position-cmaTrans.position;
            rt.y = 0;
            transform.Rotate(0,Vector3.SignedAngle(transform.forward,rt,Vector3.up)-90,0);
            camera.transform.SetParent(transform);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IdleToRight",true);
            controller.Move(vMan*dt*transform.forward);
            camera.transform.SetParent(null);
            var cmaTrans = camera.transform;
            var rt = transform.position-cmaTrans.position;
            rt.y = 0;
            transform.Rotate(0,Vector3.SignedAngle(transform.forward,rt,Vector3.up)+90,0);
            camera.transform.SetParent(transform);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IdleToBack",true);
            controller.Move(vMan*dt*transform.forward);
            camera.transform.SetParent(null);
            var cmaTrans = camera.transform;
            var rt = transform.position-cmaTrans.position;
            rt.y = 0;
            transform.Rotate(0,Vector3.SignedAngle(transform.forward,rt,Vector3.up)+180,0);
            camera.transform.SetParent(transform);
        }

       
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IdleToStraight",false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IdleToLeft",false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IdleToRight",false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IdleToBack",false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RayTry();
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     Debug.Log(Input.GetAxis("Mouse X"));
        //     Debug.Log(Input.GetAxis("Mouse Y"));
        // }
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            camera.transform.SetParent(null);
            var xRot = Input.GetAxis("Mouse X");
            var yRot = Input.GetAxis("Mouse Y");
            var scroll = Input.GetAxis("Mouse ScrollWheel");
            var cmaTrans = camera.transform;
            var pos = transform.position;
            cmaTrans.RotateAround(pos,Vector3.up, xRot*dt*vRotate);
            cmaTrans.RotateAround(pos,-camera.transform.right, yRot*dt*vRotate);
            cmaTrans.Translate(cmaTrans.forward*dt*scroll*vScroll,Space.World);
            
            // var cmaPos = cmaTrans.position;
            // cmaPos.z += dt;
            // cmaTrans.position = cmaPos;
            
            // var direction = Vector3.Normalize(pos - cmaPos);
            // cmaPos.y += direction.y * dt ;
            // cmaPos.x += direction.z * dt ;
            // cmaPos.z += direction.x * dt;
            // cmaTrans.position = cmaPos;
            //cmaTrans.LookAt(transform);
            camera.transform.SetParent(transform);
           // 
        }
    }

    void RayTry()
    {
        var ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Debug.Log(hit.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        if (other.gameObject.tag.Equals("Wall"))
        {
            canMove = false;
        }
        //throw new NotImplementedException();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit!");
        if (other.gameObject.tag.Equals("Wall"))
        {
            canMove = true;
        }
        //throw new NotImplementedException();
    }

    /*void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision!");
        if (other.gameObject.tag.Equals("Wall"))
        {
            canMove = false;
        }
        throw new NotImplementedException();
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("Collision stay!");
        throw new NotImplementedException();
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("Collision finished!");
        if (other.gameObject.tag.Equals("Wall"))
        {
            canMove = true;
        }
        throw new NotImplementedException();
    }*/
}
