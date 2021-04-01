/* global ZAGFramework */
// Place any jQuery/helper plugins in here.

//AutoClone
(function ($) {
    "use strict";

    $.AutoClone = function ($element, options) {

        $element.data('AutoClone', this);

        this.init = function ($element, options) {
            this.options = $.extend({}, $.AutoClone.defaultOptions, options);
            this.cloneElements();
        };

        this.cloneElements = function () {
            var key = $element.data('key');
            $element.trigger('cloning-from');
            $("[data-action='clone'][data-key='" + key + "'][data-type='dest']").trigger('cloning-to');
            $element.clone().appendTo("[data-action='clone'][data-key='" + key + "'][data-type='dest']").prepend('<div></div>').find('> div:first-child').unwrap().remove();
            $element.trigger('cloned-from');
            $("[data-action='clone'][data-key='" + key + "'][data-type='dest']").trigger('cloned-to');
        };

        this.init($element, options);
    };

    $.fn.AutoClone = (function (options) {
        return this.each(function () {
            (new $.AutoClone($(this), options));
        });
    });

    $.AutoClone.defaultOptions = {};

    $("[data-action='clone'][data-type='src']").AutoClone();

})(jQuery);

//AutoMove
(function ($) {
    "use strict";

    $.AutoMove = function ($element, options) {

        $element.data('AutoMove', this);

        this.$currentObject = $element;
        this.key = null;

        this.init = function ($element, options) {
            this.options = $.extend({}, $.AutoMove.defaultOptions, options);
            $(document).on({
                'enter-xs': $.proxy(function () { this.bpChange('xs'); }, this),
                'enter-sm': $.proxy(function () { this.bpChange('sm'); }, this),
                'enter-md': $.proxy(function () { this.bpChange('md'); }, this),
                'enter-lg': $.proxy(function () { this.bpChange('lg'); }, this),
                'enter-xl': $.proxy(function () { this.bpChange('xl'); }, this)
            });
        };

        this.bpChange = function (bp) {
            var key = this.$currentObject.data('key');

            /* find which of two matching elements have the right bp */
            $("[data-action='move'][data-key='" + key + "']").each(function () {
                if ($(this).attr("data-bp").indexOf(bp) === -1) { $(this).attr({ "data-type": "src" }); } else { $(this).attr({ "data-type": "dest" }); }
            });

            /* if the destination is empty, clone the partner */
            if ($("[data-action='move'][data-key='" + key + "'][data-type='dest']").is(":empty") === true) {
                $("[data-action='move'][data-key='" + key + "'][data-type='src']").trigger('moving-from');
                $("[data-action='move'][data-key='" + key + "'][data-type='dest']").trigger('moving-to');
                $("[data-action='move'][data-key='" + key + "'][data-type='src']").clone(true).appendTo($("[data-action='move'][data-key='" + key + "'][data-type='dest']")).prepend('<div></div>').find('> div:first-child').unwrap().remove();
                $("[data-action='move'][data-key='" + key + "'][data-type='src']").empty();
                $("[data-action='move'][data-key='" + key + "'][data-type='src']").trigger('moved-from');
                $("[data-action='move'][data-key='" + key + "'][data-type='dest']").trigger('moved-to');
            }

            /* remove data-type attributes for next bp */
            $("[data-action='move'][data-key='" + key + "']").removeAttr("data-type");

        };

        this.init($element, options);
    };

    $.fn.AutoMove = (function (options) {
        return this.each(function () {
            (new $.AutoMove($(this), options));
        });
    });

    $.AutoMove.defaultOptions = {};

    $("[data-action='move']").AutoMove();

})(jQuery);

//BPEvents
(function ($) {
    "use strict";

    $.BPEvents = function (options) {

        this.init = function (options) {
            this.options = $.extend({}, $.BPEvents.defaultOptions, options);
            if (window.matchMedia) {
                for (var key in ZAGFramework.BP) {
                    if (key !== "compareArrays" && key !== "indexOf") {
                        ZAGFramework.BP[key].addListener($.proxy(this.bpChange, this));
                        if (ZAGFramework.BP[key].matches) {
                            $(document).trigger('enter-' + key);
                        }
                    }
                }
            }
        };

        this.bpChange = function (media) {
            var type = (media.matches) ? 'enter' : 'leave';
            $(document).trigger(type + '-' + this.getBP(media));
        };

        this.getBP = function (media) {
            for (var key in ZAGFramework.BP) {
                if (ZAGFramework.BP[key].media === media.media) { return key; }
            }
        };

        if (ZAGFramework) {
            this.init(options);
        }
    };

    $.fn.BPEvents = (function (options) {
        (new $.BPEvents(options));
    });

    $.BPEvents.defaultOptions = {};

    $.BPEvents();

})(jQuery);