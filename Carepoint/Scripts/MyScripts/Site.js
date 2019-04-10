$(document).ready(function () {
    $(".bendoCheckbox > input").click(function () {
        console.log(this);
    });
    $("#testSelect").bendoSelect({
        icon: "&#xe109;",
        direction: "down",
        width: "259px",
        placeholder: "Rest Select",
        style: {
            bootstrapTheme: {
                fileUrl: "/Content/Darkly3.3.7.css",
                useInverseTheme: true
            }
        },
        items: {
            textField: "name",
            valueField: "id",
            dataArray: [
                { name: "David", id: "1" },
                { name: "Annam", id: "2" },
                { name: "Dan", id: "3" },
                //{ name: "Crystal", id: "4" },
            ]
        }
    });

    var messanger = $.connection.messangerHub;
    console.log(messanger);
    //call FROM server
    messanger.client.broadcastmessage = function (name, message) {
        var encodedName = $('<div>').text(name).html();
        var encodedMsg = $('<div>').text(message);
        //$("#messages").append(encodedName);
        $("#incoming-messages").append(encodedMsg);
    };
    $.connection.hub.start().done(function () {
        $("#btn-sendChat").click(function (sender) {
            var senderMesaage = $("#userMessage").val();
            //call to server
            messanger.server.send("Ben", senderMesaage);
            $("#userMessage").val(" ").focus();
        });
    }).fail(function () {
        alert("Needs work...");
        });

    $("#userMessage").keydown(function (key) {
        if (key.keyCode === 13) {
            $("#btn-sendChat").click();
        }
    });

});
$("#openBtn").click(function (args) {
    //$(".grower").toggleClass("grow-large");
    var dadiv = $("#dadiv");
    dadiv.addClass("grower");
    $("#grower").append(dadiv);
    dadiv.show();
    dadiv.toggleClass("grow-large");
});

