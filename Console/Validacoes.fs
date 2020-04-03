namespace Validacoes
open System

module Validacoes =
    
    let ehInteiro (s:string) =
       match System.Int32.TryParse s with
       | true, v -> Some v
       | false, _ -> None



