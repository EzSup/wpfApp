using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Dapper;

#nullable disable

namespace Task10WPFApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "appsettings.json");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configPath, optional: true, reloadOnChange: true)
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Courses (NAME, DESCRIPTION) VALUES ('SR', 'Social Sciences'), ('ER', 'Engineering and Technology'), ('BM', 'Biomedical Sciences')");
                connection.Execute("INSERT INTO Teachers (FIRST_NAME,SECOND_NAME) VALUES ('Ivan', 'Petriv'), ('Ryan', 'Gosling'), ('Olha','Sydorenko'), ('Nicholas','Kage'), ('Max','Lysenko'), ('Yulia', 'Kovalchuk'), ('Anna','Kovalenko'), ('Michael','Shevchenko'), ('Vasyl','Konovalec'), ('Diana','Tkachenko'), ('Alexei','Romanov')");
                connection.Execute(@"INSERT INTO Groups (COURSE_ID, TEACHER_ID, NAME)
                        VALUES
                            (1, 1, 'SR-01'),
                            (1, 6, 'SR-02'),
                            (1, 3, 'SR-03'),
                            (1, 4, 'SR-04'),
                            (2, 5, 'ER-01'),
                            (2, 7, 'ER-02'),
                            (3, 8, 'BM-01'),
                            (3, 9, 'BM-02'),
                            (3, 10,'BM-03');
                    ");
                connection.Execute(@"INSERT INTO Students (GROUP_ID, FIRST_NAME,SECOND_NAME)
                    VALUES
                     (1,'Emily','Johnson'),
                     (1,'Ethan','Davis'),
                     (1,'Olivia','Wilson'),
                     (1,'Liam','Smith'),
                     (1,'Ava','Martinez'),
                     (1,'Noah','Anderson'),
                     (1,'Isabella','Taylor'),
                     (1,'Lucas','Thomas'),
                     (1,'Sophia','Hernandez'),
                     (1,'Mason','Brown'),
                     (1,'Mia','Clark'),
                     (1,'Benjamin','Lewis'),
                     (2,'Charlotte','Lee'),
                     (2,'Alexander','Walker'),
                     (2,'Amelia','Hall'),
                     (2,'James','Allen'),
                     (2,'Harper','Young'),
                     (2,'Jacob','Green'),
                     (2,'Evelyn','Baker'),
                     (2,'Michael','Martinez'),
                     (2,'Abigail','Phillips'),
                     (3,'Ethan','Mitchell'),
                     (3,'Elizabeth','Hill'),
                     (3,'Daniel','Thompson'),
                     (3,'Sofia','Adams'),
                     (3,'William','Nelson'),
                     (3,'Madison','Turner'),
                     (3,'Alexander','Campbell'),
                     (3,'Grace','Roberts'),
                     (3,'Henry','Edwards'),
                     (3,'Victoria','Moore'),
                     (3,'Samuel','Reed'),
                     (4,'Scarlett','Phillips'),
                     (4,'Joseph','Brooks'),
                     (4,'Olena','Ivanenko'),
                     (4,'Roman','Kovalenko'),
                     (4,'Sofiya','Melnyk'),
                     (5,'Oleksandr','Shevchenko'),
                     (5,'Kateryna','Bondarenko'),
                     (5,'Samuel','Turner'),
                     (6,'Andriy','Tkachenko'),
                     (6,'Dmytro','Kravchenko'),
                     (6,'Anastasiya','Shevchuk'),
                     (6,'Volodymyr','Lysenko'),
                     (6,'Viktoriya','Yakovenko'),
                     (6,'Pavlo','Protsenko'),
                     (6,'Iryna','Zaytseva'),
                     (6,'Mykhailo','Zakharchenko'),
                     (6,'Tetiana','Boyko'),
                     (6,'Nataliya','Romanchuk'),
                     (6,'Serhiy','Lysak'),
                     (7,'Yaroslav','Ponomarenko'),
                     (7,'Olga','Rybak'),
                     (7,'Yuliya','Radchenko'),
                     (7,'Mariya','Symonenko'),
                     (7,'Kateryna','Tkachuk'),
                     (7,'Tetiana','Kovalchuk'),
                     (8,'Viktoriya','Oliynyk'),
                     (8,'Yevhen','Maksymenko'),
                     (8,'Bohdan','Mykhaylenko'),
                     (8,'Anna','Chumak'),
                     (8,'Iryna','Serhiyenko'),
                     (8,'Oleksiy','Zayarnyuk'),
                     (8,'Serhiy','Fesenko'),
                     (9,'Yana','Romanyuk'),
                     (9,'Oleksandr','Kushnir'),
                     (9,'Mariya','Pishchik'),
                     (9,'Olena','Chornovil'),
                     (9,'Vasyl','Medvedenko'),
                     (9,'Oleksandr','Kryvetska')
                
                ");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
