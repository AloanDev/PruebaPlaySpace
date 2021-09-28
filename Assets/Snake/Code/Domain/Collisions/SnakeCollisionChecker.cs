namespace Snake.Domain {
	public class SnakeCollisionChecker {
		private readonly SnakeEntity snakeEntity;

		public SnakeCollisionChecker(SnakeEntity snakeEntity) {
			this.snakeEntity = snakeEntity;
		}

		public bool IsColliding() {
			var headPosition = snakeEntity.GetHead().CurrentPosition;
			for (int i = 1; i < snakeEntity.BodyParts.Count; i++) {
				if (headPosition == snakeEntity.BodyParts[i].CurrentPosition) {
					return true;
				}
			}

			return false;
		}
	}
}