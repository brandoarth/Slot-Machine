
using System.Timers;
namespace AppBetzada
{
    public partial class MainPage : ContentPage
    {
        private Random random = new Random();
        private System.Timers.Timer t1, t2, t3;
        private int n1, n2, n3, tempo1, tempo2, tempo3;
        double aposta, resultado;


        public MainPage()
        {
            InitializeComponent();
            lblSaldo.Text = Dados.saldo.ToString("0.00");
            btnIniciar.IsEnabled = true;
            btnParar.IsEnabled = false;

        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            aposta = Convert.ToDouble(txtAposta.Text);

            if (Dados.saldo == 0)
            {
                btnIniciar.IsEnabled = true;
            }
            else if (Dados.saldo >= aposta)
            {
                Dados.saldo -= aposta;
                lblSaldo.Text = Dados.saldo.ToString("0.00");
                timer1();
                timer2();
                timer3();
                btnIniciar.IsEnabled = false;
                btnParar.IsEnabled = true;
            }
            else
            {
                lblMsg.Text = "Saldo insuficiente. Faça um depósito";
            }
        }

        private void timer1()
        {
            tempo1 = random.Next(10, 70);
            t1 = new System.Timers.Timer(tempo1);
            t1.Elapsed += T1_Elapsed;
            t1.Start();
        }

        private void T1_Elapsed(object? sender, ElapsedEventArgs e)
        {
            n1 = random.Next(0, 10);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                lblN1.Text = n1.ToString();
            });
        }

        private void timer2()
        {
            tempo2 = random.Next(10, 70);
            t2 = new System.Timers.Timer(tempo1);
            t2.Elapsed += T2_Elapsed;
            t2.Start();
        }

        private void T2_Elapsed(object? sender, ElapsedEventArgs e)
        {
            n2 = random.Next(0, 10);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                lblN2.Text = n2.ToString();
            });
        }

        private void timer3()
        {
            tempo3 = random.Next(10, 70);
            t3 = new System.Timers.Timer(tempo1);
            t3.Elapsed += T3_Elapsed;
            t3.Start();
        }

        private void T3_Elapsed(object? sender, ElapsedEventArgs e)
        {
            n3 = random.Next(0, 10);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                lblN3.Text = n3.ToString();
            });
        }
        private void btnParar_Clicked(object sender, EventArgs e)
        {
            t1.Stop();
            t2.Stop();
            t3.Stop();
            verificar();
            lblSaldo.Text = Dados.saldo.ToString("0.00");
            btnIniciar.IsEnabled = true;
            btnParar.IsEnabled = false;
        }

        private void verificar()
        {
            if ((n1 == n2) && (n2 == n3) && (n1 == 7))
            {
                resultado = aposta * 50;
                Dados.saldo += resultado;
                lblMsg.Text = "Fantástico! Ganhou 50x";
                lblMsgResult.Text = resultado.ToString();
                lblMsgResult.FontSize = 45;
                return;
            }

            else if ((n1 == n2) && (n2 == n3))
            {
                resultado = aposta * 10;
                Dados.saldo += resultado;
                lblMsg.Text = "Vitória! Ganhou 10x";
                lblMsgResult.Text = resultado.ToString();
                lblMsgResult.FontSize = 45;
                return;
            }

            else if ((n1 == n2) || (n2 == n3) || (n1 == n3))
            {
                resultado = aposta * 5;
                Dados.saldo += resultado;
                lblMsg.Text = "Ganhou 5x";
                lblMsgResult.Text = resultado.ToString();
                lblMsgResult.FontSize = 45;
                return;
            }

            else
            {
                lblMsg.Text = "Perdeu!, aposte novamente.";
                return;
            }

        }

        protected override void OnAppearing()
        {
            lblSaldo.Text = Dados.saldo.ToString("0.00");
        }

    }

}
