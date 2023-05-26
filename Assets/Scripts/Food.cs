using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] BoxCollider2D gridArea;

    void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("OnTriggerEnter2D " + other.tag);

        if (other.tag == "Player")
        {
            RandomizePosition();
            // Debug.Log("RandomizePosition " + transform.position);

        }
    }
}
