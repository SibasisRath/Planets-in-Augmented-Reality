using UnityEngine;

public class PlanetSelectionScript : MonoBehaviour
{
    private static PlanetSelectionScript instance;

    private PlanetsEnum selectedPlanet;

    public static PlanetSelectionScript Instance { get => instance; private set => instance = value;}
    public PlanetsEnum SelectedPlanet { get => selectedPlanet; set => selectedPlanet = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;  
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}