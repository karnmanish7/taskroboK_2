//This function should validate Task Titlte which should allow only alpha numerals
//and should also display error message in a <p> element with id as 'titleMsg'

var isValidated = false;
var isCategoryValidated = false;
function validateTitle() {
    debugger;
    isValidated = false;
    var contentValue = $('#TaskTitle').val().trim();
    if (contentValue === '') {
        $('#titleMsg').html('Task Title Can not be empty')
        return;
    }
    if (contentValue.length > 50) {
        $('#titleMsg').html('Task Title can not be more than 50')
        return;
    }

    isValidated = true;
}

//This function checks if taskContent is not empty and length is not more 50 characters
//and also displays error message in a <p> element with id as 'contentMsg'
function validateContent() {
    isValidated = false;
    var contentValue = $('#TaskContent').val().trim();
    if (contentValue === '') {
        $('#contentMsg').html('Task Content Can not be empty')
        return;
    }
    if (contentValue.length > 50) {
        $('#contentMsg').html('Task Content can not be more than 50')
        return;
    }
    isValidated = true;
}

//This function checks if taskStatus is not empty and length is not more 10 characters
//and also displays error message in a <p> element with id as 'statusMsg'
function validateStatus() {

    isValidated = false;
    var taskStatus = $('#TaskStatus').val().trim();

    if (taskStatus === '') {
        $('#statusMsg').html('Task Status Can not be empty')
        return;
    }
    if (taskStatus.length > 10) {
        $('#statusMsg').html('Task Status can not be more than 10')
        return;
    }
    isValidated = true;
}

//This function checks if Category is selected or not. Category is mandatory
//and also displays error message in a <p> element with id as 'categoryMsg'
// It should also prevents the form to submit, if category is not selected.
function validateForm(event) {
    validateTitle();
    validateContent();
    validateStatus()
    var taskCategory = $('#CategoryID').val()

    if (isValidated == false) {
        event.preventDefault()
    }
    if (taskCategory === '') {
        event.preventDefault()
        $('#categoryMsg').html('Task Category Can not be empty');
        return;
    }
}
$(function () {
    debugger;
    const form = document.getElementById('task');
    form.addEventListener('submit', validateForm);

    $("#TaskTitle").change(validateTitle);

    $("#TaskStatus").change(validateStatus);
    $("#TaskContent").change(validateContent);

})


//validating category
//$(function () {
//    debugger;
//    const form = document.getElementById('category');
//    form.addEventListener('submit', validateCategoryForm);

//    $("#CategoryTitle").change(validateCategoryTitle);

//})

//function validateCategoryTitle() {
//    debugger;
//    isCategoryValidated = false;
//    var categoryContentValue = $('#CategoryTitle').val().trim();
//    if (categoryContentValue === '') {
//        $('#titleMsg').html('Category Title Can not be empty')
//        return;
//    }
//    //isCategoryValidated = true;
//}

//function validateCategoryForm(event) {
//    debugger;
//    validateCategoryTitle();
    
//}

//$(function () {
//    console.log('adding form validation');

//    $("form[name='task']").validate({
//         Specify validation rules
//        rules: {
//             The key name on the left side is the name attribute
//             of an input field. Validation rules are defined
//             on the right side
//            TaskTitle: "required",
//            TaskStatus: "required",

//            TaskContent: {
//                required: true,
//                minlength: 5
//            }
//        },
//         Specify validation error messages
//        messages: {
//            TaskTitle: "Please enter your firstname",
//            TaskStatus: "Please enter your TaskStatus",
//            TaskContent: {
//                required: "Please provide a TaskContent",
//                minlength: "Your TaskContent must be at least 5 characters long"
//            },

//        },
//         Make sure the form is submitted to the destination defined
//         in the "action" attribute of the form when valid
//        submitHandler: function (form) {
//            form.submit();
//        }
//    });

//})