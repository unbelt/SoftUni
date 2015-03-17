

namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExtendedCinemaEngine : CinemaEngine
    {

        // Inserting performance
        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var venue = base.GetVenue(commandWords[5]);

            switch (commandWords[2])
            {
                case "theatre":
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;

                case "concert":
                    var movie = new Concert(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(movie);
                    break;
                default: base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        // Insert venue
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default: base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            // TODO
        }

        protected override void ExecuteSellTicketCommand(string[] commandWords)
        {
            // TODO
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            // TODO
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            // TODO
        }

        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "tickets":
                    this.ExecuteSupplyTicketsCommand(commandWords);
                    break;
                case "reporting":
                    this.ExecuteReportCommand(commandWords);
                    break;
                case "searching":
                    this.ExecuteFindCommand(commandWords);
                    break;
                default: base.ExecuteFindCommand(commandWords);
                    break;
            }
        }
    }
}
