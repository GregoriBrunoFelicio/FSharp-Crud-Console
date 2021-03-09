namespace Validations
open System

module Validations =
    
    let isANumber (s:string) =
       match Int32.TryParse s with
       | true, v -> Some v
       | false, _ -> None

