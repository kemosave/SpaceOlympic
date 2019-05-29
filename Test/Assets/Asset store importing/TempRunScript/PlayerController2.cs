using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

	public float tmpValue = 1.0f;
	public Animator anim;
	
	void Update () {
		anim.SetBool ("jump", Input.GetKeyDown (KeyCode.UpArrow));
		anim.SetBool ("slide", Input.GetKeyDown (KeyCode.DownArrow));
	}

	void OnTriggerEnter(Collider col) {
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);
		
		if (state.IsName("Base Layer.Run") ||
		    (state.IsName("Base Layer.Vaut") && col.CompareTag("Higher")) ||
		    (state.IsName("Base Layer.Slide") && col.CompareTag("Lower"))) {
			anim.SetBool ("dead", true);
			StartCoroutine("ResetFlag");
		}
	}

	IEnumerator ResetFlag() {
		yield return null;
		anim.SetBool ("dead", false);
	}
}
