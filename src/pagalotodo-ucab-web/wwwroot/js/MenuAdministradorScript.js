
// Obtener los elementos del menú y del contenido
const inicioLink = document.getElementById('inicio-link');
const usuariosLink = document.getElementById('usuarios-link');
const acercaDeLink = document.getElementById('acerca-de-link');
const archivosLink = document.getElementById('archivos-link');
const inicioContent = document.getElementById('inicio-content');
const usuariosContent = document.getElementById('usuarios-content');
const acercaDeContent = document.getElementById('acerca-de-content');
const archivosContent = document.getElementById('archivos-content');

// Función para mostrar u ocultar el submenú
function toggleMenu() {
    const subMenu = document.getElementById('subMenu');
    subMenu.classList.toggle('show');
}

// Función para deseleccionar todos los enlaces del menú
function deselectLinks() {
    inicioLink.classList.remove('selected');
    usuariosLink.classList.remove('selected');
    acercaDeLink.classList.remove('selected');
    archivosLink.classList.remove('selected');
}

// Función para ocultar todo el contenido
function hideContent() {
    inicioContent.style.display = 'none';
    usuariosContent.style.display = 'none';
    acercaDeContent.style.display = 'none';
    archivosContent.style.display = 'none';
}

// Función para mostrar el contenido correspondiente al enlace seleccionado
function showContent(content) {
    content.style.display = 'block';
}

// Event listeners para los enlaces del menú
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

// Mostrar el contenido de la sección "Inicio" por defecto
hideContent();
showContent(inicioContent);




//Abrir y cerrar el menu
function toggleMenu() {
    subMenu.classList.toggle("open-menu");
}
