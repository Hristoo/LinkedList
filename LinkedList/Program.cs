using LinkedList;
using static LinkedList.DynamicList;

public class Program
{
    private static void Main(string[] args)
    {
        DynamicList shoppingList = new DynamicList();

        shoppingList.Add("Milk", 0);
        shoppingList.Add("Honey", 1);
        shoppingList.Add("Olives", 2);
        shoppingList.Add("Beer", 1);
        shoppingList.Remove(3);

        Console.WriteLine("We need to buy:");

        for (int i = 0; i < shoppingList.Count; i++)
        {
            Console.WriteLine(shoppingList[i]);         
        }

        Console.WriteLine("Do we have to buy Bread? " +

              shoppingList.Contains("Bread"));
    }
}