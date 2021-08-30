using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody Player;
    public float Speed = 20;
    private int Score;
    public Text score;
    public GameObject YouWin;
    void Start()
    {
        Player = GetComponent<Rigidbody>();
        Score = 0;
        YouWin.SetActive(false);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        Player.AddForce(movement*Speed);
        score.text = "Score : " + Score;
        if(Score>=12)
        {
            YouWin.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            Score += 1;
        }
    }
}
