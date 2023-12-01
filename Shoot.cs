using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject cup;
    public Transform cupPosition;
    public int cupAmmo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(cupAmmo < 1)
            {
                return;
            }
            GameObject clone = Instantiate(cup, cupPosition.position, Quaternion.identity);
            Cup thecup = clone.GetComponent<Cup>();
            
            if (transform.localScale.x > 0)
            {
                thecup.direction = 1;

            }
            if (transform.localScale.x < 0)
            {
                thecup.direction = -1;
            }
            
            cupAmmo -= 1;

        }
    }
}
