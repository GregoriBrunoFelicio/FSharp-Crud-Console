
namespace Opcoes
open Modelos.Modelos
open System
module Opcoes = 
   
   let adicionar = 
           printfn "Nome"
           let nome = Some (System.Console.ReadLine())

           printfn "Descricao"
           let descricao = Some (System.Console.ReadLine())
 
           printfn "Preco"
           let preco = Some (Decimal.Parse(System.Console.ReadLine()))

           let produto = { 
              Id = 0
              Nome = nome.Value  
              Descricao = Some(descricao.Value)
              Preco = preco.Value
              Ativo = true
           }

           produto

   let atualizar =
           printfn "Id"
           let id = Some (System.Console.ReadLine()) 

           printfn "Nome"
           let nome = Some (System.Console.ReadLine())

           printfn "Descricao"
           let descricao = Some (System.Console.ReadLine())
 
           printfn "Preco"
           let preco = Some (Decimal.Parse(System.Console.ReadLine()))

           let produto = { 
              Id = System.Int32.Parse id.Value
              Nome = nome.Value  
              Descricao = Some(descricao.Value)
              Preco = preco.Value
              Ativo = true
           }

           produto

   let remover =
       printf "Id"
       let id = Some (System.Console.ReadLine()) 
       System.Int32.Parse id.Value 

