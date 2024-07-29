//========= 2023 - 2024 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controller für das ein- und ausblenden des Radial Menus mit dem Keyboard.
/// Diese Klasse realisiert die Interaktionen auf der Basis des Input Systems.
/// </summary>
public class ViuCccAction : ViuCCCTrackpad
{
    /// <summary>
    /// Action für das Ein- und Ausblenden des Radial Menus
    /// </summary>
    /// <remarks>
    /// Diese Klasse wird als Komponente einem anderen GameObject
    /// hinzugefügt.
    ///
    /// Damit wird sicher gestellt, dass wir Radial Menu in der
    /// Szene erst bei Bedarf einblenden können.
    /// </remarks>
    [Tooltip("Input Action für Ein- und Ausblenden")]
    public InputAction ShowAction;
    
    /// <summary>
    /// Verbindung zu CCC in der Szene aufnehmen und InputManager konfigurieren.
    /// </summary>
    protected void Awake()
    {
        FindTheCCC();
        if (!TheCCC) return;
        ShowAction.canceled += OnRelease;
        if (Show)
            TheCCC.SetActive(true);
    }

    /// <summary>
    /// In Enable für die Szene aktivieren wir die  Action.
    /// </summary>
    protected void OnEnable()
    {
        ShowAction.Enable();
    }
    
    /// <summary>
    /// In Disable für die Szenede aktivieren wir die  Action.
    /// </summary>
    protected void DisEnable()
    {
        ShowAction.Disable();
    }
    
    /// <summary>
    /// Ein- und Ausblenden des CCC Prefabs.
    ///<summary>
    protected void OnRelease(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValueAsButton();
        Show = !Show;
        
        TheCCC.SetActive(Show);
    }
}
