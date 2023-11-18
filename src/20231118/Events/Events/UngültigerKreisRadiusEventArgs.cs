using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class UngültigerKreisRadiusEventArgs : EventArgs
    {
        private double _ungültigerKreisRadius;

        public UngültigerKreisRadiusEventArgs(double radius)
        {
            _ungültigerKreisRadius = radius;
        }

        public double UngültigerKreisRadius
		{
			get { return _ungültigerKreisRadius; }
		}

	}
}
