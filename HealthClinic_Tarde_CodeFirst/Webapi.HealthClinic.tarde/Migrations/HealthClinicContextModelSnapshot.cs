﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webapi.HealthClinic.tarde.Context;

#nullable disable

namespace Webapi.HealthClinic.tarde.Migrations
{
    [DbContext(typeof(HealthClinicContext))]
    partial class HealthClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Clinica", b =>
                {
                    b.Property<Guid>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100) ");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<TimeSpan?>("HoraAbertura")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("HoraFechamento")
                        .HasColumnType("time");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdClinica");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Clinica");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Comentario", b =>
                {
                    b.Property<Guid>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataComentario")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<bool>("Exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("IdConsulta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdComentario");

                    b.HasIndex("IdConsulta");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Consulta", b =>
                {
                    b.Property<Guid>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("Date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdMedico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSitucao")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdSitucao");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Especialidade", b =>
                {
                    b.Property<Guid>("IdEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdEspecialidade");

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Medico", b =>
                {
                    b.Property<Guid>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("IdClinica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEspecialidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdMedico");

                    b.HasIndex("CRM")
                        .IsUnique()
                        .HasFilter("[CRM] IS NOT NULL");

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdEspecialidade");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Paciente", b =>
                {
                    b.Property<Guid>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("IdPaciente");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("RG")
                        .IsUnique();

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Situacao", b =>
                {
                    b.Property<Guid>("IdSituacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("SituacaoConsulta")
                        .HasColumnType("BIT");

                    b.HasKey("IdSituacao");

                    b.ToTable("Situacao");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.TipoUsuario", b =>
                {
                    b.Property<Guid>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdTipoUsuario");

                    b.HasIndex("Telefone")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Comentario", b =>
                {
                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Consulta", b =>
                {
                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Situacao", "Situacao")
                        .WithMany()
                        .HasForeignKey("IdSitucao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Medico", b =>
                {
                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("IdClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("IdEspecialidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Especialidade");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Paciente", b =>
                {
                    b.HasOne("Webapi.HealthClinic.tarde.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Webapi.HealthClinic.tarde.Domains.Usuario", b =>
                {
                    b.HasOne("Webapi.HealthClinic.tarde.Domains.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
