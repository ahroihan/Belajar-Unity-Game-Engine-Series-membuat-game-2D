using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burung : MonoBehaviour
{
    public int powerJump;

    Rigidbody2D lompat;
    Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey("up")))
        {
            lompat.AddForce(new Vector2(0, powerJump));
            animPlayer.SetBool("terbang", true);
        } else
        {
            animPlayer.SetBool("terbang", false);
        }
    }
}
