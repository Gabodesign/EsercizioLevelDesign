using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator anim;

    private Vector2 currentInput;
    private bool isRunning;
    private float currentSpeedValueX;
    private float currentSpeedValueY;
    public float acceleration = 5f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (InputManager.Instance != null)
        {
            InputManager.Instance.OnMove += UpdateMovementInput;
            InputManager.Instance.OnRun += UpdateRunInput;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //float speedValue = currentInput.magnitude;
        float targetSpeedX = 0f;
        float targetSpeedY = 0f;
        if (currentInput.magnitude > 0.1f)
        {
            float speedLimit = isRunning ? 1f : 0.5f;
            
            targetSpeedX = currentInput.x * speedLimit;
            targetSpeedY = currentInput.y * speedLimit;
            targetSpeedX = Mathf.Clamp(targetSpeedX, -1f, speedLimit);
            targetSpeedY = Mathf.Clamp(targetSpeedY, -1f, speedLimit);
        }
        currentSpeedValueX = Mathf.MoveTowards(currentSpeedValueX, targetSpeedX, acceleration * Time.deltaTime);
        currentSpeedValueY = Mathf.MoveTowards(currentSpeedValueY, targetSpeedY, acceleration * Time.deltaTime);

        anim.SetFloat("MoveX", currentSpeedValueX);
        anim.SetFloat("MoveY", currentSpeedValueY);
    }

    void UpdateMovementInput(Vector2 input)
    {
        currentInput = input;
    }
    void UpdateRunInput(bool run)
    {
        isRunning = run;
    }
 

    private void OnDestroy()
    {
        if (InputManager.Instance != null)
        {
            InputManager.Instance.OnMove -= UpdateMovementInput;
            InputManager.Instance.OnRun -= UpdateRunInput;
        }
    }


}
