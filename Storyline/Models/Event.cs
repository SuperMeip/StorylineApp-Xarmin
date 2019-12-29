namespace Storyline {
  public class Event {

    /// <summary>
    /// The id of this event
    /// </summary>
    public int id {
      get;
    }

    /// <summary>
    /// The name of this event
    /// </summary>
    public string name {
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
    /// The type of span of time this event occupies.
    /// </summary>
    public Timestamp.Type timespanType {
      get;
    } = Timestamp.Type.InitialInstant;

    /// <summary>
    /// What part of a span of time this event is.
    /// Used if an event occurs over multiple days in order to break it up.
    /// </summary>
    public Timestamp.Part timespanPart {
      get;
    } = Timestamp.Part.Single;

    /// <summary>
    /// The parent event of this one, if it has one.
    /// </summary>
    Event parent;

    /// <summary>
    /// Create a new event
    /// </summary>
    public Event(
      string name, 
      Timestamp start,
      Timestamp end = null, 
      Timestamp.Type timespanType = Timestamp.Type.InitialInstant,
      Timestamp.Part timespanPart = Timestamp.Part.Single
    ) {
      this.name = name;
      this.start = start;
      this.end = end;
      // If we just put in two dates, update the timespan type for us
      this.timespanType = (timespanType == Timestamp.Type.InitialInstant && end != null)
        ? Timestamp.Type.EntireDurration
        : timespanType;
      this.timespanPart = timespanPart;
    }
  }
}