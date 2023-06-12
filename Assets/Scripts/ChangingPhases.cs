using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangingPhases : MonoBehaviour
{
    public GameObject fadeOutObject;
    public GameObject fadeInObject;
    public float fadeDuration = 1f;
    public AnimationCurve fadeCurve;

    public void FadeOutFadeIn()
    {
        StartCoroutine(FadeOutFadeInCoroutine());
    }

    private IEnumerator FadeOutFadeInCoroutine()
    {
        MeshRenderer fadeOutRenderer = fadeOutObject.GetComponent<MeshRenderer>();
        MeshRenderer fadeInRenderer = fadeInObject.GetComponent<MeshRenderer>();

        Material fadeOutMaterial = fadeOutRenderer.material;
        Material fadeInMaterial = fadeInRenderer.material;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            float normalizedTime = timer / fadeDuration;
            float fadeAmount = fadeCurve.Evaluate(normalizedTime);

            Color fadeOutColor = fadeOutMaterial.color;
            fadeOutColor.a = 1f - fadeAmount;
            fadeOutMaterial.color = fadeOutColor;

            Color fadeInColor = fadeInMaterial.color;
            fadeInColor.a = fadeAmount;
            fadeInMaterial.color = fadeInColor;

            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure the final state is reached
        Color finalFadeOutColor = fadeOutMaterial.color;
        finalFadeOutColor.a = 0f;
        fadeOutMaterial.color = finalFadeOutColor;

        Color finalFadeInColor = fadeInMaterial.color;
        finalFadeInColor.a = 1f;
        fadeInMaterial.color = finalFadeInColor;
    }
}

