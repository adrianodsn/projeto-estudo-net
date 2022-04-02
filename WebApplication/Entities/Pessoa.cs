using Flunt.Notifications;
using Flunt.Validations;
using System;
using WebApplication.Utils;

namespace WebApplication.Entities
{
    public class Pessoa : Notifiable
    {
        public Pessoa() { }

        public Pessoa(string nome, string cpf, DateTime dataNascimento)
        {
            Atualizar(nome, cpf, dataNascimento);
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; set; }

        public void Atualizar(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;

            var dataNascimentoMinima = DateTime.Now.AddYears(-120);
            var dataNascimentoMaxima = DateTime.Now.AddYears(-12);

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Nome.Length, 3, 50, "Pessoa.Nome", "O nome da pessoa deve ter entre 3 e 50 caracteres.")
                .IsTrue(Cpf.IsCpf(), "Pessoa.Cpf", "CPF Inválido.")
                .IsBetween(DataNascimento, dataNascimentoMinima, dataNascimentoMaxima, "Pessoa.DataNascimento", "Data de nascimento inválida.")
            );
        }
    }
}