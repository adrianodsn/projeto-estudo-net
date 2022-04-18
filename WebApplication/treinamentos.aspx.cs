using System;

namespace WebApplication
{
    public partial class PgTreinamentos : PaginaBase
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

            txtTermo.Text = termo;
    
            var pessoas = Uow.TreinamentoRepository.BuscarTreinamentos(termo);

            grvRegistros.DataSource = pessoas;
            grvRegistros.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"treinamentos.aspx?termo={txtTermo.Text}");
        }

        protected void grvRegistros_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvRegistros.DataKeys[e.RowIndex].Value);
            Uow.TreinamentoRepository.Deletar(x => x.Id == id);
            Uow.Commit();
            CarregarRegistros();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect("treinamentos.aspx");
        }
    }
}