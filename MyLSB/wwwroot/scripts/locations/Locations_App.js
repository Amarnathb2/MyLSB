"use strict";

(function () {
    var app = angular.module("Locations_App", []);

    var getWebSiteLocation = function (location) {
        var content = "<div id='" + location.id + "' tabindex='100' class='infowindow'><div class='name'>" + location.name + "</div>";
        content += "<div>" + location.address1 + " " + location.address2 + "</div>";
        content += "<div>" + location.city + ", " + location.state + " " + location.zipCode + "</div>";
        content += "<div><a href='" + location.kenticoUrl + "' alt='click here for more detail'>More Info</a><div>";
        content += "</div>";
        return content;
    }

    var getThirdPartyLocation = function (location) {
        var content = "<div tabindex='100' class='infowindow'><div>" + location.name + "</div>";
        content += "<div>" + location.address1 + "</div>";
        content += "<div>" + location.city + ", " + location.state + " " + location.zipCode + "</div>";
        content += "<div><a href='" + location.googleDirectionsLink + "' target='_new'  alt='click here for more detail'>Directions</a><div><div>";
        return content;
    };

    var getDisplay = function (type) {
        if (type === "Website") return "";
    };

    var connectors = [
        {
            name: "Website",
            selected: true,
            icon: "map-pin.png",
            zIndex: 10000,
            content: getWebSiteLocation,
            filters: [
                { name: "LocationTypeBankingFinancialServices", selected: false },
                { name: "LocationTypeInsuranceTrustWealthManagement", selected: false },
            ]
        }
        //,
        //{
        //    name: "COOP",
        //    selected: false,
        //    icon: "coop.png",
        //    zIndex: 9999,
        //    content: getThirdPartyLocation,
        //    filters: []
        //}
    ];

    angular.element(document).ready(function () {
        var ngLocationApp = document.getElementById('ngLocationApp');
        angular.bootstrap(ngLocationApp, ['Locations_App']);
    });

    app.factory("Configuration", function () {
        return {
            defaultLocation: "50669",
            detectLocation: true,
            defaultRadius: 25,
            connectors: connectors,
            getDisplay: getDisplay
        };
    });

    app.factory("Connectors", function () {
        return connectors;
    });

    app.directive('ngEnterDisabled', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    event.preventDefault();
                }
            });
        };
    });

    app.directive('ngEnterFiltered', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    event.preventDefault();
                    if (event.target.href === undefined) {
                        $(event.target).click()
                    } else {
                        window.location = event.target.href;
                    }
                }
            });
        };
    });


    app.directive('ngFocusOnList', function () {
        return function (scope, element, attrs) {
            element.on('keydown', function (event) {
                var $location = $(".location");

                if ($location.length > 0 && event.which === 9 && !event.shiftKey) {
                    event.preventDefault();
                    $location.first().focus();
                }
            });
        };
    });

})();