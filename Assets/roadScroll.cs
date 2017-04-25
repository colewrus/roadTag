using UnityEngine;
using System.Collections;

public class roadScroll : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    public Renderer rend;
    public float maxOffset;
   
	// Use this for initialization
	void Start () {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float y = Mathf.Repeat(Time.time * scrollSpeed, maxOffset);
        /*
          Vector2 offset = new Vector2(Time.time*scrollSpeed, 0);
          rend.material.SetTextureOffset("_MainTex", offset);
          print(y);
          */
       // float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, y));
        

    }
}
