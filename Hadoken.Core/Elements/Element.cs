#region Using References

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Hadoken.Core.Elements
{
    public class Element
    {
        protected Element(string name, string symbol, int atomicNumber)
        {
            _name = name;
            _symbol = symbol;
            _atomicNumber = atomicNumber;
        }

        public Element(int atomicNumber, double atomicWeight, DateTime dateCreatedUtc, DateTime dateUpdatedUtc, double density, int? groupID, int id, string name, int period, string symbol)
            : this(name, symbol, atomicNumber)
        {
            _atomicWeight = atomicWeight;
            _dateCreatedUtc = dateCreatedUtc;
            _dateUpdatedUtc = dateUpdatedUtc;
            _density = density;
            _groupID = groupID;
            _id = id;
            _period = period;
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

        private static List<string> _notHandled = new List<string>();

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

        public static List<string> NotHandled
        {
            get
            {
                return _notHandled;
            }
        }

        public override bool Equals(object Value)
        {
            bool equals = false;

            Element element = Value as Element;

            if (element != null)
            {
                equals =
                (
                    (_atomicNumber == element._atomicNumber) &&
                    (_atomicWeight == element._atomicWeight) &&
                    (_dateCreatedUtc == element._dateCreatedUtc) &&
                    (_dateUpdatedUtc == element._dateUpdatedUtc) &&
                    (_density == element._density) &&
                    (_groupID == element._groupID) &&
                    (_id == element._id) &&
                    (_name == element._name) &&
                    (_period == element._period) &&
                    (_symbol == element._symbol)
                );
            }

            return equals;
        }

        public static Element FromString(string value)
        {
            Element element = null;

            switch (value)
            {
                case ActiniumElement.Ac:
                case ActiniumElement.Actinium:
                    element = new ActiniumElement();
                    break;

                case AluminiumElement.Al:
                case AluminiumElement.Aluminium:
                    element = new AluminiumElement();
                    break;

                case ArgonElement.Ar:
                case ArgonElement.Argon:
                    element = new ArgonElement();
                    break;

                case AntimonyElement.Sb:
                case AntimonyElement.Antimony:
                    element = new AntimonyElement();
                    break;

                case ArsenicElement.As:
                case ArsenicElement.Arsenic:
                    element = new ArsenicElement();
                    break;

                case BariumElement.Ba:
                case BariumElement.Barium:
                    element = new BariumElement();
                    break;

                case BerylliumElement.Be:
                case BerylliumElement.Beryllium:
                    element = new BerylliumElement();
                    break;

                case BismuthElement.Bi:
                case BismuthElement.Bismuth:
                    element = new BismuthElement();
                    break;

                case BoronElement.B:
                case BoronElement.Boron:
                    element = new BoronElement();
                    break;

                case BromineElement.Br:
                case BromineElement.Bromine:
                    element = new BromineElement();
                    break;

                case CadmiumElement.Cd:
                case CadmiumElement.Cadmium:
                    element = new CadmiumElement();
                    break;

                case CalciumElement.Ca:
                case CalciumElement.Calcium:
                    element = new CalciumElement();
                    break;

                case CaesiumElement.Cs:
                case CaesiumElement.Caesium:
                    element = new CaesiumElement();
                    break;

                case CarbonElement.C:
                case CarbonElement.Carbon:
                    element = new CarbonElement();
                    break;

                case CeriumElement.Ce:
                case CeriumElement.Cerium:
                    element = new CeriumElement();
                    break;

                case ChlorineElement.Cl:
                case ChlorineElement.Chlorine:
                    element = new ChlorineElement();
                    break;

                case ChromiumElement.Cr:
                case ChromiumElement.Chromium:
                    element = new ChromiumElement();
                    break;

                case CobaltElement.Co:
                case CobaltElement.Cobalt:
                    element = new CobaltElement();
                    break;

                case CopperElement.Cu:
                case CopperElement.Copper:
                    element = new CopperElement();
                    break;

                case DysprosiumElement.Dy:
                case DysprosiumElement.Dysprosium:
                    element = new DysprosiumElement();
                    break;

                case ErbiumElement.Er:
                case ErbiumElement.Erbium:
                    element = new ErbiumElement();
                    break;

                case EuropiumElement.Eu:
                case EuropiumElement.Europium:
                    element = new EuropiumElement();
                    break;

                case FluorineElement.F:
                case FluorineElement.Fluorine:
                    element = new FluorineElement();
                    break;

                case GadoliniumElement.Gd:
                case GadoliniumElement.Gadolinium:
                    element = new GadoliniumElement();
                    break;

                case GalliumElement.Ga:
                case GalliumElement.Gallium:
                    element = new GalliumElement();
                    break;

                case GermaniumElement.Ge:
                case GermaniumElement.Germanium:
                    element = new GermaniumElement();
                    break;

                case GoldElement.Au:
                case GoldElement.Gold:
                    element = new GoldElement();
                    break;

                case HafniumElement.Hf:
                case HafniumElement.Hafnium:
                    element = new HafniumElement();
                    break;

                case HeliumElement.He:
                case HeliumElement.Helium:
                    element = new HeliumElement();
                    break;

                case HydrogenElement.H:
                case HydrogenElement.Hydrogen:
                    element = new HydrogenElement();
                    break;

                case HolmiumElement.Ho:
                case HolmiumElement.Holmium:
                    element = new HolmiumElement();
                    break;

                case IodineElement.I:
                case IodineElement.Iodine:
                    element = new IodineElement();
                    break;

                case IndiumElement.In:
                case IndiumElement.Indium:
                    element = new IndiumElement();
                    break;

                case IridiumElement.Ir:
                case IridiumElement.Iridium:
                    element = new IridiumElement();
                    break;

                case IronElement.Fe:
                case IronElement.Iron:
                    element = new IronElement();
                    break;

                case KryptonElement.Kr:
                case KryptonElement.Krypton:
                    element = new KryptonElement();
                    break;

                case LanthanumElement.La:
                case LanthanumElement.Lanthanum:
                    element = new LanthanumElement();
                    break;

                case LithiumElement.Li:
                case LithiumElement.Lithium:
                    element = new LithiumElement();
                    break;

                case LutetiumElement.Lu:
                case LutetiumElement.Lutetium:
                    element = new LutetiumElement();
                    break;

                case MagnesiumElement.Mg:
                case MagnesiumElement.Magnesium:
                    element = new MagnesiumElement();
                    break;

                case ManganeseElement.Mn:
                case ManganeseElement.Manganese:
                    element = new ManganeseElement();
                    break;

                case MercuryElement.Hg:
                case MercuryElement.Mercury:
                    element = new MercuryElement();
                    break;

                case MolybdenumElement.Mo:
                case MolybdenumElement.Molybdenum:
                    element = new MolybdenumElement();
                    break;

                case NeodymiumElement.Nd:
                case NeodymiumElement.Neodymium:
                    element = new NeodymiumElement();
                    break;

                case NeonElement.Ne:
                case NeonElement.Neon:
                    element = new NeonElement();
                    break;

                case NickelElement.Ni:
                case NickelElement.Nickel:
                    element = new NickelElement();
                    break;

                case NiobiumElement.Nb:
                case NiobiumElement.Niobium:
                    element = new NiobiumElement();
                    break;

                case NitrogenElement.N:
                case NitrogenElement.Nitrogen:
                    element = new NitrogenElement();
                    break;

                case OsmiumElement.Os:
                case OsmiumElement.Osmium:
                    element = new OsmiumElement();
                    break;

                case OxygenElement.O:
                case OxygenElement.Oxygen:
                    element = new OxygenElement();
                    break;

                case PotassiumElement.K:
                case PotassiumElement.Potassium:
                    element = new PotassiumElement();
                    break;

                case LeadElement.Pb:
                case LeadElement.Lead:
                    element = new LeadElement();
                    break;

                case PalladiumElement.Pd:
                case PalladiumElement.Palladium:
                    element = new PalladiumElement();
                    break;

                case PhosphorusElement.P:
                case PhosphorusElement.Phosphorus:
                    element = new PhosphorusElement();
                    break;

                case PlatinumElement.Pt:
                case PlatinumElement.Platinum:
                    element = new PlatinumElement();
                    break;

                case PlutoniumElement.Pu:
                case PlutoniumElement.Plutonium:
                    element = new PlutoniumElement();
                    break;

                case PraseodymiumElement.Pr:
                case PraseodymiumElement.Praseodymium:
                    element = new PraseodymiumElement();
                    break;

                case PromethiumElement.Pm:
                case PromethiumElement.Promethium:
                    element = new PromethiumElement();
                    break;

                case ProtactiniumElement.Pa:
                case ProtactiniumElement.Protactinium:
                    element = new ProtactiniumElement();
                    break;

                case RheniumElement.Re:
                case RheniumElement.Rhenium:
                    element = new RheniumElement();
                    break;

                case RhodiumElement.Rh:
                case RhodiumElement.Rhodium:
                    element = new RhodiumElement();
                    break;

                case RubidiumElement.Rb:
                case RubidiumElement.Rubidium:
                    element = new RubidiumElement();
                    break;

                case RutheniumElement.Ru:
                case RutheniumElement.Ruthenium:
                    element = new RutheniumElement();
                    break;

                case SamariumElement.Sm:
                case SamariumElement.Samarium:
                    element = new SamariumElement();
                    break;

                case ScandiumElement.Sc:
                case ScandiumElement.Scandium:
                    element = new ScandiumElement();
                    break;

                case SeleniumElement.Se:
                case SeleniumElement.Selenium:
                    element = new SeleniumElement();
                    break;

                case SiliconElement.Si:
                case SiliconElement.Silicon:
                    element = new SiliconElement();
                    break;

                case StrontiumElement.Sr:
                case StrontiumElement.Strontium:
                    element = new StrontiumElement();
                    break;

                case SilverElement.Ag:
                case SilverElement.Silver:
                    element = new SilverElement();
                    break;

                case SodiumElement.Na:
                case SodiumElement.Sodium:
                    element = new SodiumElement();
                    break;

                case SulfurElement.S:
                case SulfurElement.Sulfur:
                    element = new SulfurElement();
                    break;

                case TantalumElement.Ta:
                case TantalumElement.Tantalum:
                    element = new TantalumElement();
                    break;

                case TechnetiumElement.Tc:
                case TechnetiumElement.Technetium:
                    element = new TechnetiumElement();
                    break;

                case TelluriumElement.Te:
                case TelluriumElement.Tellurium:
                    element = new TelluriumElement();
                    break;

                case TerbiumElement.Tb:
                case TerbiumElement.Terbium:
                    element = new TerbiumElement();
                    break;

                case ThalliumElement.Tl:
                case ThalliumElement.Thallium:
                    element = new ThalliumElement();
                    break;

                case ThoriumElement.Th:
                case ThoriumElement.Thorium:
                    element = new ThoriumElement();
                    break;

                case ThuliumElement.Tm:
                case ThuliumElement.Thulium:
                    element = new ThuliumElement();
                    break;

                case TinElement.Sn:
                case TinElement.Tin:
                    element = new TinElement();
                    break;

                case TitaniumElement.Ti:
                case TitaniumElement.Titanium:
                    element = new TitaniumElement();
                    break;

                case TungstenElement.W:
                case TungstenElement.Tungsten:
                    element = new TungstenElement();
                    break;

                case UraniumElement.U:
                case UraniumElement.Uranium:
                    element = new UraniumElement();
                    break;

                case VanadiumElement.V:
                case VanadiumElement.Vanadium:
                    element = new VanadiumElement();
                    break;

                case YtterbiumElement.Yb:
                case YtterbiumElement.Ytterbium:
                    element = new YtterbiumElement();
                    break;

                case YttriumElement.Y:
                case YttriumElement.Yttrium:
                    element = new YttriumElement();
                    break;

                case XenonElement.Xe:
                case XenonElement.Xenon:
                    element = new XenonElement();
                    break;

                case ZincElement.Zn:
                case ZincElement.Zinc:
                    element = new ZincElement();
                    break;

                case ZirconiumElement.Zr:
                case ZirconiumElement.Zirconium:
                    element = new ZirconiumElement();
                    break;

                default:
                    if (_notHandled.Contains(value) == false)
                    {
                        _notHandled.Add(value);
                    }
                    //	Console.WriteLine(Value);
                    //	Console.WriteLine();
                    break;
            }

            if ((element == null) || ((element != null) && (element.Symbol != value)))
            {
                throw new Exception("Unhandled element");
            }

            return element;
        }

        public override int GetHashCode()
        {
            int getHashCode =
                _atomicNumber.GetHashCode() ^
                _atomicWeight.GetHashCode() ^
                _dateCreatedUtc.GetHashCode() ^
                _dateUpdatedUtc.GetHashCode() ^
                _density.GetHashCode() ^
                _id.GetHashCode() ^
                _period.GetHashCode() ^
                _groupID.GetHashCode();

            if (String.IsNullOrEmpty(_name) == false)
            {
                getHashCode ^= _name.GetHashCode();
            }

            if (String.IsNullOrEmpty(_symbol) == false)
            {
                getHashCode ^= _symbol.GetHashCode();
            }

            return getHashCode;
        }

        public static List<string> ToElementList(string prototype)
        {
            List<int> elementStartList = new List<int>();

            //	Ag2Al2O4
            for (int i = 0; i < prototype.Length; i++)
            {
                string value = prototype.Substring(i, 1);

                if ((Int32.TryParse(value, out int integerValue) == false) && (value == value.ToUpper()))
                {
                    elementStartList.Add(i);
                }
            }

            List<string> prototypePartList = new List<string>();
            for (int i = 0, j = 1; i < elementStartList.Count; i++, j++)
            {
                int startIndex = elementStartList[i];
                int length = 0;

                if (j < elementStartList.Count)
                {
                    length = (elementStartList[j] - startIndex);
                }
                else
                {
                    length = (prototype.Length - elementStartList[i]);
                }

                string prototypePart = prototype.Substring(startIndex, length);

                if (prototypePart.Contains(".") == false)   //	HACK
                {
                    prototypePartList.Add(prototypePart);
                }
            }

            return prototypePartList.OrderBy(m => (m)).ToList();
        }

        public override string ToString()
		{
			return $"{_name} ({_symbol}, {_atomicNumber})";
		}
	}
}