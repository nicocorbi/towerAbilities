using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameEvents
{
    // Eventos est�ticos de tipo UnityEvent
    public static UnityEvent restart = new UnityEvent();
    public static UnityEvent deadPlayer = new UnityEvent();
    public static UnityEvent deadEnemy = new UnityEvent();

    // No es necesario Start ni m�todos relacionados con MonoBehaviour
    public static void SuscribirEventos()
    {
        // Suscribir los m�todos a los eventos
        deadPlayer.AddListener(DeadPlayer);
        deadEnemy.AddListener(DeadEnemy);
        restart.AddListener(Restart);
    }

    // M�todos para manejar los eventos
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

