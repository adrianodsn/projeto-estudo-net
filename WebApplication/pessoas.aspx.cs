using System;

namespace WebApplication
{
    public partial class PgPessoas : PaginaBase
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarRegistros();
            }
        }

        private void CarregarRegistros()
        {
            var termo = Request.QueryString["termo"];
            var cpf = Request.QueryString["cpf"];

            DateTime? dataNascimentoInicial = null;
            DateTime? dataNascimentoFinal = null;

            if (DateTime.TryParse(Request.QueryString["dataNascimentoInicial"], out DateTime _dataNascimentoInicial))
            {
                dataNascimentoInicial = _dataNascimentoInicial;
            }

            if (DateTime.TryParse(Request.QueryString["dataNascimentoFinal"], out DateTime _dataNascimentoFinal))
            {
                dataNascimentoFinal = _dataNascimentoFinal;
            }

            txtTermo.Text = termo;
            txtCpf.Text = cpf;

            if (dataNascimentoInicial != null) txtDataNascimentoInicial.Text = dataNascimentoInicial.Value.ToString("yyyy-MM-dd");
            if (dataNascimentoFinal != null) txtDataNascimentoFinal.Text = dataNascimentoFinal.Value.ToString("yyyy-MM-dd");

            var pessoas = Uow.PessoaRepository.BuscarPessoas(termo, cpf, dataNascimentoInicial, dataNascimentoFinal);

            grvPessoas.DataSource = pessoas;
            grvPessoas.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"pessoas.aspx?termo={txtTermo.Text}&cpf={txtCpf.Text}&dataNascimentoInicial={txtDataNascimentoInicial.Text}&dataNascimentoFinal={txtDataNascimentoFinal.Text}");
        }

        protected void grvPessoas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvPessoas.DataKeys[e.RowIndex].Value);
            Uow.PessoaRepository.Deletar(x => x.Id == id);
            Uow.Commit();
            CarregarRegistros();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"pessoas.aspx");
        }
    }
}