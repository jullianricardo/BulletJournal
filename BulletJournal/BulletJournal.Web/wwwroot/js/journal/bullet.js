$(() => {

    $("body").on("click", "button.button-edit-bullet", (event) => {

        let button = $(event.currentTarget);
        let bullet = button.closest(".bullet");
        let displayMode = bullet.find(".display-mode");
        let editMode = bullet.find(".edit-mode");

        displayMode.removeClass("d-flex").addClass("d-none");
        editMode.removeClass("d-none").addClass("d-flex");
    });

    $("body").on("submit", "form.form-edit-bullet", (event) => {
        event.preventDefault();
        let form = $(event.currentTarget);

        let formData = new FormData(form[0]);
        var formProperties = Object.fromEntries(formData);

        let bulletId = formProperties["EditBulletViewModel.BulletId"];

        let body = new URLSearchParams(formData);


        fetch('/Journal?handler=EditBullet', {
            method: 'post',
            body: body
        })
            .then((response) => response.text())
            .then(result => {

                let bullet = document.getElementById(bulletId);
                $(bullet).replaceWith(result);
            })
            .catch(response => {
                window.alert(response);
            });
    });
});