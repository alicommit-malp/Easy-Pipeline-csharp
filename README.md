# Easy pipeline in c#
If you want to create a pipeline looks like MiddleWares in the Dotnet core you should use the chain of responsibility design pattern. To ease the implementation I have created a [Nuget](https://www.nuget.org/packages/EasyPipeLine) library in order to easily create a pipeline for your application by using the chain of responsibility and builder patterns together.

>Find the source code [here](https://github.com/alicommit-malp/Easy-PipeLine)

Let's say we are going to handle the logic of a coffee shop, the steps are 
* Taking the customer's order 
* receiving the payment 
* making the coffee 

Therefore you can write something simple like this 

```c#

var order = new OrderData()
{
    Name = "Coffee",
    State = "None"
};

await new Pipeline()
    .Next(new ExceptionHandler())
    .Next(new OrderHandler())
    .Next(new CheckoutHandler())
    .Next(new ProducingHandler())
    .Run(order);
```

In above scenario the order object will travel through all the handlers starting from the ExceptionHandler and then OrderHandler and so on.

The order object must implement the IPipelineData interface 
```c#
public class OrderData : IPipelineData
{
    public string Name { get; set; }
    public string State { get; set; }
}
```
and every WorkStation must inherit from WorkStation abstract class
```c#
public class OrderWorkStation : WorkStation
{
    protected override async Task InvokeAsync(IPipelineData data)
    {
        if(!(data is OrderData order)) throw new ArgumentNullException();
        
        order.State = nameof(OrderHandler);
        
        Console.WriteLine($"State:{nameof(OrderHandler)} objectState: " +
                          $"{JsonConvert.SerializeObject(order)}");

        //call the next workstation in the pipeline 
        await base.InvokeAsync(data);
    }
}
```

>Find the nuget [here](https://www.nuget.org/packages/EasyPipeLine)

>Find the source code [here](https://github.com/alicommit-malp/Easy-PipeLine)


