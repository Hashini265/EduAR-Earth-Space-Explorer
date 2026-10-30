using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using TMPro;

public class ARObjectPlacement : MonoBehaviour
{
    public GameObject earthPrefab;
    public GameObject earthInfoPanel;
    public TextMeshProUGUI earthInfoText;

    private ARRaycastManager raycastManager;
    private GameObject placedEarth;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        earthInfoPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount == 0 ||
            Input.GetTouch(0).phase != TouchPhase.Began)
            return;

        Vector2 touchPosition = Input.GetTouch(0).position;

        Ray ray = Camera.main.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out RaycastHit objectHit))
        {
            EarthInfo info = objectHit.collider.GetComponentInParent<EarthInfo>();

            if (info != null)
            {
                earthInfoText.text = info.GetInfo();
                earthInfoPanel.SetActive(true);
                return;
            }
        }

        if (raycastManager.Raycast(
            touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (placedEarth == null)
            {
                placedEarth = Instantiate(
                    earthPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                placedEarth.transform.position = hitPose.position;
                placedEarth.transform.rotation = hitPose.rotation;
            }

            earthInfoPanel.SetActive(false);
        }
    }
}