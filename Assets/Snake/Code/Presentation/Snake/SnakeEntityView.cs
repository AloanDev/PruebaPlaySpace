using System.Collections.Generic;
using Snake.Application.Installers;
using UnityEngine;

namespace Snake.Presentation.Snake {
	public class SnakeEntityView : MonoBehaviour {
		[SerializeField] private GameObject bodyPart;

		private List<GameObject> snakeBody;
		private Camera mainCamera;
		private Vector2 bodyPartSize;

		private void Awake() {
			snakeBody = new List<GameObject>();
			GameInstaller.snakeEntity.UpdatedPosition += SetBodyPartsPosition;
			GameInstaller.snakeEntity.AddedBodyPart += AddBodyPart;

			mainCamera = Camera.main;
			var sizeX = mainCamera.pixelWidth / (float) GameInstaller.grid.Columns;
			var sizeY = mainCamera.pixelHeight / (float) GameInstaller.grid.Rows;
			bodyPartSize = new Vector2(sizeX / 100f, sizeY / 100f);
			
			Debug.Log(mainCamera.pixelWidth);
			Debug.Log(mainCamera.pixelHeight);
			Debug.Log(bodyPartSize);

			snakeBody.Add(Instantiate(bodyPart, new Vector2(0f, 0f),
				Quaternion.identity, transform));
		}

		private void AddBodyPart() {
			snakeBody.Add(Instantiate(bodyPart, snakeBody[snakeBody.Count - 1].transform.position, Quaternion.identity,
				transform));
		}

		private void SetBodyPartsPosition() {
			var bodyPartsCount = snakeBody.Count;
			for (int i = 0; i < bodyPartsCount; i++) {
				var currentPos = GameInstaller.snakeEntity.BodyParts[i].CurrentPosition;
				snakeBody[i].transform.position =
					new Vector2((bodyPartSize.x * currentPos.x) - (mainCamera.pixelWidth / 2f) / 100f,
						(bodyPartSize.y * currentPos.y) - (mainCamera.pixelHeight / 2f) / 100f);
			}
		}

		private void OnDestroy() {
			foreach (var part in snakeBody) {
				Destroy(part);
			}

			snakeBody.Clear();
			GameInstaller.snakeEntity.UpdatedPosition -= SetBodyPartsPosition;
			GameInstaller.snakeEntity.AddedBodyPart -= AddBodyPart;
		}
	}
}