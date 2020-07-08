using Unity.Entities;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Physics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UIElements;
using Material = UnityEngine.Material;
using SphereCollider = Unity.Physics.SphereCollider;
using BoxCollider = Unity.Physics.BoxCollider;
using Collider = Unity.Physics.Collider;

[AlwaysSynchronizeSystem]
public class Start : SystemBase {

    protected override void OnCreate() {
        CreateRectilinearPlane(100, 100, 0.1f);
        BallSpawner.SpawnBall(new float3(5f, 2f, 1.5f), 0.25f);
    }

    protected override void OnUpdate() { }

    public static Mesh Copy(Mesh mesh) {
        Mesh copy = new Mesh();
        foreach (var property in typeof(Mesh).GetProperties()) {
            if (property.GetSetMethod() != null && property.GetGetMethod() != null) {
                property.SetValue(copy, property.GetValue(mesh, null), null);
            }
        }
        return copy;
    }

    private async void CreateRectilinearPlane(int x, int y, float barWidth) {
        Material blackMaterial = await Addressables.LoadAssetAsync<Material>("Assets/Materials/Black.mat").Task;
        Mesh barMesh = Copy((await Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Cube.prefab").Task).GetComponent<MeshFilter>().sharedMesh);
        const float barDistance = 0.000f;

        DOTools.Meshing.ScaleMesh(ref barMesh, new float3(barWidth, 1, barWidth));
        barMesh.RecalculateNormals();

        EntityArchetype barArchetype = EntityManager.CreateArchetype(
            // Tags.
            ComponentType.ReadWrite<BarTag>(),
            // Transform.
            ComponentType.ReadWrite<LocalToWorld>(),
            ComponentType.ReadWrite<Translation>(),
            ComponentType.ReadWrite<Rotation>(),
            ComponentType.ReadWrite<NonUniformScale>(),
            // Rendering.
            ComponentType.ReadWrite<RenderMesh>(),
            ComponentType.ReadWrite<RenderBounds>(),
            ComponentType.ReadWrite<WorldRenderBounds>(),
            ComponentType.ReadWrite<ChunkWorldRenderBounds>(),
            // Physics.
            ComponentType.ReadWrite<PhysicsCollider>()
            //ComponentType.ReadWrite<PhysicsVelocity>(),
            //ComponentType.ReadWrite<PhysicsMass>(),
            //ComponentType.ReadWrite<PhysicsDamping>()
        );

        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                Entity bar = World.EntityManager.CreateEntity(barArchetype);
                float3 position = new float3(i * (barWidth + barDistance), 0, j * (barWidth + barDistance));
                float3 scale = new float3(barWidth, 1, barWidth);

                EntityManager.SetSharedComponentData(bar, new RenderMesh() {
                    mesh = barMesh,
                    material = blackMaterial
                });

                EntityManager.SetComponentData(bar, new Translation() {
                    Value = position
                });

                EntityManager.SetComponentData(bar, new NonUniformScale() {
                    Value = new float3(1f, 1f, 1f)
                });

                PhysicsCollider collider = new PhysicsCollider() {
                    Value = BoxCollider.Create(new BoxGeometry() {
                        Center = float3.zero,
                        Orientation = quaternion.identity,
                        Size = scale,
                        BevelRadius = 0.01f
                    })
                };

                EntityManager.SetComponentData(bar, collider);
                /*EntityManager.SetComponentData(bar, PhysicsMass.CreateDynamic(collider.MassProperties, 1f));

                EntityManager.SetComponentData(bar, new PhysicsVelocity {
                    Linear = 0,
                    Angular = 0
                });

                EntityManager.SetComponentData(bar, new PhysicsDamping {
                    Linear = 0.01f,
                    Angular = 0.05f
                });*/
            }
        }
    }

}