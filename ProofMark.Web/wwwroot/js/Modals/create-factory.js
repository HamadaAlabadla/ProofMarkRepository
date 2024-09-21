"use strict";

// Class definition
var KTModalNewTarget = function () {
	var submitButtonFactoryCreate;
	var cancelButtonFactoryCreate;
	var validator;
	var form;
	var modal;
	var modalEl;

	// Init form inputs
	//var Form = function() {
	//	// Tags. For more info, please visit the official plugin site: https://yaireo.github.io/tagify/
	//	var tags = new Tagify(form.querySelector('[name="tags"]'), {
	//		whitelist: ["Important", "Urgent", "High", "Medium", "Low"],
	//		maxTags: 5,
	//		dropdown: {
	//			maxItems: 10,           // <- mixumum allowed rendered suggestions
	//			enabled: 0,             // <- show suggestions on focus
	//			closeOnSelect: false    // <- do not hide the suggestions dropdown once an item has been selected
	//		}
	//	});
	//	tags.on("change", function(){
	//		// Revalidate the field when an option is chosen
 //           validator.revalidateField('tags');
	//	});

	//	// Due date. For more info, please visit the official plugin site: https://flatpickr.js.org/
	//	var dueDate = $(form.querySelector('[name="due_date"]'));
	//	dueDate.flatpickr({
	//		enableTime: true,
	//		dateFormat: "d, M Y, H:i",
	//	});

	//	// Team assign. For more info, plase visit the official plugin site: https://select2.org/
 //       $(form.querySelector('[name="team_assign"]')).on('change', function() {
 //           // Revalidate the field when an option is chosen
 //           validator.revalidateField('team_assign');
 //       });
	//}
	var initForm = $(kt_modal_new_target_form);
	// Handle form validation and submittion
	var handleForm = function() {
		// Stepper custom navigation

		// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
		validator = FormValidation.formValidation(
			form,
			{
				fields: {
					target_title: {
						validators: {
							notEmpty: {
								message: 'Target title is required'
							}
						}
					},
					target_assign: {
						validators: {
							notEmpty: {
								message: 'Target assign is required'
							}
						}
					},
					target_due_date: {
						validators: {
							notEmpty: {
								message: 'Target due date is required'
							}
						}
					},
					target_tags: {
						validators: {
							notEmpty: {
								message: 'Target tags are required'
							}
						}
					},
					'targets_notifications[]': {
                        validators: {
                            notEmpty: {
                                message: 'Please select at least one communication method'
                            }
                        }
                    },
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap5({
						rowSelector: '.fv-row',
                        eleInvalidClass: '',
                        eleValidClass: ''
					})
				}
			}
		);

		// Action buttons
		submitButtonFactoryCreate.addEventListener('click', function (e) {
			e.preventDefault();

			// Validate form before submit
			if (validator) {
				validator.validate().then(function (status) {
					console.log('validated!');

					if (status == 'Valid') {
						submitButtonFactoryCreate.setAttribute('data-kt-indicator', 'on');

						// Disable button to avoid multiple click 
						submitButtonFactoryCreate.disabled = true;

						setTimeout(function() {
							submitButtonFactoryCreate.removeAttribute('data-kt-indicator');

							// Enable button
							submitButtonFactoryCreate.disabled = false;

							var model = {
								Email: $('#Email').val(),
								CompanyName: $('#CompanyName').val(),
								Address: $('#Address').val(),
								PhoneNumber: $('#phone_number').val(),
								Password: $('#Password').val()
							};

							$.ajax({
								url: '/Admin/CreateFactory',
								type: 'POST',
								data: model,
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
												modal.hide();
												
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
												modal.hide();

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



							

							//form.submit(); // Submit form
						}, 2000);   						
					} else {
						// Show error message.
						Swal.fire({
							text: "Sorry, looks like there are some errors detected, please try again.",
							icon: "error",
							buttonsStyling: false,
							confirmButtonText: "Ok, got it!",
							customClass: {
								confirmButton: "btn btn-primary"
							}
						});
					}
				});
			}
		});

		cancelButtonFactoryCreate.addEventListener('click', function (e) {
			e.preventDefault();

			Swal.fire({
				text: "Are you sure you would like to cancel?",
				icon: "warning",
				showCancelButton: true,
				buttonsStyling: false,
				confirmButtonText: "Yes, cancel it!",
				cancelButtonText: "No, return",
				customClass: {
					confirmButton: "btn btn-primary",
					cancelButton: "btn btn-active-light"
				}
			}).then(function (result) {
				if (result.value) {
					form.reset(); // Reset form	
					modal.hide(); // Hide modal				
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
		});
	}

	return {
		// Public functions
		init: function () {
			// Elements
			modalEl = document.querySelector('#kt_modal_new_target');

			if (!modalEl) {
				return;
			}

			modal = new bootstrap.Modal(modalEl);

			form = document.querySelector('#kt_modal_new_target_form');
			submitButtonFactoryCreate = document.getElementById('kt_modal_FactoriesTable_submit');
			cancelButtonFactoryCreate = document.getElementById('kt_modal_FactoriesTable_cancel');

			//initForm();
			handleForm();
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTModalNewTarget.init();
});