#load "./fdata.csx"

#r "Newtonsoft.Json"

using System;

using Newtonsoft.Json;

public static void Run(string myQueueItem, TraceWriter log)
{
    var data = JsonConvert.DeserializeObject<fdata>(myQueueItem);

    if(data != null)
    {
        log.Info($"DeSerialize Successful: {data.s1}");
    }
    else
    {
        log.Info($"DeSerialize failed: {myQueueItem}");
    }
}
