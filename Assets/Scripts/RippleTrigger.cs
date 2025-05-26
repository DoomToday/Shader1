using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleTrigger : MonoBehaviour
{
    [SerializeField] private Color standardColor = Color.gray;
    [SerializeField] private Color collectibleColor = Color.yellow;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Standard")
        {
            Vector3 hit = other.contacts[0].point;
            StartCoroutine(StartRipple(hit,standardColor,other.gameObject.GetComponent<Material>().color, other.gameObject.GetComponent<Material>()));
        }
        else if (other.collider.tag == "Collectible")
        {
            Vector3 hit = other.contacts[0].point;
            StartCoroutine(StartRipple(hit,collectibleColor,other.gameObject.GetComponent<Material>().color, other.gameObject.GetComponent<Material>()));
        }
    }

    private IEnumerator StartRipple(Vector3 center, Color rippleColor, Color previousColor, Material material)
    {
        material.SetVector("_RippleCenter", center);

        material.SetFloat("_RippleStartTime", Time.time);
        material.SetColor("_BaseColor", previousColor);
        material.SetColor("_RippleColor", rippleColor);
        yield return new WaitForSeconds(5);
        
        material.SetVector("_RippleCenter", center);

        material.SetFloat("_RippleStartTime", Time.time);
        material.SetColor("_BaseColor", rippleColor);
        material.SetColor("_RippleColor", previousColor);
    }
}
