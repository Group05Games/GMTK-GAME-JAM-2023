using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletManager : MonoBehaviour
{
    int holder = 0;
    public TMP_Text ScoreText;
    public bool PorE;

    // Start is called before the first frame update
    Wallet wallet;
    void Start()
    {
        if (PorE == false)
        {
            wallet = new Wallet();
            Debug.Log("Hello from wallet " + wallet.getScore());
        }
        else if (PorE == true)
        {
            wallet = new Wallet(100);
            Debug.Log("Hello from wallet " + wallet.getScore());
        }
    }

    private void Update()
    {
        holder = wallet.getScore();
        ScoreText.text = holder.ToString();
    }

    //Wrapper Methods

    public int getScore() {
        return wallet.getScore();
	}
    public void setScore(int score) {
        wallet.setScore(score);
    }
    public void addScore(int score) {
        wallet.addScore(score);
	}
    public void subtractScore(int score) {
        wallet.subtractScore(score);
	}
}
