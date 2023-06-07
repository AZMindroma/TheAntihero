using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour {
    private bool isLerping = false;
    public GameObject _camera;
    public GameObject campos;
    public float speed = 1;
    // Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (isLerping == true)
        {
            _camera.transform.position = Vector3.Slerp(_camera.transform.position, campos.transform.position, speed * Time.deltaTime);
            _camera.transform.rotation = Quaternion.Slerp(_camera.transform.rotation, campos.transform.rotation, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isLerping = true;
        }
	}
}
