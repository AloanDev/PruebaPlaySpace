using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Domain {
	public class SnakeEntity {
		private readonly Grid grid;

		public Action UpdatedPosition;
		public Action AddedBodyPart;
		
		public SnakeEntity(Grid grid) {
			this.grid = grid;
			BodyParts = new List<BodyPart>();
			
			var initPoint = new Vector2Int(grid.Columns / 2, grid.Rows / 2);
			var bodyPart = new BodyPart(initPoint);
			BodyParts.Add(bodyPart);
		}

		public void Init(int initialLenght, Vector2Int direction) {
			if (initialLenght <= 0) {
				throw new Exception("Snake's initial length must be bigger than 0");
			}

			MovingDirection = direction;
			Size = initialLenght;
			var initColumn = grid.Columns / 2;
			var initRow = grid.Rows / 2;

			for (int i = 1; i < initialLenght; i++) {
				var initPoint = new Vector2Int(initColumn-i, initRow);
				var bodyPart = new BodyPart(initPoint);
				BodyParts.Add(bodyPart);
				initColumn++;
				AddedBodyPart?.Invoke();
			}
		}

		public void AddTail() {
			var tail = GetTail();
			BodyParts.Add(tail);
			Size++;
			AddedBodyPart?.Invoke();
		}

		public BodyPart GetTail() {
			return BodyParts[BodyParts.Count - 1];
		}

		public BodyPart GetHead() {
			return BodyParts[0];
		}

		public void Move() {
			BodyParts[0].CurrentPosition += MovingDirection;
			int bodyPartsCount = BodyParts.Count;
			for (int i = 1; i < bodyPartsCount; i++) {
				BodyParts[i].CurrentPosition = BodyParts[i-1].PreviousPosition;
			}
			UpdatedPosition?.Invoke();
		}

		public Vector2Int MovingDirection { get; set; }
		

		public List<BodyPart> BodyParts { get; private set; }
		public int Size { get; private set; }
	}
}
