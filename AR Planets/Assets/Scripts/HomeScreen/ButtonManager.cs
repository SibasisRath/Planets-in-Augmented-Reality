using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private PlanetsEnum planet;

    private void Start()
    {
        button.onClick.AddListener (() => OnThisPlanetButtonPressed());
    }

    private void OnThisPlanetButtonPressed()
    {
        PlanetSelectionScript.Instance.SelectedPlanet = planet;
        SceneManager.LoadScene(1);
    }
}
