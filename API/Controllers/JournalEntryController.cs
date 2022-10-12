using Domain;
using Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class JournalEntryController
    {

        private static readonly string[] Summaries = new[]
        {
        "Learn a new strumming technique", "Practiced Scales for 30 Minutes, and worked on \"Smoke on the Water\" riff.", "Worked on rhythm studies by playing with a metronome."
    };

        private readonly ILogger<JournalEntryController> _logger;

        private readonly DataContext _context;

        public JournalEntryController(ILogger<JournalEntryController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetJournalEntry")]
        public IEnumerable<JournalEntry> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new JournalEntry
            {
                Date = DateTime.Now.AddDays(index),
                //TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public ActionResult<JournalEntry> Create()
        {
            Console.WriteLine($"Database path: {_context.DbPath}");
            Console.WriteLine("Insert a new WeatherForecast");

            var entry = new JournalEntry()
            {
                Date = new DateTime(),
                Summary = "Practiced arpeggios in G, G#, and A."
            };

            _context.JournalEntries.Add(entry);
            var success = _context.SaveChanges() > 0;

            if (success)
            {
                return entry;
            }

            throw new Exception("Error creating Journal Entry");
        }
    }


}
