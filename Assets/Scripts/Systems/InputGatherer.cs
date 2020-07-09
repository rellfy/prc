using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Physics;
using UnityEngine;
using UnityEngine.InputSystem;

[AlwaysUpdateSystem]
[UpdateBefore(typeof(RectilinearMover))]
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
        Entity singleton;

        try {
            singleton = this.cursorQuery.GetSingletonEntity();
        } catch (Exception e) {
            singleton = EntityManager.CreateEntity(ComponentType.ReadWrite<InputData>());
        }
        
        InputData data = GetComponent<InputData>(singleton);

        float speed = this.sprinting ? 6f : 2f;

        this.cursorQuery.SetSingleton(new InputData() {
            cursorPosition = data.cursorPosition + this.movement * Time.DeltaTime * speed,
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