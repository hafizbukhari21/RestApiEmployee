let updateButton = document.querySelector(".update")

updateButton.addEventListener("click", () => {
    let data = {
        firstName: document.querySelector(".firstNameForm").value,
        lastName: document.querySelector(".lastNameForm").value,
        email: document.querySelector(".emailForm").value,
        phone: document.querySelector(".phoneForm").value,
        birthDate: document.querySelector(".birthDateForm").value,
        salary: document.querySelector(".salaryForm").value
    }

    console.log(data)
})
