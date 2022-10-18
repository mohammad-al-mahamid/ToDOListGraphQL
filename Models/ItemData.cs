namespace TodoListGQL.Models;
[GraphQLDescription("Used to define todo item for a specific list")]
public class ItemData
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }

  [GraphQLDescription("If the user has completed this item")]
  public bool Done { get; set; }

  [GraphQLDescription("The list which this item belongs to")]
  public int ListId { get; set; }

  [UseSorting()]
  public virtual ItemList ItemList { get; set; }
}