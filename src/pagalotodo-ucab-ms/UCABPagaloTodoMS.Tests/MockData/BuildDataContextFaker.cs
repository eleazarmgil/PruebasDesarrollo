using Bogus;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Tests.MockData;

public static class BuildDataContextFaker
{
    //Faker de Valores

    public static Faker<ValoresRequest> BuildValoresRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<ValoresRequest>()
            .RuleFor(cs => cs.Nombre, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.Apellido, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.Identificacion, fk => fk.Lorem.Word());
    }


    public static List<ValoresResponse> BuildListaValores()
    {
        var data = new List<ValoresResponse>()
        {
            new ValoresResponse()
            {
                Nombre = "BETZY DEL CARMEN ALMANZA ADAMES",
                Identificacion = "PN8388-1",
                Id= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc")
            },
            new ValoresResponse()
            {
                Nombre = "ADNAN MAURICIO QUIEL TIJERINO",
                Identificacion = "PP103-2019",
                Id= new Guid("33b6653b-128d-4178-bb89-5fd77d2164b6")
            },
            new ValoresResponse()
            {
                Nombre = "AILYN NICOLE WU MONTERREY",
                Identificacion = "PP045-2019",
                Id= new Guid("c2d0efa5-c36a-4ef8-8741-c16972d5db83")
            }
        };
        return data;
    }

    //Faker de LoginUsuario

    public static Faker<LoginUsuarioRequest> BuildLoginUsuarioRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<LoginUsuarioRequest>()
            .RuleFor(cs => cs.usuario, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.password, fk => fk.Lorem.Word());
    }

    public static List<LoginUsuarioResponse> BuildListaLoginUsuario()
    {
        var data = new List<LoginUsuarioResponse>()
        {
            new LoginUsuarioResponse()
            {
                Id= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc")
            },
            new LoginUsuarioResponse()
            {

                Id= new Guid("33b6653b-128d-4178-bb89-5fd77d2164b6")
            }
        };
        return data;
    }
    //Faker de ConsultarUsuarios
    public static List<ConsultarUsuariosResponse> BuildListaConsultarUsuarios()
    {
        var data = new List<ConsultarUsuariosResponse>()
        {
            new ConsultarUsuariosResponse()
            {
                id_usuario= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
                usuario = "Faker1",
                correo = "Faker1@gmail.com",
                nombre = "Faker1",
                estado = true,
                Discriminator = "PrestadorEntity"
            },
            new ConsultarUsuariosResponse()
            {
                id_usuario= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
                usuario = "Faker2",
                correo = "Faker2@gmail.com",
                nombre = "Faker2",
                estado = true,
                Discriminator = "ConsumidorEntity"
            },
        };
        return data;
    }

    //Faker de ConsultarConsumidor

    public static Faker<ConsultarConsumidorRequest> BuildConsultarConsumidorRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<ConsultarConsumidorRequest>()
            .RuleFor(cs => cs.ci, fk => fk.Random.Number(99999, 90000000));
    }

    public static List<ConsultarConsumidorResponse> BuildListaConsultarConsumidor()
    {
        var data = new List<ConsultarConsumidorResponse>()
        {
            new ConsultarConsumidorResponse()
            {
                Id= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc")
            },
            new ConsultarConsumidorResponse()
            {
                Id= new Guid("33b6653b-128d-4178-bb89-5fd77d2164b6")
            }
        };
        return data;
    }

    //Faker de ConsultarPrestador

    public static Faker<ConsultarPrestadorRequest> BuildConsultarPrestadorRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<ConsultarPrestadorRequest>()
            .RuleFor(cs => cs.rif, fk => fk.Random.Number(99999, 90000000));
    }

    public static List<ConsultarPrestadorResponse> BuildListaConsultarPrestador()
    {
        var data = new List<ConsultarPrestadorResponse>()
        {
            new ConsultarPrestadorResponse()
            {
                Id= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc")
            },
            new ConsultarPrestadorResponse()
            {
                Id= new Guid("33b6653b-128d-4178-bb89-5fd77d2164b6")
            }
        };
        return data;
    }
}