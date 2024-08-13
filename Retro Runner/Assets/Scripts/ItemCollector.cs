using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text AppleCount;
    [SerializeField] private AudioSource Itemcollectioneffect;
    private int Apples = 0; 

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Itemcollectioneffect.Play();
            Destroy(collision.gameObject);
            Apples++;
            AppleCount.text = "Apples:" + Apples;
        }           
    }
}
