using BlazingPizza.ComponentsLibrary.Map;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BlazingPizza.Shared {
    public class OrderWithStatus {

        public static readonly TimeSpan PreparationDuration = TimeSpan.FromSeconds(20);

        public static readonly TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1);

        public Order Order { get; set; }
        public string StatusText { get; set; }
        public List<Marker> MapMarkers { get; set; }

        public static OrderWithStatus FromOrder(Order order) {

            string Message;
            List<Marker> Markers;
            var DispatchTime = order.CreatedTime.Add(PreparationDuration);

            if (DateTime.Now < DispatchTime) {

                Message = "Preparando";
                Markers = new List<Marker> {
                  ToMapMarker("Usted", order.DeliveryLocation, showPopPup:true)
                };

            } else if (DateTime.Now < DispatchTime + DeliveryDuration) {

                Message = "En camino";
                var StartPosition = ComputeStartPosition(order);

                var proportionOfDeliveryCompleted = Math.Min(1 , (DateTime.Now - DispatchTime).TotalMilliseconds / DeliveryDuration.TotalMilliseconds);
                
                var driverPosition = LatLong.Interpolate(StartPosition , order.DeliveryLocation , proportionOfDeliveryCompleted);

                Markers = new List<Marker> {
                    ToMapMarker("Usted", order.DeliveryLocation),
                    ToMapMarker("Repartidor", driverPosition, showPopPup:true)
                };
            } else {
                Message = "Entregado";
                Markers = new List<Marker> {
                    ToMapMarker("Ubicacion de entrega", order.DeliveryLocation, showPopPup:true)
                };
            }

            return new OrderWithStatus() {
                Order = order ,
                StatusText = Message ,
                MapMarkers = Markers
            };

        }

        static Marker ToMapMarker(string description , LatLong coords, bool showPopPup = false) {
            return new Marker {
                Description = description ,
                X = coords.Longitude ,
                Y = coords.Latitude ,
                ShowPopup = showPopPup
            };
        }

        static LatLong ComputeStartPosition(Order order) {

            var Random = new Random(order.OrderId);
            var distance = 0.01 + Random.NextDouble() * 0.02;
            var angle = Random.NextDouble() * Math.PI * 2;
            var offset = 
                (distance * Math.Cos(angle),
                distance * Math.Sin(angle));

            return new LatLong(order.DeliveryLocation.Latitude + offset.Item1,
                               order.DeliveryLocation.Longitude + offset.Item2);

        }

    }
}
