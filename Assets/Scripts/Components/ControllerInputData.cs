using Unity.Entities;
using Unity.Mathematics;

public struct ControllerInputData : IComponentData {

    public float2 cursorPosition;
    public bool jump;
    public bool sprint;

}