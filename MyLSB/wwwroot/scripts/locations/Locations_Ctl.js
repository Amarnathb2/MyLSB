
"use strict";

(function () {

    function Locations_Ctl($scope, $http, Locations_Svc, Connectors, Configuration) {

        var MapMarkerWidth = 20;
        var MapMarkerHeight = 32;
        var MapMinZoom = 3;
        var MapMaximumZoom = 15;
        var MapIframeTitle = "Google Map of Searched Locations";

        // Properties
        $scope.SearchValues = {
            Radius: Configuration.defaultRadius,
            Latitude: 0,
            Longitude: 0,
            Connectors: Configuration.connectors
        };

        $scope.Address = Configuration.defaultLocation;

        $scope.map = new google.maps.Map(document.getElementById('map'), { mapTypeControlOptions: { mapTypeIds: [google.maps.MapTypeId.ROADMAP] } });
        $scope.map.setOptions({ minZoom: MapMinZoom, maxZoom: MapMaximumZoom });
        $scope.markers = [];
        $scope.infowindow = new google.maps.InfoWindow();
        $scope.Locations = [];
        $scope.LocationsLabel = "";
        $scope.CheckBoxesAreValid = true;

        // Public functions
        $scope.refresh = refresh;
        $scope.fireMarkerEvent = fireMarkerEvent;
        $scope.setCheckBoxValidation = setCheckBoxValidation;

        var refreshing = false;

        // INIT
        $scope.init = function () {
            refresh();
            $("[data-ng-enter-refresh]").bind("keydown", function (e) {
                if (e.which === 13) {
                    refresh();
                }
            });

            if ((typeof (navigator.geolocation) !== 'undefined') && (Configuration.detectLocation)) {
                navigator.geolocation.getCurrentPosition(geoInit, geoNa, { timeout: 5000 });
            }
        };

        function geoInit(position) {
            var latlng = { lat: position.coords.latitude, lng: position.coords.longitude };
            var geocoder = new google.maps.Geocoder;
            geocoder.geocode({ 'location': latlng }, function (results, status) {
                if (status === 'OK' && results[0]) {
                    $scope.Address = results[0].formatted_address;
                    $scope.$apply();
                    refresh();
                }
            });
        }

        function geoNa() {
            //console.log("they don't want their location tracked");
        }

        function setCheckBoxValidation() {
            if ($("#ngLocationApp input:checked").length > 0) {
                $scope.CheckBoxesAreValid = true;
                return
            }
            $scope.CheckBoxesAreValid = false;
        }

        // REFRESH
        function refresh() {
            $(".locationsModule").addClass('map-updating')
            $scope.map = new google.maps.Map(document.getElementById('map'), { mapTypeControlOptions: { mapTypeIds: [google.maps.MapTypeId.ROADMAP] } });
            $scope.map.setOptions({ minZoom: MapMinZoom, maxZoom: MapMaximumZoom });
            var geocoder = new google.maps.Geocoder();

            geocoder.geocode({ 'address': $scope.Address }, function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    $scope.SearchValues.Latitude = results[0].geometry.location.lat()
                    $scope.SearchValues.Longitude = results[0].geometry.location.lng()

                    Locations_Svc.Search($scope.SearchValues)
                        .then(
                            function (result) {
                                var Count = result.length;
                                $scope.LocationsLabel = Count + " location" + (Count !== 1 ? "s" : "") + " found";

                                $scope.Locations = result;
                                if ($scope.Locations.length === 0) {
                                    document.getElementById('map').innerHTML = document.getElementById('errorMessage').innerHTML;
                                    return;
                                }
                                setMarkers();
                            }
                        )
                        .finally(
                            function (result) {
                                $(".locationsModule").removeClass('map-updating');

                                // add title to iframe and remove the frameborder attr
                                $(".locationsModule #map iframe").attr("title", MapIframeTitle).removeAttr("frameborder");

                                // update the zoom level if it is too zoomed in (in the case of only one marker being set)
                                var zoom = $scope.map.getZoom();
                                $scope.map.setZoom(zoom > MapMaximumZoom ? MapMaximumZoom : zoom);
                            }
                        )
                }
            });
        }

        function setMarkers() {
            // clear map and markers
            for (var i = 0; i < $scope.markers.length; i++) {
                $scope.markers[i].setMap(null);
            }
            $scope.markers = []
            // End Clear

            var bounds = new google.maps.LatLngBounds();

            for (var i = 0; i < $scope.Locations.length; i++) {

                var location = $scope.Locations[i];
                var connector = getConnector(location.type);

                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(location.latitude, location.longitude),
                    map: $scope.map,
                    //icon: {
                    //    url: "/Content/Images/Locations/" + connector.icon,
                    //    scaledSize: new google.maps.Size(MapMarkerWidth, MapMarkerHeight),
                    //},
                    id: location.id,
                    optimized: false,
                    zIndex: connector.zIndex,
                    content: connector.content(location)
                });

                google.maps.event.addListener(marker, 'click', (function (marker) {
                    return function () {
                        $scope.infowindow.setContent(marker.content);
                        $scope.infowindow.open(map, marker);
                        $('#' + marker.id).focus();
                    }
                })(marker));

                bounds.extend(marker.getPosition());

                $scope.markers.push(marker);
            }
            $scope.map.fitBounds(bounds);
        }

        function fireMarkerEvent(id) {
            for (var i = 0; i < $scope.markers.length; i++) {
                if ($scope.markers[i].id === id) {
                    google.maps.event.trigger($scope.markers[i], 'click');

                    break;
                }
            }
        }

        function getConnector(locationType) {
            for (var i = 0; i < Connectors.length; i++) {
                if (Connectors[i].name === locationType) {
                    return Connectors[i];
                }
            }
        }
    }

    angular
      .module("Locations_App")
      .controller("Locations_Ctl", ["$scope", "$http", "Locations_Svc", "Connectors", "Configuration", Locations_Ctl]);
})();;