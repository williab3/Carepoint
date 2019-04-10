//Bendo Grid
$.fn.bendoGrid = function (args) {
    let defaultSettings = $.extend(true, {
        read: {
            data: {}
        },
        columns: [
            { title: "column 1", dataField: "", width: "30%" },
            { title: "column 2", dataField: "", width: "30%" },
            { title: "column 3", dataField: "", width: "30%" },
        ],
        style: {
            hover: true,
            bordered: false,
            class: ["table"],
            bootstrapTheme: {
                fileUrl: "",
                useInverseTheme: false,
            }
        },
    }, args);
    if (args.columns !== null) {
        defaultSettings.columns = args.columns;
    }
    console.log(defaultSettings);

    //Process grid arguments
    if (defaultSettings.style.hover === true) {
        defaultSettings.style.class.push("table-hover");
    }
    if (defaultSettings.style.bordered === true) {
        defaultSettings.style.class.push("table-bordered");
    }
    if ($.inArray("table", defaultSettings.style.class) < 0) {
        defaultSettings.style.class.push("table");
    }

    //Make Grid
    let grid = $("<table>").html($("<thead>").html($("<tr>")));
    let gridHead = grid.find("thead");
    let gridBody = $("<tbody>");
    gridBody.insertAfter(gridHead);
    $.each(defaultSettings.style.class, function (index, cssClass) {
        grid.addClass(cssClass);
    });
    //Make title row
    $.each(defaultSettings.columns, function (index, column) {
        grid.find("thead>tr").append($("<th>").text(column.title).attr("width", column.width));
    });
    // Set styles
    if (defaultSettings.style.bootstrapTheme.fileUrl !== "" && defaultSettings.style.bootstrapTheme.useInverseTheme === true) {
        $.get(defaultSettings.style.bootstrapTheme.fileUrl, function (data) {
            var inverseClassSearch = /navbar-inverse\s+{(\s|\n)(^.*;\n)+}/m;
            var classResult = data.match(inverseClassSearch);
            var bgColorSearch = /(background-color:)\s+(#+(\d|\w){3,10})/;
            var bgColorResult = classResult[0].match(bgColorSearch);
            gridHead.css("background-color", bgColorResult[2]);
            var colorSearch = /\.navbar-inverse\s?\.navbar-text\s?{\n(.*;\n)+}/;
            var colorClass = data.match(colorSearch);
            var textColor = colorClass[0].match(/(color:\s?)(#?(\d|\w){3,10})/);
            console.log(textColor);
            gridHead.css("color", textColor[2]);
        }, "text");
    }

    //Get the click actions
    if (defaultSettings.rowClick) {
        var rowClick = defaultSettings.rowClick;
    }
    //Make rows 
    var gridData = defaultSettings.read.data;
    for (var i = 0; i < gridData.length; i++) {
        var row = $("<tr>");
        
        $(row).attr("data-bendo-id", gridData[i][defaultSettings.read.idField]);
        //Get the data field  columns
        var columns = defaultSettings.columns;
        $(columns).each(function (index, _column) {
            //Make a <td> for each column
            var td = $("<td>").attr("data-bendo-field", _column.dataField);
            row.append(td);

            //Check if a custom template is used
            if (typeof _column.format == "undefined") {
                console.log("set up standard format row");
            }
            else {
                var ltemTemplate;
                var linkAction = false;
                //Get custom template
                var template = _column.format;
                //Bind template fields with the appropriate data items.
                var search = /(%#(\d|\w|\.)*#%)/g;
                var dataItems = template.match(search);
                $.each(dataItems, function (index, item) {
                    var subString = item.replace(/%#data./, "").replace(/#%/, "");
                    template = template.replace(new RegExp(item), gridData[i][subString]);
                });
                //Set the link to the click action
                for (var clickIndex = 0; clickIndex < rowClick.itemClick.length; clickIndex++) {
                    if (rowClick.itemClick[clickIndex].field == _column.dataField && rowClick.itemClick[clickIndex].id == gridData[i][defaultSettings.read.idField]) {
                        linkAction = rowClick.itemClick[clickIndex].action();
                    } 
                }
                //Add template to table cell
                if (linkAction) {
                    ltemTemplate = linkAction.replace(search, template);
                    td.html(ltemTemplate);
                    linkAction = false;
                } else {
                    td.html(template);
                }

                //$(rowClick.itemClick).each(function (rowIndex, dataClickItem) {
                //    if (dataClickItem.field == _column.dataField && dataClickItem.id == gridData[i][defaultSettings.read.idField]) {
                //        linkAction = dataClickItem.action();
                //        var linkTemplate = linkAction.replace(search, template);
                //        td.html(linkTemplate);
                //        return false;
                //    } else {
                //        td.html(template);
                //        return false;
                //    }
                //});
            }
            gridBody.append(row);
        });

    }
    this.append(grid);
};

//Bendo Checkbox
$.fn.bendoCheckbox = function (args) {
    var defaultSettings = $.extend({
        setCheck: "",
        height: "25",
        postUpdate: function (args) {
            $.ajax({
                method: this.postBack.method,
                url: this.postBack.url,
                data: args
            });
        }
    }, args);
    this.settings = new function () {
        return defaultSettings;
    };
    this.each(function (i, element) {
        var dataChecked = $(element).attr("data-bendo-checked");
        if (defaultSettings.setCheck === "true" || dataChecked === "true") {
            $(element).attr("data-bendo-checked", "true");
            $(element).addClass("bendoCheckbox").addClass("text-center");
            let holder = $("<div>").addClass("checkbox-holder");
            let checkedImg = $("<img>").attr("height", defaultSettings.height).attr("data-bendo-display", "show").attr("src", defaultSettings.checkedImagUrl).addClass("checkedImg");
            holder.append(checkedImg);
            let uncheckedImg = $("<img>").attr("height", defaultSettings.height).attr("data-bendo-display", "").attr("src", defaultSettings.uncheckedImageUrl).addClass("uncheckedImg");
            holder.append(uncheckedImg);
            $(element).prepend(holder);
        } else {
            $(element).addClass("bendoCheckbox").addClass("text-center");
            let holder = $("<div>").addClass("checkbox-holder");
            let checkedImg = $("<img>").attr("height", defaultSettings.height).attr("data-bendo-display", "").attr("src", defaultSettings.checkedImagUrl).addClass("checkedImg");
            holder.append(checkedImg);
            let uncheckedImg = $("<img>").attr("height", defaultSettings.height).attr("data-bendo-display", "show").attr("src", defaultSettings.uncheckedImageUrl).addClass("uncheckedImg");
            holder.append(uncheckedImg);
            $(element).prepend(holder);
        }
    });
    this.data("bendoCheckbox", this);
    this.click(function (e, sender) {
        var _attribute = $(this).attr("data-bendo-checked");
        if (_attribute == "true") {
            $(this).attr("data-bendo-checked", "");
            let checkedImg = $(this).find("img.checkedImg");
            checkedImg.attr("data-bendo-display", "");
            let uncheckedImg = $(this).find("img.uncheckedImg");
            uncheckedImg.attr("data-bendo-display", "show");
        } else {
            $(this).attr("data-bendo-checked", "true");
            let checkedImg = $(this).find("img.checkedImg");
            checkedImg.attr("data-bendo-display", "show");
            let uncheckedImg = $(this).find("img.uncheckedImg");
            uncheckedImg.attr("data-bendo-display", "");
            }
    });
};
//Bendo Select list
$.fn.bendoSelect = function (args) {
    let defaultSettings = $.extend(true, {
        placeholder: "Placeholder",
        direction: "down",
        width: "230px",
        id: this.attr("id"),
        style: {
            bootstrapTheme: {
                fileUrl: "",
                useInverseTheme: false,
            }
        }
    }, args);
    this.attr("id", defaultSettings.id + "-bendoSelect").width(defaultSettings.width);
    let mySelect = this;
    let selectContainer = $("<div>").addClass("bendo-select").width(defaultSettings.width);

    // Set styles
    var bgColorResult;
    var textColor;
    if (defaultSettings.style.bootstrapTheme.fileUrl !== "" && defaultSettings.style.bootstrapTheme.useInverseTheme === true) {
        $.get(defaultSettings.style.bootstrapTheme.fileUrl, function (data) {
            let inverseClassSearch = /navbar-inverse\s+{(\s|\n)(^.*;\n)+}/m;
            let classResult = data.match(inverseClassSearch);
            let bgColorSearch = /(background-color:)\s+(#+(\d|\w){3,10})/;
            bgColorResult = classResult[0].match(bgColorSearch);
            mySelect.css("background-color", bgColorResult[2]);
            let colorSearch = /\.navbar-inverse\s?\.navbar-text\s?{\n(.*;\n)+}/;
            let colorClass = data.match(colorSearch);
            textColor = colorClass[0].match(/(color:\s?)(#?(\d|\w){3,10})/);
            console.log(textColor);
            mySelect.css("color", textColor[2]);
        }, "text");
    }
    //Set custom icon
    if (defaultSettings.icon) {
        let icon = $("<span>").html(defaultSettings.icon).addClass("icon");

        selectContainer.append(icon);
    }

    let body = $("<div>").attr("id", defaultSettings.id + "-selectBody").width(defaultSettings.width).css("position", "relative");
    let selectPlacholder = $("<p>").text(defaultSettings.placeholder);
    body.prepend(selectPlacholder);
    selectContainer.append(body);
    let chevron = $("<span>").addClass("chevron").html("&#xe114;");
    selectContainer.append(chevron);
    this.append(selectContainer);

    //Add select option items
    let selectOptions = $("<div>").width(defaultSettings.width).addClass("selectOptions").css("max-height", "0px").attr("id", defaultSettings.id + "-bendoSlectList");
    let optionsContainer = $("<div>");
    let dataItems = $(defaultSettings.items.dataArray);
    dataItems.each(function (index, item) {
        let listItem = $("<div>").attr("data-select-value", item[defaultSettings.items.valueField]).addClass("bendo-selectItem");
        listItem.hover(function (args) {
            listItem.css("background-color", bgColorResult[2]).css("color", textColor[2]);
        }, function (args) {
            listItem.removeAttr("style");
            });
        var contents = $("<p>").text(item[defaultSettings.items.textField]);
        listItem.click(function (args) {
            selectPlacholder.text(contents.text());
            mySelect.focusout();
        });
        listItem.html(contents);
        selectOptions.prepend(listItem);
        selectOptions.append(optionsContainer);
    });
    body.append(selectOptions);
    //Set open direction
    if (defaultSettings.direction === "down") {
        selectOptions.addClass("bendo-dropdown");
    } else {
        selectOptions.addClass("bendo-dropup");
        //body.prepend(selectOptions);
    }
    $(this).attr("tabindex", '0');

    this.click(function (args) {
        this.focus();
        selectOptions.css("max-height", "500px").css("padding", "5px 3px 0px 5px");
        chevron.css("transform", "rotate(180deg)").css("padding", "0px");
        $("#bendoSlectList").show();
    });

    this.focusout(function (args) {
        selectOptions.css("max-height", "0px").css("padding", "0px");
        chevron.css("transform", "rotate(0deg)");
        $("#bendoSlectList").hide();
    });

};

//Bendo Instant Messenger
$.fn.bendoMessanger = function (args) {
    let defaultSettings = $.extend(true, {
        placeholder: "Placeholder",
    }, args);
    this.addClass("incoming-messages");
    var contactList = $("<div>").addClass("message-selector").attr("id", "bendo-messengerSelect");
    let bendoMessenger = this;
    contactList.bendoSelect({
        icon: "&#xe008;",
        direction: "up",
        width: "265px",
        placeholder: defaultSettings.placeholder,
        style: {
            bootstrapTheme: {
                fileUrl: "/Content/Darkly3.3.7.css",
                useInverseTheme: true
            }
        },
        items: {
            textField: defaultSettings.contactList.textField,
            valueField: defaultSettings.contactList.valueField,
            dataArray: defaultSettings.contactList.dataArray
        }
    });
    this.append(contactList);
    var messegeBox = $("<div>").attr("id", "bendo-messegeBox").addClass("messageBox").scrollTop(50);
    this.append(messegeBox);
    var messageInputContainer = $("<div>").attr("id", "input-container").css("display", "flex").css("position", "fixed");
    var messageTexbox = $("<input>").attr("type", "text").width("230px").attr("id", "userMessage");
    messageInputContainer.append(messageTexbox);
    var sendButton = $("<button>").addClass("btn").addClass("btn-primary").addClass("btn-sm").attr("type", "button").attr("id", "btn-sendChat");
    var icon = $("<span>").addClass("glyphicon").addClass("glyphicon-send");
    sendButton.html(icon);
    messageTexbox.keydown(function (args) {
        if (args.keyCode === 13) {
            sendButton.click();
        }
    });
    sendButton.click(function (args) {
        var iM = $("<p>").text("Ben");
        messegeBox.append(iM);
    });
    messageInputContainer.append(sendButton);
    this.append(messageInputContainer);
};
