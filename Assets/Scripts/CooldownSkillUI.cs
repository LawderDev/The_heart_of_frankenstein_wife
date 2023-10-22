using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSkillUi : MonoBehaviour
{
    public Slider slider;
    private Coroutine cooldownRoutine;

    public void SetCooldown(float value)
    {
        if (cooldownRoutine != null)
        {
            StopCoroutine(cooldownRoutine);
        }

        cooldownRoutine = StartCoroutine(StartCooldown(value));
    }

    private IEnumerator StartCooldown(float startValue)
    {
        float timer = startValue;
        float maxValue = slider.maxValue;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            slider.value = Mathf.Lerp(maxValue, 0, timer / startValue); // Inversion des valeurs minimales et maximales
            yield return null;
        }
        StopCoroutine(cooldownRoutine);
    }
}
