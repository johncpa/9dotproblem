using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

    public void fade(Image fadeImage, Color fadeToColor, float fadeTime, UnityAction postMethod)
    {
        StartCoroutine(fadeCoro(fadeImage, fadeToColor, fadeTime, postMethod));
    }

    IEnumerator fadeCoro(Image fadeImage, Color fadeToColor, float fadeTime, UnityAction postMethod)
    {
        for (float i = 0; i < fadeTime; i += Time.deltaTime)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, fadeToColor, fadeTime * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        postMethod();
    }
}
