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
            .WithoutBurst()
            .ForEach(
        (
            ref ControllerInputData controller,
            in ControllerCharacteristics characteristics
        ) => {
            ApplyInput(ref controller, in characteristics, in input, dt);
        })
            .Run();
    }

    public static void ApplyInput(
        ref ControllerInputData controller,
        in ControllerCharacteristics characteristics,
        in InputData input,
        float dt
    ) {
        controller.jump = input.jumped;
        controller.sprint = input.sprinted;
        controller.cursorPosition += input.cursorMovement
                                     * dt
                                     * (controller.sprint ? 
                                         characteristics.sprintSpeed : 
                                         characteristics.defaultSpeed);
    }

}