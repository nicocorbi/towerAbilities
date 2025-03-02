using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameEvents
{
    // Eventos estáticos de tipo UnityEvent
    public static UnityEvent restart = new UnityEvent();
    public static UnityEvent deadPlayer = new UnityEvent();
    public static UnityEvent deadEnemy = new UnityEvent();

    // No es necesario Start ni métodos relacionados con MonoBehaviour
    public static void SuscribirEventos()
    {
        // Suscribir los métodos a los eventos
        deadPlayer.AddListener(DeadPlayer);
        deadEnemy.AddListener(DeadEnemy);
        restart.AddListener(Restart);
    }

    // Métodos para manejar los eventos
    static void DeadPlayer()
    {
        Debug.Log("El personaje ha muerto");
    }

    static void DeadEnemy()
    {
        Debug.Log("El enemigo ha muerto");
        
    }

    static void Restart()
    {
        Debug.Log("Reiniciando el juego...");
        SceneManager.LoadScene("SampleScene");
    }
}

