using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    private float length;
    private float startXpos;

    public GameObject cam;
    public float parallaxEffect;
    
    // Start is called before the first frame update
    void Start() {
        startXpos = transform.position.x;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update() {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startXpos + dist, transform.position.y, transform.position.z);
        if (temp > startXpos + length) startXpos += length;
        else if (temp < startXpos - length) startXpos -= length;
    }
}
