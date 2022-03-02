using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    private bool hasBeenHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        hasBeenHit = true;
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collidedObject);
        }
    }

    public bool GetHasBeenHit()
    {
        return this.hasBeenHit;
    }
}
