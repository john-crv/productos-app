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
                        $('#contenidoProductos').prepend(`
                             <div class="card-body">
                             <div class="card-title">${data.nombre}</div>
                            <div class="card-text">${data.descripcion}</div>
                            </div>
                        `);

                        $('#modalCrearProduto').modal('toggle');
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