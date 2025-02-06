using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<GameObject> segments;
    public GameObject segment;
    // Start is called before the first frame update
    void Start()
    {
        segments.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        print(segments[0].name);
    }
}
