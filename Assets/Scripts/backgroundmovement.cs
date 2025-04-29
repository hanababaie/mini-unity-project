using UnityEngine;

public class backgroundmovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>(); //getting access to the sprite render
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * speed; //gives us an numeber
        rend.material.SetTextureOffset("_MainTex", new Vector2(0,offset)); //it moves vertically for horizentally we can write vector2(offset,0)
        //here we fill the plane with this texture.
        
    }
}
