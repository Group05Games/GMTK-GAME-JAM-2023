using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    // Start is called before the first frame update
    Wallet wallet;
    void Start()
    {
        wallet = new Wallet();
        Debug.Log("Hello from wallet " +  wallet.getScore());
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
