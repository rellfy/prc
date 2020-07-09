using Unity.Entities;
using Unity.Mathematics;

public struct ControllerInput : IComponentData {

    public float2 cursorPosition;
    public bool jump;
    public bool sprint;

}