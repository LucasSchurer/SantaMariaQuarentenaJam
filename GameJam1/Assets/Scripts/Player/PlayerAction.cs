using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public delegate void InfectCreature(Creature newCreature);
    public static event InfectCreature infectCreature;
    public Creature currentCreature;
    public float infectRadius = 10f;
    public float infectRadarTime = 1f;
    public LayerMask infectMask = 1 << 9;

    public List<Creature> creaturesInRadar;

    void Start()
    {
        creaturesInRadar = new List<Creature>();

        StartCoroutine(InfectionRadar());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Infect the first creature on the list
            if (creaturesInRadar.Count != 0)
            {
                if (creaturesInRadar[0] != null)
                {
                    if (infectCreature != null)
                        infectCreature(creaturesInRadar[0]);
                }
            }   
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentCreature.UseAction();
        }
    }

    private IEnumerator InfectionRadar()
    {
        while(true)
        {
            yield return new WaitForSeconds(infectRadarTime);

            creaturesInRadar.Clear();

            Collider2D[] hits = Physics2D.OverlapCircleAll(currentCreature.transform.position, infectRadius, infectMask);
            if (hits != null)
            {
                foreach (Collider2D hit in hits)
                {   
                    Creature scannedCreature = hit.GetComponent<Creature>();
                    creaturesInRadar.Add(scannedCreature);
                    print(hit.name);
                }
            }
        }
    }
}
