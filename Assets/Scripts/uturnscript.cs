using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uturnscript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CubeMovementLine.uturn = true;
        }
    }
}
