var phoneNumberCount = 1;

function addPhoneNumberField() {
    phoneNumberCount++;

    var inputGroup = document.createElement("div");
    inputGroup.className = "input-group mb-3";

    var input = document.createElement("input");
    input.type = "text";
    input.name = "PhoneNumbers[" + (phoneNumberCount - 1) + "]";
    input.className = "form-control";

    var buttonGroup = document.createElement("div");
    buttonGroup.className = "address-group-append";

    var addButton = document.createElement("button");
    addButton.className = "btn btn-outline-secondary";
    addButton.type = "button";
    addButton.innerText = "+";
    addButton.addEventListener("click", addPhoneNumberField);

    buttonGroup.appendChild(addButton);

    inputGroup.appendChild(input);
    inputGroup.appendChild(buttonGroup);

    document.getElementById("phoneNumbers").appendChild(inputGroup);
}

var addressCount = 1;

function addAddressField() {
    addressCount++;

    var addressRow = document.createElement("div");
    addressRow.className = "row";

    var addressGroup = document.createElement("div");
    addressGroup.className = "col-8 address-group mb-3 d-flex align-items-center";

    var input = document.createElement("input");
    input.type = "text";
    input.name = "Addresses[" + (addressCount - 1) + "]";
    input.className = "form-control";

    addressGroup.appendChild(input);

    var buttonGroup = document.createElement("div");
    buttonGroup.className = "ml-2 col-4 address-group-append d-flex align-items-center justify-content-center";

    var primaryRadio = document.createElement("input");
    primaryRadio.type = "radio";
    primaryRadio.name = "PrimaryAddressIndex";
    primaryRadio.value = (addressCount - 1).toString();

    var primaryText = document.createElement("span");
    primaryText.className = "px-2";
    primaryText.innerText = " Primary";

    var addButton = document.createElement("button");
    addButton.className = "btn btn-outline-secondary";
    addButton.type = "button";
    addButton.innerText = "+";
    addButton.addEventListener("click", addAddressField);

    primaryRadio.addEventListener("change", function () {
        if (primaryRadio.checked) {
            uncheckOtherPrimaryRadios(primaryRadio);
        }
    });

    buttonGroup.appendChild(primaryRadio);
    buttonGroup.appendChild(primaryText);
    buttonGroup.appendChild(addButton);

    addressRow.appendChild(addressGroup);
    addressRow.appendChild(buttonGroup);

    document.getElementById("addresses").appendChild(addressRow);

    function uncheckOtherPrimaryRadios(currentRadio) {
        var radios = document.getElementsByName("PrimaryAddressIndex");
        radios.forEach(function (radio) {
            if (radio !== currentRadio) {
                radio.checked = false;
            }
        });
    }
}