using UnityEngine;

public class MenuController : MonoBehaviour {
    private Animator animator;
    private bool isInstructions;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
    void Update () {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if (!isInstructions) {
                animator.SetTrigger("ShowInstructions");
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
