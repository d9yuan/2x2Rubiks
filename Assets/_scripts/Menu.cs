using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public bool can_load_next = true;
    public bool can_load_prev = false;

    [System.Obsolete]
    void OnGUI() {

        int loadedLevel = Application.loadedLevel;
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        if (Input.GetMouseButton(0) && can_load_next)
			Application.LoadLevel (loadedLevel + 1);
        if (Input.GetMouseButton(1) && can_load_prev)
            Application.LoadLevel(loadedLevel - 1);
        

	}
}
