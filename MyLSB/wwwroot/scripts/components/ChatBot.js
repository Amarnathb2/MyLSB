﻿var App = App || {};

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