using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

/// <summary>
/// Elevates bars on a rectilinear plane according to a controller input.
/// </summary>
public class RectilinearElevator : SystemBase {

    protected override void OnUpdate() {
        Entities
            .WithoutBurst()
            .WithAll<BarTag>()
            .ForEach(
        (
            ref Translation translation,
            in ControllerCharacteristics characteristics,
            in ControllerInputData input
        ) => {
            float distance = GetControllerDistanceToCursor(
                translation.Value,
                input.cursorPosition
            );

            if (distance > characteristics.maximumRadius) {
                ConstrainController(ref translation);
                return;
            }

            ElevateController(
                ref translation,
                in characteristics,
                in input,
                distance
            );
        }).Run();
    }

    public static float GetControllerDistanceToCursor(
        float3 controllerTranslation,
        float2 cursorPosition
    ) {
        return math.length(
            new float2(
                math.abs(controllerTranslation.x - cursorPosition.x),
                math.abs(controllerTranslation.z - cursorPosition.y)
            )
        );
    }

    public static void ElevateController(
        ref Translation translation,
        in ControllerCharacteristics characteristics,
        in ControllerInputData input,
        float distance
    ) {
        float height = math.lerp(
            characteristics.maximumRadius,
            characteristics.minimumHeight,
            distance / characteristics.maximumRadius
        );

        translation.Value += new float3(0, -translation.Value.y + height, 0);
    }

    public static void ConstrainController(ref Translation translation) {
        translation.Value += new float3(0, -translation.Value.y, 0);
    }

}