using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandButton : XRBaseInteractable
{
    public UnityEvent OnPress = null;

    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private bool previousPress = false;

    private float previousHandHeight = 0.0f;
    private XRBaseInteractor handInteractor = null;
    protected override void Awake()
    {
        base.Awake();

        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);
    }

    private void OnDestroy()
    {
        onHoverEntered.RemoveListener(StartPress);
        onHoverExited.RemoveListener(EndPress);
    }

    private void StartPress(XRBaseInteractor interactor)
    {
        handInteractor = interactor;
        previousHandHeight = GetLocalYPos(handInteractor.transform.position);
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        handInteractor = null;
        previousHandHeight = 0.0f;

        previousPress = false;
        SetYPos(yMax);
    }

    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        yMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (handInteractor)
        {
            float newHandHeight = GetLocalYPos(handInteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPos(newPosition);

            CheckPress();
        }
    }

    private float GetLocalYPos(Vector3 pos)
    {
        Vector3 localPos = transform.root.InverseTransformPoint(pos);
        return localPos.y;
    }

    private void SetYPos(float pos)
    {
        Vector3 newPos = transform.localPosition;

        newPos.y = Mathf.Clamp(pos, yMin, yMax);
        transform.localPosition = newPos;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if(inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();
        }

        previousPress = inPosition;
    }

    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + 0.01f);

        return transform.localPosition.y == inRange;
    }
}
