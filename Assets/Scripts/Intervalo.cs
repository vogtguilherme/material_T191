using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intervalo : MonoBehaviour
{
    public Text intervaloText;

    public void SetText()
    {
        intervaloText.enabled = true;
        intervaloText.text = "INTERVALO???";
    }
}
