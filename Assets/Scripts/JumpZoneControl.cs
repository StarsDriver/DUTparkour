using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZoneControl : MonoBehaviour
{
    public GameObject JUMP;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Instantiate(JUMP,transform.position,transform.rotation);
        }

    }
}
