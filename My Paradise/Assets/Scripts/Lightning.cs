using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private float secondPerRealTime;
    
    private bool isNight = false;

    public Material daySky;
    public Material nightSky;
    
    void Start()
    {
        RenderSettings.skybox = daySky;
    }

    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * secondPerRealTime * Time.deltaTime);

        if (transform.eulerAngles.x >= 170)
            isNight = true;
        else if (transform.eulerAngles.x <= 10)
            isNight = false;

        if (isNight)
        {
            RenderSettings.skybox = nightSky;
        }
        else
        {
            RenderSettings.skybox = daySky;
        }
    }
}