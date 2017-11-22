#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Hadoken.IO.Web.MaterialsProject
{
    [DataContract]
    public class MaterialsProjectSearchResult
    {
        [DataMember(Name = "band_gap")]
        public double BandGap
        {
            get;
            set;
        }

        //  [DataMember(Name = "diel")]
        //  public string Diel
        //  {
        //      get;
        //      set;
        //  }

        [DataMember(Name = "e_above_hull")]
        public double EnergyAboveHull
        {
            get;
            set;
        }

        //  [DataMember(Name = "elasticity")]
        //  public string Elasticity
        //  {
        //      get;
        //      set;
        //  }

        [DataMember(Name = "Elements")]
        public string[] Elements
        {
            get;
            set;
        }

        [DataMember(Name = "energy")]
        public double Energy
        {
            get;
            set;
        }

        [DataMember(Name = "formation_energy_per_atom")]
        public double FormationEnergyPerAtom
        {
            get;
            set;
        }

        [DataMember(Name = "full_formula")]
        public string FullFormula
        {
            get;
            set;
        }

        //  [DataMember(Name = "hubbards")]
        //  public string Hubbards
        //  {
        //      get;
        //      set;
        //  }

        //  [DataMember(Name = "icsd_id")]
        //  public string IcsdID
        //  {
        //      get;
        //      set;
        //  }

        [DataMember(Name = "IcsdIDs")]
        public string[] IcsdIDs
        {
            get;
            set;
        }

        [DataMember(Name = "is_hubbard")]
        public bool IsHubbard
        {
            get;
            set;
        }

        [DataMember(Name = "nsites")]
        public int NumberOfSites
        {
            get;
            set;
        }

        [DataMember(Name = "oxide_type")]
        public string OxideType
        {
            get;
            set;
        }

        //  [DataMember(Name = "piezo")]
        //  public string Piezo
        //  {
        //      get;
        //      set;
        //  }

        [DataMember(Name = "pretty_formula")]
        public string PrettyFormula
        {
            get;
            set;
        }

        [DataMember(Name = "spacegroup")]
        public Spacegroup Spacegroup
        {
            get;
            set;
        }

        [DataMember(Name = "tags")]
        public string[] Tags
        {
            get;
            set;
        }

        [DataMember(Name = "task_ids")]
        public string[] TaskIDs
        {
            get;
            set;
        }

        [DataMember(Name = "total_magnetization")]
        public double TotalMagnetization
        {
            get;
            set;
        }

        [DataMember(Name = "unit_cell_formula")]
        public UnitCellFormula UnitCellFormula
        {
            get;
            set;
        }

        [DataMember(Name = "volume")]
        public double Volume
        {
            get;
            set;
        }
    }
}