using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;

    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);

    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;
    bool hasPackage;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("bump");

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "packages"&& !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if(other.tag == "customer"&& hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage= false;
            spriteRenderer.color = noPackageColor;
            

        }
    }
}
