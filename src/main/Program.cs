using WinterCubeTimer.forms;

namespace WinterCubeTimer.main{
    internal static class Program{
        [STAThread]
        static void Main(){
            ApplicationConfiguration.Initialize();
            Application.Run(new WinterCubeTimerForm());
        }
    }
}