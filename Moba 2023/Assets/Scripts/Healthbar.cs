using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    Slider health_Slider;

    private void Start()
    {
        health_Slider = transform.GetChild(0).gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.parent.position.x, 12, transform.parent.position.z + 3);
        health_Slider.value = (float)transform.parent.gameObject.GetComponent<Statsinfo>().curHealth / transform.parent.gameObject.GetComponent<Statsinfo>().maxHealth;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
    }
}
