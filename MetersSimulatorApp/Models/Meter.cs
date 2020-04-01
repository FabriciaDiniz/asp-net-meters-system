using System;
using System.Collections.Generic;
using System.Text;

namespace MetersSimulatorApp.Models
{
    class Meter
    {
        private long _kwh = new Random().Next(500);
        private bool _isOn = true;

        public long Id { get; set; }
        public string IdCp { get; set; }
        public string IdCs { get; set; }
        public string IdTrafo { get; set; }
        public long Kwh {
            get 
            {
                return _kwh;
            }
            set
            {
                _kwh = value;
            }
        }
        public bool IsOn
        {
            get
            {
                return _isOn;
            }
            set
            {
                _isOn = value;
            }
        }

        public Meter(string meterData)
        {
            var fields = meterData.Split(";");

            this.Id = Int32.Parse(fields[0]);
            this.IdCp = fields[1];
            this.IdCs = fields[2];
            this.IdTrafo = fields[3];
            this.Kwh = Int32.Parse(fields[4]);
            this.IsOn = Boolean.Parse(fields[5]);

        }
    }

}
