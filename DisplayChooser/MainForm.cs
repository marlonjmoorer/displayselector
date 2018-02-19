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


            try
            {
                 RegisterService();
            }catch(Exception e){

                MainForm.Show(null,e);
                throw e;

            }
          

           


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

            this.ModeText.Text = "Laptop";
            this.displayclient.SetRotationMode((int)RotationStates.MODE_LAPTOP);
            ScreenRotator.Rotate(RotationStates.MODE_LAPTOP);


        }
        private void ChangeDisplay(object sender, EventArgs e)
        {
           RotationStates state;
           var button = sender as Button;
           if (button!=null && Enum.TryParse(button.Tag.ToString(),out state))
           {
                this.displayclient.SetRotationMode((int)state);
                this.ModeText.Text = button.Text;
                ScreenRotator.Rotate(state);
               // RotateMainBtn.Enabled = RotateRemoteBtn.Enabled = state == RotationStates.MODE_LAYFLAT;
            
            
           }
           
        }

        private void RotateMainBtn_Click(object sender, EventArgs e)
        {
            ScreenRotator.RotateMain();
        }

        private void RotateRemoteBtn_Click(object sender, EventArgs e)
        {
            ScreenRotator.RotateRemote();
        }

        public  static void Show(string message,Exception e)
        {
            MessageBox.Show(message??e.Message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
