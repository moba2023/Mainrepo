using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traceanim : MonoBehaviour
{

    private void Start()
    {
        Invoke("Destroy", 0.50f);
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0, 0, 1), 1.5f * Time.deltaTime);

        if (Input.GetMouseButtonDown(1)) Destroy();
    }

    private void Destroy()
    {
        Destroy(this.transform.gameObject);
    }
}
