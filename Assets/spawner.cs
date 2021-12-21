using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spawner : MonoBehaviour
{
   private Rigidbody2D rb;
    public Vector2 spawnBall = new Vector2(-0.05f, y: 9f);
    private Transform currentBall;
    public Chromebeh chromeprefab;
    public Coinbeh coin;
    public List<Vector2> coinSpawns = new List<Vector2>();
    private bool isKinematic;
    List<Transform> coinList = new List<Transform>();
    private bool canshoot = true;
    public Vector2 worldscreen;
    public TMP_Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewBall();
        DoSpawn();
         
    }

    List<GameObject> goListcoins = new List<GameObject>();

    private void SpawnNewBall()
    {
        currentBall = Instantiate(chromeprefab.transform, spawnBall, Quaternion.identity); // спавним новый шар
        Chromebeh nashball = currentBall.GetComponent<Chromebeh>();
        nashball.Kinematic();
        canshoot = true;
        nashball.peredachatexta(scoretext);
    }

    public void Remover(Coinbeh c)
    {
        coinList.Remove(c.transform);
    }
    public void DoSpawn()
    {
        
        int lastIndex = coinSpawns.Count - 1;
        int randomIndex = Random.Range(0, lastIndex);
       var currentcoin =  Instantiate(coin.gameObject, coinSpawns[randomIndex], Quaternion.identity);
        coinList.Add(currentcoin.transform);
        currentcoin.GetComponent<Coinbeh>().setspawner(this);

    }

    private void MoveCoins()
    {
        foreach (var coin2 in coinList) // Проходимся по нашему листу монет
        {
            float deltaPos = 1f; // насколько подымать вверх будем монеты
            coin2.transform.position = new Vector2(coin2.transform.position.x, coin2.transform.position.y + deltaPos);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canshoot)
        {
            currentBall.GetComponent<Chromebeh>().Dynamic();
            canshoot = false;
        }
        if (currentBall != null) // сразу избавляем себя от лишней ошибки
        {
             
            if (currentBall.transform.position.y < - 9f) // Если наш текущий шар упадет слишком низко, значит можем считать его потраченным
            {
                Destroy(currentBall.gameObject); //Уничтожаем его
                currentBall = null;
                MoveCoins(); // Перемещаем монеты, если они живы
                DoSpawn(); // После этого спавним новую монету
                SpawnNewBall(); // И теперь спавним новый шар
                
            }
             
        }
        
    }
}
