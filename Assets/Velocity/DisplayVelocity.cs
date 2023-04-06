using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class DisplayVelocity : XRGrabInteractable
{
    private ControllerVelocity controllerVelocity = null;
    public Text counterText;

    protected override void Awake()
    {
        base.Awake();
        Vector3 velocity = controllerVelocity ? controllerVelocity.Velocity : Vector3.zero;
        counterText.text = velocity.ToString();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        controllerVelocity = args.interactor.GetComponent<ControllerVelocity>();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        controllerVelocity = null;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected)
        {
            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
                UpdateText();
        }
    }

    private void UpdateText()
    {
        Vector3 velocity = controllerVelocity ? controllerVelocity.Velocity : Vector3.zero;
        Debug.Log(string.Format("velocity x: {0:F3}; velocity y: {1:F3}; velocity z: {2:F3}", velocity.x, velocity.y, velocity.z));
    }
    public void Update()
    {
        Vector3 velocity = controllerVelocity ? controllerVelocity.Velocity : Vector3.zero;
        counterText.text = velocity.ToString();
    }
}
