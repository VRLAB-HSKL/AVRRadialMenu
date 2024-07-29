//========= 2023 - -2024 Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Interface und Implementierung des Radial Menus
/// auf Basis von Vive Input Utility.
/// </summary>
public class RadialMenu : MonoBehaviour
{
    /// <summary>
    /// GameObject, das die Prefabs enthält
    /// </summary>
     [Tooltip("Objekt mit CCC-Prefabs")] 
    public GameObject TheCCC;
	
    /// <summary>
    /// Linker oder rechter Controller?
    /// </summary>
    public HandRole CCCHand = HandRole.LeftHand;
	
    /// <summary>
    /// Der verwendete Button kann im Editor mit Hilfe
    /// eines Pull-Downs eingestellt werden.
    /// </summary>
     [Tooltip("Welcher Button auf dem Controller wird für das Einblenden eingesetzt?")]
    public ControllerButton ActivationButton = ControllerButton.Trigger;
	
    /// <summary>
    /// Button für das Press-Event bei Trackpad
    /// </summary>
    public ControllerButton SelectionButton = ControllerButton.Grip;
    
    /// <summary>
    /// Button für das Press-Event bei Collidern
    /// </summary>
    public ColliderButtonEventData.InputButton SelectButton = 
        ColliderButtonEventData.InputButton.PadOrStick;
		
	// <summary>
    /// CCC anzeigen oder nicht?
    /// </summary>
     [Tooltip("CCC beim Start anzeigen?")]
    public bool Show = false;
	
    /// <summary>
    /// GameObject des Controllers, den wir verwenden möchten.
    /// </summary>	
    protected GameObject m_Controller;
	
	/// <summary>
    /// GameObjekct des Colliders des Controllers, den wir nicht verwenden.
    /// </summary>
    protected GameObject m_ControllerCollider;
    
	/// <summary>
    /// Registrieren der Listener für den gewünschten Button
    /// </summary>
    protected void OnEnable()
    {
        ViveInput.AddListenerEx(CCCHand,
            ActivationButton,
            ButtonEventType.Up,
            ToggleCCC);
    }
    
	/// <summary>
    /// Listener wieder aus der Registrierung
    /// herausnehmen beim Beenden der Anwendung
    /// </summary>
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
    
	/// <summary>
    /// Verbindung zu GameObject  in der Szene herstellen,
    /// das die CCC-Prefabs enthält
    /// </summary>
    protected void FindTheCCC()
    {
        TheCCC = GameObject.Find(TheCCC.name);
        if (!TheCCC)
        {
            Logger.Fatal("CCC-Objekt wurde nicht gefunden!!");
            return;
        }
    }
    
	/// <summary>
    /// Festlegen der Positionierung und Orientierung des Radial Menus.
    /// </summary>
    protected virtual void SetPositionAndRotation()
    {
        TheCCC.transform.SetPositionAndRotation(
            m_Controller.transform.position, 
            m_Controller.transform.rotation);  
    }
	
    /// <summary>
    /// Instanz eines Log4Net Loggers
    /// </summary>    
    protected static readonly log4net.ILog Logger 
        = log4net.LogManager.GetLogger(typeof(ViuCCC));
    
}
