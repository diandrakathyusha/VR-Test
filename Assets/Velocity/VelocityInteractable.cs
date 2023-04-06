using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VelocityInteractable : XRGrabInteractable
{
    private ControllerVelocity controllerVelocity = null;
    private MeshRenderer meshRenderer = null;

    protected override void Awake()
    {
        base.Awake();
        meshRenderer = GetComponent<MeshRenderer>();
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
                UpdateColorUsingVelocity();
        }
    }

    private void UpdateColorUsingVelocity()
    {
        Vector3 velocity = controllerVelocity ? controllerVelocity.Velocity : Vector3.zero;
        Color color = new Color(velocity.x, velocity.y, velocity.z);
        meshRenderer.material.color = color;
        Debug.Log(string.Format("velocity x: {0:F3}; velocity y: {1:F3}; velocity z: {2:F3}", velocity.x, velocity.y, velocity.z));
    }

}
