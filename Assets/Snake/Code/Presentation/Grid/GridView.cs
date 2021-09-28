using Snake.Application.Installers;
using UnityEngine;

namespace Snake.Code.Presentation.Grid {
	public class GridView : MonoBehaviour {
		private Camera mainCamera;
		private void Awake() {
			mainCamera = Camera.main;
			var sizeX = mainCamera.pixelWidth / GameInstaller.grid.Columns;
			var sizeY = mainCamera.pixelHeight / GameInstaller.grid.Rows;
		}
	}
}