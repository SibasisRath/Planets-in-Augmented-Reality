using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TestTextManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text.text = PlanetSelectionScript.Instance.SelectedPlanet.ToString();
    }

}
