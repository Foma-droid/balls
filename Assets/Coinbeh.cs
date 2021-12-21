using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coinbeh : MonoBehaviour
{
    public TMP_Text scoretext;
    public float score;
    public float hp = 2;
    private spawner _spawner;
    public float damage = 1;
    public TMP_Text hptext;
    private int pole;
    private float lastTimeHit;
    public GameObject coin;
    
    // Start is called before the first frame update
    void Start()
    {
        
        hptext.text = hp.ToString();
        
    }

    IEnumerator Dochek()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(coin.gameObject);
        
    }
    public void setspawner(spawner s)
    {
        _spawner = s;
        
    }
    public void MinusHp()
    {
        
        var currentTime = Time.realtimeSinceStartup;
        if(lastTimeHit == 0 || (currentTime - lastTimeHit > 0.2f))
        {
            hp--;
            lastTimeHit = currentTime;
        }
        if (hp == 0)
        {
            _spawner.Remover(this);
            StartCoroutine(Dochek());
        }
        hptext.text = hp.ToString();
       
    }
    // Update is called once per frame
    void Update()
    {
        
        hptext.text = hp.ToString(); 
    }
}
