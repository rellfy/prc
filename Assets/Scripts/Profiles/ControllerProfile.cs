using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Profiles/Controller")]
public class ControllerProfile : ScriptableObject {

    public float maximumHeight;
    public float maximumRadius;
    public float defaultSpeed;
    public float sprintSpeed;

}