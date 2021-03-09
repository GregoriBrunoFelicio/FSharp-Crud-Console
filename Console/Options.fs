namespace Options
open System
open Models.Models
module Options = 
   
   let add = 
           printfn "Name"
           let name = Some (System.Console.ReadLine())

           printfn "Description"
           let description = Some (System.Console.ReadLine())
 
           printfn "Price"
           let price = Some (Decimal.Parse(System.Console.ReadLine()))

           let product = { 
              Id = 0
              Name = match name with | Some name -> name| None -> ""
              Description = description
              Price = match price with | Some price -> price| None -> (decimal)0 
              Activate = true
            }

           product

   let edit =
           printfn "Id"
           let id = Some (System.Console.ReadLine()) 

           printfn "Name"
           let name = Some (System.Console.ReadLine())

           printfn "Description"
           let description = Some (System.Console.ReadLine())
 
           printfn "Price"
           let price = Some (Decimal.Parse(System.Console.ReadLine()))

           let product = { 
              Id = 0
              Name = match name with | Some name -> name| None -> ""
              Description = description
              Price = match price with | Some price -> price| None -> (decimal)0 
              Activate = true
            }

           product

   let delete =
       printf "Id"
       let id = Some (System.Console.ReadLine()) 
       match id with 
       | Some id-> (System.Int32.Parse id)
       | None -> 0

