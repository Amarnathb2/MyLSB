var App = App || {};

App = (function ($) {
    "use strict";

    var $window = $(window),
        $html = $('html'),
        $body = $('body');

    function init() {
        $('a[href^="#"]')
            .not('.skipto, #sbModalSubmit')
            .on('click', function (e) {
                var $this = $(this);

                e.preventDefault();

                if ($this.attr('href') !== '#' && $this.attr('role') !== 'tab') {
                    scrollTo($($this.attr('href')));
                }
            });

        onScrollInit($('.os-animation'));

        $('.staggered-animation').each(function () {
            var $this = $(this);
            onScrollInit($this, $this.parents('.staggered-animation-container'));
        });
    }

    function addOverlay() {
        $body.addClass('has-overlay');
    }

    function removeOverlay() {
        $body.removeClass('has-overlay');
    }

    function onScrollInit(items, $trigger) {
        items.each(function () {
            var $osElement = $(this),
                osAnimationClass = $osElement.attr('data-os-animation'),
                osAnimationDelay = $osElement.attr('data-os-animation-delay');

            $osElement.css({
                '-webkit-animation-delay': osAnimationDelay,
                '-moz-animation-delay': osAnimationDelay,
                'animation-delay': osAnimationDelay
            });

            var $osTrigger = ($trigger) ? $trigger : $osElement;

            $osTrigger.waypoint(function () {
                $osElement
                    .one('animationend', function () {
                        $osElement
                            .addClass('animation-complete')
                            .removeClass('animate__animated');
                    })
                    .addClass('animate__animated')
                    .addClass(osAnimationClass);
            }, {
                triggerOnce: true,
                offset: '90%'
            });
        });
    }

    function speak(text, priority) {
        var el = document.createElement("div");
        var id = "speak-" + Date.now();
        el.setAttribute("id", id);
        el.setAttribute("aria-live", priority || "polite");
        el.classList.add("sr-only");
        document.body.appendChild(el);

        window.setTimeout(function () {
            document.getElementById(id).innerHTML = text;
        }, 100);

        window.setTimeout(function () {
            document.body.removeChild(document.getElementById(id));
        }, 1000);
    }

    function getQueryString(field, url) {
        var href = url ? url : window.location.href;
        var reg = new RegExp('[?&]' + field + '=([^&#]*)', 'i');
        var string = reg.exec(href);
        return string ? string[1] : null;
    }

    function scrollTo($el) {
        var duration = 600,
            offset = $el.offset().top;

        $('html, body').stop()
            .animate({
                scrollTop: offset
            }, duration);
    }

    return {
        init: init,
        $window: $window,
        $html: $html,
        $body: $body,
        addOverlay: addOverlay,
        removeOverlay: removeOverlay
    };

})(jQuery);

$(function () {
    App.init();
});