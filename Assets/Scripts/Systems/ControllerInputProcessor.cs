using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

/// <summary>
/// Applies player input via singleton component to controller inputs.
/// </summary>
[AlwaysUpdateSystem]
[UpdateAfter(typeof(InputGatherer))]
public class ControllerInputProcessor : SystemBase {

    protected override void OnUpdate() {
        InputData input = GetSingleton<InputData>();
        float dt = Time.DeltaTime;

        Entities
            .ForEach(
        (
            ref ControllerInput controller
        ) => {
            ApplyInput(ref controller, input, dt);
        })
            .Schedule();
    }

    public static void ApplyInput(ref ControllerInput controller, in InputData input, float dt) {
        controller.jump = input.jumped;
        controller.sprint = input.sprinted;
        controller.cursorPosition += input.cursorMovement * dt * (controller.sprint ? 6f : 2f);
    }

}