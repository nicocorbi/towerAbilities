using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Transform player;
    public float speed = 3f; // Velocidad de movimiento
    public float damage = 100;
    

    void Start()
    {
        GameEvents.SuscribirEventos();
        // Buscar al jugador por su etiqueta "Player"
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            player = jugador.transform;
        }
       
    }

    void Update()
    {
        if (player.GetComponent<salud>().isPlayerDead)
        {
            // Si el personaje está muerto, los enemigos se alejan
            Vector3 direction = (transform.position - player.position).normalized; // Invertir la dirección para alejarse
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // Si el personaje está vivo, los enemigos se acercan
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
        
    }
}

