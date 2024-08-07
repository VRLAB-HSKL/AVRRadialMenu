//========= 2023 -2024  Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
///  Komponente mit Funktionen für das Bewegen eines GameObjects
/// </summary>
public class Mover : MonoBehaviour
{
    /// <summary>
    /// Delta für die Veränderung der Koordinaten
    /// </summary>
    public float Delta = 0.1f;
    
	/// <summary>
    /// Zuweisung der Funktionen zu einem Cube für Radial Menu mit Trackpad
    /// </summary>
	public void ExecuteFunction(int cubeID)
    {
        switch (cubeID)
        {
            case 0:
                PositiveX();
                break;
            case 1:
                NegativeY();
                break;
            case 2:
                NegativeX();
                break;
            case 3:
                PositiveY();
                break;
            default:
                Debug.LogWarning("Keine Funktion definiert für diesen Würfel!");
                break;
        }
    }
	
    /// <summary>
    /// Verschieben in positive x-Richtung
    /// </summary>
    public void PositiveX()
    {
        Logger.Debug(">>> PositiveX");
        Logger.Debug(transform.position);
        transform.Translate(Delta*Vector3.right);
        Logger.Debug(transform.position);
        Logger.Debug("<<< PositiveX");
    }
    
    /// <summary>
    /// Verschieben in negative x-Richtung
    /// </summary>
    public void NegativeX()
    {
        Logger.Debug(">>> NegativeX");
        Logger.Debug(transform.position);
        transform.Translate(Delta*Vector3.left);
        Logger.Debug(transform.position);
        Logger.Debug("<<< NegativeX");
    }
    
    /// <summary>
    /// Verschieben in positive y-Richtung
    /// </summary>
    public void PositiveY()
    {
        Logger.Debug(">>> PositiveY");
        Logger.Debug(transform.position);
        transform.Translate(Delta*Vector3.up);
        Logger.Debug(transform.position);
        Logger.Debug("<<< PositiveY");
    }
    
    /// <summary>
    /// Verschieben in negative  y-Richtung
    /// </summary>
    public void NegativeY()
    {
        Logger.Debug(">>> NegativeY");
        Logger.Debug(transform.position);
        transform.Translate(Delta*Vector3.down);
        Logger.Debug(transform.position);
        Logger.Debug("<<< NegativeY");
    }
    
    /// <summary>
    /// Instanz eines Log4Net Loggers
    /// </summary>
    private static readonly log4net.ILog Logger 
        = log4net.LogManager.GetLogger(typeof(Mover));
}
