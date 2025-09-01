using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class restart : MonoBehaviour
{
    public Button yourButton;
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {

    }
   public void Reset()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
