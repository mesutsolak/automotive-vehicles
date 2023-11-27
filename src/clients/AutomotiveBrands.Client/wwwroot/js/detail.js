$(document).ready(function () {
    var checkboxMappings = {
        "option-a4": "8W",
        "option-a3": "8Y",
        "option-a5": "F5",
        "option-a6": "4A",
        "option-a7": "4K",
        "option-a8": "4N",
        "option-q2": "GA",
        "option-q3": "F3",
        "option-q5": "FY",
        "option-q7": "4M",
        "option-q8": "E4",
        "option-q8-etron": "GE",
        "option-etron-gt": "F8"
    };

    var currentPagePath = window.location.pathname.replace(/^\//, '');

    Object.keys(checkboxMappings).forEach(function (checkboxId) {
        var targetUrlPart = checkboxMappings[checkboxId];
        if (currentPagePath.endsWith("/" + targetUrlPart)) {
            $("#" + checkboxId).prop("checked", true);
            if (targetUrlPart === "GE") {
                $(".model_logo").css("font-size", "80px");
            }
            else if (targetUrlPart === "F8") {
                $(".model_logo").css("font-size", "51px");
            }
            else {
                $(".model_logo").css("font-size", "");
            }
        }
    });

    $("input[type='checkbox']").on("change", function () {
        var checkboxId = $(this).attr("id");
        var newUrlPart = checkboxMappings[checkboxId];

        $("input[type='checkbox']").not(this).prop("checked", false);

        if (newUrlPart) {
            var newUrl = "/" + currentPagePath.replace(/\/[^/]*$/, "/" + newUrlPart);
            window.location.href = newUrl;
        }
    });

    $('.owl-carousel').owlCarousel({
        loop: false,
        margin: 10,
        nav: true,
        dots: false,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            1200: {
                items: 3
            }
        }
    });
});