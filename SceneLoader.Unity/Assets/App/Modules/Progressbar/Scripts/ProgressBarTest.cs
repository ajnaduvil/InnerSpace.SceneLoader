using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Innerspace.TestApp.UI;
public class ProgressBarTest : MonoBehaviour
{
    public Progressbar progressbar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProgressBarChangeTest());
    }  
    IEnumerator ProgressBarChangeTest()
    {
        while (true)
        {
            progressbar.Progress = Mathf.PingPong(Time.time, 1);
            yield return null;
        }
    }
}
