namespace Snake.Domain {
	public class GridCollisionChecker {
		private readonly Grid grid;
		private readonly SnakeEntity snakeEntity;

		public GridCollisionChecker(Grid grid, SnakeEntity snakeEntity) {
			this.grid = grid;
			this.snakeEntity = snakeEntity;
		}

		public bool IsColliding() {
			var headPosition = snakeEntity.GetHead().CurrentPosition;
			if (headPosition.x >= grid.Columns || headPosition.x < 0) {
				return true;
			}

			if (headPosition.y >= grid.Rows || headPosition.y < 0) {
				return true;
			}

			return false;
		}
	}
}