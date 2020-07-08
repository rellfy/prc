using Unity.Entities;
using Unity.Mathematics;

public struct InputData : IComponentData {

    public float2 cursorPosition;
    public bool jumped;
    public bool sprinted;
    public bool spawnedBall;

}