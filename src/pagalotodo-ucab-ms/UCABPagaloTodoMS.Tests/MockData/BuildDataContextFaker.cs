using Bogus;
using System.Diagnostics.CodeAnalysis;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Tests.MockData;

[ExcludeFromCodeCoverage]

public static class BuildDataContextFaker
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             FAKER DE VALORES
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             FAKER DE USUARIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //------------------------------------------------------------------------------------------
    //Faker de LoginUsuario

    public static LoginUsuarioRequest BuildLoginUsuarioRequest()
    {
        var data = new LoginUsuarioRequest()
        {
            usuario = "Faker1",
            password = "Faker.12"
        };
        return data;
    }

    public static List<LoginUsuarioResponse> BuildListaLoginUsuarioResponse()
    {
        var data = new List<LoginUsuarioResponse>()
        {
            new LoginUsuarioResponse()
            {
                Id= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc")
            },
        };
        return data;
    }

    //------------------------------------------------------------------------------------------
    //Faker de ConsultarUsuarios

    public static List<ConsultarUsuariosResponse> BuildListaConsultarUsuariosRequest()
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

    //------------------------------------------------------------------------------------------
    //Faker de ConsultarConsumidor

    public static Faker<ConsultarConsumidorRequest> BuildConsultarConsumidorRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<ConsultarConsumidorRequest>()
            .RuleFor(cs => cs.ci, fk => fk.Lorem.Word());
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

    //------------------------------------------------------------------------------------------
    //Faker de ConsultarPrestador

    public static Faker<ConsultarPrestadorRequest> BuildConsultarPrestadorRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<ConsultarPrestadorRequest>()
            .RuleFor(cs => cs.rif, fk => fk.Lorem.Word());
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

    //Faker de PreguntasDeSeguridad

    public static Faker<ConsultarUsuarioRequest> BuildPreguntasDeSeguridadRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<ConsultarUsuarioRequest>()
            .RuleFor(cs => cs.usuario, fk => fk.Lorem.Word());
    }

    public static List<PreguntasDeSeguridadResponse> BuildListaPreguntasDeSeguridad()
    {
        var data = new List<PreguntasDeSeguridadResponse>()
        {
            new PreguntasDeSeguridadResponse()
            {
                pregunta_de_seguridad = "PreguntaFaker1",
                pregunta_de_seguridad2 = "PreguntaFaker2"
            },
            new PreguntasDeSeguridadResponse()
            {
                pregunta_de_seguridad = "PreguntaFaker3",
                pregunta_de_seguridad2 = "PreguntaFaker4"
            },
        };
        return data;
    }

    //Faker de RecuperarClave

    public static Faker<RecuperarClaveRequest> BuildRecuperarClaveRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<RecuperarClaveRequest>()
            .RuleFor(cs => cs.usuario, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad2, fk => fk.Lorem.Word());
    }

    public static List<RecuperarClaveResponse> BuildListaRecuperarClave()
    {
        var data = new List<RecuperarClaveResponse>()
        {
            new RecuperarClaveResponse()
            {
                Id= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
                password = "passwordFaker"
            },
            new RecuperarClaveResponse()
            {
                Id= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
                password = "passwordFaker2"
            },
        };
        return data;
    }

    //Faker de AdministradorActualizarPrestador

    public static Faker<AdministradorActualizarPrestadorRequest> BuildAdministradorActualizarPrestadorRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<AdministradorActualizarPrestadorRequest>()
            .RuleFor(cs => cs.usuario, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.password, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.correo, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.nombre, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.apellido, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.preguntas_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.preguntas_de_seguridad2, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad2, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.rif, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.nombre_empresa, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.estado, fk => fk.Random.Bool());
        ;
    }
    public static Guid BuildGuidAdministradorActualizarPrestador()
    {
        var data = new AdministradorActualizarPrestadorResponse()
        {
                Id= new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
        };
        return data.Id;
    }

    //Faker de AdministradorActualizarConsumidor

    public static Faker<AdministradorActualizarConsumidorRequest> BuildAdministradorActualizarConsumidorRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<AdministradorActualizarConsumidorRequest>()
            .RuleFor(cs => cs.usuario, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.password, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.correo, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.nombre, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.apellido, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.preguntas_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.preguntas_de_seguridad2, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad2, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.ci, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.estado, fk => fk.Random.Bool());
        ;
    }
    public static Guid BuildGuidAdministradorActualizarConsumidor()
    {
        var data = new AdministradorActualizarConsumidorResponse()
        {
            Id = new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
        };
        return data.Id;
    }

    //Faker de CambiarClave

    public static Faker<CambiarClaveUsuarioRequest> BuildCambiarClaveUsuarioRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<CambiarClaveUsuarioRequest>()
            .RuleFor(cs => cs.usuario, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.password, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.newpassword, fk => fk.Lorem.Word());
        ;
    }
    public static Guid BuildGuidCambiarClaveUsuario()
    {
        var data = new AdministradorActualizarConsumidorResponse()
        {
            Id = new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
        };
        return data.Id;
    }

    //Faker de AgregarPrestador

    public static Faker<RegistrarPrestadorRequest> BuildRegistrarPrestadorRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<RegistrarPrestadorRequest>()
            .RuleFor(cs => cs.usuario, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.password, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.correo, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.nombre, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.apellido, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.preguntas_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.preguntas_de_seguridad2, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad2, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.rif, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.nombre_empresa, fk => fk.Lorem.Word());
    }
    public static Guid BuildGuidRegistrarPrestador()
    {
        var data = new AdministradorActualizarPrestadorResponse()
        {
            Id = new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
        };
        return data.Id;
    }

    //Faker de AgregarConsumidor

    public static Faker<RegistrarConsumidorRequest> BuildRegistrarConsumidorRequest()
    {
        Randomizer.Seed = new Random(100);
        return new Faker<RegistrarConsumidorRequest>()
            .RuleFor(cs => cs.usuario, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.password, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.correo, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.nombre, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.apellido, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.preguntas_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.preguntas_de_seguridad2, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.respuesta_de_seguridad2, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.ci, fk => fk.Lorem.Word());
    }
    public static Guid BuildGuidRegistrarConsumidor()
    {
        var data = new AdministradorActualizarConsumidorResponse()
        {
            Id = new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
        };
        return data.Id;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             FAKER DE SERVICIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Faker de AgregarServicio

    public static Faker<RegistrarServicioRequest> BuildRegistrarServicioRequest()
    {
        var guid = Guid.NewGuid();
        Randomizer.Seed = new Random(100);
        return new Faker<RegistrarServicioRequest>()
            .RuleFor(cs => cs.PrestadorEntityId, fk => guid)
            .RuleFor(cs => cs.nombre, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.descripcion, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.monto, fk => fk.Random.Double(0, 10000));
    }
    public static Guid BuildGuidRegistrarServicio()
    {
        var data = new RegistrarServicioResponse()
        {
            PrestadorEntityId = new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
        };
        return data.PrestadorEntityId;
    }

    //Faker de ConsultarServicios

    public static List<ConsultarServiciosResponse> BuildGuidConsultarServicios()
    {
        var data = new List<ConsultarServiciosResponse>()
        {
            new ConsultarServiciosResponse()
            {
                id_servicio = new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
                nombre = "ServicioFaker",
                monto = 20.00,
                id_prestador = new Guid(),
                nombre_prestador = "NombreFaker"
            },
            new ConsultarServiciosResponse()
            {
                id_servicio = new Guid("f1da2b25-922e-44ce-92bb-07b069b43dfc"),
                nombre = "ServicioFaker2",
                monto = 30.00,
                id_prestador = new Guid(),
                nombre_prestador = "NombreFaker2"
            },
        };
        return data;
    }

    //Faker de ActualizarServicio

    public static Faker<ActualizarServicioRequest> BuildActualizarServicioRequest()
    {
        var guid = Guid.NewGuid();
        Randomizer.Seed = new Random(100);
        return new Faker<ActualizarServicioRequest>()
            .RuleFor(cs => cs.Id, fk => guid)
            .RuleFor(cs => cs.nombre, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.descripcion, fk => fk.Lorem.Word())
            .RuleFor(cs => cs.monto, fk => fk.Random.Double(0, 10000));
    }
    public static Guid BuildGuidActualizarServicio()
    {
        var data = new ActualizarServicioResponse()
        {
            Id = new Guid("f1da2b15-922e-44ce-92bb-07b069b43dfc"),
        };
        return data.Id;
    }
}