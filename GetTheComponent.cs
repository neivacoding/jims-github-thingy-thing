using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTheComponent : MonoBehaviour
{
    private Collider2D theCollider;
    private SpriteRenderer sp;
    private Pickups pickups;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent gets access to the specified component
        theCollider = GetComponent<Collider2D>();
        sp = GetComponent<SpriteRenderer>();
        //pickups = GetComponent<Pickups>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            theCollider.enabled = false;
            Random.Range(4, 7);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            sp.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //pickups.halo.SetActive(true);
        }
    }
}
