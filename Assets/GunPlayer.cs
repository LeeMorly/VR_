using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour {
	private bool sfx = false;
	private bool afx = false;
	private bool bfx = false;
	private int  Rcnt = 0;
	public bool GChange = false;

	private GameObject GunFireSpr;
	private int idleCnt = 0;
	private Light GunFireLight; 

	public bool reload=false;

	public AnimationClip startClip;
	public AnimationClip idleClip;
	public AnimationClip walkClip;
	public AnimationClip attackClip;
	public AnimationClip shootClip;
	public AnimationClip oneShootClip;
	public AnimationClip reloadClip;

	private bool gunStart=false;

	public AudioClip attackSound;
	public AudioClip shootSound;
	public AudioClip reloadSound;

	public float animSpeed = 1.0f;
    public Transform prefabBullet;

	public bool reloadKey=false;
	public bool getFire;
	// Use this for initialization
	void Start () {
		gunStart =false;
		if (GameObject.Find ("GunFire"))
		{
			GunFireSpr=GameObject.Find ("GunFire");
			GunFireLight=GameObject.Find ("GunFireLight").GetComponent <Light> (); 
			GunFireSpr.GetComponent <Renderer>().enabled=false;
			GunFireLight.intensity=0;
		}

		setClips();
		setAnimSpeed(animSpeed);



		if (startClip) {
			this.GetComponent <Animation>().Play  (startClip.name); 
			//yield WaitForSeconds (startClip.length);
			//gunStart=true;
			StartCoroutine (MyMetod (startClip.length));
		}
	}
	IEnumerator MyMetod (float timeWait)
	{
		yield return new WaitForSeconds (timeWait);
		gunStart = true;
	}

	// Update is called once per frame
	void Update () {

	}
	void LateUpdate () {
		if (GChange){

			gunStart=false;
			if (!afx){
				animBlend( startClip);
				playAnim ( startClip);
			}

		}	

		if (gunStart){
			if (GameObject.Find ("GunFire"))
			{
				GunFireSpr=GameObject.Find ("GunFire");
				GunFireLight=GameObject.Find ("GunFireLight").GetComponent <Light>(); 
				GunFireSpr.GetComponent<Renderer>().enabled=false;
				GunFireLight.intensity=0;
			}

			//reloadKey=Input.GetKeyDown ("r");
			//reloadKey=true;

			if (reloadKey){
				reload=true;
				Rcnt=0;
			}




			//var getFire=(Input.GetButton ("Fire1")||Input.GetButton ("Fire2")||Input.GetButton ("Fire3")/*&& ! Joystick.isActive*/);
			var getMoveH = Input.GetAxisRaw("Horizontal");
			var getMoveV = Input.GetAxisRaw("Vertical");



			var jump=Input.GetButton ("Jump");

			if (this.reload){
				if (reloadClip){
					if (!sfx&& Rcnt==0){
						playSound (reloadSound);
						animBlend( reloadClip);
						playAnim ( reloadClip);
						Rcnt++;
					}
				}
				idleCnt=0;
			}


			if (!jump&&  getMoveH==0 && getMoveV==0  &&!getFire&& !sfx)
			{
				idleCnt++;
				animBlend( idleClip);
				if (idleCnt>100){
					animBlend( idleClip);
					playAnim ( idleClip);
				}
			}


			if ( getMoveH>0 || getMoveV>0 && !getFire && reload==false){

				if ( walkClip){
					animBlend( walkClip);
					playAnim ( walkClip);
					idleCnt=0;
				}
			}


			if (getFire && reload==false)
			{
				if (attackClip){
					playSound (attackSound);
					animBlend( attackClip);
					playAnim ( attackClip);
					idleCnt=0;
				}
				else {

					if (oneShootClip)
					{

						if (!bfx){
							oneGunFire();
							oneShoot();
							onePlaySound (shootSound);
							oneGunFire();
						}

						if (!bfx)

							animBlend(oneShootClip);
						playAnim (oneShootClip);

					}


					if (shootClip)
					{
						gunFire();
						if (!bfx)
							shoot();

						if (!sfx)
							playSound (shootSound);
						animBlend(shootClip);
						playAnim (shootClip);

					}
					idleCnt=0;
				}
			}
		}

	}
	void setClips(){

		if (startClip)
			this.GetComponent<Animation>().AddClip(startClip, startClip.name);
		if (idleClip)
			this.GetComponent<Animation>().AddClip(idleClip, idleClip.name);
//		if (walkClip)
//			this.GetComponent<Animation>().AddClip(walkClip, walkClip.name);

		if (attackClip)
			this.GetComponent<Animation>().AddClip(attackClip, attackClip.name);

		if (shootClip)
			this.GetComponent<Animation>().AddClip(shootClip, shootClip.name);

		if (oneShootClip)
			this.GetComponent<Animation>().AddClip(oneShootClip, oneShootClip.name);


		if (reloadClip)
			this.GetComponent<Animation>().AddClip(reloadClip, reloadClip.name);

	}
	void setAnimSpeed (float speed)
	{
		/*foreach (var state in GetComponent <Animation>()) {
			state = speed;
		}*/
	}
	void playAnim(AnimationClip animName)
	{
		afx=true;
		this.GetComponent <Animation>().Play(animName.name);
		//		yield WaitForSeconds (animName.length);
		//afx=false;
		StartCoroutine (MyMetod2 (animName.length));
		if (animName==reloadClip){
			reload=false;
			Rcnt=0;
		}
	}
	IEnumerator MyMetod2 (float timeWait)
	{
		yield return new WaitForSeconds (timeWait);
		afx = false;
	}

	void animBlend(AnimationClip animName)
	{
		this.GetComponent <Animation>().CrossFadeQueued(animName.name, 0.2f);

		StartCoroutine (MyMetod3 (0.2f));
	}

	IEnumerator MyMetod3 (float timeWait)
	{
		yield return new WaitForSeconds (timeWait);

	}

	void playSound (AudioClip soundClip){
		this.GetComponent <AudioSource>().clip = soundClip;
		this.GetComponent <AudioSource>().Play();
		sfx=true;
		//yield WaitForSeconds (soundClip.length);
		//sfx=false;
		StartCoroutine (MyMetod4 (soundClip.length));
	}

	IEnumerator MyMetod4 (float timeWait)
	{
		yield return new WaitForSeconds (timeWait);
		sfx = false;
	}

	void onePlaySound (AudioClip soundClip){
		this.GetComponent<AudioSource>().clip = soundClip;
		this.GetComponent<AudioSource>().Play();
		sfx=true;
		//yield WaitForSeconds (oneShootClip.length);
		//sfx=false;
		StartCoroutine (MyMetod5 (oneShootClip.length));
	}
	IEnumerator MyMetod5 (float timeWait)
	{
		yield return new WaitForSeconds (timeWait);
		sfx = false;
	}


	void oneGunFire (){

		GunFireSpr.GetComponent<Renderer>().enabled=true;
		GunFireLight.intensity=7.0f;

	}


	void gunFire (){
		var range= Random.RandomRange (0,2);

		if (range>0){
			GunFireSpr.GetComponent<Renderer>().enabled=true;


		}
		else 
			GunFireSpr.GetComponent<Renderer>().enabled=false;
		GunFireLight.intensity=Random.RandomRange (0,8.0f);

	}

	void shoot()
	{
		//var instanceBullet = Instantiate(prefabBullet, GunFireSpr.transform.position , Quaternion.identity);
		//instanceBullet.GetComponent<Rigidbody>().AddRelativeForce ((GameObject.Find ("GunCamera").transform.forward) * 300 );
		bfx=true;
		//yield WaitForSeconds (0.1);
		//bfx=false;
		StartCoroutine (MyMetod6 (0.1f));
	}

	IEnumerator MyMetod6 (float timeWait)
	{
		yield return new WaitForSeconds (timeWait);
		bfx = false;
	}
	void oneShoot()
	{
		//var instanceBullet = Instantiate(prefabBullet, GunFireSpr.transform.position , Quaternion.identity);
		//instanceBullet.GetComponent<Rigidbody>().AddRelativeForce ((GameObject.Find ("GunCamera").transform.forward) * 300 );
		bfx=true;
		oneGunFire ();

		StartCoroutine (MyMetod7 (oneShootClip.length));
	}
	IEnumerator MyMetod7 (float timeWait)
	{
		yield return new WaitForSeconds (timeWait);
		bfx = false;
	}
}