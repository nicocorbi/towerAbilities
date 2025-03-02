using UnityEngine;

public class HabilityHolder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Ability[] abilities;
    int abilityNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            abilities[abilityNumber].Trigger();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilityNumber = 0;
            

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            abilityNumber = 1;

            

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            abilityNumber = 2;
            


        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            abilityNumber = 3;



        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            abilityNumber = 4;



        }
    }
}
