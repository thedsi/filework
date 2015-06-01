using System;
using System.Drawing;
using System.Windows.Forms;

namespace filework
{
    class Tray : IDisposable
    {
        MainForm mainForm;
        Engine engine;

        static Icon[] trayIcons = new Icon[] 
        {
            Properties.Resources.app_r0,
            Properties.Resources.app_r15,
            Properties.Resources.app_r30,
            Properties.Resources.app_r45,
            Properties.Resources.app_r60,
            Properties.Resources.app_r75
        };
        
        int currentIcon = 0;
        bool animEnable = false;
        NotifyIcon notifyIcon = new NotifyIcon();
        Timer changeIconTimer = new Timer();
        Timer toolTipUpdateTimer = new Timer();
        MenuItem statusItem;

        void UpdateIcon()
        {
            notifyIcon.Icon = trayIcons[currentIcon];
        }

        public Tray(MainForm parent, Engine engine)
        {
            this.mainForm = parent;
            this.engine = engine;
            engine.OnEngineUpdate += engine_OnEngineUpdate;
            notifyIcon.Visible = true;
            
            UpdateIcon();
            changeIconTimer.Interval = 87;
            changeIconTimer.Tick += new EventHandler((s, e) => {
                if (++currentIcon == trayIcons.Length) currentIcon = 0;
                UpdateIcon();
                if (currentIcon == 0) changeIconTimer.Enabled = animEnable;
            });
            changeIconTimer.Enabled = animEnable;

            toolTipUpdateTimer.Interval = 1000;
            toolTipUpdateTimer.Tick += new EventHandler((s, e) =>
            {
                UpdateToolTip();
            });

            ContextMenu x = new ContextMenu();
            statusItem = x.MenuItems.Add("", new EventHandler((s,e) =>
            {
                engine.ScanNow();
            }));
            x.MenuItems.Add("Настройка...", new EventHandler((s,e) =>
            {
                ShowMainForm();
            }));
            x.MenuItems.Add("Выход", new EventHandler((s, e) =>
            {
                mainForm.Dispose();
                Application.Exit();
            }));
            notifyIcon.ContextMenu = x;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;

            engine_OnEngineUpdate();
        }

        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        void UpdateToolTip()
        {
            notifyIcon.Text = engine.GetStatus();
            statusItem.Text = notifyIcon.Text;
        }

        void engine_OnEngineUpdate()
        {
            EnableAnimation(engine.State == Engine.EngineStates.Scanning ||
                            engine.State == Engine.EngineStates.Processing ||
                            engine.State == Engine.EngineStates.MovingToDone);
            statusItem.Enabled = (engine.State == Engine.EngineStates.WaitScan);
            toolTipUpdateTimer.Enabled = true;
            UpdateToolTip();
        }

        ~Tray()
        {
            Dispose();
        }

        void EnableAnimation(bool Enable)
        {
            animEnable = Enable;
            if(Enable) changeIconTimer.Enabled = true;
        }

        public void Dispose()
        {
            notifyIcon.Dispose();
            changeIconTimer.Dispose();
            GC.SuppressFinalize(this);
        }

        void ShowMainForm()
        {
            mainForm.Show();
            mainForm.Activate();
        }
    }
}
