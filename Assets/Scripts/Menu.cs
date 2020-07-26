using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button freeRunButton;
    [SerializeField] PostProcessVolume postProcessVolume;
    public float bloomSpeed = 0.5f;
    private float direction = 1;
    private Bloom bloom;

  
    // Start is called before the first frame update
    void Start()
    {
       
        postProcessVolume.profile.TryGetSettings(out bloom);
        bloom.intensity.value = 1;
        freeRunButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
    }

    // Update is called once per frame
    void Update()
    {
        bloom.intensity.value += direction * bloomSpeed * Time.deltaTime;
        if (bloom.intensity.value >= 12)
        {
            direction = -1;
        }
        else if(bloom.intensity.value <= 1)
        {
            direction = 1;
        }
    }
}
