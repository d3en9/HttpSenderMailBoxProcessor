namespace HttpSenderMailBoxProcessorClient

module Dto =

    //type public Message = {
    //    Url: string
    //    Json: string
    //}

    type public Message<'a> = {
        Url: string
        Param: 'a
    }