using System;
using System.Collections.Generic;
using System.Text;

namespace Storyline {

  /// <summary>
  /// A time and date value used between different timelines
  /// </summary>
  public class Timestamp {

    /// <summary>
    /// The type of timespan.
    /// Used to determine how an event's dates determine when it happens/what time period it occupies.
    /// </summary>
    public enum Type {
      /// <summary>
      /// If the event occured at exactly the start time,
      /// Not for duration events or events that last a period of time
      /// </summary>
      InitialInstant,
      /// <summary>
      /// For events that last the entire durration of start to end date/time
      /// </summary>
      EntireDurration,
      /// <summary>
      /// For events that occur in a single instant, 
      /// but are sometime between start and end
      /// </summary>
      SometimeBetween,
      /// <summary>
      /// If this event is only set to a fuzzy time of day, like morning, evening.
      /// </summary>
      FuzzyTimeOfDay,
      /// <summary>
      /// For events that trail an event prior
      /// (with a specific id in event.parent_event_id)
      /// Event.start is used to determine how long after the parent event this event starts
      /// </summary>
      TrailingAction
    }

    /// <summary>
    /// Used for multi-day spanned events, as events are separated per-day.
    /// This tells what part of the multi-day event we're looking at.
    /// Single means this is not a multi day event.
    /// </summary>
    public enum Part {
      Single,
      Beginning,
      Middle,
      End
    }

    /// <summary>
    /// The ordinal date endings
    /// </summary>
    static string[] OrdinalEndings 
      = { "th", "st", "nd", "rd", "th", "th", "th", "th", "th", "th" };

    /// <summary>
    /// The moment of time within the hour that this timestamp represents.
    /// Represented as a float % between 0 and 1
    /// </summary>
    public float moment {
      get;
    } = 0;

    /// <summary>
    /// The hour of the day
    /// </summary>
    public int hour {
      get;
    } = 0;

    /// <summary>
    /// The day of the month
    /// </summary>
    public int day {
      get;
    }

    /// <summary>
    /// The ordinal day (1st, 3rd...)
    /// </summary>
    public string ordinalDay {
      get => GetOrdinalDate(day);
    }

    /// <summary>
    /// The month of the year
    /// </summary>
    public int month {
      get;
    }

    /// <summary>
    /// The year of this timestamp.
    /// </summary>
    public int? year {
      get;
    } = null;

    /// <summary>
    /// Make a new timestamp
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <param name="year">Can be null</param>
    /// <param name="hour"></param>
    /// <param name="moment">The minuet within the hour, as a % between 0 and 1</param>
    public Timestamp(int day, int month, int? year = null, int hour = 0, float moment = 0) {
      this.day    = day;
      this.month  = month;
      this.year   = year;
      this.hour   = hour;
      this.moment = moment;
    }

    /// <summary>
    /// Get if this timestamp is before another
    /// </summary>
    /// <returns></returns>
    public bool isBefore(Timestamp date) {
      return year < date.year
        // if the year is equal, and the month is smaller that works too
        || (year == date.year && month < date.month)
        // if the year is equal, and the month is equal, the day could be smaller
        || (year == date.year && month == date.month && day < date.day)
        // if the year is equal, and the month is equal, and the day too, the hour needs to be smaller
        || (year == date.year && month == date.month && day == date.day && hour < date.hour)
        // once more for moment.
        || (year == date.year && month == date.month && day == date.day && hour < date.hour && moment < date.moment);
    }

    /// <summary>
    /// Get an ordinal value for the given xth of the month
    /// </summary>
    /// <param name="dayOfTheMonth"></param>
    /// <returns>The ordinal day (1st, 2nd, 3rd etc)</returns>
    public static string GetOrdinalDate(int dayOfTheMonth) {
      if (((dayOfTheMonth % 100) >= 11) && ((dayOfTheMonth % 100) <= 13)) {
        return dayOfTheMonth + "th";
      } else {
        return dayOfTheMonth + OrdinalEndings[dayOfTheMonth % 10];
      }
    }
  }
}
