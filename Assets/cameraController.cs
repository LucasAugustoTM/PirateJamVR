using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public GameObject Player;
    public GameObject Sail;
    public float speed;
    // Start is called before the first frame update
    private void awake()
    {
        Player = GameObject.FindGameObjectWithTag("steer");
        Sail = GameObject.FindGameObjectWithTag("sail");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        follow();
    }

    private void follow() {

        gameObject.transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(Sail.gameObject.transform.position);
    }
}
