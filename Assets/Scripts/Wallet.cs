using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Wallet {
    private int score;

    public Wallet(int score) {
        this.score = score;
	}
    public Wallet() {
        this.score = 0;
	}

    public int getScore() {
        return this.score;
	}
    public void setScore(int score) {
        this.score = score;
	}
    public void addScore(int score) {
        this.score += score;
        Debug.Log("Added " + score + " points");
	}
    public void subtractScore(int score) {
        this.score -= score;
	}
}
