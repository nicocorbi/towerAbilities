using UnityEngine;
using System.Collections;


public class habilidadFuerza : Ability
{
    [SerializeField] atributos attributes;
    [SerializeField] disparo1 shot1;
    [SerializeField] disparo2 shot2;
    public float time = 10;
    public ParticleSystem particlesForce;
    private float cooldownTimer;

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            icon.fillAmount = 1 - (cooldownTimer / cooldown); // La barra se vac�a en 1 segundo
        }
    }

    public override void Trigger()
    {
        if (cooldownTimer <= 0)
        {
            StartCoroutine(AplicarEfecto());
            cooldownTimer = cooldown; // Reinicia el cooldown
            icon.fillAmount = 0;

        }
    }

    private IEnumerator AplicarEfecto()
    {
        
        attributes.damageMultiplier = 3;      
        particlesForce.Play();
        print("Fuerza activada");      
        while (time > 0)
        {
            
            shot1.damage = 40 * attributes.damageMultiplier;
            shot2.damage = 50 * attributes.damageMultiplier;           
            print("Da�o actualizado: disparo1 - " + shot1.damage + ", disparo2 - " + shot2.damage);
            time -= Time.deltaTime; 
            yield return null; 
        }   
        shot1.damage = 40;  
        shot2.damage = 50;  
        print("Fuerza finalizada");
        particlesForce.Stop();
    }
}
