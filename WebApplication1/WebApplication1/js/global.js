function doFirst() {

    window.addEventListener("dragenter", function (e) { e.preventDefault(); }, false);
    window.addEventListener("dragleave", function (e) { e.preventDefault(); }, false);
    window.addEventListener("dropped", function (e) { e.preventDefault(); }, false);
    window.addEventListener("dragover", function (e) { e.preventDefault(); }, false);
    

    dropzone = document.getElementById('dropzone');
    dropzone.addEventListener("drop", dropped, false);
    dropzone.addEventListener("dragover", dragover, false);
    dropzone.addEventListener("dragleave", dragleave, false);
    dropzone.addEventListener("dragenter", function (e) { e.preventDefault(); }, false);
}

var dropzone = "dropzone";
function upload(files) {
    //console.log(files);
    var formData = new FormData(),
    xhr = new XMLHttpRequest(),
    x;
    for (x = 0; x < files.length; x = x + 1)
    {
        formData.append('file[]', files[x]);
    }
    xhr.onload = function () {
        var data = this.responseText;
        //alert(formData)
        console.log(formData)
    }
    xhr.open('post', 'Handler1.ashx');
    
    xhr.send(formData);
}


function dropped(e) {
    dropzone.ondrop = function (e) {
        e.preventDefault();
        this.className = 'dropzone';
        //console.log(e.dataTransfer.files);
        upload(e.dataTransfer.files);
    };
}
function dragover(e) {
    dropzone.ondragover = function () {
        e.preventDefault();
        this.className = 'dropzone dragover';
        return false;
    };
}
function dragleave(e) {
    dropzone.ondragleave = function () {
        e.preventDefault();
        this.className = 'dropzone';
        return false;
    };
}
window.addEventListener("load", doFirst, false);

//document.body.addEventListener('drop', function (e) {
//    e.preventDefault();
//}, false);

//window.addEventListener("dragenter", function (e) {
//    if (e.target.id != dropzone) {
//        e.preventDefault();
//        e.dataTransfer.effectAllowed= false;
//        e.dataTransfer.dropEffect = "none";
//    }
//}, false);

//window.addEventListener("dragover", function (e) {
//    if (e.target.id != dropzone) {
//        e.preventDefault();
//        e.dataTransfer.effectAllowed = "none";
//        e.dataTransfer.dropEffect = "none";
//    }
//});

//window.addEventListener("drop", function (e) {
//    if (e.target.id != dropzoneId) {
//        e.preventDefault();
//        e.dataTransfer.effectAllowed = "none";
//        e.dataTransfer.dropEffect = "none";
//    }
//});












