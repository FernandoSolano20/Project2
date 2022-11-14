var markers = [];
function initMap(element,btnBorrar,txtMap) {
    if (!element) {
        element = document.getElementById('map');
        btnBorrar = document.getElementById("borrar-marker");
    }
        
    let haightAshbury = { lat: 9.9281, lng: -84.0907 };

    var map = new google.maps.Map(element, {
        zoom: 13,
        center: haightAshbury,
    });
    map.addListener('click', function (event) {
        addMarker(event.latLng, map, btnBorrar, txtMap);
    });
}
function addMarker(location, map, btnBorrar, txtMap) {
    if (!markers.some(element => element.map === map)) {
        var marker = new google.maps.Marker({
            position: location,
            map: map
        });
        markers.push({
            marker: marker,
            map: map,
            txtMap: txtMap
        });
        btnBorrar.addEventListener("click", function() {
            deleteMarkers(map, marker, txtMap);
        });
    }
}

function clearMarkers(map, marker, txtMap) {
    setMapOnAll(null, marker);
    var index = markers.indexOf({ map: map, marker: marker, txtMap: txtMap });
    markers.splice(index, 1);
}

function deleteMarkers(map, marker) {
    clearMarkers(map, marker);
    markers = [];
}
function setMapOnAll(map, marker) {
    marker.setMap(map);
}