using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Vector2 areaSize;
    public float spacing;

    private void Start()
    {
        // Get the number of children objects and calculate the rows and columns needed to fit them all
        int childCount = transform.childCount;
        int rows = Mathf.CeilToInt(Mathf.Sqrt(childCount));
        int columns = Mathf.CeilToInt((float)childCount / rows);

        // Calculate the size of each cell in the grid
        float cellWidth = (areaSize.x - (spacing * (columns - 1))) / columns;
        float cellHeight = (areaSize.y - (spacing * (rows - 1))) / rows;

        // Loop through all the children objects and position them in the grid
        int childIndex = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if (childIndex >= childCount)
                {
                    break;
                }

                Transform childTransform = transform.GetChild(childIndex);
                Vector3 newPosition = new Vector3(column * (cellWidth + spacing), row * (cellHeight + spacing), 0f);
                childTransform.localPosition = newPosition;

                childIndex++;
            }
        }
    }
}