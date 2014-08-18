using UnityEngine;
using System.Collections;

public class Opacity : MonoBehaviour {
  public float opacity = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    SpriteRenderer r = GetComponent<SpriteRenderer>();
    Color color = r.color;
    color.a = opacity;
    r.color = color;
	}
}
