using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIINtUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextValue.text = "x" + soInt.value.ToString();
    }
}
