using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToneSwitcher : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite lightSprite; // Dark Background
    public Sprite darkSprite; // Light Background

    public Camera camera;

    public Color32 colorDark = new Color32(14, 14, 14, 0);
    public Color32 colorLight = new Color32(242, 233, 225, 0);

    public int lightLimit = 5;

    private float timer = 0.0f;

    private bool isInLight = false;

    public UnityEngine.UI.Text timerCountDownText;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = lightSprite;
        camera.backgroundColor = colorDark;
        timerCountDownText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Process Inputs
        ProcessInputs();
        if (isInLight)
        {
            UpdateTimer();
        }
    }

    private void ProcessInputs()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SwitchSprite();
        }
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        timerCountDownText.text = "Light Remaining: " + Mathf.Abs((seconds - lightLimit)).ToString();
        
        if (seconds == lightLimit)
        {
            timer = 0.0f;
            timerCountDownText.text = "";
            SwitchSprite();
        }
    }

    void SwitchSprite()
    {
        if (spriteRenderer.sprite == lightSprite) // Light Background
        {
            spriteRenderer.sprite = darkSprite;
            camera.backgroundColor = colorLight;
            isInLight = true;
        }
        else // Dark Background
        {
            spriteRenderer.sprite = lightSprite;
            camera.backgroundColor = colorDark;
            isInLight = false;
        }
    }
}
