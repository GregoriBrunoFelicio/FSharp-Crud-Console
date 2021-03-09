namespace Models

module Models = 

    type Product = 
         { 
            Id:int;
            Name:string;
            Description: Option<string>; 
            Price: decimal;
            Activate: bool 
         }


