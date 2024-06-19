//========= 2023 - 2024  Copyright Manfred Brill. All rights reserved. ===========
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Hover-Events aus VIU für das Ein- und Ausblenden der Schichten in
/// einer CCC-Komponente.
/// </summary>
public class LayerEventManager : MonoBehaviour,
    IColliderEventHoverEnterHandler,
    IColliderEventHoverExitHandler
{
    /// <summary>
    /// Soll die Schicht angezeigt werden oder nicht?
    /// </summary>
    [Tooltip("Anzeige der Schicht")]
    public bool Show = true;
	
    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        Logger.Debug(">>> LayerEventManager.OnColliderEventHoverEnter");
        object[] args = {m_goName, 
            "HoverEnter",            
        };
        Logger.DebugFormat("{0}; {1};", args);
        // Wenn wir in die Schicht eintreten  wird die Schicht sichtbar
        m_Show.Invoke();
        Logger.Debug("<<< LayerEventManager.OnColliderEventHoverEnter");
    }

    public void OnColliderEventHoverExit(ColliderHoverEventData eventData)
    {
        Logger.Debug(">>> LayerEventManager.OnColliderEventHoverExit");
        Logger.Debug("HoverEnter Event");
        // Wenn wir die Schicht verlassen  wird die Schicht unsichtbar
        m_NoShow.Invoke();
        Logger.Debug("<<< LayerEventManager.OnColliderEventHoverExit");
    }

    /// <summary>
    /// Initialisieren
    /// </summary>
    void Awake()
    {
        m_goName = gameObject.name;
        m_DetermineCubeRenderers();
        
        m_Show.AddListener(ShowTheLayer);
        m_NoShow.AddListener(NoShowTheLayer);
    }

    void Start()
    {
        if (Show)
            ShowTheLayer();
        else
            NoShowTheLayer();
    }
    
    void Update()
    {
        if (Show)
            ShowTheLayer();
        else
            NoShowTheLayer();
    }

    /// <summary>
    /// Unity-Event mit einem Callback,der in der Lage ist
    /// einen der Layer einzublenden.
    /// </summary>
    private UnityEvent m_Show = new UnityEvent();
    
    /// <summary>
    /// Unity-Event mit einem Callback,der in der Lage ist
    /// einen der Layer ausblenden.
    /// </summary>
    private UnityEvent m_NoShow = new UnityEvent();
    
    /// <summary>
    /// Callback für das Einblendene einer Schicht.
    /// </summary>
    public void ShowTheLayer()
    {
        Logger.Debug(">>> ShowTheLayer");
        object[] args = {"Show the Layer",            
            m_goName
        };
        Logger.DebugFormat("{0}; {1};", args);
        Show = true;
        for (var i = 0; i < cubeRenderers.Length; i++)
            cubeRenderers[i].enabled = true;
        Logger.Debug("<<< ShowTheLayer");
    }
    
    /// <summary>
    /// Callback für das Ausblenden einer Schicht.
    /// </summary>
    public  void NoShowTheLayer()
    {
        Logger.Debug(">>> NoShowTheLayer");
        object[] args = {"No Show the Layer",           
            m_goName
        };
        Logger.DebugFormat("{0}; {1};", args);
        Show = false;
        for (var i = 0; i < cubeRenderers.Length; i++)
            cubeRenderers[i].enabled = true;
        Logger.Debug("<<< ShowTheLayer");
    }
    
    /// <summary>
    /// Wir bestimmen den Index der Schicht aus dem Namen
    /// </summary>
    /// <returns></returns>
    private uint m_DetermineLayerIndex()
    {
        uint i=99;
        switch (m_goName)
        {
            case "Schicht1": 
                i = 1;
                break;
        }

        return i;
    }
    /// <summary>
    /// Name des GameObjects, das durch dieses Prefab definiert wird.
    /// </summary>
    private string m_goName;

    /// <summary>
    /// Index der Schicht: 0, 1 oder 2.
    /// </summary>
    private uint m_LayerIndex;

    /// <summary>
    /// Die Renderer der einzelnen Würfel im Layer abfragen
    /// </summary>
    private void m_DetermineCubeRenderers()
    {
        switch (m_goName)
        {
            case "Schicht1":
                cubeRenderers[0] = m_getRenderer("CC0"); 
                cubeRenderers[1] = m_getRenderer("CC1");
                cubeRenderers[2] = m_getRenderer("CC2");
                cubeRenderers[3] = m_getRenderer("CC3");
                break;
        }
    }
    
    /// <summary>
    /// Array für die Renderer der Würfel in der aktuellen Schicht
    /// </summary>
    private Renderer[] cubeRenderers = new Renderer[4];

    /// <summary>
    /// Renderer im übergebenen GameObject abfragen
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private Renderer m_getRenderer(string name)
    {
        return GameObject.Find(name).GetComponent<Renderer>() as Renderer;
    }
	
    /// <summary>
    /// Instanz eines Log4Net Loggers
    /// </summary>
    private static readonly log4net.ILog Logger 
        = log4net.LogManager.GetLogger(typeof(LayerEventManager));
}
