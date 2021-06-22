using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloor : MonoBehaviour
{
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float time = 0;
    int count = 0;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 5)
        {
            time = 0;
            count++;
            Instantiate(floor, new Vector2(200 * count, -0.415f), Quaternion.identity);
        }
    }
}
