using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool hasBeenHit = false;
    private bool specialShot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision){
        GameObject collidedObject = collision.gameObject;
        if (specialShot == false)
        {
            if (collision.gameObject.tag == "Enemy")
            {
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
        else if (specialShot == true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collidedObject);
                hasBeenHit = true;
            }
            else
            {
                hasBeenHit = true;
            }
        }
    }

    public bool GetHasBeenHit()
    {
        return this.hasBeenHit;
    }

    public void ChangeShot()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            specialShot = !specialShot;
        }
    }

    public bool GetSpecialShot()
    {
        return specialShot;
    }
}
