function DeleteFactory(id) {
	Swal.fire({
		text: "Are you sure you would like to Delete Product?",
		icon: "warning",
		showCancelButton: true,
		buttonsStyling: false,
		confirmButtonText: "Yes, Delete it!",
		cancelButtonText: "No, return",
		customClass: {
			confirmButton: "btn btn-danger",
			cancelButton: "btn btn-active-light"
		}
	}).then(function (result) {
		if (result.value) {
			$.ajax({
				url: '/Factory/DeleteProduct',
				type: 'DELETE',
				data:{ Id : id },
				success: function (response) {
					if (response.success) {
						// Show success message. For more info check the plugin's official documentation: https://sweetalert2.github.io/
						Swal.fire({
							text: response.message,
							icon: "success",
							buttonsStyling: false,
							confirmButtonText: "Ok, got it!",
							customClass: {
								confirmButton: "btn btn-primary"
							}
						}).then(function (result) {
							if (result.isConfirmed) {
								table.DataTable().ajax.reload(null, false);
							}
						});
					} else {
						Swal.fire({
							text: response.message,
							icon: "error",
							buttonsStyling: false,
							confirmButtonText: "Ok, got it!",
							customClass: {
								confirmButton: "btn btn-primary"
							}
						}).then(function (result) {
							if (result.isConfirmed) {
							}
						});
					}
				},
				error: function () {
					Swal.fire({
						text: 'Error occurred.',
						icon: "error",
						buttonsStyling: false,
						confirmButtonText: "Ok, got it!",
						customClass: {
							confirmButton: "btn btn-primary"
						}
					}).then(function (result) {
						if (result.isConfirmed) {
							modal.hide();

						}
					});
				}
			});
				
		} else if (result.dismiss === 'cancel') {
			Swal.fire({
				text: "Your form has not been cancelled!.",
				icon: "error",
				buttonsStyling: false,
				confirmButtonText: "Ok, got it!",
				customClass: {
					confirmButton: "btn btn-primary",
				}
			});
		}
	});
}