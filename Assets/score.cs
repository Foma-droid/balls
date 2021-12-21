using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class score : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public Coinbeh coin;
    public float sCore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
       
    }
public void pScore()
{
   
}
    // Update is called once per frame
    void Update()
    {
        var hits = Physics2D.CircleCastAll(transform.position, 0.5f, Vector2.zero);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("Coin"))
            {
                
               

            }

            
        }
    }
}
