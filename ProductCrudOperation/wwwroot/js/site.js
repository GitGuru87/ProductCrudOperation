//$(document).ready(function () {
//    // Handle Delete Form Submission
//    $('#deleteForm').on('submit', function (e) {
//        e.preventDefault();

//        const productName = $(this).data('product-name'); // Get product name from data attribute
//        if (confirm(`Are you sure you want to delete the product "${productName}"?`)) {
//            $.ajax({
//                type: 'POST',
//                url: $(this).attr('action'),
//                data: $(this).serialize(),
//                success: function (response) {
//                    if (response.success) {
//                        alert('Data deleted successfully!');
//                        window.location.href = $('#deleteForm').data('redirect-url'); // Redirect URL from data attribute
//                    } else {
//                        alert('Delete failed: ' + response.message);
//                    }
//                },
//                error: function (xhr, status, error) {
//                    console.log("Error:", xhr.responseText);
//                    alert('An error occurred while deleting the data.');
//                }
//            });
//        }
//    });

//    // Handle Add Form Submission
//    $(document).ready(function () {
//        $('#productForm').on('submit', function (e) {
//            e.preventDefault();

//            if ($(this).valid()) {
//                $.ajax({
//                    type: 'POST',
//                    url: $(this).attr('action'),
//                    data: $(this).serialize(),
//                    success: function (response) {
//                        alert('Data added successfully!');
//                        window.location.href = '@Url.Action("Add", "Product")';
//                    },
//                    error: function (xhr, status, error) {
//                        console.log("Error:", xhr.responseText);
//                        alert('An error occurred while adding the data.');
//                    }
//                });
//            } else {
//                $('.text-danger').show();
//            }
//        });
//    });

//    // Handle Update Form Submission
//    $('#updateForm').on('submit', function (e) {
//        e.preventDefault();

//        if ($(this).valid()) {
//            $.ajax({
//                type: 'POST',
//                url: $(this).attr('action'),
//                data: $(this).serialize(),
//                success: function (response) {
//                    if (response.success) {
//                        alert('Data updated successfully!');
//                        window.location.href = response.redirectUrl || '@Url.Action("Index", "Product")'; // Use the URL from the response or default to Index
//                    } else {
//                        alert('Update failed: ' + response.message);
//                    }
//                },
//                error: function (xhr, status, error) {
//                    console.log("Error:", xhr.responseText);
//                    alert('An error occurred while updating the data.');
//                }
//            });
//        } else {
//            $('.text-danger').show(); // Display validation errors
//        }
//    });
//});
