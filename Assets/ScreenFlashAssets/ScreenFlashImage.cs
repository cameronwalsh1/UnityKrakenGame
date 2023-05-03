using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScreenFlashImage : MonoBehaviour
{
    Image _image = null;
    Coroutine _activeFlashRoutine = null;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void BeginFlash(float flashTimeLength, float maxOpacity, Color newColor)
    {
        _image.color = newColor;

        maxOpacity = Mathf.Clamp(maxOpacity, 0, 1);

        if(_activeFlashRoutine != null)
            StopCoroutine(_activeFlashRoutine);
            _activeFlashRoutine = StartCoroutine(Flash(flashTimeLength, maxOpacity));
        
    }

    IEnumerator Flash(float flashTimeLength, float maxOpacity)
    {
        float flashAppearTimeLength = flashTimeLength / 2;
        for (float t = 0; t <= flashAppearTimeLength; t += Time.deltaTime)
        {
            Color currentColor = _image.color;
            currentColor.a = Mathf.Lerp(0, maxOpacity, t / flashAppearTimeLength);
            _image.color = currentColor;
            yield return null;
        }

        float flashFadeTimeLength = flashTimeLength / 2;
        for (float t = 0; t <= flashFadeTimeLength; t += Time.deltaTime)
        {
            Color currentColor = _image.color;
            currentColor.a = Mathf.Lerp(maxOpacity, 0, t / flashFadeTimeLength);
            _image.color = currentColor;
            yield return null;
        }

        _image.color = new Color32(0, 0, 0, 0);
    }
}
