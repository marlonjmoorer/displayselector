using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using DisplaySelector.ServiceDisplayMode;
using System.Configuration;

namespace DisplaySelector
{
    public partial class MainForm : Form
    {
       
        private SixModeServiceClient displayclient;


        public MainForm()
        {
            InitializeComponent();

            RegisterService();

        }

        void RegisterService()
        {
            string url = ConfigurationManager.AppSettings["serviceUrl"];
            NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.None);
            tcpBinding.MaxReceivedMessageSize = 2000000;
            EndpointAddress address = new EndpointAddress(url);
            var callbackInstance = new InstanceContext(new ChangeDetector());

            this.displayclient = new SixModeServiceClient(callbackInstance,tcpBinding,address);
            displayclient.Register();
           
          

        }
        private void ChangeDisplay(object sender, EventArgs e)
        {
           RotationStates type;
            var button = sender as Button;
           if (button!=null && Enum.TryParse(button.Tag.ToString(),out type))
           {
                this.displayclient.SetRotationMode((int)type);
                this.ModeText.Text = button.Text;
                //ScreenRotator.Rotate(type);
            
           }
           
        }



       
    }
}
