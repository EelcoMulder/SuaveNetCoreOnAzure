open System.Net
open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

let appWebPart =
  choose
    [ GET >=> choose
        [ path "/hello" >=> OK "Hello F#.Net Core 2.0 with Suave running as Azure App Service" ] ]

let getPort argv =
  match Array.length argv with
    | 0 -> 8080us
    | _ -> argv.[0] |> uint16

[<EntryPoint>]
let main argv =

  let conf =
    { defaultConfig with
            bindings = [ HttpBinding.create HTTP IPAddress.Loopback <| getPort argv ] }

  startWebServer conf  appWebPart
  0
