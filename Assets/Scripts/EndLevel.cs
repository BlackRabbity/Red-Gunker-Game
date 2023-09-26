using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject CompleteLvlUi;
    public GameObject GameUi;
    public TextMeshProUGUI PlayerCoin;
    public TextMeshProUGUI PlayerTime;
    public TextMeshProUGUI ShowPlayerCoin;
    public TextMeshProUGUI ShowPlayerTime;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
            ShowPlayerCoin.text = PlayerCoin.text;
            ShowPlayerTime.text = PlayerTime.text;
            GameUi.SetActive(false);
            CompleteLvlUi.SetActive(true);
        }
    }
}
