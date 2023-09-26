using UnityEngine;
using TMPro;

public class CollectCoinsUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;

    private void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        coinText.text = playerInventory.NumberOfCoins.ToString();
    }
}
