namespace TodoListGQL.Models;

[GraphQLDescription("Used to group the do list item into groups")]
public class ItemList
{
  public ItemList()
  {
    ItemDatas = new HashSet<ItemData>();
  }

  public int Id { get; set; }
  public string Name { get; set; }
  
  [UseSorting]
  public virtual ICollection<ItemData> ItemDatas { get; set; }
}