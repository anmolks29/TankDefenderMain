using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 25, -25);
    }
}
