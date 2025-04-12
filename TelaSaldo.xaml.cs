namespace AppBetzada;

public partial class TelaSaldo : ContentPage
{
    double valor;
    public TelaSaldo()
    {
        InitializeComponent();
    }

    private void btnDepositar_Clicked(object sender, EventArgs e)
    {
        valor = Convert.ToDouble(txtValor.Text);

        if (valor > 0)
        {

            Dados.saldo = Dados.saldo + valor;
            lblMsg.Text = "Depósito realizado com sucesso!";
            lblSaldoAtual.Text = Dados.saldo.ToString("0.00");
            txtValor.Text = lblSaldoAtual.Text;
        }
        else
        {

            lblMsg.Text = "Valor de depósito insuficiente!";
        }
    }

    private void btnSacar_Clicked(object sender, EventArgs e)
    {
        valor = Convert.ToDouble(txtValor.Text);

        if (valor > Dados.saldo)
        {
            lblMsg.Text = "Saque indisponível. Saldo insuficiente!";
        }
        else if (valor == 0)
        {
            lblMsg.Text = "Saque cancelado! \n Valor deve ser maior do que zero";
        }
        else
        {
            Dados.saldo -= valor;
            lblMsg.Text = "Saque realizado com sucesso!";
            lblSaldoAtual.Text = Dados.saldo.ToString("0.00");
        }
    }

    protected override void OnAppearing()
    {
        lblSaldoAtual.Text = Dados.saldo.ToString("");

    }


}
