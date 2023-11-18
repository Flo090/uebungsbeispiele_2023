using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class Kreis : INotifyPropertyChanged
    {
		private double _radius;
        public event KreisRadiusHandler UngültigerKreisRadius;
        public event PropertyChangedEventHandler PropertyChanged;

        public Kreis()
        {
            _radius = 10;
        }

        public double Radius
		{
			get { return _radius; }

			set
            {
                if (value >= 0)
                {
                    _radius = value;
                    OnPropertyChanged("Radius");
                }
                else
                {
                    // Ereignis auslösen
                    OnUngültigerKreisRadius(new UngültigerKreisRadiusEventArgs(value));
                }
            }
		}
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnUngültigerKreisRadius(UngültigerKreisRadiusEventArgs e)
        {
            if (UngültigerKreisRadius != null)
            {
                UngültigerKreisRadius(this, e);
            }
        }
    }
}
