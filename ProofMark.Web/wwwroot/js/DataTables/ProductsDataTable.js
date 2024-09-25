var table = $('#ProductsTable');
$(document).ready(function () {
    table.dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Factory/GetFactoryProducts",
            "type": "GET",
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
                "title": "Name",
                "data": "name",
                "name":"Name",
                "render": function (data, type, row) {
                    // Render custom HTML (for example, an Edit and Delete button)
                    return `
                        <td>
							<div class="d-flex align-items-center">
								<div class="d-flex justify-content-start flex-column">
									<a href="/Factory/#" class="text-dark fw-bold text-hover-primary fs-6">${data}</a>
								</div>
							</div>
						</td>
                    `;
                },
                "orderable": true // Disable sorting on this column
            },
            
            {
                "title": "Description",
                "data": "description",
                "name":"Description",
                "render": function (data, type, row) {
                    // Render custom HTML (for example, an Edit and Delete button)
                    return `
                        <td>
							<p  class="text-dark fw-bold text-hover-primary d-block fs-6">${data}</p>
						</td>
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
            },
            
            {
                "title": "IsDelete",
                "data": "isDelete",
                "name": "IsDelete",
                "render": function (data, type, row) {
                    // Render custom HTML (for example, an Edit and Delete button)
                    if (!data) {
                        return ` <td class="text-end">
                                    <span class="badge badge-light-info fw-semibold me-1">No </span>
                                </td>`;
                    } else {
                        return `<td class="text-end">
                                    <span class="badge badge-light-danger fw-semibold me-1"> Yes </span>
                                </td>` ;
                    }
                },
                "orderable": true // Disable sorting on this column
            },
            {
                "title": "Actions",
                "data": null,
                "render": function (data, type, row) {
                    // Render custom HTML (for example, an Edit and Delete button)
                    return `
                        <td>
								<a href="#" onclick="DeleteFactory(${row.id})" class="btn btn-icon btn-bg-light btn-active-color-primary btn-sm">
									<!--begin::Svg Icon | path: icons/duotune/general/gen027.svg-->
									<span class="svg-icon svg-icon-3">
										<svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
											<path d="M5 9C5 8.44772 5.44772 8 6 8H18C18.5523 8 19 8.44772 19 9V18C19 19.6569 17.6569 21 16 21H8C6.34315 21 5 19.6569 5 18V9Z" fill="currentColor" />
											<path opacity="0.5" d="M5 5C5 4.44772 5.44772 4 6 4H18C18.5523 4 19 4.44772 19 5V5C19 5.55228 18.5523 6 18 6H6C5.44772 6 5 5.55228 5 5V5Z" fill="currentColor" />
											<path opacity="0.5" d="M9 4C9 3.44772 9.44772 3 10 3H14C14.5523 3 15 3.44772 15 4V4H9V4Z" fill="currentColor" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</a>
							</div>
						</td>
                    `;
                },
                "orderable": false // Disable sorting on this column
            }


        ]
    });
})


