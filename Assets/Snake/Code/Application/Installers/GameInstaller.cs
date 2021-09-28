using System;
using System.Collections;
using Snake.Code.Application.Input;
using Snake.Domain;
using UnityEditor;
using UnityEngine;
using Grid = Snake.Domain.Grid;

namespace Snake.Application.Installers {
	public class GameInstaller : MonoBehaviour {
		[Range(10, 100)] [SerializeField] private int columnsCount = 10;
		[Range(10, 100)] [SerializeField] private int rowsCount = 10;
		[Range(2, 5)] [SerializeField] private int initialSnakeSize = 3;
		[Range(6, 10)] [SerializeField] private int goalSnakeSize = 6;
		[Range(0.1f, 1)] [SerializeField] private float movementSpeed = 0.2f;

		private bool isGameOver;
		public static Grid grid;
		public static SnakeEntity snakeEntity;
		public static SnakeCollisionChecker snakeCollisionChecker;
		public static GridCollisionChecker gridCollisionChecker;
		public static KeyboardInput keyboardInput;
		public static float elapsedTime;

		private void Awake() {
			grid = new Grid(columnsCount, rowsCount);
			snakeEntity = new SnakeEntity(grid);
			snakeCollisionChecker = new SnakeCollisionChecker(snakeEntity);
			gridCollisionChecker = new GridCollisionChecker(grid, snakeEntity);
			keyboardInput = new KeyboardInput(snakeEntity);
		}

		private void Start() {
			snakeEntity.Init(initialSnakeSize, Vector2Int.right);
		}

		private void Update() {
			if (isGameOver) {
				return;
			}
			
			if (snakeEntity.Size == goalSnakeSize) {
				// TODO: Victory
			}
			
			keyboardInput.Tick();
			if (gridCollisionChecker.IsColliding()) {
				EditorApplication.isPlaying = false;
			}

			elapsedTime += Time.deltaTime;
			if (!(elapsedTime >= movementSpeed)) return;
			
			snakeEntity.Move();
			elapsedTime = 0f;
				
			if (snakeCollisionChecker.IsColliding()) {
				StartCoroutine(GameOver());
			}
		}

		IEnumerator GameOver() {
			isGameOver = true;
			yield return new WaitForSeconds(0.5f);
			EditorApplication.isPlaying = false;
		}
	}
}