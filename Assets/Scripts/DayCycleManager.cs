using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range(0,1)]
    public float dayTime;
    public float dayDuration = 300f;
    public AnimationCurve sunCurve;
    public AnimationCurve moonCurve;
    public Light sun;
    public Light moon;
    private float sunIntensity;
    private float moonIntensity;
    // Start is called before the first frame update
    void Start()
    {
        sunIntensity = sun.intensity;
        moonIntensity = moon.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        dayTime += Time.deltaTime / dayDuration;
        if (dayTime > 1)
        {
            dayTime -= 1;
        }

        sun.transform.localRotation = Quaternion.Euler(dayTime * 360f, 180, 0);
        moon.transform.localRotation = Quaternion.Euler(dayTime * 360f + 180, 180, 0);
        sun.intensity = sunIntensity * sunCurve.Evaluate(dayTime);
        moon.intensity = moonIntensity * moonCurve.Evaluate(dayTime);
    }
}
