/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class LevelGrid
{
    private Vector2Int foodGridPosition;
    private Vector2Int coinGridPosition;
    private GameObject foodGameObject;
    private GameObject coinGameObject;
    private int width;
    private int height;
    private Snake snake;
    private int eatFoodTimes;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;

        SpawnFood();
    }

    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) != -1);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    private void SpawnCoin()
    {
        do
        {
            coinGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(coinGridPosition) != -1);

        coinGameObject = new GameObject("Coin", typeof(SpriteRenderer));
        coinGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.coinSprite;
        coinGameObject.transform.position = new Vector3(coinGridPosition.x, coinGridPosition.y);
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Score.AddScore();
            eatFoodTimes++;
            if (eatFoodTimes > 3)
            {
                Object.Destroy(coinGameObject);
                SpawnCoin();
                eatFoodTimes = 0;
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TrySnakeEatCoin(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == coinGridPosition)
        {
            Object.Destroy(coinGameObject);
            Score.AddScoreCoin();
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if (gridPosition.x < 0)
        {
            gridPosition.x = width - 1;
        }

        if (gridPosition.x > width - 1)
        {
            gridPosition.x = 0;
        }

        if (gridPosition.y < 0)
        {
            gridPosition.y = height - 1;
        }

        if (gridPosition.y > height - 1)
        {
            gridPosition.y = 0;
        }

        return gridPosition;
    }
}