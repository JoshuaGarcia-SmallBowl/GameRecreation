using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponsorship : MonoBehaviour
{
    private BoxCollider2D hitbox;
    private float funnylength;
    public float spawnmin;
    public float spawnmax;
    public float spawny;
    private int speedchange;
    
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        funnylength = hitbox.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            GameControlScript.instance.Sponsor();
            spawny = Random.Range(spawnmin, spawnmax);
            Vector2 groundOffset = new Vector2(funnylength * 12f, spawny);
            float spawnYPosition = Random.Range(spawnmin, spawnmax);
            transform.position = (Vector2)groundOffset;
            speedchange++;

        }
    }
}
