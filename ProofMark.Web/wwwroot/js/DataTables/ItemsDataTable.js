var table = $('#ItemsTable');
var id = document.getElementById('Id').innerText;
$(document).ready(function () {
    table.dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Factory/GetProductItems",
            "type": "GET",
            "data": {Id:id},
            "datatype": "json",
            "error": function (xhr, error, thrown) {
                console.log(xhr.responseText); // Log the response for debugging
            },
            

        },
        "columnDefs": [{
            "targets": [0],
            "visible": true,
            "searchable": false
        }],
        "columns": [
            {
                "title": "Id",
                "data": "id",
                "name":"Id",
                "render": function (data, type, row) {
                    // Render custom HTML (for example, an Edit and Delete button)
                    return `
                        <td>
							<div class="d-flex align-items-center">
								<div class="d-flex justify-content-start flex-column">
									<a href="#" class="text-dark fw-bold text-hover-primary fs-6">${data}</a>
								</div>
							</div>
						</td>
                    `;
                },
                "orderable": true // Disable sorting on this column
            },
            {
                "title": "SerialNumber",
                "data": "serialNumber",
                "name":"SerialNumber",
                "render": function (data, type, row) {
                    // Render custom HTML (for example, an Edit and Delete button)
                    return `
                        <td>
							<div class="d-flex align-items-center">
								<div class="d-flex justify-content-start flex-column">
									<p class="text-dark fw-bold text-hover-primary fs-6">${data}</p>
								</div>
							</div>
						</td>
                    `;
                },
                "orderable": true // Disable sorting on this column
            },
            
            {
                "title": "QRCode",
                "data": null,
                "name": "QRCode",
                "render": function (data, type, row) {
                    // Render custom HTML for displaying the QR code image
                    return `
                                <img src="data:image/png;base64,${row.qrCode}" alt="QR Code ${row.qrCode}" />
                           `;
                     },
                "orderable": false // Disable sorting on this column
            },
            {
                "title": "CreatedAt",
                "data": "createdAt",
                "name": "CreatedAt",
                "render": function (data, type, row) {
                    // Render custom HTML (for example, an Edit and Delete button)

                return ` <td class="text-end">
                            <span class="badge badge-light-info fw-semibold me-1">${data} </span>
                        </td>`;

                },
                "orderable": true // Disable sorting on this column
            }
          


        ]
    });
})


