using System;
using Snake.Application.Installers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Snake.Code.Presentation.Grid {
	public class BallEntityCreator : MonoBehaviour {

		[SerializeField] private GameObject ballPrefab;
		
		private Camera mainCamera;
		private Vector2 bodyPartSize;
		private BallEntityView ballEntityView;
		
		private void Awake() {
			
			mainCamera = FindObjectOfType<Camera>();
			var sizeX = mainCamera.pixelWidth / (float) GameInstaller.grid.Columns;
			var sizeY = mainCamera.pixelHeight / (float) GameInstaller.grid.Rows;
			bodyPartSize = new Vector2(sizeX / 100f, sizeY / 100f);
		}

		private void Start() {
			CreateBall();
		}

		private void CreateBall() {
			if (gameObject == null) {
				return;
			}
			
			var columnId = Random.Range(0, GameInstaller.grid.Columns);
			var rowId = Random.Range(0, GameInstaller.grid.Rows);

			ballEntityView = Instantiate(ballPrefab, new Vector2((bodyPartSize.x * columnId) - (mainCamera.pixelWidth / 2f) / 100f,
				(bodyPartSize.y * rowId) - (mainCamera.pixelHeight / 2f) / 100f), Quaternion.identity, transform).GetComponent<BallEntityView>();
			ballEntityView.SetPosition(new Vector2Int(columnId, rowId));
			ballEntityView.Destroyed += Destroyed;
		}

		private void Destroyed() {
			ballEntityView.Destroyed -= Destroyed;
			CreateBall();
		}
	}
}