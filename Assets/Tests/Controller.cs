using NUnit.Framework;
using Unity.Mathematics;

namespace Tests {

    public class Controller {

        [Test]
        public void ApplyInput_Sprint_True() {
            InputData input = new InputData() {
                sprinted = true
            };

            ControllerInput controller = new ControllerInput();

            ControllerInputProcessor.ApplyInput(
                ref controller,
                in input,
                0
            );

            Assert.That(controller.sprint == true);
        }

        [Test]
        public void ApplyInput_Jump_True() {
            InputData input = new InputData() {
                jumped = true
            };

            ControllerInput controller = new ControllerInput();

            ControllerInputProcessor.ApplyInput(
                ref controller,
                in input,
                0
            );

            Assert.That(controller.jump == true);
        }

        [Test]
        public void ApplyInput_MoveNoSprint_True() {
            InputData input = new InputData() {
                cursorMovement = new float2(1f, 1f)
            };

            const float dt = 1;

            ControllerInput controller = new ControllerInput();

            ControllerInputProcessor.ApplyInput(
                ref controller,
                in input,
                dt
            );

            Assert.That(
                controller.cursorPosition.Equals(new float2(2,2))
            );
        }

    }

}