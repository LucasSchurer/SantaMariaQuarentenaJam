using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public Transform controlledPipe;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangePipeState()
    {
        if (controlledPipe != null)
        {
            if (controlledPipe.gameObject.activeInHierarchy)
            {
                StartCoroutine(ChangePipe());
            } 
            else
            {
                controlledPipe.gameObject.SetActive(true);
                anim.SetTrigger("deactivated");
            }
        }
    }

    private IEnumerator ChangePipe()
    {
        anim.SetTrigger("activated");

        yield return new WaitForSeconds(2f);
        controlledPipe.gameObject.SetActive(false);

        yield return null;
    }
}
