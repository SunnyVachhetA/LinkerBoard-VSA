using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LinkerBoard.API.Migrations
{
    /// <inheritdoc />
    public partial class UserConfigWithBogusData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    createdAt = table.Column<DateOnly>(type: "date", nullable: false),
                    updatedAt = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "createdAt", "email", "updatedAt", "username" },
                values: new object[,]
                {
                    { new Guid("025e350b-6614-488b-9205-65420c58e9fe"), new DateOnly(2024, 5, 2), "Shawna97@hotmail.com", null, "Shawna68" },
                    { new Guid("03b19c17-f8ee-4591-b064-aa56720276ce"), new DateOnly(2023, 9, 2), "Christopher1@hotmail.com", null, "Christopher52" },
                    { new Guid("046e62ca-5be3-4b52-b773-f1adb2296348"), new DateOnly(2023, 8, 20), "Becky_Glover10@gmail.com", null, "Becky.Glover" },
                    { new Guid("08ac8593-e31d-439f-b041-2eb7dc3a3831"), new DateOnly(2024, 1, 31), "Tiffany_Funk80@yahoo.com", new DateOnly(2023, 6, 28), "Tiffany_Funk66" },
                    { new Guid("0af7ba5c-1ba9-4847-ac09-75c8d5858ba3"), new DateOnly(2023, 11, 29), "Eunice76@hotmail.com", null, "Eunice.Hyatt60" },
                    { new Guid("0ccf903d-526f-4ac5-8d08-a3af1f3b2286"), new DateOnly(2024, 3, 21), "Violet_Windler@yahoo.com", null, "Violet_Windler80" },
                    { new Guid("0e9f77b3-6f98-45ae-8730-938bcd6db1a0"), new DateOnly(2024, 2, 14), "Dean.McClure74@yahoo.com", null, "Dean48" },
                    { new Guid("0fe34001-27e2-43b7-a57f-458a84c7052b"), new DateOnly(2023, 7, 27), "Beatrice46@gmail.com", new DateOnly(2024, 1, 5), "Beatrice62" },
                    { new Guid("0ff3beea-a032-4096-b2bb-45a4b4599164"), new DateOnly(2023, 12, 25), "Rickey94@gmail.com", null, "Rickey56" },
                    { new Guid("10a6a906-305e-4c18-8c37-7a71f4197e2d"), new DateOnly(2023, 6, 19), "Bob56@gmail.com", null, "Bob_Kunde" },
                    { new Guid("126ab011-58d7-4898-b97d-f67fc9655f29"), new DateOnly(2024, 5, 6), "Orville_Little@yahoo.com", null, "Orville.Little53" },
                    { new Guid("138fabdf-bdd1-43da-9a49-06b1571400d7"), new DateOnly(2023, 6, 23), "Earl.Auer3@yahoo.com", new DateOnly(2023, 6, 10), "Earl32" },
                    { new Guid("1865ffa7-8e81-49ba-838c-0c19e5cbd67c"), new DateOnly(2023, 10, 27), "Alicia4@yahoo.com", new DateOnly(2023, 7, 5), "Alicia64" },
                    { new Guid("19f7690f-956c-4a21-84a5-33cadc882c95"), new DateOnly(2023, 7, 28), "Kim.Lesch@gmail.com", null, "Kim_Lesch27" },
                    { new Guid("1b886b5d-3919-4b9d-b1ad-c19b719d0619"), new DateOnly(2024, 1, 28), "Vickie_Skiles6@yahoo.com", null, "Vickie.Skiles" },
                    { new Guid("1caffa2d-4916-496e-8c40-05cabbe9038a"), new DateOnly(2023, 7, 12), "Jeannette.Ledner@yahoo.com", null, "Jeannette.Ledner1" },
                    { new Guid("1de70ad1-5334-4477-995e-4ba05d41d5c6"), new DateOnly(2024, 4, 30), "Martha52@gmail.com", new DateOnly(2024, 4, 9), "Martha_Buckridge" },
                    { new Guid("1f127154-e12a-4348-a1fb-75010c12e005"), new DateOnly(2024, 2, 18), "Mario95@hotmail.com", null, "Mario.Gislason" },
                    { new Guid("23046167-d381-4a91-b234-2bd729ca4b0a"), new DateOnly(2023, 6, 22), "Ethel_Veum90@yahoo.com", null, "Ethel.Veum" },
                    { new Guid("24fbf4bf-2879-4339-a2ed-9ee6a9229ba8"), new DateOnly(2024, 1, 13), "Jimmie23@hotmail.com", null, "Jimmie.Hirthe8" },
                    { new Guid("284ad785-3d42-49dc-8f13-6dd42ed7d6ab"), new DateOnly(2024, 3, 25), "Kay2@yahoo.com", null, "Kay_Monahan37" },
                    { new Guid("2a1f1726-5cf9-45a1-b84b-d629c2ddabb8"), new DateOnly(2023, 12, 11), "Tabitha.Maggio47@gmail.com", null, "Tabitha.Maggio" },
                    { new Guid("2bc6d2a5-60b9-4038-bfe7-0f86bc24c564"), new DateOnly(2023, 9, 10), "Harriet_Steuber58@hotmail.com", null, "Harriet7" },
                    { new Guid("2c0949d4-588c-4cba-a805-4337e452199a"), new DateOnly(2023, 11, 18), "Lowell.Johns28@gmail.com", null, "Lowell.Johns" },
                    { new Guid("2dbbbc52-f532-44a9-bc4b-6f36542c2a65"), new DateOnly(2024, 1, 10), "Dan56@hotmail.com", null, "Dan_Predovic" },
                    { new Guid("2e5c3bf6-7fa4-4681-9ac9-6cf99127d22b"), new DateOnly(2024, 5, 6), "Jamie_Pfannerstill87@yahoo.com", null, "Jamie.Pfannerstill" },
                    { new Guid("2f3b7caa-6b3f-483f-b34b-de0426078377"), new DateOnly(2023, 7, 4), "Rose.Adams@gmail.com", null, "Rose84" },
                    { new Guid("2f9559b0-ffd9-440b-8f9e-44a5c78767f5"), new DateOnly(2023, 9, 6), "Felicia98@yahoo.com", null, "Felicia_Sporer" },
                    { new Guid("31c43f58-8658-46d6-96c6-eb947c19f62b"), new DateOnly(2023, 7, 30), "Courtney52@gmail.com", null, "Courtney78" },
                    { new Guid("32b53edc-f09b-4587-86f6-0887a6fedfd0"), new DateOnly(2023, 7, 24), "Leigh_Bogan@gmail.com", null, "Leigh22" },
                    { new Guid("36882642-facc-4512-9466-2cb2baa471ee"), new DateOnly(2024, 3, 5), "Alexis_Kertzmann81@yahoo.com", null, "Alexis20" },
                    { new Guid("3809b76f-f539-4228-a98c-be99e27cf52b"), new DateOnly(2023, 7, 16), "Moses_Boyer@gmail.com", null, "Moses_Boyer47" },
                    { new Guid("39fc981c-001d-4d27-8a9e-e9ef99d665af"), new DateOnly(2024, 1, 1), "Ricky.Considine69@hotmail.com", null, "Ricky13" },
                    { new Guid("3a60c57c-0727-48fe-9dd2-6fa791daa129"), new DateOnly(2023, 8, 14), "Kenneth.Hayes@gmail.com", null, "Kenneth_Hayes" },
                    { new Guid("3fbe0e9a-7cac-49eb-af2f-deb7ab24fa89"), new DateOnly(2023, 12, 17), "Cindy.Pagac@gmail.com", null, "Cindy_Pagac20" },
                    { new Guid("40407a21-91d2-4409-b5a5-dc35def12d18"), new DateOnly(2024, 5, 12), "Dallas1@yahoo.com", null, "Dallas71" },
                    { new Guid("47e333fe-851b-4a7c-80d2-a40560e1c089"), new DateOnly(2023, 8, 25), "Neal.Murray@hotmail.com", null, "Neal_Murray" },
                    { new Guid("48549b33-2e06-40d1-bead-1dda91629a45"), new DateOnly(2024, 3, 26), "Kendra_OConner@yahoo.com", new DateOnly(2023, 10, 31), "Kendra88" },
                    { new Guid("4dd00251-297c-4470-aaf2-0c1cf7534261"), new DateOnly(2024, 3, 31), "Minnie26@hotmail.com", new DateOnly(2023, 12, 25), "Minnie.Miller11" },
                    { new Guid("502b2700-62bd-4c0d-86ce-b9220bb4458c"), new DateOnly(2023, 7, 16), "Gustavo.Hagenes@hotmail.com", new DateOnly(2023, 6, 21), "Gustavo.Hagenes24" },
                    { new Guid("5894960c-ac2f-4b80-a731-d921f946f7c6"), new DateOnly(2024, 5, 4), "Tara.Cummerata@hotmail.com", null, "Tara.Cummerata30" },
                    { new Guid("5fceeb08-5998-4db3-965e-5cb2d93243dd"), new DateOnly(2024, 5, 30), "Justin.Konopelski64@yahoo.com", new DateOnly(2024, 4, 15), "Justin_Konopelski43" },
                    { new Guid("62fe3904-115e-4e5d-989a-4a8bab253600"), new DateOnly(2024, 1, 1), "Cecelia5@yahoo.com", null, "Cecelia_Douglas" },
                    { new Guid("67093e73-e3b0-409b-8937-46b879c536be"), new DateOnly(2024, 3, 8), "Elena.Dicki@gmail.com", null, "Elena.Dicki" },
                    { new Guid("696e6497-361d-4cd3-9fb5-50a543cafaf8"), new DateOnly(2024, 4, 10), "Andres_Green62@hotmail.com", new DateOnly(2024, 2, 20), "Andres42" },
                    { new Guid("6e4b1d4b-1576-4e19-b0f3-279521d7e5f4"), new DateOnly(2024, 5, 25), "Gwen_Hammes@yahoo.com", null, "Gwen_Hammes50" },
                    { new Guid("7a93c18c-cf3e-4136-a55f-64ce7f2d3a8e"), new DateOnly(2023, 8, 8), "Elmer29@gmail.com", null, "Elmer_Senger13" },
                    { new Guid("7e21ee39-7541-4463-92f7-bd7de69687fa"), new DateOnly(2023, 10, 5), "Guillermo49@hotmail.com", null, "Guillermo_Deckow84" },
                    { new Guid("8092c62d-66d8-4579-8709-883f5cb17218"), new DateOnly(2023, 11, 24), "Lola4@hotmail.com", null, "Lola_Jaskolski" },
                    { new Guid("859b7abd-b290-4b1a-9dd9-cedd20724af3"), new DateOnly(2023, 12, 14), "Melba_Strosin85@yahoo.com", null, "Melba54" },
                    { new Guid("8ec5f5cc-26ef-4178-aade-6c5bc5fdaa35"), new DateOnly(2024, 1, 5), "Jeanne60@hotmail.com", null, "Jeanne_Kozey" },
                    { new Guid("8fbc91bb-59f3-4efb-a1ef-bb6f0dd0f758"), new DateOnly(2024, 4, 21), "Sue_Beatty@gmail.com", null, "Sue_Beatty" },
                    { new Guid("914c4603-545d-4654-abcc-dbb27cb45237"), new DateOnly(2023, 7, 30), "Veronica_Waelchi@hotmail.com", null, "Veronica_Waelchi" },
                    { new Guid("92a3c552-95cd-4ec1-8146-6430a2ab77c4"), new DateOnly(2023, 10, 26), "Tommie.Effertz@yahoo.com", new DateOnly(2023, 6, 22), "Tommie3" },
                    { new Guid("9396c32a-983b-46c7-84b6-e03bdcf3ce54"), new DateOnly(2024, 5, 22), "Vernon53@yahoo.com", null, "Vernon.Schultz87" },
                    { new Guid("941483d7-33da-4cb3-a49c-37f0651df455"), new DateOnly(2023, 11, 12), "Amy.Zulauf51@hotmail.com", null, "Amy35" },
                    { new Guid("94aef0f5-40fc-492e-9b3c-f13ae07580a4"), new DateOnly(2024, 3, 26), "Wilfred95@hotmail.com", null, "Wilfred36" },
                    { new Guid("986cebc7-53ca-45b0-adc0-64e6ec2d72bd"), new DateOnly(2023, 7, 2), "Keith.Toy@hotmail.com", new DateOnly(2023, 6, 18), "Keith_Toy97" },
                    { new Guid("987c52b6-1ba9-4477-89ea-ab0c33c40533"), new DateOnly(2024, 3, 23), "Lillie_Kub@hotmail.com", new DateOnly(2024, 3, 21), "Lillie.Kub" },
                    { new Guid("9bc1d626-e029-416a-8acd-cdc216537b4f"), new DateOnly(2023, 6, 24), "Amelia53@hotmail.com", null, "Amelia58" },
                    { new Guid("9daba698-7874-4147-9e2e-312900d977f4"), new DateOnly(2024, 1, 15), "Kathy_Cassin17@gmail.com", null, "Kathy.Cassin" },
                    { new Guid("9dea27de-345c-4616-aaf2-127c11d1928c"), new DateOnly(2023, 12, 30), "Rachael59@hotmail.com", null, "Rachael74" },
                    { new Guid("a044777a-8428-4d7e-9c20-7d5b52f08fca"), new DateOnly(2024, 1, 13), "Ernest8@gmail.com", new DateOnly(2023, 6, 8), "Ernest67" },
                    { new Guid("a09f4281-801b-4b80-9cc1-ae3486ba564d"), new DateOnly(2023, 6, 30), "Alejandro.Mraz79@yahoo.com", new DateOnly(2024, 5, 17), "Alejandro.Mraz" },
                    { new Guid("a815a7af-d534-429c-93b4-af8f4550e6b8"), new DateOnly(2023, 11, 19), "Dwight_Wilderman@gmail.com", new DateOnly(2023, 11, 30), "Dwight.Wilderman54" },
                    { new Guid("a9e6bf08-8736-45f5-bfad-ca6a497b2724"), new DateOnly(2024, 5, 25), "Roger.Heller20@gmail.com", new DateOnly(2023, 12, 24), "Roger.Heller" },
                    { new Guid("abf3cd16-e6f0-42e3-981e-6cc46734204e"), new DateOnly(2024, 4, 4), "Louise.Hessel@yahoo.com", null, "Louise81" },
                    { new Guid("acc56aed-f164-4324-8d27-44b4f8a22e1a"), new DateOnly(2023, 6, 18), "Terri50@yahoo.com", null, "Terri_McLaughlin84" },
                    { new Guid("adc4253a-2ee3-4245-b71e-0c067c5339a3"), new DateOnly(2023, 9, 5), "Della.Rosenbaum@yahoo.com", new DateOnly(2023, 12, 13), "Della_Rosenbaum29" },
                    { new Guid("b14e5271-e8ff-40ab-903a-0b927f9dacc1"), new DateOnly(2023, 12, 18), "Rodolfo_Gusikowski@hotmail.com", null, "Rodolfo90" },
                    { new Guid("b26c7361-54bf-4f24-8cb8-0ecc04aebd4c"), new DateOnly(2024, 5, 14), "Claude_Beer9@yahoo.com", null, "Claude.Beer" },
                    { new Guid("b5e7cb2e-a9c6-49ef-8405-4829f7c4fe6b"), new DateOnly(2024, 4, 17), "Marilyn.Orn@hotmail.com", new DateOnly(2024, 5, 6), "Marilyn.Orn94" },
                    { new Guid("b67224f7-5965-4f46-b721-dd29893444dc"), new DateOnly(2023, 7, 7), "Jane.Flatley49@gmail.com", new DateOnly(2024, 1, 18), "Jane.Flatley40" },
                    { new Guid("b6807d32-c4f1-4027-be0a-cb6fd54487c3"), new DateOnly(2023, 9, 3), "Grant.Rogahn@hotmail.com", null, "Grant.Rogahn3" },
                    { new Guid("ba52045d-c9ab-4f36-a0aa-59020c6f3e51"), new DateOnly(2024, 5, 21), "Karla98@gmail.com", null, "Karla39" },
                    { new Guid("bda17694-00ed-4369-b5ed-4f650b86dd63"), new DateOnly(2023, 6, 25), "Wendell_Rippin@yahoo.com", null, "Wendell_Rippin77" },
                    { new Guid("c974232e-0f82-4b29-8337-df16a4a45b45"), new DateOnly(2023, 6, 9), "Shawn_Turcotte@gmail.com", new DateOnly(2023, 12, 20), "Shawn.Turcotte" },
                    { new Guid("cb8e4cd0-7766-4353-a90a-1e0fce2542ca"), new DateOnly(2023, 9, 15), "Kent99@gmail.com", null, "Kent_Howe34" },
                    { new Guid("cc40775b-8fb3-44ee-8a87-347decca2a9d"), new DateOnly(2024, 2, 6), "Frederick80@yahoo.com", null, "Frederick_Barrows64" },
                    { new Guid("d681fbb0-e577-4d15-a3f7-a59d3f482293"), new DateOnly(2024, 4, 8), "Jack.Ryan@hotmail.com", null, "Jack.Ryan" },
                    { new Guid("d7147495-f771-4c05-b167-fe0d436c54e7"), new DateOnly(2023, 10, 7), "Sherry.Schimmel@yahoo.com", null, "Sherry16" },
                    { new Guid("d72fb72a-798b-4909-bc09-32e4984b9960"), new DateOnly(2023, 7, 16), "Joann_Batz96@hotmail.com", null, "Joann.Batz90" },
                    { new Guid("d8936dca-e398-4ac1-a3d0-88238600cce4"), new DateOnly(2024, 1, 17), "William_Braun@hotmail.com", null, "William.Braun74" },
                    { new Guid("da9e7c9d-ea26-4463-9662-1e8a0e075150"), new DateOnly(2024, 4, 2), "Luis49@yahoo.com", null, "Luis_Collins" },
                    { new Guid("dea6836a-665f-4285-bd75-1624393dbc97"), new DateOnly(2024, 2, 13), "Winifred7@yahoo.com", null, "Winifred_Yundt" },
                    { new Guid("e4dd0a82-b632-48e9-a340-9bcc6682fdcb"), new DateOnly(2023, 10, 19), "Ben_Quigley40@hotmail.com", null, "Ben.Quigley" },
                    { new Guid("e7127432-46be-4779-9820-883c9ba8c1e1"), new DateOnly(2024, 3, 6), "Barry.Marks@gmail.com", null, "Barry0" },
                    { new Guid("ec266827-cfb2-4745-af0b-ed84102f387f"), new DateOnly(2023, 8, 1), "Arnold.Weissnat@gmail.com", null, "Arnold94" },
                    { new Guid("ed87c45f-5ea9-4d9c-b7ea-ade5e4966743"), new DateOnly(2024, 2, 10), "Faith_Harber@hotmail.com", new DateOnly(2023, 11, 16), "Faith.Harber76" },
                    { new Guid("ee32b695-4a35-4322-bcdd-10a9d53a67da"), new DateOnly(2024, 3, 8), "Billie_Rempel92@yahoo.com", null, "Billie26" },
                    { new Guid("eeb1921d-506e-4e2c-9202-63b8746890ca"), new DateOnly(2023, 9, 26), "Freddie_Labadie@yahoo.com", null, "Freddie10" },
                    { new Guid("f0acbe0d-2dfd-400a-afdd-17370b8c09e2"), new DateOnly(2023, 10, 28), "Ervin22@gmail.com", null, "Ervin_Wisoky7" },
                    { new Guid("f1201475-9c4d-4929-aaba-383f5963825a"), new DateOnly(2024, 3, 28), "Harold.Feest@gmail.com", null, "Harold0" },
                    { new Guid("f1575608-59fd-496d-ae38-02d3c9f11f60"), new DateOnly(2024, 2, 14), "Kevin.Koch32@hotmail.com", new DateOnly(2023, 11, 8), "Kevin.Koch17" },
                    { new Guid("f3ddcd7e-08f2-4599-aae7-c4864039fd0d"), new DateOnly(2024, 4, 11), "Dexter.Wolff98@yahoo.com", null, "Dexter.Wolff" },
                    { new Guid("f77fbb08-33d8-411c-b8a3-a22d4830adf9"), new DateOnly(2024, 3, 20), "Abraham73@yahoo.com", null, "Abraham.DAmore57" },
                    { new Guid("fbbcf5e4-0da7-42c2-8531-f0a0c38475c4"), new DateOnly(2023, 11, 16), "Jessica_Thompson@yahoo.com", null, "Jessica.Thompson71" },
                    { new Guid("fce822b7-835b-4821-9089-27045a631134"), new DateOnly(2023, 6, 18), "Rolando46@hotmail.com", null, "Rolando_Lueilwitz" },
                    { new Guid("fee7cf44-81f7-44db-88c7-44cbcedba30b"), new DateOnly(2024, 3, 22), "Brandi_Gottlieb@yahoo.com", null, "Brandi_Gottlieb" },
                    { new Guid("ffc97380-6172-4d8e-99c6-aabb65c05247"), new DateOnly(2023, 10, 8), "Jeanette50@gmail.com", new DateOnly(2023, 6, 25), "Jeanette45" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_email",
                table: "tblUser",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
