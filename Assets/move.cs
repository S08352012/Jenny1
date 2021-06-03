using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    player myScript;
    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        myScript = GameObject.Find("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
    }
}
