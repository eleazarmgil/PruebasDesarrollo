
// Obtener los elementos del men� y del contenido
const inicioLink = document.getElementById('inicio-link');
const usuariosLink = document.getElementById('usuarios-link');
const acercaDeLink = document.getElementById('acerca-de-link');
const archivosLink = document.getElementById('archivos-link');
const inicioContent = document.getElementById('inicio-content');
const usuariosContent = document.getElementById('usuarios-content');
const acercaDeContent = document.getElementById('acerca-de-content');
const archivosContent = document.getElementById('archivos-content');
const botonBuscar = document.getElementById('buscar-boton');
const imagenUsuario = document.getElementById('user-pic');
// Funci�n para mostrar u ocultar el submen�
function toggleMenu() {
    const subMenu = document.getElementById('subMenu');
    subMenu.classList.toggle('show');
}

// Funci�n para deseleccionar todos los enlaces del men�
function deselectLinks() {
    inicioLink.classList.remove('selected');
    usuariosLink.classList.remove('selected');
    acercaDeLink.classList.remove('selected');
    archivosLink.classList.remove('selected');
}

// Funci�n para ocultar todo el contenido
function hideContent() {
    inicioContent.style.display = 'none';
    usuariosContent.style.display = 'none';
    acercaDeContent.style.display = 'none';
    archivosContent.style.display = 'none';
}

// Funci�n para mostrar el contenido correspondiente al enlace seleccionado
function showContent(content) {
    content.style.display = 'block';
}

// Event listeners para los enlaces del men�
inicioLink.addEventListener('click', () => {
    deselectLinks();
    inicioLink.classList.add('selected');
    hideContent();
    showContent(inicioContent);
});

usuariosLink.addEventListener('click', () => {
    deselectLinks();
    usuariosLink.classList.add('selected');
    hideContent();
    showContent(usuariosContent);
});

acercaDeLink.addEventListener('click', () => {
    deselectLinks();
    acercaDeLink.classList.add('selected');
    hideContent();
    showContent(acercaDeContent);
});

archivosLink.addEventListener('click', () => {
    deselectLinks();
    archivosLink.classList.add('selected');
    hideContent();
    showContent(archivosContent);
});

imagenUsuario.addEventListener('click', () => {
    toggleMenu();
});

function buscarPorNombre() {
    // Obtener el valor del campo de entrada de texto
    var nombre = document.getElementById("buscar-nombre").value.toLowerCase();

    // Obtener todas las filas de la tabla
    var filas = document.getElementById("tabla-usuarios").getElementsByTagName("tr");

    // Recorrer todas las filas de la tabla, excepto la fila de encabezado
    for (var i = 1; i < filas.length; i++) {
        var fila = filas[i];
        var nombreUsuario = fila.getElementsByTagName("td")[1].textContent.toLowerCase();

        // Ocultar o mostrar la fila seg�n si el nombre coincide con la b�squeda
        if (nombreUsuario.indexOf(nombre) > -1) {
            fila.style.display = "";
        } else {
            fila.style.display = "none";
        }
    }
}


// Funciones para la busqueda en las Tablas
botonBuscar.addEventListener('click', () => {
    buscarPorNombre();
});











// Mostrar el contenido de la secci�n "Inicio" por defecto
hideContent();
showContent(inicioContent);




//Abrir y cerrar el menu
function toggleMenu() {
    subMenu.classList.toggle("open-menu");
}
