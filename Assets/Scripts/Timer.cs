
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    private float startTimer;
    void Start()
    {
        startTimer = Time.time;
    }
    void Update()
    {
        float temp = Time.time - startTimer;
        string sec = (temp % 60).ToString("f0");
        string min = ((int) temp / 60).ToString();

        TimeText.text = min + ":" + sec + ":" + (Time.time/60).ToString("f3").Remove(0,4);
    }
}
