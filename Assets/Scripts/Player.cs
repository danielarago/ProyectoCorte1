using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // serializefield permite que sea una variable privada pero accesible desde el editor de Unity
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    float minX, maxX, maxY, minY;
    [SerializeField] float fireRate;
    private float allowFire;
    private GameObject instanceBullet;
    private bool specialShot = false;


    // Start is called before the first frame update
    void Start()
    {
        /* Acceso a la cámara dentro del juego. Posición en viewport traducida a posición real dentro
        del juego. De esta manera definimos el rango de la pantalla. 
        */
        Vector2 esqInfI = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        minX = esqInfI.x;
        minY = esqInfI.y;

        Vector2 esqSupD = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        maxX = esqSupD.x;
        maxY = esqSupD.y;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(KeyCode.RightArrow))
            transform.Translate(new Vector2(0.1f, 0));
        */

        /* 
        Get Axis es de acuerdo con Project Settings > Input Manager, da valores entre -1 y 1 
        Dos otros factores en el el Input Manager son gravity y sensitivity, gravity es la demora
        del input en volver a valor neutral mientras que sensitivity es la demora del input en llegar
        al valor dado.
        Snap hace que la transición entre los valores sea instántanea.
        */
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        /*
        Podríamos multiplicar por 0.1 para reducir la velocidad. Sin embargo en este ejemplo sigue siendo
        una velocidad por frame, dependiente del frame. En vez, podemos crear una variable speed para
        cambiar la velocidad y multiplicarla por Time.deltaTime que da el valor de tiempo entre cada
        frame y hace que sea una velocidad por segundo, no por frame.
        */
        transform.Translate(new Vector2(movH * speed * Time.deltaTime, movV * speed * Time.deltaTime));

        /*
        El viewport, o la vista siempre tiene las mismas coordenadas, la esquina inferior izquierda
        es 0,0 y la esquina superior derecha es 1,1. 
        Clamp se asegura que los valores se encuentre entre los máximos y mínimos establecidos
        más arribas.
        */
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > allowFire)) { 
            {
                instanceBullet = Instantiate(bullet, transform.position, transform.rotation);
                allowFire = Time.time + fireRate;
            }
        }

        if (instanceBullet.GetComponent<Bullet>().GetHasBeenHit() == true)
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(instanceBullet);
    }

    public void ChangeShot()
    {
        specialShot = !specialShot;
    }

}
