using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] int levelTime = 10;
    bool triggerFinish = false;

    public int LevelTime { get => levelTime; set => levelTime = value; }

    // Update is called once per frame
    void Update()
    {   
        if (triggerFinish) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelTime;

        if (Time.timeSinceLevelLoad > LevelTime)
        {
            FindObjectOfType<LevelController>().LevelFinished();
            triggerFinish = true;
        }
    }
}
