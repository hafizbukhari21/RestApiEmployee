
let updateButton = document.querySelector(".update")

//Update
function updateData() {
  
    let data = {
        nik: document.querySelector(".nikForm").value,
        firstName: document.querySelector(".firstNameForm").value,
        lastName: document.querySelector(".lastNameForm").value,
        phone: document.querySelector(".phoneForm").value,
        birthDate: document.querySelector(".birthDateForm").value,
        salary: document.querySelector(".salaryForm").value,
        email: document.querySelector(".emailForm").value,
       
    }
  
    $.ajax({
        url: "https://localhost:44360/api/baseController/EmployeeControllerV2/withPost",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data)
    }).done(e => {
        console.log(e)
        Swal.fire('Berhasil Update Data!', '', 'success')
    }).fail(err => console.log(err))

    
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
                
            }
            else {

                actionApi()

            }
            form.classList.add('was-validated');
        }, false);
    });
}


//Insert
function insertData() {
    
 
    let data = {
        firstName: document.querySelector(".firstNameInsert").value,
        lastName: document.querySelector(".lastNameInsert").value,
        phone: document.querySelector(".phoneInsert").value,
        birthDate: document.querySelector(".birthDateInsert").value,
        salary: document.querySelector(".salaryInsert").value,
        email: document.querySelector(".emailInsert").value,
        gender: document.querySelector(`input[name="genderInsert"]:checked`).value,
        gpa: document.querySelector(".gpaInsert").value,
        degree: document.querySelector(".degreeInsert").value,
        password: document.querySelector(".passwordInsert").value,
        univeristyId: document.querySelector(".universityIdInsert").value,

    }

    console.log(data)

    if (
        checkEmailValidity(
            data.email,
            ".emailfeedbackInsert",".emailInsert",
            "Please Reformat your Email address"
        ) && checkPassword(data.password,".passwordFeedbackInsert")
    ) {
        loading.style.display = "flex"
            $.ajax({
                url: "https://localhost:44319/api/Employee/custom",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(data)
            }).done(e => {
                loading.style.display = "none"
                Swal.fire('Berhasil Menambahkan Data', '', 'success')
                console.log(e)
            }).fail(err => console.log(err))

            console.log(data)
            setTimeout(() => {
                table.ajax.reload()
            }, 3000)
       }

   
}

//insertButton.addEventListener("click", (e) => {
//    e.preventDefault()
    
    
    
//})
