$(() => {

    $("body").on("submit", "form.form-add-bullet", (event) => {
        event.preventDefault();
        let form = $(event.currentTarget);
        //$.post('/Journal', form.serialize(), function (response) {
        //    alert(response);
        //}, function (response) {
        //    alert(response);
        //});

        let formData = new FormData(form[0]);
        var formProperties = Object.fromEntries(formData);

        let logId = formProperties["AddBulletViewModel.LogId"];

        let body = new URLSearchParams(formData);


        fetch('/Journal', {
            method: 'post',
            body: body
        })
            .then((response) => response.text())
            .then(result => {

                let log = document.getElementById(logId);
                let logBullets = $(log).find("ol.log-bullets");
                let newBullet = $("<li>").addClass("log-bullet");
                newBullet.html(result);
                logBullets.append(newBullet);
            })
            .catch(response => {
                window.alert(response);
            });
    });

});