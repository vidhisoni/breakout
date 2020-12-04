using UnityEngine;

public class Brick : MonoBehaviour
{
    private int _hits = 1;
    //[SerializeField] private int _mScore = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        --_hits;
        if(_hits <= 0)
        {
            Destroy(gameObject);
        }
    }
}
