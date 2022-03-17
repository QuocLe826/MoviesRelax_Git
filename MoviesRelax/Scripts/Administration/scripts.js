function uploadImage(event) {
    var image = document.getElementById('display-image');
    image.src = URL.createObjectURL(event.target.files[0]);
}
