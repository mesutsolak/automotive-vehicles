let vehicleTypes = [];
let vehiclePrices = [];
let vehicleVats = [];
let vehicleExciseDuties = [];
let spinnerVisible = false;

$(function () {
    owlCarousel();
});

$("#ModelDetail button").click(function () {
    $('html,body').animate({
        scrollTop: $("#detail-info").offset().top
    },
        'slow');
})

$(document).on('click change', '.sub-models', function () {
    let isModelChecked = $(this).closest("div").prev().find("input[name='rdModel']").is(":checked");

    if (!isModelChecked)
        $(this).closest("div").prev().find("input[name='rdModel']").prop("checked", true);

    let path = "/vehicledetail/" + $(this).val();

    showProgress();

    $.get(path, function (data) {
        $(".model_name").html(data.modelDescription);
        $(".model-price-text").html(data.price);
        $(".model-fuel-combined").html(data.fuelConsumption);
        $(".model-co2-emission").html(data.cO2);
        $("#Adetail-model").html(data.modelDescription);
        $("#Adetail-engine").html(data.engine);
        $(".Adetail-volume-text").html(data.engineCapacity);
        $("#Adetail-msrp .first-column").html(data.price);
        $("#Adetail-net .first-column").html(data.netPrice);
        $("#Adetail-otv .first-column").html(data.exciseDuty);
        $("#Adetail-vat .first-column").html(data.vat);
        $("#Adetail-mtv").html(data.motorVehicleTax);
        $("#Adetail-otv-rate").html(data.exciseDutyRate);
        $("#Adetail-plate-expense").html(data.trafficRegistrationOfficialFee);
        $("#Adetail-service-expense").html(data.trafficRegistrationServiceFee);
    }).done(function () {
        $("#loader-wrapper").hide();

        hideProgress();
    });
});

$(document).on('change', "input[name='rdModel']", function () {
    $(this).closest("div").next().find(".sub-models option:first").prop('selected', true).trigger('change');
});

$(document).on("click", ".vehicle-type-filter", function () {
    let isChecked = $(this).is(':checked');

    let vehicleType = $(this).val();

    if (isChecked) {
        vehicleTypes.push(vehicleType);
    }
    else {

        let vehicleTypeIndex = vehicleTypes.indexOf(vehicleType);

        if (vehicleTypeIndex === -1)
            return;

        vehicleTypes.splice(vehicleTypeIndex, 1);
    }

    applyFilter();
});

$(document).on("click", ".net-price-filter", function () {
    let isChecked = $(this).is(':checked');

    let vehiclePrice = $(this).val();

    if (isChecked) {
        vehiclePrices.push(vehiclePrice);
    }
    else {
        let vehiclePriceIndex = vehiclePrices.indexOf(vehiclePrice);

        if (vehiclePriceIndex === -1)
            return;

        vehiclePrices.splice(vehiclePriceIndex, 1);
    }

    applyFilter();
});

$(document).on("click", ".vat-filter", function () {
    let isChecked = $(this).is(':checked');

    let vehicleVat = $(this).val();

    if (isChecked) {
        vehicleVats.push(vehicleVat);
    }
    else {
        let vehicleVatIndex = vehicleVats.indexOf(vehicleVat);

        if (vehicleVatIndex === -1)
            return;

        vehicleVats.splice(vehicleVatIndex, 1);
    }

    applyFilter();
});

$(document).on("click", ".excise-duty-filter", function () {
    let isChecked = $(this).is(':checked');

    let vehicleExcideDuty = $(this).val();

    if (isChecked) {
        vehicleExciseDuties.push(vehicleExcideDuty);
    }
    else {
        let vehicleExcideDutyIndex = vehicleExciseDuties.indexOf(vehicleExcideDuty);

        if (vehicleExcideDutyIndex === -1)
            return;

        vehicleExciseDuties.splice(vehicleExcideDutyIndex, 1);
    }

    applyFilter();
});

function applyFilter() {

    let queryString = "";
    let baseUrl = window.location.origin + "/partial/vehicledetail";
    let vehicleIdQueryString = "?vehicleId=" + $("#vehicleid").val();

    $.each(vehiclePrices, function (index, val) {
        queryString += "&prices=" + val;
    });

    $.each(vehicleTypes, function (index, val) {
        queryString += "&modelnames=" + val;
    });

    $.each(vehicleVats, function (index, val) {
        queryString += "&vatrates=" + val;
    });

    $.each(vehicleExciseDuties, function (index, val) {
        queryString += "&excisedutyrates=" + val;
    });

    let url = baseUrl + vehicleIdQueryString + queryString

    showProgress();

    $.get(url, function (response) {
        $("#vehicle-model-detail").html(response);
        owlCarousel();
        hideProgress();
    })
}

function owlCarousel() {
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
}

function showProgress() {
    if (!spinnerVisible) {
        $("span#spinner").addClass("is-active");
        spinnerVisible = true;
    }
};

function hideProgress() {
    if (spinnerVisible) {
        let spinner = $("span#spinner");
        spinner.stop();
        spinner.removeClass("is-active");
        spinnerVisible = false;
    }
};