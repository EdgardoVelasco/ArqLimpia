using System.Timers;
namespace MVVMApp.ViewModels
{


    public class ClockViewModel
    {
        public string Name { get; set; } = "";

        public System.Timers.Timer _timer { get; set; }
        public string CurrentTime { get; set; }

        public ClockViewModel() {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += Update;
            _timer.Start();
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        }

        public void Update(object sender, ElapsedEventArgs args) {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        }

        public void Dispose() {
            _timer?.Dispose();
        }

    }
}
