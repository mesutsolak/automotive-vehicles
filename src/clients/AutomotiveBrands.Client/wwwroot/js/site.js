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

    let subModelId = $(this).val();

    $("#loader-wrapper").show();

    $.post("/Home/SubModel", { subModelId: subModelId }, function (data) {
        $(".model_name").html(data.definition);
        $(".model-price-text").html(data.mrsp);
        $(".model-fuel-combined").html(data.fuelCombined);
        $(".model-co2-emission").html(data.cO2Emission);
        $("#Adetail-model").html(data.definition);
        $("#Adetail-engine").html(data.engine);
        $(".Adetail-volume-text").html(data.engineVolume);
        $("#Adetail-msrp .first-column").html(data.mrsp);
        $("#Adetail-net .first-column").html(data.netPrice);
        $("#Adetail-otv .first-column").html(data.otv);
        $("#Adetail-vat .first-column").html(data.vat);
        $("#Adetail-mtv").html(data.mtv);
        $("#Adetail-otv-rate").html(data.otvRate);
        $("#Adetail-plate-expense").html(data.plateExpense);
        $("#Adetail-service-expense").html(data.serviceExpense);
    }).done(function () {
        $("#loader-wrapper").hide();
    });
});

$(document).on('change', "input[name='rdModel']", function () {
    $(this).closest("div").next().find(".sub-models option:first").prop('selected', true).trigger('change');
});

