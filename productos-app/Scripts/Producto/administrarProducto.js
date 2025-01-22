﻿$(document).ready(function(){
    $('.btnEliminarProducto').on('click', function () {
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

    $('.btnEditarProducto').on('click', function () {
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
                }
            });
        }
        $('#modalEditarProducto').modal('toggle');
    });

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