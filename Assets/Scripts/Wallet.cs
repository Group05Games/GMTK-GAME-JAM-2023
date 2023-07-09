using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet {
    private int score;

    public Wallet(int score) {
        this.score = score;
	}

    public int getScore() {
        return this.score;
	}
    public void setScore(int score) {
        this.score = score;
	}
    public void addScore(int score) {
        this.score += score;
	}
    public void subtractScore(int score) {
        this.score -= score;
	}
}
