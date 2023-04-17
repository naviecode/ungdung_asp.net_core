using System;
using Microsoft.EntityFrameworkCore.Migrations;
using asp14_Validation.Models;
using Bogus;

namespace asp14_Validation.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.ID);
                });

                //InsertData
                //Fake Data: Bogus
                Randomizer.Seed = new Random(8675309);

                var fakeData = new Faker<Article>();
                fakeData.RuleFor(a=>a.Title, f => f.Lorem.Sentence(5,5));
                fakeData.RuleFor(a=>a.Created, f => f.Date.Between(new DateTime(2021,1,1), new DateTime(2021,7,30)));
                fakeData.RuleFor(a=>a.Content, f => f.Lorem.Paragraphs(1,4));
                for(int i = 0; i < 150; i++)
                {
                    Article article = fakeData.Generate();
                    migrationBuilder.InsertData(
                        table:"posts",
                        columns: new []{"Title","Created","Content"},
                        values: new object[]{
                            article.Title,
                            article.Created,
                            article.Content
                        }
                    );
                }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
