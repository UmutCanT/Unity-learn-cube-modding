using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    MeshRenderer cubeRenderer;
    float rotationSpeed;
    float scaleMax = 10f;
    float scaleMin = 1f;
    float opacityMin = 0f;
    float opacityMax = 1f;
    
    void Start()
    {
        rotationSpeed = Random.Range(20f, 100f);
        cubeRenderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        transform.Rotate(Vector3.right * playerHorizontalInputs() * rotationSpeed * Time.deltaTime);
        CubeScaler();
        SprayTheCube();
        CubeVisibility(cubeRenderer.material);
    }

    void SprayTheCube()
    {
        if (Input.anyKeyDown)
        {
            CubeColor(Input.inputString, cubeRenderer.material);
        }
    }

    void CubeVisibility(Material material)
    {
        Color color = material.color;
        color.a += Time.deltaTime * playerVerticalInputs();
        if (color.a >= opacityMax)
        {
            color.a = opacityMax;
        }
        if (color.a <= opacityMin)
        {
            color.a = opacityMin;
        }
        material.color = color;
    }

    float playerHorizontalInputs()
    {
        return Input.GetAxis("Horizontal");
    }

    float playerVerticalInputs()
    {
        return Input.GetAxis("Vertical");
    }

    void CubeColor(string key, Material material)
    {
        switch (key)
        {
            case "1":
                material.color = Color.red;
                break;
            case "2":
                material.color = Color.yellow;
                break;
            case "3":
                material.color = Color.blue;
                break;
            case "4":
                material.color = Color.green;
                break;
            case "5":
                material.color = Color.black;
                break;
            case "6":
                material.color = Color.cyan;
                break;
            case "7":
                material.color = Color.white;
                break;
        }
    }

    void CubeScaler()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.localScale += Vector3.one;

            if (transform.localScale.magnitude >= scaleMax)
            {
                transform.localScale = Vector3.one * scaleMax;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.localScale -= Vector3.one;

            if (transform.localScale.magnitude <= scaleMin)
            {
                transform.localScale = Vector3.one * scaleMin;
            }
        }
    }
}
