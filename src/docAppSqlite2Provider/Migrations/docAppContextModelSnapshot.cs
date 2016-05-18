using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using docAppSqlite2Provider;

namespace docAppSqlite2Provider.Migrations
{
    [DbContext(typeof(docAppContext))]
    partial class docAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901");

            modelBuilder.Entity("docAppDomain.Model.AppointmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AppointmentDate");

                    b.Property<string>("AppointmentTime");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("Email");

                    b.Property<bool>("EstablishedPatient");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("InsuranceOption");

                    b.Property<string>("LastName");

                    b.Property<string>("Reason");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });
        }
    }
}
