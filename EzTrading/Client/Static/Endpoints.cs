using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzTrading.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string SellersEndpoint = $"{Prefix}/Sellers";
        public static readonly string CartsEndpoint = $"{Prefix}/Carts";
        public static readonly string PaymentsEndpoint = $"{Prefix}/Payments";
        public static readonly string CustomersEndpoint = $"{Prefix}/Customers";
        public static readonly string ItemsEndpoint = $"{Prefix}/Items";
        public static readonly string DeliveriesEndpoint = $"{Prefix}/Deliveries";
    }
}
