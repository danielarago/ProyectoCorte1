using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Recuperamos el rigidbody del animal.
    Rigidbody2D myBody;

    [SerializeField] float speed;
    [SerializeField] int life;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void TakeNormalShot()
    {
        life--;
    }

    public int GetLife()
    {
        return life;
    }
}
