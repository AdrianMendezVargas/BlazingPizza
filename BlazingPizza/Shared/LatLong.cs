﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingPizza.Shared {
    public class LatLong {

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LatLong() {
        }

        public LatLong(double latitude , double longitude) : this() {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static LatLong Interpolate(LatLong start , LatLong end , double proportion) {
            // The Earth is flat, right? So no need for spherical interpolation.
            return new LatLong(
                start.Latitude + (end.Latitude - start.Latitude) * proportion ,
                start.Longitude + (end.Longitude - start.Longitude) * proportion);
        }

    }
}
