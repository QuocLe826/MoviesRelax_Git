function uploadImage(event) {
    var image = document.getElementById('display-image');
    image.src = URL.createObjectURL(event.target.files[0]);
}

function setActiveMenu() {
    var menu = document.getElementsByClassName("menu");
    var btns = menu.getElementsByClassName("menu-link");
    for (var i = 0; i < btns.length; i++) {
        btns[i].addEventListener("click", function () {
            var current = document.getElementsByClassName("active");
            current[0].className = current[0].className.replace(" active", "");
            this.className += " active";
        });
    }
}