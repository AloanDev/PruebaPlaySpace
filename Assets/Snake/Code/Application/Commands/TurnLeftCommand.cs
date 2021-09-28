using Snake.Domain;
using Snake.Domain.Common;
using UnityEngine;

namespace Snake.Application.Commands {
	public class TurnLeftCommand : ICommand {
		private readonly SnakeEntity snake;

		public TurnLeftCommand(SnakeEntity snake) {
			this.snake = snake;
		}

		public void Execute() {
			if (snake.MovingDirection.x == 1) {
				snake.MovingDirection = Vector2Int.up;
				return;
			}

			if (snake.MovingDirection.x == 0 && snake.MovingDirection.y == -1) {
				snake.MovingDirection = Vector2Int.right;
				return;
			}

			if (snake.MovingDirection.x == 0 && snake.MovingDirection.y == 1) {
				snake.MovingDirection = Vector2Int.left;
				return;
			}

			if (snake.MovingDirection.x == -1) {
				snake.MovingDirection = Vector2Int.down;
			}
		}
	}
}