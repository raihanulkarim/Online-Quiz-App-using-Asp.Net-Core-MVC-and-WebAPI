using Microsoft.EntityFrameworkCore;

namespace OnlineQuizApi.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Questions> Questions{ get; set; }
        public DbSet<Categories> Categories{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId=1, Title="C#"});
            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId=2, Title="MsSQL"});
            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId=3, Title="ASP.Net Core"});
           
            modelBuilder.Entity<Questions>().HasData(
                new Questions { Id = 1, Question= "Correct Declaration of Values to variables a and b?", Option1= "A int a = 32, b = 40.6;", Option2= "B int a = 42; b = 40;", Option3= "C int a = 32; int b = 40;", Option4= "D int a = b = 42;", CorrAns= "C int a = 32; int b = 40;",CategoryId = 1});
            modelBuilder.Entity<Questions>().HasData(
                new Questions { Id = 2, Question= "How many Bytes are stored by Long Datatype in C# .net?", Option1="8", Option2="4", Option3="2", Option4="1", CorrAns="8",CategoryId = 1});
            modelBuilder.Entity<Questions>().HasData(
                new Questions { Id = 3, Question= "Which Is The Subset Of SQL Commands Used To Manipulate Oracle Database Structures, Including Tables?", Option1= "Data Manipulation Language(DML)", Option3= "Both Of Above", Option2= "Data Definition Language(DDL)", Option4= "None", CorrAns= "Data Manipulation Language(DML)",CategoryId = 2});
            modelBuilder.Entity<Questions>().HasData(
                new Questions { Id = 4, Question= "The SQL Statement<br>SELECT SUBSTR('123456789', INSTR('abcabcabc', 'b'), 4) FROM DUAL;", Option1= "6789", Option2= "1234", Option3= "2345", Option4= "456789", CorrAns= "2345", CategoryId = 2});
            modelBuilder.Entity<Questions>().HasData(
                new Questions { Id = 5, Question= "Which property of the session object is used to set the local identifier?", Option1= "LCID", Option2= "SessionId", Option3= "Key", Option4= "Item", CorrAns= "LCID", CategoryId = 3});
        }
    }
}
