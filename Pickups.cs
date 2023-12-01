using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int gemCount = 0;
    public int coinCount = 0;
    public int potionCount = 0;
    public int numberCount = 0;
    private Vector3 lastCheckpoint;
    private Shoot shootScript;


    // Start is called before the first frame update
    void Start()
    {
        shootScript = GetComponent<Shoot>();
        lastCheckpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            coinCount += 1;
            print($"Collected {coinCount} Coin{(coinCount > 1 ? "s" : "")}");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("gem"))
        {
            gemCount += 1;
            print($"Collected {gemCount} Gem{(gemCount > 1 ? "s" : "")}");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("potion"))
        {
            potionCount += 1;
            shootScript.cupAmmo += 1;
            print($"Collected {potionCount} Potion{(potionCount > 1 ? "s" :"")}");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("checkpoint"))
        {
            lastCheckpoint = collision.transform.position;
        }

        if (collision.CompareTag("enemy"))
        {
            transform.position = lastCheckpoint;
        }
      
        if (collision.CompareTag("number"))
        {
            numberCount += 1;
            print($"Collected {numberCount} Potion{(numberCount > 1 ? "s" : "")}");
            if (numberCount == 5)
            {
                print("Game Over");
            }
            Destroy(collision.gameObject);
        }
    }
}
