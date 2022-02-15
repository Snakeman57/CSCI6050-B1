// Show alert when attempting to login
var alertPlaceholder = document.getElementById('alert-message')
var alertTrigger = document.getElementById('test-alert-btn')

function alert(message, type) {
    var wrapper = document.createElement('div')
    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message + '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'

    alertPlaceholder.append(wrapper)
}

if (alertTrigger) {
    alertTrigger.addEventListener('click', function () {
        alert('Incorrect login credentials! Please try again.', 'danger')
    })
} // if

// Toast popup
window.onload = (event) => {
    // let myAlert = document.querySelectorAll('.toast');
    let myAlert = document.getElementById('liveToast');
    let bsAlert = new bootstrap.Toast(myAlert);
    bsAlert.show();
}

// Toast popup with button
// var toastTrigger = document.getElementById('liveToastBtn')
// var toastLiveExample = document.getElementById('liveToast')
// if (toastTrigger) {
//   toastTrigger.addEventListener('click', function () {
//     var toast = new bootstrap.Toast(toastLiveExample)

//     toast.show()
//   })
// }