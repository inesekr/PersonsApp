function openSinglePopup(personId) {
    $('#dummyPersonId').val(personId);
    $('#dummyMaritalStatus').val('Single');
    console.log('Opening single popup for', personId);
    $('#dummyModal').modal('show');
}

function openMarriedPopup(personId) {
    $('#marriedPersonId').val(personId);
    $('#marriedMaritalStatus').val('Married');
    console.log('Opening married popup for', personId);
    $('#marriageModal').modal('show');
}

function redirectToIndex() {
    window.location.href = '@Url.Action("Index", "HomeController")';
    $('#dummyModal').modal('hide');
    window.location.href = '/Home/Index';
}

$(document).ready(function () {
    var spouseSearchInput = $('#spouseSearchInput');
    var spouseSearchResults = $('#spouseSearchResults');
    var spouseIdInput = $('#spouseId');

    var typingTimer;
    var doneTypingInterval = 5;

    spouseSearchInput.on('input', function () {
        clearTimeout(typingTimer);
        typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });

    spouseSearchInput.on('keyup', function () {
        clearTimeout(typingTimer);
    });

    function doneTyping() {
        console.log('Done typing!');
        var searchInput = spouseSearchInput.val();

        $.get('/PersonDetails/SearchSpouses', { searchInput: searchInput }, function (data) {
            spouseSearchResults.empty();

            $.each(data, function (index, item) {
                var li = $('<li class="list-group-item"></li>');
                li.attr('data-personid', item.id);
                li.text(item.fullName);
                spouseSearchResults.append(li);
            });

            $('#spouseSearchResults li').click(function () {
                var spouseId = $(this).data('personid');
                var spouseFullName = $(this).text();

                console.log('Clicked spouseId:', spouseId);
                console.log('Clicked spouseFullName:', spouseFullName);

                spouseIdInput.val(spouseId);
                spouseSearchInput.val(spouseFullName);
            });
        });
    }
});