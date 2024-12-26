using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    public void SetBulletsCount(int count)
    {
        _counterText.text = count.ToString();
    }
}
