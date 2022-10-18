using HotChocolate.Subscriptions;
using TodoListGQL.Data;
using TodoListGQL.Models;

namespace TodoListGQL.GraphQL;

public class Mutation
{
  public record AddListPayload(ItemList list);
  public record AddListInput(string name);
  public record AddItemInput(string title, string description, bool done, int listId);
  public record AddItemPayload(ItemData item);

  // this attribute will help us utilise the multi threaded api db context
  [UseDbContext(typeof(ApiDbContext))]
  public async Task<AddListPayload> AddListAsync(
    AddListInput input, 
    [ScopedService] ApiDbContext context,
    [Service] ITopicEventSender eventSender,
    CancellationToken cancellationToken)
  {
    var list = new ItemList
    {
      Name = input.name
    };

    context.Lists.Add(list);
    await context.SaveChangesAsync(cancellationToken);

    // we emit our subscription
    await eventSender.SendAsync(nameof(Subscription.OnListAdded), list, cancellationToken);

    return new AddListPayload(list);
  }
  
  [UseDbContext(typeof(ApiDbContext))]
  public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] ApiDbContext context)
  {
    var item = new ItemData
    {
      Description = input.description,
      Done = input.done,
      Title = input.title,
      ListId = input.listId
    };

    context.Items.Add(item);
    await context.SaveChangesAsync();

    return new AddItemPayload(item);
  }

}