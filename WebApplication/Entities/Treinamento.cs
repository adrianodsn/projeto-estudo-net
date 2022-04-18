using Flunt.Notifications;
using Flunt.Validations;
using System;
using WebApplication.Utils;

namespace WebApplication.Entities
{
    public class Treinamento : Notifiable
    {
        public Treinamento() { }

        public Treinamento(string nome, decimal cargaHoraria)
        {
            Atualizar(nome, cargaHoraria);
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal CargaHoraria { get; private set; }

        public void Atualizar(string nome, decimal cargaHoraria)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Nome.Length, 2, 200, "Treinamento.Nome", "O nome do treinamento deve ter entre 2 e 200 caracteres.")
                .IsBetween(CargaHoraria, 1, 100, "Treinamento.CargaHoraria", "A carga horária deve estar entre 1 e 100 horas.")
            );
        }
    }
}