using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftRentals
{
    public class CarDetails
    {
        private string _carModel;
        private string _carBrand {  get; set; }
        private string _carRegistationDate;
        private int _carRentalRates;
        private bool _carAvailability;

        public string CarModel
        {
            get { return _carModel; }
            set { _carModel = value; }
        }

        public string CarBrand
        {
            get { return _carBrand; }
            set { _carBrand = value; }
        }

        public string CarRegistationDate
        {
            get { return _carRegistationDate; }
            set { _carRegistationDate = value; }
        }

        public int CarRentalRates
        {
            get { return _carRentalRates; }
            set { _carRentalRates = value; }
        }
        public CarDetails()
        {
            
        }

        public CarDetails(string model, string brand, string registration, int rates)
            :this()
        {
            this._carModel = model;
            this._carBrand = brand;
            this._carRegistationDate = registration;
            this._carRentalRates = rates;
        }
    }
}
