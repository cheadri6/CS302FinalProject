using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

    public GameObject shadow;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        shadow.transform.parent = player.transform;
    }
}
