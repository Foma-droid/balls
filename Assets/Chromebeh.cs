using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chromebeh : MonoBehaviour
{
    // Start is called before the first frame update
    private Input m_PlayerInput;
    public Chromebeh Chrome;
    public Vector2 worldscreen; 
    private bool isk = true;
    private Rigidbody2D rb;
    public bool canshoot = true;
    private TMP_Text scoretext;
    public static float _score;

    private float lastTimeHit = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        
    }

    public void Dynamic()
    { 
        Vector2 mousePosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 actscreen = new Vector2(mousePosition.x - Chrome.transform.position.x, mousePosition.y - Chrome.transform.position.y);
        rb.simulated = true;
        rb.AddForce(actscreen*2200f);
           
    }

    
    public void peredachatexta(TMP_Text t)
    {
        scoretext = t;
        var hits = Physics2D.CircleCastAll(transform.position, 0.5f, Vector2.zero);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("Coin"))
            {
                
                var currentTime = Time.realtimeSinceStartup;
                if(lastTimeHit == 0 || (currentTime - lastTimeHit > 0.2f))
                {
                    _score++;
                    lastTimeHit = currentTime;
                }
                
                scoretext.text = _score.ToString();
            }
        }
    }
    public void Kinematic()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }
    // Update is called once per frame
    void Update()
    {
        var hits = Physics2D.CircleCastAll(transform.position, 0.5f, Vector2.zero);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("Coin"))
            {
                var detectedCoin = hits[i];
                detectedCoin.transform.GetComponent<Coinbeh>().MinusHp();
                var currentTime = Time.realtimeSinceStartup;
                if(lastTimeHit == 0 || (currentTime - lastTimeHit > 0.2f))
                {
                    _score++;
                    lastTimeHit = currentTime;
                }
                
                scoretext.text = _score.ToString();
            }
        }
        
    }
    
}
