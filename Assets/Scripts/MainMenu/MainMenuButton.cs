using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class MainMenuButton : MonoBehaviour {

    [SerializeField] int index;
    private Animator anim;

    public UnityEvent onClick;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (index == MainMenuManager.instance.currentIndex) {
            anim.SetBool("selected", true);
            if (Input.GetButtonDown("Submit")) {
                anim.SetBool("pressed", true);
                if (onClick != null)
                    onClick.Invoke();
            }
        } else {
            anim.SetBool("selected", false);
            anim.SetBool("pressed", false);
        }
	}
}
