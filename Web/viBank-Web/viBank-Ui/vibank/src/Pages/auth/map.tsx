import React from "react";
import { GoogleMap, useJsApiLoader } from "@react-google-maps/api";

const containerStyle = {
    width: "100%",
    height: "100vh",
};

const center = {
    lat: -3.745,
    lng: -38.523,
};

export const MapsMapper = () => {
    const {isLoaded} = useJsApiLoader({
        id: 'google-map-script',
        googleMapsApiKey: process.env.NEXT_PUBLIC_GOOGLE_MAPS_API_KEY as string,
    })
    const [map, setMap] = React.useState(null)
    const onLoad = React.useCallback(function callback(map: any) {
        const bounds = new window.google.maps.LatLngBounds(center);
        map.fitBounds(bounds);
        setMap(map)
    }, [])
    const onMount = React.useCallback(function callback(map:any) {
        setMap(null)
    }, [])
    
    return isLoaded ? (
        <GoogleMap
            mapContainerStyle={containerStyle}
            center={center}
            zoom={10}
            onLoad={onLoad}
            onUnmount={onMount}
        >
        </GoogleMap>
    ) : (
            <></>   
            
    )
}

