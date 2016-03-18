// by @torahhorse
// modified/modernized by @nathanwentworth

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LockMouse : MonoBehaviour {

	private bool cursorAbleToLock;

	void Start() {
		if (SceneManager.GetActiveScene().buildIndex > 0) {
			LockCursor(true);
			cursorAbleToLock = true;
		}
		else {
			LockCursor(false);
			cursorAbleToLock = false;
		}
		
	}

    void Update() {
    	if (cursorAbleToLock) {
	    	// lock when mouse is clicked
	    	if (Input.GetMouseButtonDown(0) && Time.timeScale > 0.0f) {
	    		LockCursor(true);
	    	}
	    
	    	// unlock when escape is hit
	        if (Input.GetKeyDown(KeyCode.Escape)) {
	        	LockCursor(false);
	        }
    	}
    }
    
    public void LockCursor(bool lockCursor) {
    	if (lockCursor) {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    	}
    	else {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    	}
    }
}