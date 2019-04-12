function preparePage() {
    offOnHandle('#show-password-btn', 'click', changePasswordVisibility);
}

function changePasswordVisibility() {
    var $this = $(this);
    var input = $($this.data('target'));
    if (input !== undefined) {
        if (input.attr('type') === 'password') {
            input.attr('type', 'text');
        } else {
            input.attr('type', 'password');
        }
    }
}