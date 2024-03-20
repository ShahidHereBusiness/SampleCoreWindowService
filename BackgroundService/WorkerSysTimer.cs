using static SOA.MakeDeminish;

namespace SampleWorkerService
{
    public class WorkerSysTimer : BackgroundService
    {
        private readonly ILogger<WorkerSysTimer> _logger;
        private static System.Timers.Timer? aTimer;        

        public WorkerSysTimer(ILogger<WorkerSysTimer> logger)
        {
            _logger = logger;            
        }
        #region BackgroundService
        public override async Task StartAsync(CancellationToken stoppingToken)
        {
            LogEvent("The event was StartAsync.");
            await base.StartAsync(stoppingToken);
            SetTimer();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            LogEvent("The ExecuteAsync event Working.");
        Found://Mark Jump
            await Task.Delay(new TimeSpan(0, 0, 25));
            LogEvent($"ExecuteAsync Jump event was raised at {DateTime.Now.ToString("yyyyMMddHHmmssfff")}");            

            if (!stoppingToken.IsCancellationRequested)
                goto Found;
            // End of Jump Statement
            LogEvent($"ExecuteAsync Jump End event was raised at {DateTime.Now.ToString("yyyyMMddHHmmssfff")}");
        }
        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            aTimer.Enabled = false;
            LogEvent("The event was StopAsync.");
            await base.StopAsync(stoppingToken);
        }
        #endregion Service Task Trigger
        
        #region System.Timers.Timer
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(CountDown);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, EventArgs e)
        {
            aTimer.Enabled = false;
            LogEvent($"The Elapsed event was raised at {DateTime.Now.ToString("yyyy-MM-dd::HH:mm:ss:fff")}");
            aTimer.Enabled = true;
        }
        #endregion
        ~WorkerSysTimer()
        {
            GC.Collect();
        }
    }
}