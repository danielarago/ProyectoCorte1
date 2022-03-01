using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    // Recuperamos el rigidbody del animal.
    Rigidbody2D myBody;
    float minX, maxX, maxY, minY;

    [SerializeField] float speed;
    [SerializeField] int life;
    public Slider Vida;
    public float DañoDeBullet;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        Vector2 esqInfI = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        minX = esqInfI.x;
        minY = esqInfI.y;

        Vector2 esqSupD = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        maxX = esqSupD.x;
        maxY = esqSupD.y;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
               Mathf.Clamp(transform.position.x, minX, maxX),
               Mathf.Clamp(transform.position.y, minY, maxY)
           );

        
    }

    private void FixedUpdate() {
        /*
        Al usar rigid body para trabajar con velocidad es mejor usar fixed update, tiene la frecuencia
        del sistema de la física, en vez de la frecuencia del fps.En promedio, 50 veces por segundo, es la 
        actualización del sistema de física de Unity.
        Falta hacer que cuando se llegue al límite de la pantalla se pase la velocidad a valor negativo, y vuelva a valor
        positivo al límite de x de la pantalla.
        */
        myBody.velocity = new Vector2(speed,myBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Vida.value -= DañoDeBullet;
            Destroy(collision.gameObject);
        }
    }

    public void TakeNormalShot()
    {
        life--;
    }

    public int GetLife()
    {
        return life;
    }
}
