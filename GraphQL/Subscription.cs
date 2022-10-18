using TodoListGQL.Models;

namespace TodoListGQL.GraphQL;

public class Subscription
{
  [Subscribe]
  [Topic]
  public ItemList OnListAdded([EventMessage] ItemList list) => list;
}