let createOrUpdateUserOrganization = document.getElementById("createOrUpdateUserOrganization");
if (createOrUpdateUserOrganization) {
    createOrUpdateUserOrganization.addEventListener('change', function (event) {
        const selectedOrgId = createOrUpdateUserOrganization.options[createOrUpdateUserOrganization.selectedIndex].value;
        //console.log(`[createOrUpdateUserOrganization][ChangeEventListener] => (selectedOrgId): ${selectedOrgId}`);

        let createOrUpdateUserManager = document.getElementById("createOrUpdateUserManager");
        if (createOrUpdateUserManager) {
            createOrUpdateUserManager.innerHTML = "";
            createOrUpdateUserManager.add(createOption("", "Working ..."));

            $.ajax({
                type: "GET",
                url: "/api/ua/users",
                data: {
                    orgId: selectedOrgId
                },
                cache: false,
                success: function (data) {
                    //console.log("Call to '/api/ua/users' was successful.");
                    createOrUpdateUserManager.innerHTML = "";
                    createOrUpdateUserManager.add(createOption("", " -- Select Manager --"));
                    $.each(data, function (key, item) {
                        //console.log("item:", item);
                        createOrUpdateUserManager.add(createOption(item.UserId, item.DisplayLabel));
                    })
                }
            });
        }
    });
}

function createOption(value, text) {
    let option = document.createElement("option");
    option.setAttribute("value", value);
    option.textContent = text;
    return option;
}