﻿﻿var App = App || {};

App.ChatBot = (function ($) {
    "use strict";

    function init() {
        window.onload = function () {
           
            if ($('#check-chat-available').length) {
                checkContainerdiv1();
            }
        };
       
    }
    function loadAfterTime() {
        $('#five9-maximize-button').attr('tabindex', '0');
        $('#five9-maximize-button').attr('aria-label', 'chat');

        var chatButton = document.getElementById('five9-maximize-button');
        chatButton.addEventListener('keypress', function (e) {
            if (e.keyCode == 13) {
                $('#five9-maximize-button').trigger('click');
            }
        });
    }
    function checkContainerdiv1() {
        if ($('#five9-maximize-button').is(':visible')) {
            loadAfterTime();
        } else {
            setTimeout(checkContainerdiv1, 50); //wait 50 ms, then try again
        }
    }    
    return {
        init: init
    };

})(jQuery);

$(function () {
    App.ChatBot.init();
});