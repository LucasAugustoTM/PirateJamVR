using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private List<GameObject> sails;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private GameObject Steer; // nova

    private float input;
    private float inputSpeed = 2f;
    private float sailRotation;
    

    private void FixedUpdate()
    {



        transform.GetComponent<Rigidbody>().AddRelativeTorque(0, sailRotation / rotationSpeed, 0, ForceMode.Acceleration);
        Steer = GameObject.FindGameObjectWithTag("steer"); // nova
    }

    // Update is called once per frame
    void Update()
    {

        //input = Input.GetAxis("Horizontal") / inputSpeed;
        input = Steer.transform.localRotation.z / inputSpeed;

        Vector3 myRotation = Vector3.zero;

        foreach (var item in sails)
        {
            item.transform.Rotate(0, input*3*(-1), 0); // novo input*4*-1

            myRotation = item.transform.localRotation.eulerAngles;

            if (myRotation.y > 180) myRotation.y -= 360f;

            myRotation.y = Mathf.Clamp(myRotation.y, -45f, 45f);


            item.transform.localRotation = Quaternion.Euler(myRotation);
        }

        sailRotation = myRotation.y;

    }
}
