var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax":{
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "price", "width": "20%" },
            { "data": "category.name", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class = "w-75 btn-group" role = "group">
                        <a href="/Admin/Product/Upsert?id=${data}"  class = "btn btn-primary mx-2"> 
                            <i class="bi bi-pencil-square"></i> &nbsp; Змінити </a>
                        <a onClick = Delete('/Admin/Product/Delete/${data}')  class = "btn btn-danger mx-2">
                            <i class="bi bi-trash3"></i> &nbsp; Видалити </a>
                    </div>

                        `
                },
                "width": "20%"
            },
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Ви впевнені, що хочете видалити?',
        text: "Ви не зможете повернути назад !!!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Так',
        cancelButtonText: 'Скасувати'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toasrt.success(data.message);
                    }
                    else {
                        toasrt.error(data.message);
                    }
                }

            })
        }
    })
}