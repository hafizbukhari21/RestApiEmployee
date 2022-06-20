function checkEmailValidity(email, messageElement_class,element_class, message) {
    let messageElement = document.querySelector(messageElement_class)
    let element = document.querySelector(element_class)
    if (!email.match(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)) {
        element.classList.remove("is-valid")
        element.classList.add("is-invalid")
        document.querySelector(".emailInsert").classList.add("is-invalid")
        messageElement.style.display = "block"
        messageElement.innerHTML = message
        return false
    } else {
        messageElement.style.display = "none"
        return true
    }
    
}

function checkLength(string, min, messageElement_class, message) {
    let messageElement = document.querySelector(messageElement_class)
    console.log(`panjhang ${string.length}`)
    if (string.length < min) {
        
        messageElement.innerHTML = message
        messageElement.style.display = "block"
        return false
    } else {
        messageElement.style.display = "none"
        return true
    }
}

function checkPassword(password, messageElement_class) {
    let messageElement = document.querySelector(messageElement_class)
    let regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+])[0-9a-zA-Z!@#$%^&*()_+]{8,}$/
    if (!password.match(regex)) {
        messageElement.innerHTML = "Minimum eight characters, at least one letter, one number and one special characte"
        messageElement.style.display = "block"
        return false
    }
    else {
        messageElement.style.display = "none"
        return true
    }


}