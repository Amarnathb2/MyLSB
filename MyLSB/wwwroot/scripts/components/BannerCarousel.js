var App = App || {};

App.BannerCarousel = (function ($) {
    "use strict";

    var $carousels;

    function init() {
        $carousels = $('.banner-carousel');
        
        $carousels.each(function () {
            var $carousel = $(this).find('.banner-carousel__slides'),
                $controls = $(this).find('.banner-carousel-controls');

            $carousel.slick({
                arrows: false,
                autoplay: true,
                autoplaySpeed: 7000,
                dots: false,
                draggable: false
            });

            if ($controls) {
                var $play = $controls.find('.play').parent('li'),
                    $pause = $controls.find('.pause').parent('li');


                $controls.on('click', 'button', function (e) {
                    var $this = $(this);
                    e.preventDefault();
                    $carousel.slick($this.data('action'));

                    if ($this.hasClass('play')) {
                        $play.hide();
                        $pause.show();
                    } else if ($this.hasClass('pause')) {
                        $play.show();
                        $pause.hide();
                    }
                });
            }
        });
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.BannerCarousel.init();
});