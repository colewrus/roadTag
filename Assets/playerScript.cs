using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class playerScript : MonoBehaviour {

    public List<Sprite> frames = new List<Sprite>();
    public float playerSpeed;
    public float playerFast;

    public float playerSlow;

    public GameObject bkg;
    private Renderer rend;
    public float scrollSpeed;
    public GameObject sideScroll;

	// Use this for initialization
	void Start () {
        rend = bkg.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                GetComponent<SpriteRenderer>().sprite = frames[2];

                //scroll the background
                float y = Mathf.Repeat(Time.time * scrollSpeed, 1);              
                rend.material.SetTextureOffset("_MainTex", new Vector2(y,0));
                this.transform.Translate(Vector3.right * (playerSpeed * Time.deltaTime));
            }

            if(Input.GetAxis("Horizontal") < 0)
            {
                GetComponent<SpriteRenderer>().sprite = frames[1];
                //scroll the background
                float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
                rend.material.SetTextureOffset("_MainTex", new Vector2(-y, 0));
                this.transform.Translate(-Vector3.right * (playerSpeed * Time.deltaTime));
                          

            }
        }else
        {
            GetComponent<SpriteRenderer>().sprite = frames[0];
        }

	}

    void OnTriggerExit2D(Collider2D other)
    {
        playerSpeed = playerSlow;
        //change the scrollspeed
        sideScroll.GetComponent<roadScroll>().scrollSpeed = -0.1f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerSpeed = playerFast;
        sideScroll.GetComponent<roadScroll>().scrollSpeed = -0.25f;
    }
}
