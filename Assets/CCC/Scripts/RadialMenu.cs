using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

public class RadialMenu : MonoBehaviour
{
    public GameObject TheCCC;
    public HandRole CCCHand = HandRole.LeftHand;
    // Button zum Ein-/Ausblenden des Menus
    public ControllerButton ActivationButton = ControllerButton.Trigger;
    // Button zum auswählen eines Menu-Elements
    public ControllerButton SelectionButton = ControllerButton.Grip;
    // Button zum auswählen eines Elements wenn Collider nicht genutzt werden sollen 
    public ColliderButtonEventData.InputButton SelectButton = 
        ColliderButtonEventData.InputButton.PadOrStick;
    public bool Show = false;
    protected GameObject m_Controller;
    protected GameObject m_ControllerCollider;
    
    protected void OnEnable()
    {
        ViveInput.AddListenerEx(CCCHand,
            ActivationButton,
            ButtonEventType.Up,
            ToggleCCC);
    }
    
    protected void OnDisable()
    {
        ViveInput.RemoveListenerEx(CCCHand,
            ActivationButton,
            ButtonEventType.Up,
            ToggleCCC);
    }
    
    /// <summary>
    ///Callback für das Aktivieren und Deaktivieren des CCC Prefabs
    /// </summary>
    protected void ToggleCCC()
    {
        Logger.Debug(">>> ToggleCCC");
        Show = !Show;

        if (Show)
        {   
            TheCCC.SetActive(Show);
            SetPositionAndRotation();
            m_ControllerCollider.SetActive(false);
        }
        else
        {
            TheCCC.SetActive(Show);
            Logger.Debug("CCC Objekt wird ausgeblendet!");
            m_ControllerCollider.SetActive(true);
        }
        Logger.Debug("<<< ToggleCCC");
    }
    
    protected void FindTheCCC()
    {
        TheCCC = GameObject.Find(TheCCC.name);
        if (!TheCCC)
        {
            Logger.Fatal("CCC-Objekt wurde nicht gefunden!!");
            return;
        }
    }
    
    // Position is bound to controller position, orientation faces the camera 
    protected virtual void SetPositionAndRotation()
    {
        TheCCC.transform.SetPositionAndRotation(
            m_Controller.transform.position, 
            m_Controller.transform.rotation);  
    }
    
    protected static readonly log4net.ILog Logger 
        = log4net.LogManager.GetLogger(typeof(ViuCCC));
    
}
