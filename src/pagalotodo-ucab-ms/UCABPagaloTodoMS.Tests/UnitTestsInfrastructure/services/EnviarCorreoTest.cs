//using Microsoft.Extensions.Logging;
//using Moq;
//using System;
//using System.Net.Mail;
//using UCABPagaloTodoMS.Core.Services;
//using Xunit;
//using UCABPagaloTodoMS.Infrastructure;
//using UCABPagaloTodoMS.Infrastructure.Correo;

//namespace UCABPagaloTodoMS.Tests.UnitTestsInfrastructure.Services;

//public class EnviarCorreoTests
//{
//    [Fact(DisplayName = "Enviar correo pasa")]
//    public void EnviaCorreoUsuario_SmtpClientSendsMail_Successfully()
//    {
//        // Arrange
//        var correoParaQuien = "destinatario@example.com";
//        var asuntoDelCorreo = "Prueba de correo";
//        var cuerpoDelMensaje = "Este es el cuerpo del mensaje de prueba";

//        var smtpClientMock = new Mock<SmtpClient>("smtp.gmail.com", 587);
//        smtpClientMock.Setup(c => c.Send(It.IsAny<MailMessage>())).Verifiable();

//        var enviarCorreo = new EnviarCorreo
//        {
//            cliente = smtpClientMock.Object
//        };

//        // Act
//        enviarCorreo.EnviaCorreoUsuario(correoParaQuien, asuntoDelCorreo, cuerpoDelMensaje);

//        // Assert
//        smtpClientMock.Verify(c => c.Send(It.IsAny<MailMessage>()), Times.Once);
//    }

//    [Fact]
//    public void EnviaCorreoUsuario_SmtpClientThrowsException_ExceptionHandled()
//    {
//        // Arrange
//        var correoParaQuien = "destinatario@example.com";
//        var asuntoDelCorreo = "Prueba de correo";
//        var cuerpoDelMensaje = "Este es el cuerpo del mensaje de prueba";

//        var smtpClientMock = new Mock<SmtpClient>("smtp.gmail.com", 587);
//        smtpClientMock.Setup(c => c.Send(It.IsAny<MailMessage>())).Throws<Exception>();

//        var loggerMock = new Mock<EnviarCorreo>();

//        var enviarCorreo = new EnviarCorreo
//        {
//            cliente = smtpClientMock.Object,
//            logger = loggerMock.Object
//        };

//        // Act
//        enviarCorreo.EnviaCorreoUsuario(correoParaQuien, asuntoDelCorreo, cuerpoDelMensaje);

//        // Assert
//        loggerMock.Verify(
//            x => x.LogError(It.IsAny<Exception>(), It.IsAny<string>()),
//            Times.Once);
//    }
//}
