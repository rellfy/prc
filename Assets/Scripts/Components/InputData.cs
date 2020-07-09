using Unity.Entities;
using Unity.Mathematics;

public struct InputData : IComponentData {

    public float2 cursorMovement;
    public bool jumped;
    public bool sprinted;
    public bool spawnedBall;

}