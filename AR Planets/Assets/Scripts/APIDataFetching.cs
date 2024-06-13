using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class APIDataFetching : MonoBehaviour
{
    private string url = "https://666b34457013419182d2a3d8.mockapi.io/planets/all";
    [SerializeField] private TextMeshProUGUI details;

    private void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                string json = request.downloadHandler.text;

                // Handle JSON array
                string fixedJson = "{ \"planets\": " + json + "}";
                PlanetDataList planetDataList = JsonUtility.FromJson<PlanetDataList>(fixedJson);

                // Display data
                DisplayPlanetData(planetDataList.planets);
            }
        }
    }

    void DisplayPlanetData(PlanetData[] data)
    {
        string displayText = "";

        foreach (PlanetData planet in data)
        {
            if (planet.name != PlanetSelectionScript.Instance.SelectedPlanet.ToString())
            {
                continue;
            }
            displayText += $"Name: {planet.name}\n";
            displayText += $"Mass: {planet.mass} Earth Masses\n";
            displayText += $"Age: {planet.age} million years\n";
            displayText += $"Has Moon: {(planet.hasMoon ? "Yes" : "No")}\n";

            if (planet.hasMoon && planet.moons != null && planet.moons.Length > 0)
            {
                displayText += "Moons: ";
                foreach (string moon in planet.moons)
                {
                    displayText += $"{moon}, ";
                }
                displayText = displayText.TrimEnd(',', ' ') + "\n"; // Remove last comma
            }

            displayText += "\n";
        }

        details.text = displayText;
    }

    [System.Serializable]
    private class PlanetDataList
    {
        public PlanetData[] planets;
    }
}
