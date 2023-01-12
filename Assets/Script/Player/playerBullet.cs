using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    public GameObject hitEffect;

    private strengthBar strength;

    void Start()
    {
        strength = FindObjectOfType<strengthBar>();
    }
    void OnCollisionEnter2D ( Collision2D collision )
    {
        strength.StrengthGain();

        GameObject effect = Instantiate ( hitEffect, transform.position, Quaternion.identity );
        Destroy( effect, 1f );
        Destroy(gameObject);
   
    }
}
