//========= 2023 -2024  Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Basisklasse für Radial Menu
/// </summary>
/// <remarks>
/// Wir initialisieren die Schicht und setzen die Sichtbarkeit.
/// </remarks>
public class CCC : MonoBehaviour
{

    /// <summary>
    /// GameObjects für die Schicht
    /// </summary>
    protected GameObject m_Layer1;

    /// <summary>
    /// Layer zuordnen
    /// </summary>
    private void Awake()
    {
        m_Layer1 = GameObject.Find(("Schicht1"));
    }
    
    /// <summary>
    /// Einstellen der Sichtbarkeiten aus Default-Werten
    /// </summary>
    protected void m_SetDefaultShows()
    {
        m_Layer1.GetComponent<LayerEventManager>().Show = true;
    }

    /// <summary>
    /// Einstellen der No-Shows  aus Default-Werten
    /// </summary>
    protected void m_SetNoShows()
    {
        m_Layer1.GetComponent<LayerEventManager>().Show = false;
    }
}
