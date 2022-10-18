using TodoListGQL.Data;
using TodoListGQL.Models;

namespace TodoListGQL.GraphQL;

public class Query
{
  // Will return all of our todo list items
  // We are injecting the context of our dbConext to access the db
  [UseDbContext(typeof(ApiDbContext))]
  [UseFiltering]
  [UseSorting]
  public IQueryable<ItemData> GetItems([ScopedService] ApiDbContext context)
  {
    return context.Items;
  }
  
  [UseDbContext(typeof(ApiDbContext))]
  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<ItemList> GetLists([ScopedService] ApiDbContext context)
  {
    return context.Lists;
  }

}