using LinkedList;
using static LinkedList.DynamicList;

public class Program
{
    private static void Main(string[] args)
    {
        DynamicList shoppingList = new DynamicList();

        shoppingList.Add("Milk");
        shoppingList.Add("Honey");
        shoppingList.Add("Olives");
        shoppingList.Add("Beer");
        shoppingList.Remove(1);

        Console.WriteLine("We need to buy:");

        for (int i = 0; i < shoppingList.Count; i++)
        {
            Console.WriteLine(shoppingList[i]);         
        }

        Console.WriteLine("Do we have to buy Bread? " +

              shoppingList.Contains("Bread"));
    }
}