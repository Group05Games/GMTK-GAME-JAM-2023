public class Bullet {

	private float speed;
	private string owner;

	public Bullet(float speed, string owner) {
		this.speed = speed;
		this.owner = owner;
	}

	public float getSpeed() {
		return this.speed;
	}
	public void setSpeed(float speed) {
		this.speed = speed;
	}

	public string getOwner() {
		return this.owner;
	}
	public void setOwner(string owner) {
		this.owner = owner;
	}
}
