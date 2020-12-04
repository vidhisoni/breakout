using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 _screenBounds;
    private float _boundaryThickness = 0.1f;

    public PhysicMaterial physicsMaterial;

    // Start is called before the first frame update
    void Start()
    {
        System.Collections.Generic.Dictionary<string, Transform> colliders = new System.Collections.Generic.Dictionary<string, Transform>();
        colliders.Add("Top", new GameObject().transform);
        //colliders.Add("Bottom", new GameObject().transform);
        colliders.Add("Right", new GameObject().transform);
        colliders.Add("Left", new GameObject().transform);

        Vector3 cameraPos = Camera.main.transform.position;

        _screenBounds.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        _screenBounds.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        foreach (KeyValuePair<string, Transform> valPair in colliders)
        {
            valPair.Value.gameObject.AddComponent<BoxCollider>();
            valPair.Value.name = valPair.Key + "Collider";
            valPair.Value.parent = transform;
            if(valPair.Key == "Left" || valPair.Key == "Right")
            {
                valPair.Value.localScale = new Vector3(_boundaryThickness, _screenBounds.y * 2, _boundaryThickness);
            }
            else
            {
                valPair.Value.localScale = new Vector3(_screenBounds.x * 2, _boundaryThickness, _boundaryThickness);
            }

            if (physicsMaterial)
            {
                valPair.Value.gameObject.GetComponent<BoxCollider>().sharedMaterial = physicsMaterial;
            }
        }
        colliders["Right"].position = new Vector3(cameraPos.x + _screenBounds.x + (colliders["Right"].localScale.x * 0.5f), cameraPos.y, 0);
        colliders["Left"].position = new Vector3(cameraPos.x - _screenBounds.x - (colliders["Left"].localScale.x * 0.5f), cameraPos.y, 0);
        colliders["Top"].position = new Vector3(cameraPos.x, cameraPos.y + _screenBounds.y + (colliders["Top"].localScale.y * 0.5f), 0);
        //colliders["Bottom"].position = new Vector3(cameraPos.x, cameraPos.y - _mScreenBounds.y - (colliders["Bottom"].localScale.y * 0.5f), 0);
    }
}