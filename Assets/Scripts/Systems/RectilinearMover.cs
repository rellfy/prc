using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

public class RectilinearMover : SystemBase {

    protected override void OnUpdate() {
        InputData inputData = GetSingleton<InputData>();

        Entities
            .WithoutBurst()
            .WithAll<BarTag>()
            .ForEach(
        (
            ref Translation translation
            //ref PhysicsVelocity velocity,
            //in CursorHeightMap cursorHeightMap
        ) => {
            float distanceX = math.abs(inputData.cursorPosition.x - translation.Value.x);
            float distanceY = math.abs(inputData.cursorPosition.y - translation.Value.z);
            float distance = math.length(new float2(distanceX, distanceY));
            float maxDistance = 0.2f;

            if (distance > maxDistance) {
                translation.Value += new float3(0, -translation.Value.y, 0);
                return;
            }

            float height = math.lerp(0.5f, 0f, distance / maxDistance);
            translation.Value += new float3(0, -translation.Value.y + height, 0);
        }).Run();
    }

}