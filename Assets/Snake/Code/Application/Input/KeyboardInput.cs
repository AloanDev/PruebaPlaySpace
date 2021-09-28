using Snake.Application.Commands;
using Snake.Domain;
using Snake.Domain.Common;
using UnityEngine;

namespace Snake.Code.Application.Input {
	public class KeyboardInput : IInputable, ITickable {

		private ICommand turnLeftCommand;
		private ICommand turnRightCommand;
		
		public KeyboardInput(SnakeEntity snake) {
			turnLeftCommand = new TurnLeftCommand(snake);
			turnRightCommand = new TurnRightCommand(snake);
		}
		
		public void Tick() {
			if (IsTurningLeft()) {
				turnLeftCommand.Execute();
				return;
			}

			if (IsTurningRight()) {
				turnRightCommand.Execute();
			}
		}

		private bool IsTurningLeft() => UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow);
		private bool IsTurningRight() => UnityEngine.Input.GetKeyDown(KeyCode.RightArrow);
	}
}