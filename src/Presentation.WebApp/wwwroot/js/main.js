const consumirMetodoAccion = (pUrl, pAsync, pType, pData, funDone, funFail = undefined, funAlways = undefined) => {
    $.ajax({
        url: location.origin + pUrl,
        data: pData,
        async: pAsync,
        type: pType
    })

        .done(funDone)

        .fail(funFail)

        .always(funAlways);
}

function ocultar() {

    let x = document.querySelector("#header");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}