using System.Data.SqlTypes;
using UnityEngine;

public class Statics : MonoBehaviour
{
    public static System.Random randyTheRandom = new();
    public static void ReadStatement(string statement)
    {
        FindFirstObjectByType<DialogueManager>().ReadDescription(statement);
    }
    public static int FlipACoin()
    {
        int result = Random.Range(0, 2);
        return result;
    }
    public static int RollADice(int whichDice)
    {
        int result = 0;
        //d4
        if (whichDice == 0)
        {
            result = Random.Range(1, 5);
        }
        //d6
        if (whichDice == 1)
        {
            result = Random.Range(1, 7);
        }
        //d8
        if (whichDice == 2)
        {
            result = Random.Range(1, 9);
        }
        //d12
        if (whichDice == 3)
        {
            result = Random.Range(1, 13);
        }
        //d20
        if (whichDice == 4)
        {
            result = Random.Range(1, 21);
        }
        return result;
    }
    //public static void UpdateGraph(GameObject gameObject)
    //{
    //    Collider2D collider = gameObject.GetComponent<Collider2D>();
    //    if (collider != null)
    //    {
    //        Bounds bounds = collider.bounds;
    //        AstarPath.active.UpdateGraphs(bounds);
    //    }
    //}
}
