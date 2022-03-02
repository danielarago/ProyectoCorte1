using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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

    /*
    * Detecta colisi�n y le resta un punto de vida a animal si se detecta colisi�n con un enemigo.
    */
    public void OnCollisionEnter2D(Collision2D collision){
        GameObject collidedObject = collision.gameObject;
        hasBeenHit = true;
        if (collision.gameObject.tag == "Enemy")
         {
            collidedObject.GetComponent<Animal>().TakeNormalShot();
            if (collidedObject.GetComponent<Animal>().GetLife() == 0)
            {
                Destroy(collidedObject);
            }
         }
    }

    public bool GetHasBeenHit()
    {
        return this.hasBeenHit;
    }
}
