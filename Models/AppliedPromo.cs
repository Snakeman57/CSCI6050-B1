using System.ComponentModel.DataAnnotations;

namespace CineWeb.Models {
    public class AppliedPromo : Order { // promo for application to orders
        protected Order OrderRef { get; set; } // order to affect (aggregation)
        public double PercentOff { get; set; } // how much to affect order by
        public AppliedPromo() { }
        public AppliedPromo(Order order) {
            OrderRef = order;
            PercentOff = 0;
        }
        public static AppliedPromo NewPromo(Order order, MoviePromotion origin) {
            if (origin.Start < DateTime.Now && origin.End > DateTime.Now) {
                switch (origin.Type) {
                    case "flat": return new PromoByFlat(order, origin.Deal);
                    case "total": return new PromoByTotal(order, origin.Deal);
                    case "ticket": return new PromoByTType(order, origin.Deal, origin.Artifacts);
                    case "attribute":
                        var pt = origin.Artifacts.IndexOf(" ");
                        var attr = origin.Artifacts.Substring(0, pt);
                        var val =  origin.Artifacts.Substring(pt + 1);
                        return new PromoByAttr(order, origin.Deal, attr, val);
                }
            }
            return new AppliedPromo(order);
        }
        public double calcPrice() {
            return OrderRef.calcPrice();
        }
        public double percentType(string type) {
            return OrderRef.percentType(type);
        }
        public bool hasAttr(string attr, string val) {
            return OrderRef.hasAttr(attr, val);
        }
    }
    public class PromoByFlat : AppliedPromo { // flat amt off
        public double calcPrice() {
            return OrderRef.calcPrice() - PercentOff;
        }
        public PromoByFlat(Order order, double deal) {
            OrderRef = order;
            PercentOff = deal;
        }
    }
    public class PromoByTotal : AppliedPromo { // percent off total
        public double calcPrice() {
            return OrderRef.calcPrice() - OrderRef.calcPrice() * PercentOff;
        }
        public PromoByTotal(Order order, double deal) {
            OrderRef = order;
            PercentOff = deal;
        }
    }
    public class PromoByTType : AppliedPromo { // percent off certain tickets
        public string Type { get; set; }
        public double calcPrice() {
            return OrderRef.calcPrice() - OrderRef.calcPrice() * OrderRef.percentType(Type) * PercentOff;
        }
        public PromoByTType(Order order, double deal, string type) {
            OrderRef = order;
            PercentOff = deal;
            Type = type;
        }
    }
    public class PromoByAttr : AppliedPromo { // percent off movies w/ certain attributes
        public string Attr { get; set;} // attribute to check
        public string Val { get; set; } // value to compare
        public double calcPrice() {
            if (OrderRef.hasAttr(Attr, Val))
                return OrderRef.calcPrice() - OrderRef.calcPrice() * PercentOff;
            else
                return OrderRef.calcPrice();
        }
        public PromoByAttr(Order order, double deal, string attr, string val) {
            OrderRef = order;
            PercentOff = deal;
            Attr = attr;
            Val = val;
        }
    }
}