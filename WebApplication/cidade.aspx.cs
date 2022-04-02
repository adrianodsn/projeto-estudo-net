using System;
using System.Web.UI.WebControls;
using WebApplication.Entities;

namespace WebApplication
{
    public partial class PgCidade : PaginaBase
    {
        Cidade Cidade { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Cidade = Uow.CidadeRepository.Procurar(id);

            if (!IsPostBack)
            {
                litAcao.Text = "Nova cidade";

                ddlEstadoId.DataSource = Uow.EstadoRepository.ObterTodos();
                ddlEstadoId.DataTextField = "Nome";
                ddlEstadoId.DataValueField = "Id";
                ddlEstadoId.DataBind();
                ddlEstadoId.Items.Insert(0, new ListItem("Selecione", string.Empty));

                if (Cidade != null)
                {
                    litAcao.Text = "Edição de cidade";

                    txtNome.Text = Cidade.Nome;
                    ddlEstadoId.SelectedValue = Cidade.EstadoId.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var estadoId = !string.IsNullOrEmpty(ddlEstadoId.SelectedValue) ? Convert.ToInt32(ddlEstadoId.SelectedValue) : 0;
            var nome = txtNome.Text.Trim();

            var estado = Uow.EstadoRepository.Procurar(estadoId);

            if (Cidade == null)
            {
                Cidade = new Cidade(estado, nome);
                Uow.CidadeRepository.Adicionar(Cidade);
            }
            else
            {
                Cidade.Atualizar(estado, nome);
            }

            if (Cidade.Valid)
            {
                Uow.Commit();
                Response.Redirect("cidades.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Cidade.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}