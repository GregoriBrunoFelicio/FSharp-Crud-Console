namespace Repository
open FSharp.Data.Sql
open Models.Models 

module Repository =

    [<Literal>]
    let connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=FsharpDb"

    type sql = SqlDataProvider<Common.DatabaseProviderTypes.MSSQLSERVER, connectionString>

    let context = sql.GetDataContext();

    let getAll = 
         query {
             for c in context.Dbo.Product do
             where (c.Active)
             select c
          }

    let getById id =
        query {
             for c in context.Dbo.Product do
                where (c.Id = id)
                select c
                exactlyOneOrDefault
        }
        
    let create (product: Product) =
        try
          context.Dbo.Product.Create(
             Name = product.Name,
             Description = match product.Description with | Some p -> p | None -> "",
             Price = product.Price,
             Activate = product.Activate) |> ignore
          context.SubmitUpdates()
        with
            ex -> printf "ERROR: %s" ex.Message

    let edit (product: Product) =
        try
          let p = Some(getById product.Id)
          match p with
          | Some p -> 
                 p.Name <- product.Name
                 Description <- match product.Description with | Some p -> p | None -> ""
                 p.Price <- product.Price
                 p.Activate <- product.Activate
                 context.SubmitUpdates()
          | None -> ()  
        with
            ex -> printf "ERROR: %s" ex.Message

    let delete id =
        try
            let p = Some(getById id)
            match p with
            | Some p ->
                p.Delete() 
                context.SubmitUpdates()
            | None -> ()
        with
            ex -> printf "ERROR: %s" ex.Message
