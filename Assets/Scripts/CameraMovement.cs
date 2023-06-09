﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject Player;
    [Range(0.0001f, 1f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;
    private Vector3 _cameraOffset;

	// Use this for initialization
	void Start () {
        _cameraOffset = transform.position - Player.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = Player.transform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        if (LookAtPlayer)
        {
            transform.LookAt(Player.transform);
        }
	}
}
