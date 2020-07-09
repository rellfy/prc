using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Physics;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Gathers player input as a singleton.
/// </summary>
[AlwaysUpdateSystem]
[UpdateBefore(typeof(RectilinearElevator))]
public class InputGatherer : SystemBase, Input.IControllerActions {

    private bool jumped;
    private bool spawnedBall;
    private bool sprinting;
    private EntityQuery cursorQuery;
    private float2 movement = float2.zero;
    private Input controls;

    protected override void OnCreate() {
        this.controls = new Input();
        this.controls.Controller.SetCallbacks(this);
        this.controls.Enable();

        this.cursorQuery = GetEntityQuery(ComponentType.ReadWrite<InputData>());
    }

    protected override void OnUpdate() {
        if (this.cursorQuery.CalculateEntityCount() == 0)
            EntityManager.CreateEntity(ComponentType.ReadWrite<InputData>());

        SetSingleton(new InputData() {
            cursorMovement = this.movement,
            jumped = this.jumped,
            sprinted = this.sprinting,
            spawnedBall = this.spawnedBall
        });

        // Reset boolean states.
        this.jumped = false;
        this.spawnedBall = false;
    }

    public void OnMove(InputAction.CallbackContext context) => this.movement = context.ReadValue<Vector2>();
    public void OnUpwardImpulse(InputAction.CallbackContext context) { if (context.started) this.jumped = true; }
    public void OnSpawnNewBall(InputAction.CallbackContext context) { if (context.started) this.spawnedBall = true; }
    public void OnSprint(InputAction.CallbackContext context) { this.sprinting = context.started || !context.canceled && this.sprinting; }

}