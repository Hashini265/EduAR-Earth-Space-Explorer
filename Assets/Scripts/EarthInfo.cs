using UnityEngine;

public class EarthInfo : MonoBehaviour
{
    public string GetInfo()
    {
        return "EARTH\n\n" +
               "Distance from Sun: 149.6 million km\n\n" +
               "Diameter: 12,742 km\n\n" +
               "Interesting Fact:\n" +
               "Earth is the only known planet with liquid water on its surface.";
    }
}