using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RelaxYourEyes
{
    public partial class FormMain : Form
    {
        private bool _autoStart = false;

        private DateTime _dateLastRest;

        private bool _warning1showed;
        private bool _warning2showed;
        private bool _hasDelayedBreak;

        private const int MINUTES_WITHOUT_BREAK = 57;
        private const int BREAK_LENGTH = 3;
        private const int FIRST_WARNING_MINUTES = 3;
        private const int SECOND_WARNING_MINUTES = 1;
        private const int DELAY_MINUTES = 3;

        public FormMain(bool autostart)
        {
            this.InitializeComponent();

            // if the program was loaded with the argument -autostart, the application will start and hide
            this._autoStart = autostart;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // we register a method to the session switches
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(this.SystemEvents_SessionSwitch);

            // we set the time of the break
            this.timerResting.Interval = BREAK_LENGTH * 60 * 1000;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (this._autoStart)
            {
                StartAndHide();
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            StartAndHide();
        }

        /// <summary>
        /// Method to start the program and hide the main form
        /// </summary>
        private void StartAndHide()
        {
            this._dateLastRest = DateTime.UtcNow;
            this.ResetWarningsAndBreak();
            this.timerRest.Start();
            this.Hide();
        }

        /// <summary>
        /// Method called each second during the "non-break" period
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRest_Tick(object sender, EventArgs e)
        {
            var endDate = this._dateLastRest.AddMinutes(MINUTES_WITHOUT_BREAK);

            // we display a first warning X minutes before
            if (!this._warning1showed && endDate.AddMinutes(-FIRST_WARNING_MINUTES) < DateTime.UtcNow)
            {
                this._warning1showed = true;
                this.ShowPauseBalloonTip(FIRST_WARNING_MINUTES);
            }
            else if (!this._warning2showed && endDate.AddMinutes(-SECOND_WARNING_MINUTES) < DateTime.UtcNow)
            {
                // we display a second warning X minutes before
                this._warning2showed = true;
                this.ShowPauseBalloonTip(SECOND_WARNING_MINUTES);
            }
            else if (endDate < DateTime.UtcNow)
            {
                // we lock the work station
                this.timerRest.Stop();
                this.timerResting.Start();
                LockWorkStation();
            }
        }

        /// <summary>
        /// Method called when the break ends
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerResting_Tick(object sender, EventArgs e)
        {
            this.timerResting.Stop();
            this._dateLastRest = DateTime.UtcNow;
            this.ResetWarningsAndBreak();
            this.timerRest.Start();
        }

        /// <summary>
        /// Method to delay the next break
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delayNextBreakBy3MinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this._hasDelayedBreak)
            {
                this._hasDelayedBreak = true;
                this._warning2showed = false;
                this._dateLastRest = this._dateLastRest.AddMinutes(DELAY_MINUTES);
            }
            else
            {
                MessageBox.Show("Nope, you already delayed your break.");
            }
        }

        /// <summary>
        /// Method that is called when the state of the session changes. If you are supposed to be in a break, but your session is unlocked, it will be lock again in a few seconds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                if (timerResting.Enabled)
                {
                    System.Threading.Thread.Sleep(4000);
                    LockWorkStation();
                }
            }
            else if (e.Reason == SessionSwitchReason.SessionLock)
            {
                if (!timerResting.Enabled)
                {
                    // pause the timer
                }
            }
        }

        /// <summary>
        /// Resets the states of the warnings
        /// </summary>
        private void ResetWarningsAndBreak()
        {
            this._warning2showed = false;
            this._warning1showed = false;
            this._hasDelayedBreak = false;
        }

        /// <summary>
        /// This method shows a tooltip balloon with a warning: "You will have to relax your eyes in {0} minutes".
        /// </summary>
        /// <param name="minutes">the number of minutes before the lock of your session</param>
        private void ShowPauseBalloonTip(int minutes)
        {
            this.notifyIconFormMain.BalloonTipText = string.Format("You will have to relax your eyes in {0} minutes.", minutes);
            this.notifyIconFormMain.ShowBalloonTip(4);
        }

        /// <summary>
        /// Here is the code to lock the workstation
        /// </summary>
        private const int WmSyscommand = 0x0112;
        private const int ScMonitorpower = 0xF170;
        private const int HwndBroadcast = 0xFFFF;
        private const int ShutOffDisplay = 2;
        [DllImport("user32.dll")]
        private static extern void LockWorkStation();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
