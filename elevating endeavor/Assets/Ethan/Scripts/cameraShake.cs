using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class cameraShake : MonoBehaviour
{
    public Color damageColor;
    public Color healColor;
    private IEnumerator Shake(float duration, float magnitude)
    {
        Vector2 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-0.07f, 0.07f) * magnitude;
            float y = Random.Range(-0.07f, 0.07f) * magnitude;

            transform.localPosition = new Vector2(x, y);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;

    }
    private IEnumerator ChangeVignette()
    {
        if (GetComponent<Volume>().profile.TryGet(out Vignette redTint))
        {
            redTint.color.Override(damageColor);
            yield return new WaitForSeconds(0.2f);
            redTint.color.Override(healColor);
        }
    }

    public void takeDamage(float duration, float magnitude)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeVignette());
        StartCoroutine(Shake(duration, magnitude));
    }
}
