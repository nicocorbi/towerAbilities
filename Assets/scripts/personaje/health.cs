using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class salud : MonoBehaviour
{
  
    public float maxHealth = 100; 
    public float currentHealth;
    [SerializeField] TMP_Text gameOverUI;
    [SerializeField] public bool isPlayerDead = false;
    public Gradient gradient;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float gradientValue = 1f;
    [SerializeField] atributos attributes;



    void Start()
    {
        currentHealth = maxHealth;
        gradient.Evaluate(1);
        GameEvents.SuscribirEventos();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = 100;
            spriteRenderer.color = gradient.Evaluate(gradientValue);
        }
        if (attributes.time >= 2f)
        {
            currentHealth = currentHealth + attributes.healthRegeration;
            attributes.time = 0f;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameEvents.restart.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= collision.gameObject.GetComponent<Enemigo>().damage;
            currentHealth = Mathf.Max(currentHealth, 0);
            gradientValue = Mathf.Clamp01(currentHealth / maxHealth);
            spriteRenderer.color = gradient.Evaluate(gradientValue);

            if (currentHealth <= 0 && !isPlayerDead)
            {
                isPlayerDead = true;
                GameEvents.deadPlayer.Invoke();
                gameOverUI.gameObject.SetActive(true);
            }
        }

    }

}
