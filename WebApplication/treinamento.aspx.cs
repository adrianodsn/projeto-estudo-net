using System;
using WebApplication.Entities;

namespace WebApplication
{
    public partial class PgTreinamento : PaginaBase
    {
        Treinamento Treinamento { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Treinamento = Uow.TreinamentoRepository.Procurar(id);

            if (!IsPostBack)
            {
                litAcao.Text = "Novo treinamento";

                if (Treinamento != null)
                {
                    litAcao.Text = "Edição de treinamento";

                    txtNome.Text = Treinamento.Nome;
                    txtCargaHoraria.Text = Treinamento.CargaHoraria.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text.Trim();
            var cargaHoraria = Convert.ToDecimal(txtCargaHoraria.Text.Trim());

            if (Treinamento == null)
            {
                Treinamento = new Treinamento(nome, cargaHoraria);

                Uow.TreinamentoRepository.Adicionar(Treinamento);
            }
            else
            {
                Treinamento.Atualizar(nome, cargaHoraria);
            }

            if (Treinamento.Valid)
            {
                Uow.Commit();

                Response.Redirect("treinamentos.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Treinamento.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}