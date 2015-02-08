using UnityEngine;

public class MenuController : MonoBehaviour {
    private Animator animator;
    private bool isInstructions;
	public AudioSource intro;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
    void Update () {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if (!isInstructions) {
                animator.SetTrigger("ShowInstructions");
				intro.Play();
                isInstructions = true;
            }
            else {
                animator.SetTrigger("FadeOut");
                Invoke("ChangeLevel", 0.5f);
            }
        }
    }

    private void ChangeLevel() {
       Application.LoadLevel(1);
    }
}
