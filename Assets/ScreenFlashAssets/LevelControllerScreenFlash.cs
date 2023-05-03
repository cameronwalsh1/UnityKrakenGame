using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScreenFlash : MonoBehaviour
{
    [Header("Chosen Flash")]
    [SerializeField] ScreenFlashImage _flashImage = null;
    [Header("Assign Button To Activate Flash")]
    [SerializeField] string key = "space";
    [Header("Flash Variables")]
    [SerializeField] Color _newColor = Color.red;
    [SerializeField] float _timeLength = 1f;
    [SerializeField] float _opacity = .5f;

    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            _flashImage.BeginFlash(_timeLength, _opacity, _newColor);
        }
    }
}
