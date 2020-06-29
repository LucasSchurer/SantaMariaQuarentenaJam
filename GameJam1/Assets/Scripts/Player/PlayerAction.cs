using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAction : MonoBehaviour
{
    public delegate void InfectCreature(Creature newCreature);
    public static event InfectCreature infectCreature;
    public delegate void SearchingForHost(bool isSearching);
    public static event SearchingForHost searchingForHost;
    public delegate void PossibleHostSelected(Creature selectedCreature);
    public static event PossibleHostSelected possibleHostSelected;

    public Creature currentCreature;
    public float infectRadius = 10f;
    public float infectRadarTime = 0.5f;
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

        //StartCoroutine(InfectionRadar());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            InfectionRadar();
            isSearchingForHost = !isSearchingForHost;

            if (searchingForHost != null)
                searchingForHost(isSearchingForHost);
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

            if (possibleHostSelected != null)
                possibleHostSelected(selectedCreature);
        }
            
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedCreatureIndex -= 1;

            if (selectedCreatureIndex < 0)
                selectedCreatureIndex = creaturesInRadarCount - 1;

            selectedCreature = creaturesInRadar[selectedCreatureIndex];

            if (possibleHostSelected != null)
                possibleHostSelected(selectedCreature);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedCreatureIndex += 1;

            if (selectedCreatureIndex > creaturesInRadarCount - 1)
                selectedCreatureIndex = 0;

            selectedCreature = creaturesInRadar[selectedCreatureIndex];

            if (possibleHostSelected != null)
                possibleHostSelected(selectedCreature);
        }

        if (Input.GetKeyDown(KeyCode.E))
            if  (infectCreature != null)
            {
                infectCreature(selectedCreature);
                
                selectedCreature = null;
                isSearchingForHost = false;

                if (searchingForHost != null)
                    searchingForHost(false);

                return;
            }
    }

    private void InfectionRadar()
    {
        creaturesInRadar.Clear();

        Collider2D[] hits = Physics2D.OverlapCircleAll(currentCreature.transform.position, infectRadius, infectMask);
        List<Collider2D> tempList = hits.ToList();
        
        List<Collider2D> leftHits = tempList.Where
            (x => x.transform.position.x <= currentCreature.transform.position.x).ToList()
            .OrderBy(x => (new Vector3(currentCreature.transform.position.x, 0f, 0f) - x.transform.position).sqrMagnitude).ToList();
    
        leftHits.Reverse();

        List<Collider2D> rightHits = tempList.Where
            (x => x.transform.position.x > currentCreature.transform.position.x).ToList()
            .OrderBy(x => (new Vector3(currentCreature.transform.position.x, 0f, 0f) - x.transform.position).sqrMagnitude).ToList();

        List<Collider2D> hitList = leftHits.Concat(rightHits).ToList();

        if (hitList != null)
        {
            foreach (Collider2D hit in hitList)
            {   
                Creature scannedCreature = hit.GetComponent<Creature>();
                creaturesInRadar.Add(scannedCreature);
                print(hit.name);
            }
        }
    }

    /*private IEnumerator InfectionRadar()
    {
        while(true)
        {
            yield return new WaitForSeconds(infectRadarTime);

            creaturesInRadar.Clear();

            Collider2D[] hits = Physics2D.OverlapCircleAll(currentCreature.transform.position, infectRadius, infectMask);
            List<Collider2D> tempList = hits.ToList();
            
            List<Collider2D> leftHits = tempList.Where
                (x => x.transform.position.x <= currentCreature.transform.position.x).ToList()
                .OrderBy(x => (new Vector3(currentCreature.transform.position.x, 0f, 0f) - x.transform.position).sqrMagnitude).ToList();
        
            leftHits.Reverse();

            List<Collider2D> rightHits = tempList.Where
                (x => x.transform.position.x > currentCreature.transform.position.x).ToList()
                .OrderBy(x => (new Vector3(currentCreature.transform.position.x, 0f, 0f) - x.transform.position).sqrMagnitude).ToList();

            List<Collider2D> hitList = leftHits.Concat(rightHits).ToList();

            if (hitList != null)
            {
                foreach (Collider2D hit in hitList)
                {   
                    Creature scannedCreature = hit.GetComponent<Creature>();
                    creaturesInRadar.Add(scannedCreature);
                    print(hit.name);
                }
            }
        }
    }*/
}
