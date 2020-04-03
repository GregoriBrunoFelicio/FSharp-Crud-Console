
open Repository
open Opcoes

[<EntryPoint>]
let main argv =

    printfn "1 - Ver todos \n2 - Adicionar \n3 - Atualizar \n4 - Remover"
    let opcao = Some (System.Console.ReadLine())

    match opcao with
    | Some opcao when opcao = "1" -> 
        Repository.obterTodos
        |> Seq.iter (fun produto -> printfn "Nome: %s Preco: %f" produto.Nome produto.Preco)
    | Some opcao when opcao = "2" -> 
        Repository.criar Opcoes.adicionar
    | Some opcao when opcao = "3" -> 
        Repository.editar Opcoes.atualizar
    | Some opcao when opcao = "4" -> 
        Repository.remover Opcoes.remover
    | _ -> printfn "Opcao invalida." 
    | None -> ()

    0
