using System;
using System.Collections.Generic;
using System.Text;

namespace Storyline {

  /// <summary>
  /// A named span of time within a timeline.
  /// </summary>
  public class Era {

    public enum AffixType { Suffix, Prefix }

    /// <summary>
    /// The id of this Era
    /// </summary>
    public int id {
      get;
    }

    /// <summary>
    /// The name of this Era
    /// </summary>
    public string name {
      get;
    }

    /// <summary>
    /// The suffix or prefix of this era
    /// </summary>
    public string affix {
      get;
    }

    /// <summary>
    /// The type of affix this era uses
    /// </summary>
    public AffixType affixType {
      get;
    } = AffixType.Suffix;

    /// <summary>
    /// The number year this era's dates start with
    /// ex: 0 A.D vs 1 A.D
    /// </summary>
    public int startingYear {
      get;
    } = 1;

    /// <summary>
    /// If the years in this era are reverse, like in B.C
    /// </summary>
    public bool yearsAreReversed {
      get;
    }

    /// <summary>
    /// The beginning of this era.
    /// </summary>
    public Timestamp start {
      get;
    }

    /// <summary>
    /// The end of this era.
    /// </summary>
    public Timestamp end {
      get;
    }

    /// <summary>
    /// Create a new Era
    /// </summary>
    /// <param name="id">The id of the era</param>
    /// <param name="name">The name of the new era</param>
    /// <param name="affix"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="yearsAreReversed"></param>
    /// <param name="affixType"></param>
    /// <param name="startingYear"></param>
    public Era(
      string name,
      string affix,
      Timestamp end = null,
      Timestamp start = null,
      bool yearsAreReversed = false,
      AffixType affixType = AffixType.Suffix,
      int startingYear = 1
    ) {
      this.name = name;
      this.affix = affix;
      this.start = start;
      this.end = end;
      this.yearsAreReversed = yearsAreReversed;
      this.affixType = affixType;
      this.startingYear = startingYear;
    }
  }
}
