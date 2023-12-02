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
    });
});

$(document).on('change', "input[name='rdModel']", function () {
    $(this).closest("div").next().find(".sub-models option:first").prop('selected', true).trigger('change');
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