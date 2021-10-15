var App = App || {};

App.Community = (function ($) {
    "use strict";

    var $stats,
        numArr = [];

    function init() {
        var bp = ZAGFramework.GetCurrentBP();
        $stats = $('.community__stats');

        $stats
            .find('.stat__value').each(function () {
                var $this = $(this);

                numArr.push(new Odometer({
                    el: this,
                    value: $this.data('start-val'),
                    endValue: $this.data('end-val'),
                    format: getNumberFormat($this.data('end-val')),
                    theme: 'default',
                    duration: 2500
                }));
            })
            .waypoint(function () {
                $.each(numArr, function () {
                    this.update(this.options.endValue);
                });
            }, {
                triggerOnce: true,
                offset: '90%'
            });

        if (bp === 'xs' || bp === 'sm' || bp === 'md') {
            initCarousel();
        }

        App.$window.on('enter-xs enter-sm enter-md', initCarousel);
        App.$window.on('enter-lg enter-xl', destroyCarousel);
    }

    function initCarousel() {
        $stats.each(function () {
            var $this = $(this);
            if (!$this.hasClass('flickity-enabled')) {
                $this.flickity({
                    adaptiveHeight: true,
                    imagesLoaded: true,
                    pageDots: true,
                    prevNextButtons: false
                });
            }
        });
    }

    function destroyCarousel() {
        $stats.each(function () {
            var $this = $(this);
            if ($this.hasClass('flickity-enabled')) {
                $this.flickity('destroy');
            }
        });
    }

    function getNumberFormat(value) {
        if (value % 1 != 0) {
            return '(,ddd).dd'
        }

        return '(,ddd)';
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.Community.init();
});