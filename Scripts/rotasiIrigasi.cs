using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotasiIrigasi : MonoBehaviour
{
    public int speedX, speedY, speedZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedX, speedY, speedZ);
    }
}
