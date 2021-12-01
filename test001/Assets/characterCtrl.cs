using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCtrl : MonoBehaviour
{
    [SerializeField] private float m_speed       = 400f; 

    [SerializeField] private Camera player_cam;

    private bool inAir;
    // Start is called before the first frame update
    void Start()
    {
        inAir = false;
        Cursor.lockState = CursorLockMode.Locked;//锁定指针到视图中心
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move() ;
        rotateCamera();
    }

    public void Move()
    {
         if (Input.GetKey(KeyCode.W))
        {
            //按自身朝向的前向移动
            if (Input.GetKey(KeyCode.LeftShift)){
                GetComponent<Rigidbody>().velocity = transform.forward * m_speed * 2.1f;
            } else
            {
                GetComponent<Rigidbody>().velocity = transform.forward * m_speed * 1.1f;

            }

        }


        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity = transform.forward * m_speed * -1.1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Vector3 a = new Vector3(0, -1, 0);
            // GetComponent<Transform>().Rotate(a);
            GetComponent<Rigidbody>().velocity = transform.right * m_speed * -1.1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
           // Vector3 a = new Vector3(0,1, 0);
           // GetComponent<Transform>().Rotate(a);
            GetComponent<Rigidbody>().velocity = transform.right * m_speed * 1.1f;

        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 a = new Vector3(0, 1, 0);
            GetComponent<Rigidbody>().AddForce(a * m_speed * 2.1f);
            inAir = true;
        }



    }

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX =1,
        MouseY =2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 2.0f;
    public float sensitivityVert = 2.0f;
    public float _rotationX = 0f;
    public float minmumVert = -45f;
    public float maxmumVert = 45f;
    void rotateCamera()
    {
        /*if (Input.GetMouseButton(1))
        {*/
            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                _rotationX = _rotationX - Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);
                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
       /* }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        inAir = false;
    }



}
