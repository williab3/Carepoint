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
});
