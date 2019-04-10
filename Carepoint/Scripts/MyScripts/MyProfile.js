$("#editCarePointName-btn").click(function (args) {
    $(".CarepointName").toggle();
    
});

$("#editPhone-btn").click(function (args) {
    $(".PhoneNumber").toggle();
    
});

$("#editDSNPhone-btn").click(function (args) {
    $(".DSNPhone").toggle();
    
});

$("#editBio-btn").click(function (args) {
    $("#Bio").toggle();
    $("#bioMessage").toggle();
});

$("#profilePic").click(function (args) {
    $("#fileUploader").click();
});

$("#fileUploader").change(function (args) {
    var selectedFile = this.files[0];
    var filePath = $(this).val();
    var extension = filePath.split('.').pop();
    if (extension === "png" || extension === "gif" || extension === "jpeg" || extension === "jpg") {
        var picImg = $("#profilePic");
        var reader = new FileReader();
        reader.onload = function (args) {
            picImg.attr("src", args.target.result);
        };
        reader.readAsDataURL(selectedFile);
        //picImg.attr("src", selectedFile);
        $("#fileWarning").hide();
    } else {
        $("#fileWarning").show();
    }
});