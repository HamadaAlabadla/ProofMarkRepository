// script.js file

function domReady(fn) {
    if (
        document.readyState === "complete" ||
        document.readyState === "interactive"
    ) {
        setTimeout(fn, 1000);
    } else {
        document.addEventListener("DOMContentLoaded", fn);
    }
}

domReady(function () {

    // If found you qr code
    function onScanSuccess(decodeText, decodeResult) {
       // alert("You Qr is : " + decodeText, decodeResult);
        // Assuming you're using jQuery for simplicity
        $.ajax({
            url: '/ProductVerification/VerifyProduct', // Adjust URL to your controller and action
            type: 'POST', // or 'GET' depending on your needs
            data: { QRCodeText: decodeText }, // Adjust data as needed
            dataType: 'json',
            success: function (response) {
                if (response.success) {
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
                        }
                    });
                } else {
                    Swal.fire({
                        title: "Warning!", // Title of the alert
                        text: "Fake product detected! " + response.message, // Custom message
                        icon: "warning", // Icon type
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!", // Text for the confirm button
                        customClass: {
                            confirmButton: "btn btn-primary" // Custom class for styling the confirm button
                        }
                    }).then(function (result) {
                        if (result.isConfirmed) {
                            // Add any additional actions you want to take after the user confirms
                            console.log("User acknowledged the warning about the fake product.");
                            // For example, redirect to another page or reload the current page
                            // location.reload(); or window.location.href = '/some-url';
                        }
                    });
                }
            },
            error: function (xhr, status, error) {
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
    }

    let htmlscanner = new Html5QrcodeScanner(
        "my-qr-reader",
        { fps: 10, qrbos: 250 }
    );
    htmlscanner.render(onScanSuccess);
});
