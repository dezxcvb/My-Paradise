using System.Collections;
using UnityEngine;
using TMPro;

public class FadeInOut : MonoBehaviour
{
    public TMP_Text tmpText;
    private CanvasGroup cg;
    public float fadeTime = 3f;
    float aTime = 0f;
    private Coroutine fadeCoroutine;
    
    void Start()
    {
        Invoke("ChangeText1", 3f);
        StartFadeOut();
    }

    void ChangeText1()
    {
        tmpText.text = "Three keys must be found to become human again!";
        Invoke("ChangeText2", 3f);
    }

    void ChangeText2()
    {
        tmpText.text = "3 Keys Left";
        Invoke("ChangeText3", 3f);
    }
    
    void ChangeText3()
    {
        tmpText.text = "Good luck!";
        Invoke("DestroyObjects", 3f);
    }

    void DestroyObjects()
    {
        Destroy(tmpText.gameObject);
        Destroy(gameObject);
    }

    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        if (fadeCoroutine != null)
        {
            StopAllCoroutines();
            fadeCoroutine = null;
        }
        fadeCoroutine = StartCoroutine(FadeIn());

    }

    public void StartFadeOut()
    {
        if (fadeCoroutine != null)
        {
            StopAllCoroutines();
            fadeCoroutine = null;
        }
        fadeCoroutine = StartCoroutine(FadeOut());

    }

    private IEnumerator FadeIn()
    {
        aTime = 0f;
        while (aTime < fadeTime)
        {
            cg.alpha = Mathf.Lerp(0f, 1f, aTime / fadeTime);
            yield return null;
            aTime += Time.deltaTime;
        }
        cg.alpha = 1f;
    }
    
    private IEnumerator FadeOut()
    {
        aTime = 0f;
        while (aTime < fadeTime)
        {
            cg.alpha = Mathf.Lerp(1f, 0f, aTime / fadeTime);
            yield return null;
            aTime += Time.deltaTime;
        }
        cg.alpha = 0f;
    }
}