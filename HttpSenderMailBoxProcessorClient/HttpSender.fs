namespace HttpSenderMailBoxProcessorClient
open Dto
open System.Net.Http
open Newtonsoft.Json
open System.Text


module HttpSender =
    
    let PostAsync (client:HttpClient, url:string, param:obj): Async<Result<string,string>> =
        async {
            let json = JsonConvert.SerializeObject(param)
            use content = new StringContent(json, Encoding.UTF8, "application/json")
            let! response = client.PostAsync(url, content) |> Async.AwaitTask
            let! body = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            return match response.IsSuccessStatusCode with 
            | true -> Ok body
            | false -> Error body
        }

    let public Post (message:Dto.Message<obj>) =
        async {
            let url = message.Url
            use httpClient = new System.Net.Http.HttpClient()

            let! result = PostAsync(httpClient, message.Url, message.Param)

            match result with
            | Ok message -> printfn "Succsess request"
            | Error err -> printfn "Failed request: %s" err
        }