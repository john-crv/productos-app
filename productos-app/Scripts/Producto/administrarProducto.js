$(document).ready(function () {

    var productoEditar = null;

    $('.btnEliminarProducto', '#contenidoProductos').on('click', function () {
        const id = $(this).attr('id');
        const resp = confirm('Desea eliminar el producto?');
        if (resp) {
            $.ajax({
                url: `/Producto/EliminarProducto/${id}`,
                method: 'DELETE',
                async: false,
                success: (data) => {
                    if (data) {
                        $(`#cardProducto-${id}`).remove();
                    }
                },
                error: (error) => {
                    console.log(error);
                },
            });
        }
    
    });

    $('#btnModalEditarProducto').on('click', function () {
        const nombreProducto = $('#txtEditarNombreProducto').val();
        const descripcionProducto = $('#txtEditarDescripcionProducto').val();
        const categoriaProducto = $('#selectEditarCategoriaProducto option:selected').val();
        const imagenProducto = '';
        if (nombreProducto !== '' && descripcionProducto !== '') {
            if (categoriaProducto > 0) {
                const producto = { nombre: nombreProducto, descripcion: descripcionProducto, imagen: imagenProducto, idCategoria: categoriaProducto }
                $.ajax({
                    url: `/Producto/EditarProducto/${productoEditar.id}`,
                    method: 'PUT',
                    async: false,
                    data: producto,
                    success: (data) => {
                        $(`#cardProducto-${productoEditar.id}`).html(`
                         <div class="card mb-3" style="width: 18rem;">
                             <div class="card-body">
                             <div class="card-title"><strong>${nombreProducto}</strong></div>
                            <div class="card-text mb-2">${descripcionProducto}</div>
                            <button class="btn btn-danger btnEliminarProducto" id="${producto.id}">Eliminar</button>
                            <button class="btn btn-info btnEditarProducto" id="${producto.id}">Editar</button>
                            </div>
                            </div>
                        `);

                        $('#modalEditarProducto').modal('hide');
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

    $('.btnEditarProducto', '#contenidoProductos').on('click', function () {
        const idEditarProducto = $(this).attr('id');
        if (idEditarProducto != null && idEditarProducto != "") {
            $.ajax({
                url: `GetProducto/${idEditarProducto}`,
                method: 'GET',
                async: false,
                success: (data) => {
                    data = JSON.parse(data);
                    $('#txtEditarNombreProducto').val('asdas');
                    $('#txtEditarDescripcionProducto').val(data.descripcion)
                    $('#selectEditarCategoriaProducto').val(data.idCategoria);
                    productoEditar = data;
                }
            });
        }
        $('#modalEditarProducto').modal('show');
    });

    $('#btnCrearProducto').on('click', () => {
        const nombreProducto = $('#txtNombreProducto').val().trim();
        const descripcionProducto = $('#txtDescripcionProducto').val().trim();
        const categoriaProducto = $('#selectCategoriaProducto option:selected').val().trim();
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
                        data = JSON.parse(data);
                        $('#contenidoProductos').prepend(`
                               <div class="card mb-3" style="width: 18rem;">
                             <div class="card-body">
                             <div class="card-title"><strong>${data.nombre}</strong></div>
                            <div class="card-text mb-2">${data.descripcion}</div>
                            <button class="btn btn-danger btnEliminarProducto" id="${data.id}">Eliminar</button>
                            <button class="btn btn-info btnEditarProducto" id="${data.id}">Editar</button>
                            </div>
                            </div>
                            <br />`);
                        $('#modalCrearProduto').modal('hide');
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