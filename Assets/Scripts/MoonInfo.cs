using UnityEngine;

public class MoonInfo : MonoBehaviour
{
    public string GetInfo()
    {
        return "MOON\n\n" +
               "Distance from Earth: 384,400 km\n\n" +
               "Diameter: 3,474 km\n\n" +
               "Interesting Fact:\n" +
               "The Moon takes about 27.3 days to orbit Earth.";
    }
}
