using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_end : MonoBehaviour
{
    public void OnClickStartButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
