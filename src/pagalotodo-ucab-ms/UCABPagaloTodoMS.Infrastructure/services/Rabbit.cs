using Newtonsoft.Json;
using System.Text;
using RabbitMQ.Client;
using UCABPagaloTodoMS.Core.services;

namespace UCABPagaloTodoMS.Infrastructure.services;

public class Rabbit : IRabbit
{
    public async Task EnviarMensajeCola(String message)
    {
        //Aquí especificamos el servidor Rabbit MQ. usamos la imagen acoplable de rabbitmq y la usamos
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        //Cree la conexión RabbitMQ usando los detalles de la fábrica de conexiones como mencioné anteriormente
        var connection = factory.CreateConnection();

        //Aquí creamos canal con sesión y modelo.
        using var channel = connection.CreateModel();

        //declarar la cola después de mencionar el nombre y algunas propiedades relacionadas con eso
        channel.QueueDeclare("Consumidores", exclusive: false);

        //Serializar el mensaje
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        //poner los datos en la cola del Consumidor
        channel.BasicPublish(exchange: "", routingKey: "Consumidores", body: body);
    }
}
