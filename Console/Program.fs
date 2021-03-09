
open Repository
open Options

[<EntryPoint>]
let main argv =

    printfn "1 - Get all \n2 - Add \n3 - Update \n4 - Delete"
    let option = Some (System.Console.ReadLine())

    match option with
    | Some option when option = "1" -> 
        Repository.getAll
        |> Seq.iter (fun product -> printfn "Nome: %s Preco: %f" product.Name product.Price)
    | Some option when option = "2" -> 
        Repository.create Options.add
    | Some option when option = "3" -> 
        Repository.edit Options.edit
    | Some option when option = "4" -> 
        Repository.delete Options.delete
    | _ -> printfn "option invalida." 
    | None -> ()

    0
