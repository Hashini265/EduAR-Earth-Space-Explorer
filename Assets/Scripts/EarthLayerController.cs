using UnityEngine;

public class EarthLayerController : MonoBehaviour
{
    public GameObject crust;
    public GameObject mantle;
    public GameObject outerCore;
    public GameObject innerCore;

    public void ShowCrust()
    {
        ShowLayer(crust);
    }

    public void ShowMantle()
    {
        ShowLayer(mantle);
    }

    public void ShowOuterCore()
    {
        ShowLayer(outerCore);
    }

    public void ShowInnerCore()
    {
        ShowLayer(innerCore);
    }

    public void ShowAllLayers()
    {
        crust.SetActive(true);
        mantle.SetActive(true);
        outerCore.SetActive(true);
        innerCore.SetActive(true);
    }

    private void ShowLayer(GameObject selectedLayer)
    {
        crust.SetActive(selectedLayer == crust);
        mantle.SetActive(selectedLayer == mantle);
        outerCore.SetActive(selectedLayer == outerCore);
        innerCore.SetActive(selectedLayer == innerCore);
    }
}