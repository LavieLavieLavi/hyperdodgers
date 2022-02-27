using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordTime : MonoBehaviour
{
    public Text HSText;

    // Start is called before the first frame update
    void Start()
    {
        HSText.text = "H I G H S C O R E: " +  PlayerPrefs.GetFloat("Highscore");
    }

}
  