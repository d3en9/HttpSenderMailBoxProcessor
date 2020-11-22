namespace HttpSenderMailBoxProcessorClient
open Dto
open System.IO
open System
open HttpSender

module Agent =
    let httpSenderAgent: MailboxProcessor<Message<obj>> = MailboxProcessor<Dto.Message<obj>>.Start(fun inbox->

        // the message processing function
        let rec messageLoop() = async{

            // read a message
            let! msg = inbox.Receive()

            // process a message
            Post(msg) |> Async.RunSynchronously
            // loop to top
            return! messageLoop()  
            }

        // start the loop 
        messageLoop() 
    )

    let public Add (task: Dto.Message<'a>) =
        httpSenderAgent.Post task
