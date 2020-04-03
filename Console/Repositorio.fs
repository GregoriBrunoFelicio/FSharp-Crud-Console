
namespace Repository
open FSharp.Data.Sql
open Modelos.Modelos 

module Repository =

    [<Literal>]
    let connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=EstudoFSharp"

    type sql = SqlDataProvider<Common.DatabaseProviderTypes.MSSQLSERVER, connectionString>

    let contexto = sql.GetDataContext();

    let obterTodos = 
         query {
             for c in contexto.Dbo.Produto do
             where (c.Ativo)
             select c
          }

    let obterPorId id =
        query {
             for c in contexto.Dbo.Produto do
                where (c.Id = id)
                select c
                exactlyOneOrDefault
        }
        
    let criar (produto: Produto) =
        try
          contexto.Dbo.Produto.Create(
             Nome = produto.Nome, 
             Descricao = produto.Descricao.Value, 
             Preco = produto.Preco, 
             Ativo = produto.Ativo) |> ignore
          contexto.SubmitUpdates()
        with
            ex -> printf "ERROR: %s" ex.Message

    let editar (produto: Produto) =
        try
          let p = Some(obterPorId produto.Id)
          match p with
          | Some p -> 
              p.Nome <- produto.Nome
              p.Descricao <- produto.Descricao.Value
              p.Preco <- produto.Preco
              p.Ativo <- produto.Ativo
              contexto.SubmitUpdates()
          | None -> ()  
        with
            ex -> printf "ERROR: %s" ex.Message

    let remover id =
        try
            let p = Some(obterPorId id)
            match p with
            | Some p ->
                p.Delete() 
                contexto.SubmitUpdates()
            | None -> ()
        with
            ex -> printf "ERROR: %s" ex.Message
            



