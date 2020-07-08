using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine.AddressableAssets;
using Material = UnityEngine.Material;

public class BallSpawner : SystemBase {

    protected override void OnUpdate() {
        InputData inputData = GetSingleton<InputData>();

        if (!inputData.spawnedBall)
            return;

        SpawnBall(new float3(5f, 2f, 1.5f), 0.25f);
    }

    public static async void SpawnBall(float3 position, float radius) {
        Material whiteMaterial = await Addressables.LoadAssetAsync<Material>("Assets/Materials/White.mat").Task;

        BlobAssetReference<Collider> collider = SphereCollider.Create(new SphereGeometry() {
            Radius = radius
        });

        DOTools.Physics.CreateDynamicBody
        (
            position,
            quaternion.identity,
            collider,
            float3.zero,
            float3.zero,
            1f,
            whiteMaterial
        );
    }

}