using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koin : MonoBehaviour
{
    gerak komponenGerak;

    // Start is called before the first frame update
    void Start()
    {
        komponenGerak = GameObject.Find("player").GetComponent<gerak>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            komponenGerak.koin++;
            Destroy(gameObject);
        }
        
    }
}
