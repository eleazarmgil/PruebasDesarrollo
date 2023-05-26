//using Newtonsoft.Json;
//using RabbitMQ.Client;

//namespace UCABPagaloTodoMS.Infrastructure.Services;
//public class Rabbit
//{
//    public void SendProductMessage<T>(T message) 
//    {
//        try
//        {
//            var factory = new ConnectionFactory
//            {
//                HostName = "localhost",
//            };

//            var connection = factory.CreateConnection();

//            using var channel = connection.CreateModel();

//            channel.QueueDeclare("casita", exclusive: false);

//            var json = JsonConvert.SerializeObject(message);

//            var body = Encoding.UTF8.GetBytes(json);

//            channel.BasicPublish(exchange: "amq.topic", routingKey: "product", body: body);
//        }
//        catch (Exception ex)
//        {
//            throw ex;
//        }
//    }


//}

