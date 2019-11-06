using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	public Renderer background;
	private SpaceshipAnimation animations;

	public float speed;
	public float extraLimiter;

	public GameObject bullet;
	public GameObject[] cannons;

	private float screenLimiterX;
	private float screenLimiterY;
	private float playerSpaceshipHalfWidth;
	private float playerSpaceshipHalfHeight;

	protected bool destroyed;

	private PolygonCollider2D getCollider(){
		return this.GetComponent<PolygonCollider2D> ();
	}

	protected void spaceshipCreated(SpaceshipAnimation animations){
		screenLimiterX = background.transform.localScale.x / 2;
		screenLimiterY = background.transform.localScale.y / 2;
		playerSpaceshipHalfWidth = getCollider().bounds.size.x / 2;
		playerSpaceshipHalfHeight = getCollider().bounds.size.y / 2;
		this.animations = animations;
		destroyed = false;
	}

	private void moveHorizontal(float m, bool blockRight, bool blockLeft){

		float move = m * Time.deltaTime * speed;

		if (getLeftPosition () + move < -screenLimiterX && blockLeft) {
			move = -screenLimiterX - getLeftPosition ();
		}

		if (getRightPosition () + move > screenLimiterX && blockRight) {
			move = screenLimiterX - getRightPosition ();
		}

		transform.Translate (new Vector2 (move, 0));

	}

	private void moveVertical(float m, bool blockUp, bool blockDown){

		float move = m * Time.deltaTime * speed;

		if(getDownPosition() + move < -screenLimiterY && blockDown){
			move = -screenLimiterY - getDownPosition ();
		}

		if (getUpPosition () + move > screenLimiterY && blockUp) {
			move = screenLimiterY - getUpPosition ();
		}

		transform.Translate(new Vector2(0, move));
	}

	//Real Position

	private float getLeftPosition(){
		return getCollider().bounds.center.x - playerSpaceshipHalfWidth - extraLimiter;
	}

	private float getRightPosition(){
		return getCollider().bounds.center.x + playerSpaceshipHalfWidth + extraLimiter;
	}

	private float getUpPosition(){
		return getCollider().bounds.center.y + playerSpaceshipHalfHeight + extraLimiter;
	}

	private float getDownPosition(){
		return getCollider().bounds.center.y - playerSpaceshipHalfHeight - extraLimiter;
	}

	protected void move(float vertical, float horizontal, bool[] blockPass = null){
		if(blockPass == null){
			blockPass = new bool[]{ true, true, true, true };
		}
		/*
		 * blockPass
		 * [0] = UP
		 * [1] = RIGHT
		 * [2] = DOWN
		 * [3] = LEFT
		 * Like clock direction
		 */ 
		moveVertical(vertical, blockPass[0], blockPass[2]);
		moveHorizontal (horizontal, blockPass[1], blockPass[3]);
	}

	protected void fire(){
		foreach(GameObject cannon in cannons)
			Instantiate (bullet, new Vector3 (cannon.transform.position.x, cannon.transform.position.y, cannon.transform.position.z), Quaternion.identity);
	}

	public void explode(){
		animations.animator.SetBool ("Destroyed", true);
		Destroy (this.gameObject, animations.ExplosionLength);
		destroyed = true;
	}

	protected class SpaceshipAnimation{

		public SpaceshipAnimation(Animator animator, string explosionAnimName){
			this.animator = animator;
			this.explosionLength = getAnimationLength(explosionAnimName);
		}

		public Animator animator;

		private float explosionLength;
		public float ExplosionLength { 
			get {
				return explosionLength;
			}
			private set{ 
				this.explosionLength = value;
			}
		}

		private float getAnimationLength(string name){
			RuntimeAnimatorController ac = animator.runtimeAnimatorController; 
			for(int i =0;i < ac.animationClips.Length; i++){
				if (ac.animationClips [i].name == name) {
					return ac.animationClips [i].length;
				}
			}
			return 0;
		}
	}
}
