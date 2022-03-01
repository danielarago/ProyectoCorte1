using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool hasBeenHit=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        GameObject collidedObject = collision.gameObject;
        if (collision.gameObject.tag == "Enemy") {
            collidedObject.GetComponent<Animal>().TakeNormalShot();
            if (collidedObject.GetComponent<Animal>().GetLife() == 0)
            {
                Destroy(collidedObject);
            }
        }
        else
        {
            hasBeenHit = true;
        }
    }

    public bool GetHasBeenHit()
    {
        return this.hasBeenHit;
    }
}
