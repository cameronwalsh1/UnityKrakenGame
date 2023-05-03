using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScreenFlash : MonoBehaviour
{
    [SerializeField] ScreenFlashImage _flashImage = null;
    [SerializeField] Color _newColor = Color.red;
    [SerializeField] float _timeLength = 1;
    [SerializeField] float _opacity = .5f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _flashImage.BeginFlash(_timeLength, _opacity, _newColor);
        }
    }
}
