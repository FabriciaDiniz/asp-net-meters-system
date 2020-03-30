using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MetersDesktopApp.Models
{
    [Table("meters")]
    public class Meter
    {
        private string _sn = GenerateSerialNumber();
        private long _kwh = new Random().Next(500);
        private bool _isOn = true;

        [Key]
        public long Id { get; set; }
        public string IdCp { get; set; }
        public string IdCs { get; set; }
        public string IdTrafo { get; set; }
        public string SerialNumber 
        { 
            get 
            {
                return _sn;
            }
            set
            {
                this._sn = value;
            } 
        }
        public long Kwh { 
            get
            {
                return _kwh;
            } 
        }
        public bool IsOn {
            get 
            {
                return _isOn;            
            }
            set
            {
                _isOn = value;
            }
        }

        public override string ToString()
        {
            string meter = $"{Id};{SerialNumber};{IdCp};{IdCs};{IdTrafo};{Kwh};{IsOn}";
            return meter;
        }

        public static string GenerateSerialNumber()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }
    }
}
