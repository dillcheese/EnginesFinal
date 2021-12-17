using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;

public class UseDLLLvies : MonoBehaviour
{
    [DllImport("ExamDLL")]
    private static extern int GetLives();

  

    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Player>().lives = GetLives();

    }

}
