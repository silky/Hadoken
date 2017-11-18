#region Using References

using System;

#endregion

namespace Hadoken.Core
{
    public class Element
    {
        public Element(int atomicNumber, double atomicWeight, DateTime dateCreatedUtc, DateTime dateUpdatedUtc, double density, int? groupID, int id, string name, int period, string symbol)
        {
            _atomicNumber = atomicNumber;
            _atomicWeight = atomicWeight;
            _dateCreatedUtc = dateCreatedUtc;
            _dateUpdatedUtc = dateUpdatedUtc;
            _density = density;
            _groupID = groupID;
            _id = id;
            _name = name;
            _period = period;
            _symbol = symbol;
        }

        private readonly int _atomicNumber;
        private readonly double _atomicWeight;
        private readonly DateTime _dateCreatedUtc;
        private readonly DateTime _dateUpdatedUtc;
        private readonly double _density;
        private readonly int? _groupID;
        private readonly int _id;
        private readonly string _name;
        private readonly int _period;
        private readonly string _symbol;

        public int AtomicNumber
        {
            get
            {
                return _atomicNumber;
            }
        }

        public double AtomicWeight
        {
            get
            {
                return _atomicWeight;
            }
        }

        public DateTime DateCreatedUtc
        {
            get
            {
                return _dateCreatedUtc;
            }
        }

        public DateTime DateUpdatedUtc
        {
            get
            {
                return _dateUpdatedUtc;
            }
        }

        public double Density
        {
            get
            {
                return _density;
            }
        }

        public int? GroupID
        {
            get
            {
                return _groupID;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Period
        {
            get
            {
                return _period;
            }
        }

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }
    }
}