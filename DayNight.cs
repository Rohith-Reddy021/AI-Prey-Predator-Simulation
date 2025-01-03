using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Light directionalLight;
    public float dayDuration = 10f;
    public float nightDuration = 2f;
    public float transitionSpeed = 1f;

    private float timer = 0f;
    private bool isNight = false;
    private float targetIntensity;

    public bool IsNight
    {
        get { return isNight; }
    }

    void Start()
    {
        if (directionalLight == null)
        {
            directionalLight = GameObject.FindObjectOfType<Light>();
        }
        if (directionalLight != null)
        {
            directionalLight.intensity = 1f;
            targetIntensity = 1f;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isNight)
        {
            if (timer >= nightDuration)
            {
                isNight = false;
                timer = 0f;
                targetIntensity = 1f;
            }
        }
        else
        {
            if (timer >= dayDuration)
            {
                isNight = true;
                timer = 0f;
                targetIntensity = 0f;
            }
        }

        SmoothTransition();
    }

    void SmoothTransition()
    {
        if (directionalLight != null)
        {
            directionalLight.intensity = Mathf.Lerp(directionalLight.intensity, targetIntensity, transitionSpeed * Time.deltaTime);
        }
    }
}
