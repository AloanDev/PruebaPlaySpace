using System;
using Snake.Application.Installers;
using UnityEngine;

namespace Snake.Code.Presentation.Grid {
	public class BallEntityView : MonoBehaviour {

		private Vector2Int position;
		public Action Destroyed;
		private bool isTriggered;

		public void SetPosition(Vector2Int point) {
			position = point;
		}

		private void Update() {
			if (isTriggered) {
				return;
			}
			
			if (GameInstaller.snakeEntity.GetHead().CurrentPosition == position) {
				isTriggered = true;
				//GameInstaller.snakeEntity.AddedBodyPart();
				Destroy(gameObject);
			}
		}

		private void OnDestroy() {
			Destroyed?.Invoke();
		}
	}
}