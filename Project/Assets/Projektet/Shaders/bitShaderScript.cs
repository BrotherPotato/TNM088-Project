using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitShaderScript : MonoBehaviour
{

    [SerializeField] private Material BitShader;

    private float pixelateAmount = 0f;
    private float pixelateAmountTarget = 0f;

    float pixelateSpeed = 2f;
    float delta = 0.0001f;

    private bool pixelateGoalReached = true;
    private bool pixelated = false;
    void Start()
    {
        
    }

    void Update()
    {
        if(pixelateGoalReached)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                pixelated = !pixelated;
                pixelateGoalReached = false;
                Debug.Log("T is pressed");
                Debug.Log(pixelateAmountTarget);
                Debug.Log(pixelateGoalReached);
            }
        }

        if(pixelated)
        {
            pixelateAmountTarget = 0.8f;
        } 
        else 
        {
            pixelateAmountTarget = 0f;
        }

        // could be changed
        if(Mathf.Abs(pixelateAmount - pixelateAmountTarget) < delta)
        {
            pixelateGoalReached = true;
        } 
        if(!pixelateGoalReached)
        {
            pixelateAmount = Mathf.Lerp(pixelateAmount, pixelateAmountTarget, Time.deltaTime * pixelateSpeed);
        } 
        // with this
        //pixelateAmount = Mathf.Lerp(pixelateAmount, pixelateAmountTarget, Time.deltaTime * pixelateSpeed);


        BitShader.SetFloat("_PixelateAmount", pixelateAmount);
    }
}
