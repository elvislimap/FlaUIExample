using System.Threading;
using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using Xunit;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using System.Diagnostics;
using System.Linq;
using AutomationTests2.Utils;

namespace AutomationTests2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var cf = new ConditionFactory(new UIA3PropertyLibrary());
            var application = Application.Attach(@"C:\Users\Elvis\AppData\Local\Programs\" +
                @"Microsoft VS Code\Code.exe");
            Application.AttachOrLaunch(new ProcessStartInfo(@"D:\PontoSys\Integrador\" +
                "Integrations.VirtualIntegration.Presentation.App.exe"));

            Thread.Sleep(3000);

            var windowVsCode = application.GetMainWindow(new UIA3Automation());
            var desktop = windowVsCode.Parent.AsWindow();
            var taskBar = desktop.FindFirstDescendant(cf.ByName("Barra de Tarefas")).AsWindow();
            var trayNotify = taskBar.FindFirstDescendant(cf.ByClassName("TrayNotifyWnd")).AsWindow();
            var sysPagerTray = trayNotify.FindFirstDescendant(cf.ByClassName("SysPager")).AsWindow();
            var toolbarWindow32 = sysPagerTray
                .FindFirstDescendant(cf.ByClassName("ToolbarWindow32")).AsWindow();

            toolbarWindow32
                .FindFirstDescendant(cf.ByName("Integrador - Ponto.Sys Sistemas"))
                .AsButton().Click();

            Thread.Sleep(1000);
            var frmPrincipal = desktop.FindFirstDescendant(cf.ByAutomationId("FrmPrincipal"))
                .AsWindow();

            frmPrincipal.FindFirstDescendant(cf.ByName("Pedzap")).AsMenuItem().Click();
            Thread.Sleep(500);
            frmPrincipal.FindFirstDescendant(cf.ByName("Configurações PedZap")).AsMenuItem().Click();
            Thread.Sleep(2000);

            var frmConfigurarPedzap = frmPrincipal
                .FindFirstDescendant(cf.ByAutomationId("FrmConfigurarPedzap")).AsWindow();
            frmConfigurarPedzap.FindFirstDescendant(cf.ByAutomationId("Close")).AsButton().Click();

            Thread.Sleep(1000);
            frmPrincipal.FindFirstDescendant(cf.ByAutomationId("Close")).AsButton().Click();
        }

        [Fact]
        public void Test2()
        {
            var cf = new ConditionFactory(new UIA3PropertyLibrary());
            var application = Application
                .AttachOrLaunch(new ProcessStartInfo(@"D:\PontoSys\Integrador\" +
                "Integrations.VirtualIntegration.Presentation.App.exe"));

            Thread.Sleep(1000);
            OpenWindowIntegration();
            Thread.Sleep(1000);

            var windows = application.GetWindows();
            var frmPrincipal = windows.First(w => w.AutomationId == "FrmPrincipal");

            frmPrincipal.FindFirstDescendant(cf.ByName("Pedzap")).AsMenuItem().Click();
            Thread.Sleep(500);
            frmPrincipal.FindFirstDescendant(cf.ByName("Configurações PedZap")).AsMenuItem().Click();
            Thread.Sleep(2000);

            var frmConfigurarPedzap = frmPrincipal
                .FindFirstDescendant(cf.ByAutomationId("FrmConfigurarPedzap")).AsWindow();
            frmConfigurarPedzap.FindFirstDescendant(cf.ByAutomationId("Close")).AsButton().Click();

            Thread.Sleep(1000);
            frmPrincipal.FindFirstDescendant(cf.ByAutomationId("Close")).AsButton().Click();
        }


        private void OpenWindowIntegration()
        {
            var width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            var heigth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            Mouse.MoveTo(width - 210, heigth - 20);
            Mouse.Click();
        }
    }
}
