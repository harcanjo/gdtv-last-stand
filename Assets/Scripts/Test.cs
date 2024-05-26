using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	[SerializeField] private float correctionSpeed = 1f; // Adjust as needed

    private void Update()
    {
        // Check if the Y position is below 0
        if (transform.position.y < 0)
        {
            // Gradually move the Y position towards 0
            float newY = Mathf.Lerp(transform.position.y, 0, Time.deltaTime * correctionSpeed);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
