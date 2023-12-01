using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    private int direction = 1;
    public bool moveHorizontal = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveHorizontal == true)
        {
            transform.Translate(speed * direction * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(0, speed * direction * Time.deltaTime, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "boundary")
        {
            direction *= -1;
        }
        if (collision.tag == "Player")
        {
            //Player parented to platform
            collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Player unparented to platform
            collision.transform.parent = null;
        }
    }

}
