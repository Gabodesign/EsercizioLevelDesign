using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator anim;

    private Vector2 currentInput;
    private bool isRunning;
    private float currentSpeedValue;
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
        float targetSpeed = 0f;
        if (currentInput.magnitude > 0.1f)
        {
            float speedLimit = isRunning ? 1f : 0.5f;
            targetSpeed = currentInput.magnitude * speedLimit;
            targetSpeed = Mathf.Clamp(targetSpeed, 0f, speedLimit);
        }
        currentSpeedValue = Mathf.MoveTowards(currentSpeedValue, targetSpeed, acceleration * Time.deltaTime);

        anim.SetFloat("Move", currentSpeedValue);
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
