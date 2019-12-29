using System;
using System.Collections.Generic;
using System.Text;

namespace Storyline {

  /// <summary>
  /// A collection of events in narritive or cronological order.
  /// </summary>
  class Timeline {

    /// <summary>
    /// The id of this timeline
    /// </summary>
    public int id {
      get;
    }

    /// <summary>
    /// The name of this timeline
    /// </summary>
    public string name {
      get;
    }

    /// <summary>
    /// The type of calendar to use for this timeline.
    /// </summary>
    public Type type {
      get;
    }

    /// <summary>
    /// The ordered collection of events
    /// </summary>
    public List<Event> events {
      get;
    }

    /// <summary>
    /// Get a test human timeline
    /// </summary>
    public Timeline getTestTimeline() {
      Timeline testTimeline = new Timeline();
      testTimeline.events.AddRange(new Event[] {
        new Event("My Birthday", new Timestamp(12, 4, 21994, 3)),
        new Event("His Birthday", new Timestamp(11, 3, 21993, 1)),
        new Event("The Day Before My Birthday", new Timestamp(11, 4, 21994)),
        new Event("BirthWeek", new Timestamp(10, 4, 21994), new Timestamp(17, 4, 21994))
      });

      return testTimeline;
    }
  }

  /// <summary>
  /// A type of timeline
  /// This contains information about how the months days years and eras work within a custom calendar.
  /// </summary>
  public class Type {

    /// <summary>
    /// The id of this timeline type
    /// </summary>
    public int id {
      get;
      private set;
    }

    /// <summary>
    /// The name of this timeline type
    /// </summary>
    public string name {
      get;
      private set;
    }

    /// <summary>
    /// The length of an hour compared to 1 Earth hour in this timeline
    /// </summary>
    public float hourLength {
      get;
      private set;
    }

    /// <summary>
    /// The number of hours in a day in this timeline
    /// </summary>
    public int hoursInADay {
      get;
      private set;
    }

    /// <summary>
    /// The number of minuets in an hour in this timeline
    /// </summary>
    public int minuetsInAnHour {
      get;
      private set;
    }

    /// <summary>
    /// The distance between leap years in this timeline
    /// @TODO: make this a function to determine if the year is a leap year in this timeline
    /// </summary>
    public int leapYearFrequency {
      get;
      private set;
    }

    /// <summary>
    /// If this timeline's months use 'Xth of Month' naming instead of 'Month, X'
    /// </summary>
    public bool usesDayOfMonthNaming {
      get;
      private set;
    }

    /// <summary>
    /// The day and month of the leap day
    /// </summary>
    public Timestamp leapDate {
      get;
      private set;
    }

    /// <summary>
    /// The linux epoch's date and time in this timeline
    /// </summary>
    public Timestamp epoch {
      get;
      private set;
    }

    /// <summary>
    /// The months in this calendar's timeline in order
    /// </summary>
    public Month[] months {
      get;
      private set;
    }

    /// <summary>
    /// Named date ranges for this timeline, in order.
    /// </summary>
    public Era[] eras {
      get;
      private set;
    }

    /// <summary>
    /// Create a new type of timeline.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="epoch"></param>
    /// <param name="months"></param>
    /// <param name="eras"></param>
    /// <param name="hourLength"></param>
    /// <param name="hoursInADay"></param>
    /// <param name="minuetsInAnHour"></param>
    /// <param name="leapYearFrequency"></param>
    /// <param name="leapDate"></param>
    /// <param name="usesDayOfMonthNaming"></param>
    public Type(
      string name,
      Timestamp epoch,
      Month[] months,
      float hourLength,
      int hoursInADay,
      int minuetsInAnHour,
      bool usesDayOfMonthNaming,
      Era[] eras,
      int leapYearFrequency = 0,
      Timestamp leapDate = null
    ) {
      this.name = name;
      this.epoch = epoch;
      this.months = months;
      this.eras = eras;
      this.hourLength = hourLength;
      this.hoursInADay = hoursInADay;
      this.minuetsInAnHour = minuetsInAnHour;
      this.leapYearFrequency = leapYearFrequency;
      this.leapDate = leapDate;
      this.usesDayOfMonthNaming = usesDayOfMonthNaming;
    }

    public Type[] getAllTestTimelineTypes() {
      return new Type[] {
        new Type(
          "Human",
          new Timestamp(1, 1, 21970),
          new Month[] {
            new Month("January", 31),
            new Month("February", 28),
            new Month("March", 31),
            new Month("April", 30),
            new Month("May", 31),
            new Month("June", 30),
            new Month("July", 31),
            new Month("August", 31),
            new Month("September", 30),
            new Month("October", 31),
            new Month("November", 30),
            new Month("December", 31)
          },
          1.0f,
          24,
          60,
          false,
          new Era[] {
            new Era(
              "Before The Common Era",
              "B.C.E",
              new Timestamp(1, 1, 20000),
              null,
              true
            ),
            new Era("Common Era", "C.E")
          },
          4,
          new Timestamp(20, 2, 21972)
        ),
        new Type(
          "Tantar",
          new Timestamp(1, 1, 20000),
          new Month[] {
            new Month("New Summer", 24),
            new Month("Old Summer", 24),
            new Month("The Gentle Season", 24),
            new Month("Stormy Skies", 24),
            new Month("The Misty Season", 24),
            new Month("Preparation", 24),
            new Month("Gathering Season", 24),
            new Month("Spite", 24),
            new Month("Reclamation", 24),
            new Month("New Spring", 24),
            new Month("Old Spring", 24),
            new Month("Smoldering", 24)
          },
          1.2f,
          12,
          60,
          true,
          new Era[] {
            new Era("The Beginning", "'D Ral", new Timestamp(7, 1, 1)),
            new Era("The Age Of Gold", "D' Korr^o", new Timestamp(7, 1, 1), new Timestamp(8, 1, 1)),
            new Era("The Age Of Reclamation", "D' KyaM^i", new Timestamp(1, 1, 3), new Timestamp(24, 12, 902)),
            new Era("The Age of Darkness", "D' Ul", new Timestamp(1, 1, 903), new Timestamp(24, 12, 7567)),
            new Era("The Age of Gods", "D' R^ael", new Timestamp(1, 1, 7568), new Timestamp(24, 12, 11167)),
            new Era("Our Age", "D' Tar", null, new Timestamp(1, 1, 11168))
          }
        )
      };
    }

    /// <summary>
    /// A type of month
    /// </summary>
    public class Month {

      /// <summary>
      /// The # of days in this month
      /// </summary>
      public int numberOfDays {
        get;
      }

      /// <summary>
      /// The name of this month
      /// </summary>
      public string name {
        get;
      }

      /// <summary>
      /// Make a new month
      /// </summary>
      /// <param name="name"></param>
      /// <param name="numberOfDays"></param>
      public Month(string name, int numberOfDays) {
        this.numberOfDays = numberOfDays;
        this.name = name;
      }
    }
  }
}
