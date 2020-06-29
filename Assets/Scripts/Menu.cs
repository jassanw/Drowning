using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button freeRunButton;
    // Start is called before the first frame update
    void Start()
    {
        freeRunButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
