var App = App || {};

App.PositioningText = (function ($) {
    "use strict";

    var $statements;

    function init() {
        $statements = $('.positioning__statement');

        if ($statements.length > 1) {
            $statements
                .first()
                .one('animationend', function () {
                    $('.positioning__statements')
                        .rotaterator({ fadeSpeed: 2000, pauseSpeed: 100 });                    
                });
        }
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    //App.PositioningText.init();
});