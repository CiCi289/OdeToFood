//same as ajax.beginform but we can customize here

$(function () {
    //-----Ajax form submission-----//
    let ajaxFormSubmit = function () {
        let $form = $(this); //ref to from, wrapped in $() - to use jQuery functions on that
        let options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            //async call,
            //options is used to know where to call url, data to be passed, get or post.
            //once done, function will be invoked, 
            //response from server will be transferred into data object and replaced in DOM

            let $target = $($form.attr("data-otf-target"));// find the target DOM
            let $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");//replace that DOM with data from response
        });
        return false; //prevent html reloading request
    };
    
    //-----Autocomplete & Autosubmission upon label selection-----//
    let submitAutocompleteForm = function (event, ui) {
        let $input = $(this);
        $input.val(ui.item.label);

        let $form = $input.parents("form:first");
        $form.submit();
    };

    let createAutocomplete = function () {
        let $input = $(this);

        let options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocompleteForm
        };
        $input.autocomplete(options);
    };

    //-----Paged List-----//
    let getPage = function () {
        let $a = $(this);

        let options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };
        $.ajax(options).done(function (data) {
            let target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });
        return false;
    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);

    $("input[data-otf-autocomplete]").each(createAutocomplete); //for each input, create Autocomplete widget

    $(".main-content").on("click", ".pagedList a", getPage);

});
