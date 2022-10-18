# ToDOListGraphQL
GraphQl with asp .net core 6 

resource : https://dev.to/moe23/net-5-api-with-graphql-step-by-step-2b20 

endpoint: https://localhost:7132/graphQL/
Documentation endpoint : https://localhost:7132/graphql-voyager 
query {
  items{
    id
    title
    listId
  }
}

query{
  items
  {
    id
    title
  }
}

query {
  a:items{
    id
    title
  }
  b:items{
    id
    title
  }
   c:items{
    id
    title
  }
}

query{
  lists{
    name
     itemDatas {
      id
      title
    }
  }
}


query {
  lists(where: {id: {eq: 1} })
  {
    id
    name
    itemDatas {
      title
    }
  }
}

query{
  lists(order: {name: DESC})
  {
    id
    name
  }
}

mutation{
  addList(input: {
    name: "drink"
  })
  {
    list
    {
      name
    }
  }
}



mutation{
  addItem(input: {
    title: "Bring laptop",
    description: "Bring the laptop with charger",
    done: true,
    listId: 1
  })
  {
    item
    {
      id
      title
    }
  }
}

## TO DO Migration

dotnet ef migrations add "Initial Migrations"

## TO Update the Database

dotnet ef database update

## Path

https://localhost:7262/graphQL/ 