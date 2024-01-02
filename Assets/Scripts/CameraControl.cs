using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private int RoadNum = 2;
    private GameObject Player;
    private float y = 5.490016f;
    private float z = 7.98648f;
    private float velocity = 20;
    private PlayerControl playerControl;
    public PlayerControl IsHighJump;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        IsHighJump =Player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity += 0.2f*Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                RoadNum--;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                RoadNum++;
            }

        }
        if (!IsHighJump.highJump)
        {
            transform.position -= Vector3.forward * velocity * Time.deltaTime;
            switch (RoadNum)
            {
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.05f, Player.transform.position.y + y, Player.transform.position.z + z), 50 * Time.deltaTime);
                    break;
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.138f, Player.transform.position.y + y, Player.transform.position.z + z), 50 * Time.deltaTime);
                    break;
                case 3:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(-2.89f, Player.transform.position.y + y, Player.transform.position.z + z), 50 * Time.deltaTime);
                    break;
            }
        }else
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + y, Player.transform.position.z + z);
        }
        

    }
}
