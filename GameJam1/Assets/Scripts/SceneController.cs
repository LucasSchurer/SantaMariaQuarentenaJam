using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator sceneChanger;

    void Start()
    {
        //
        StartCoroutine(FadeIn(1f));
    }

    private IEnumerator FadeIn(float time)
    {
        sceneChanger.SetTrigger("fadeIn");

        yield return new WaitForSeconds(time);

        sceneChanger.gameObject.SetActive(false);
    }

    private IEnumerator FadeOut(float time, string scene)
    {
        sceneChanger.gameObject.SetActive(true);

        sceneChanger.SetTrigger("fadeOut");

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeOut(float time, int scene)
    {
        sceneChanger.gameObject.SetActive(true);

        sceneChanger.SetTrigger("fadeOut");

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(scene);
    }

    public void Restart()
    {
        StartCoroutine(FadeOut(1f, SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(FadeOut(1f, scene));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
