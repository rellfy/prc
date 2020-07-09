using NUnit.Framework;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine.AddressableAssets;

namespace Tests {

    public class Controller {

        public async Task<ControllerCharacteristics> GetCharacteristics() {
            return (await Addressables.LoadAssetAsync<ControllerProfile>(
                PRC.Addressables.Profiles.Controller
            ).Task).characteristics;
        }

        [Test]
        public async void ApplyInput_Sprint_True() {
            InputData input = new InputData() {
                sprinted = true
            };

            ControllerInputData controller = new ControllerInputData();
            ControllerCharacteristics characteristics = await GetCharacteristics();

            ControllerInputProcessor.ApplyInput(
                ref controller,
                in characteristics,
                in input,
                0
            );

            Assert.That(controller.sprint == true);
        }

        [Test]
        public async void ApplyInput_Jump_True() {
            InputData input = new InputData() {
                jumped = true
            };

            ControllerInputData controller = new ControllerInputData();
            ControllerCharacteristics characteristics = await GetCharacteristics();

            ControllerInputProcessor.ApplyInput(
                ref controller,
                in characteristics,
                in input,
                0
            );

            Assert.That(controller.jump == true);
        }

        [Test]
        public async void ApplyInput_MoveNoSprint_True() {
            InputData input = new InputData() {
                cursorMovement = new float2(1f, 1f)
            };

            const float dt = 1;

            ControllerInputData controller = new ControllerInputData();
            ControllerCharacteristics characteristics = await GetCharacteristics();

            ControllerInputProcessor.ApplyInput(
                ref controller,
                in characteristics,
                in input,
                dt
            );

            Assert.That(
                controller.cursorPosition.Equals(new float2(2,2))
            );
        }

    }

}