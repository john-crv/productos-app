$(document).ready(() => {

    $('#btnCrearProducto').on('click', () => {
        const nombreProducto = $('#txtNombreProducto').val();
        const descripcionProducto = $('#txtDescripcionProducto').val();
        const categoriaProducto = $('#selectCategoriaProducto option:selected').val();
        const imagenProducto = '';
        if (nombreProducto !== '' && descripcionProducto !== '') {
            if (categoriaProducto > 0) {
                const producto = { nombre: nombreProducto, descripcion: descripcionProducto, imagen: imagenProducto, idCategoria: categoriaProducto}
                $.ajax({
                    url: '/Producto/CrearProducto',
                    method: 'POST',
                    async: false,
                    data: producto,
                    success: (data) => {
                        console.log(data);
                    },
                    error: (error) => {
                        console.log(error);
                    }
                });
            } else {
                alert('Debe seleccionar una categoria');
            }
        } else {
            alert('Debe llenar los campos')
        }
    });
})