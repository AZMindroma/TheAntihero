using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMovementLine : MonoBehaviour {
    public GameObject Actor;
    public float speed = 7f;
    private Vector3 pos;
    public Material mat;
    private int loopCount = 0;
    public bool onGround = true;
    public float distFromGround = 0.6f;
    public bool isAlive = true;
    public GameObject StartText;
    public GameObject RestartText;
    public GameObject Restartbutton;
    public bool Started = false;
    public GameObject music;
    public static bool uturn = false;
    // Use this for initialization
    void Start()
    {
       speed = 7f;
       loopCount = 0;
       onGround = true;
       distFromGround = 0.6f;
       isAlive = true;
       Started = false;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            StartText.gameObject.SetActive(false);
            Started = true;
            music.gameObject.SetActive(true);
        }
        if (isAlive && Started == true)
        {
            onGround = isGrounded();
            pos = Actor.transform.position;
			Actor.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (onGround == true)
            {
                GameObject Actor2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Actor2.transform.position = pos;
                Actor2.GetComponent<MeshRenderer>().material = mat;
                Actor2.GetComponent<BoxCollider>().isTrigger = true;
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    if (uturn == false)
                    {
                        if (loopCount % 2 != 0)
                        {
                            Actor.transform.eulerAngles = new Vector3(0, 90, 0);
                            loopCount++;
                        }
                        else
                        {
                            Actor.transform.eulerAngles = new Vector3(0, 0, 0);
                            loopCount++;
                        }
                    }
                    if(uturn == true)
                    {
                        if (loopCount % 2 != 0)
                        {
                            Actor.transform.eulerAngles = new Vector3(0, 90, 0);
                            loopCount++;
                        }
                        else
                        {
                            Actor.transform.eulerAngles = new Vector3(0, 180, 0);
                            loopCount++;
                        }
                    }
                }    
            }
        }
    }
    public bool isGrounded()
    {
        return Physics.Raycast(Actor.transform.position, Vector3.down, distFromGround);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            isAlive = false;
            Started = false;
            music.gameObject.SetActive(false);
            GameObject Prime = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject Prime1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject Prime2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Prime.transform.position = pos;
            Prime1.transform.position = pos;
            Prime2.transform.position = pos;
            Prime.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 50;
            Prime1.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 50;
            Prime2.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 100;
            Prime.GetComponent<MeshRenderer>().material = mat;
            Prime1.GetComponent<MeshRenderer>().material = mat;
            Prime2.GetComponent<MeshRenderer>().material = mat;
            RestartText.gameObject.SetActive(true);
            Restartbutton.gameObject.SetActive(true);



        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
