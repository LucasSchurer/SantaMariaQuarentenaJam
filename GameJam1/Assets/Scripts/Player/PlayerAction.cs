using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public delegate void InfectCreature(Creature newCreature);
    public static event InfectCreature infectCreature;
    public delegate void SearchingForHost(bool isSearching);
    public static event SearchingForHost searchingForHost;

    public Creature currentCreature;
    public float infectRadius = 10f;
    public float infectRadarTime = 1f;
    public LayerMask infectMask = 1 << 9;

    public List<Creature> creaturesInRadar;

    public bool slowMotion = false;

    public bool isSearchingForHost;

    public Creature selectedCreature;
    public int selectedCreatureIndex;
    public int creaturesInRadarCount;

    void Start()
    {
        creaturesInRadar = new List<Creature>();

        StartCoroutine(InfectionRadar());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && creaturesInRadar.Count != 0)
        {
            isSearchingForHost = !isSearchingForHost;

            if (searchingForHost != null)
                searchingForHost(isSearchingForHost);

            /*
            // Infect the first creature on the list
            if (creaturesInRadar.Count != 0)
            {
                if (creaturesInRadar[0] != null)
                {
                    if (infectCreature != null)
                        infectCreature(creaturesInRadar[0]);
                }
            }*/
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentCreature.UseAction();
        }

        if (isSearchingForHost)
            SearchHostUI();
        else if (selectedCreature != null)
            selectedCreature = null;
    }

    private void SearchHostUI()
    {
        creaturesInRadarCount = creaturesInRadar.Count;

        if (creaturesInRadarCount == 0)
        {
            isSearchingForHost = false;
            if (searchingForHost != null)
                searchingForHost(isSearchingForHost);

            return;
        }

        if (selectedCreature == null)
        {
            selectedCreature = creaturesInRadar[0];
            selectedCreatureIndex = 0;
        }
            
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedCreatureIndex -= 1;

            if (selectedCreatureIndex < 0)
                selectedCreatureIndex = creaturesInRadarCount - 1;

            selectedCreature = creaturesInRadar[selectedCreatureIndex];
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedCreatureIndex += 1;

            if (selectedCreatureIndex > creaturesInRadarCount - 1)
                selectedCreatureIndex = 0;

            selectedCreature = creaturesInRadar[selectedCreatureIndex];
        }

        if (Input.GetKeyDown(KeyCode.E))
            if  (infectCreature != null)
            {
                infectCreature(selectedCreature);
                selectedCreature = null;
                isSearchingForHost = false;
                searchingForHost(false);
                return;
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
