﻿using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplication.Entities
{
    public class Cidade : Notifiable
    {
        public Cidade() { }

        public Cidade(Estado estado, string nome)
        {
            Atualizar(estado, nome);
        }

        public int Id { get; set; }
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public bool Excluir { get; set; }

        public void Atualizar(Estado estado, string nome)
        {
            Estado = estado;
            Nome = nome;

            if (Estado != null)
            {
                AddNotifications(Estado);
            }

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Nome.Length, 3, 50, "Cidade.Nome", "O nome da cidade deve ter entre 3 e 50 caracteres.")
                .IsFalse(Estado == null, "Cidade.Estado", "O estado não pode ser nulo.")
            );
        }

        public Estado Estado { get; set; }
    }
}