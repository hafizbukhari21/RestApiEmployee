
let updateButton = document.querySelector(".update")

function updateData() {
    let data = {
        nik: document.querySelector(".nikForm").value,
        firstName: document.querySelector(".firstNameForm").value,
        lastName: document.querySelector(".lastNameForm").value,
        phone: document.querySelector(".phoneForm").value,
        birthDate: document.querySelector(".birthDateForm").value,
        salary: document.querySelector(".salaryForm").value
    }
    $.ajax({
        url: "https://localhost:44360/api/baseController/EmployeeControllerV2",
        type: "PATCH",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data)
    }).done(e => console.log(e)).fail(err => console.log(err))

    
    setTimeout(() => {
        table.ajax.reload()

    }, 3000)

    console.log(data)
}
    


let insertButton = document.querySelector(".insert")


window.addEventListener('load', function () {
    actionForm(document.getElementsByClassName('needs-validation'),insertData)
    actionForm(document.getElementsByClassName('needs-validation-update-form'),updateData)
}, false);

function actionForm(forms, actionApi) {
    var validation = Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault();
            event.stopPropagation();
            if (form.checkValidity() === false) {
                alert("Isi Form Belum Sesuai")
            }
            else {
                actionApi()
            }
            form.classList.add('was-validated');
        }, false);
    });
}



function insertData() {
    let data = {
        firstName: document.querySelector(".firstNameInsert").value,
        lastName: document.querySelector(".lastNameInsert").value,
        phone: document.querySelector(".phoneInsert").value,
        birthDate: document.querySelector(".birthDateInsert").value,
        salary: document.querySelector(".salaryInsert").value,
        email: document.querySelector(".emailInsert").value,
        gender: document.querySelector(".genderInsert").value,
        gpa: document.querySelector(".gpaInsert").value,
        degree: document.querySelector(".degreeInsert").value,
        password: document.querySelector(".passwordInsert").value,
        univeristyId: document.querySelector(".universityIdInsert").value,

    }

    $.ajax({
        url: "https://localhost:44360/api/baseController/EmployeeControllerV2/register" ,
        type :"POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data)
    }).done(e => console.log(e)).fail(err => console.log(err))

    console.log(data)
    setTimeout(() => {
        table.ajax.reload()
        
    }, 3000)
}

//insertButton.addEventListener("click", (e) => {
//    e.preventDefault()
    
    
    
//})
