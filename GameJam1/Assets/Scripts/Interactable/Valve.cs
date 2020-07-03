using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public List<Transform> controlledPipeList;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangePipeState()
    {
        foreach (Transform controlledPipe in controlledPipeList)
        {
            if (controlledPipe != null)
            {
                if (controlledPipe.gameObject.activeInHierarchy)
                {
                    StartCoroutine(ChangePipe(controlledPipe));
                } 
                else
                {
                    controlledPipe.gameObject.SetActive(true);
                    anim.SetTrigger("deactivated");
                }
            }
        }
    }

    private IEnumerator ChangePipe(Transform controlledPipe)
    {
        anim.SetTrigger("activated");

        yield return new WaitForSeconds(2f);
        controlledPipe.gameObject.SetActive(false);
    
        yield return null;
    }
}
