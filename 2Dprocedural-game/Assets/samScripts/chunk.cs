using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunk : MonoBehaviour
{

    public List<GameObject> myObjects;
    private Vector2 chunkSize;
    private Vector2 topLeftCorner;
    private Vector2 bottomRightCorner;
    private Collider2D[] myColls;
    public LayerMask set_layerMask;
    public static LayerMask layerMask;
    // Start is called before the first frame update
    void Start ()
    {
        layerMask = set_layerMask;

        chunkSize = new Vector2(mapGenerator.chunkSize,backgroundMovement.repeatHeight);

        topLeftCorner = new Vector2(transform.position.x - (chunkSize.x / 2), transform.position.y + (chunkSize.y / 2));
        bottomRightCorner = new Vector2(transform.position.x + (chunkSize.x / 2), transform.position.y - (chunkSize.y / 2));
        myObjects = new List<GameObject>();
        myColls = Physics2D.OverlapAreaAll(bottomRightCorner, topLeftCorner);

        foreach (Collider2D coll in myColls)
        {

            GameObject obj = coll.gameObject;
            if(obj != gameObject && obj.tag == "mapObjects")
            {
                obj.transform.SetParent(gameObject.transform);
                myObjects.Add(obj);
            }


        }

        gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
