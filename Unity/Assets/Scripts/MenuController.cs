using UnityEngine;

public class MenuController : MonoBehaviour {
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
    void Update () {
        if(Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("FadeOut");
            Invoke("ChangeLevel", 0.5f);
        }
    }

    private void ChangeLevel() {
       Application.LoadLevel(1);
    }
}
