let map;

function initMap() {
  map = new google.maps.Map(document.getElementById("map"), {
    center: {
      lat: 4.045470,
      lng: 9.709780
    },
    zoom: 10,
  });
}
