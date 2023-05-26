using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> segments;
    [SerializeField] Transform segmentPrefab;
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        this.transform.position = new Vector3(
                            Mathf.Round(this.transform.position.x) + direction.x,
                            Mathf.Round(this.transform.position.y) + direction.y,
                            0);
    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
    }
}
