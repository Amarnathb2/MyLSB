var App = App || {};

App.FooterNav = (function ($) {
    'use strict';

    var $footerNav;

    function init() {
        var bp = ZAGFramework.GetCurrentBP();

        $footerNav = $('#footerNav');

        $(document).on({
            'enter-xs enter-sm enter-md': enableAccordion,
            'enter-lg enter-xl': disableAccordion
        });

        if (bp === 'lg' || bp === 'xl') {
            disableAccordion();
        }
    }

    function enableAccordion() {
        if ($footerNav.find('.footer-nav__level-1-item > button').first().attr('data-toggle') !== 'collapse') {
            $footerNav
                .find('.footer-nav__level-1-item > button')
                .attr({
                    'class': 'collapsed',
                    'data-toggle': 'collapse',
                    'aria-expanded': 'false',
                    'tabindex': ''
                })
                .removeAttr('role')
                .next('.footer-nav__level-2')
                .addClass('collapse');
        }
    }

    function disableAccordion() {
        $footerNav
            .find('.footer-nav__level-1-item > button')
            .attr({
                'class': '',
                'data-toggle': '',
                'tabindex': '-1',
                'role': 'presentation'
            })
            .removeAttr('aria-expanded')
            .next('.footer-nav__level-2')
            .removeClass('collapse show');
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.FooterNav.init();
});