using UnityEngine;

namespace Snake.Domain {
	public class BodyPart {
		private Vector2Int currentPosition;

		public BodyPart(Vector2Int position) {
			currentPosition = PreviousPosition = position;
		}

		public Vector2Int CurrentPosition {
			get => currentPosition;
			set {
				if (currentPosition == value) {
					return;
				}

				PreviousPosition = currentPosition;
				currentPosition = value;
			}
		}
		
		public Vector2Int PreviousPosition { get; private set; }
	}
}