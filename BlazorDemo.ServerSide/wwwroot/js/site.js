window.utils = {
    setFocus: function (element, selector) {
        $(element).find(selector).focus();
    },
    registerPopover: function (element) {
        $(element).find('[data-toggle="popover"]').popover();
    },
    unregisterPopover: function (element) {
        $(element).find('[data-toggle="popover"]').popover('dispose');
    }
};