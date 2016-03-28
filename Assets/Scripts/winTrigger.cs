using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class winTrigger : MonoBehaviour {

    public bool hasWon = false;

    void OnTriggerEnter(Collider other)
    {
        hasWon = true;
    }

    void OnGUI()
    {
        if (hasWon)
        {
            float buttonWidth = 160;
            float buttonHeight = 30;
            float originX = (Screen.width - buttonWidth) / 2;
            float originY = (Screen.height - buttonHeight) / 2 + 10;
            Rect pos = new Rect(originX, originY, buttonWidth, buttonHeight);

            if (GUI.Button(pos, "You won!"))
            {
                SceneManager.LoadScene(0);
            }
        }
        
    }
}
