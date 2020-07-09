using Unity.Entities;

[System.Serializable]
public struct ControllerCharacteristics : ISharedComponentData {

    public float minimumHeight;
    public float maximumHeight;
    public float maximumRadius;
    public float defaultSpeed;
    public float sprintSpeed;

}