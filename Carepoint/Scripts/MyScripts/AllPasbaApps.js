    // Bendo function calls
    $(document).ready(function () {
        $("[data-bendo-checked]").bendoCheckbox({
            height: "40",
            test: function () {
            },
            uncheckedImageUrl: "/Content/Images/Glyph Icons/Unfavorite.png",
            checkedImagUrl: "/Content/Images/Glyph Icons/Favorite.png",
            postBack: {
                url: "/Home/SetFavoriteApp",
                method: "POST",
                data: function () {
                }
            },
            
        });

        var myCheckbox = $("[data-bendo-checked]").data("bendoCheckbox");
        console.log($(myCheckbox));
        $("[data-bendo-checked]").click(function (e) {
            var _checkbox = $(this);
            var checkboxData = $(this).data("bendoCheckbox");

            var pasbaApp = {
                id: _checkbox.attr("data-bendo-dataId"),
                IsFavorite: _checkbox.attr("data-bendo-checked")
            };
            checkboxData.settings.postUpdate(pasbaApp);
        });
    });
