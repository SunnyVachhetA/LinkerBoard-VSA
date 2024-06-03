using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LinkerBoard.API.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrationForUserLinkBoardsLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    createdAt = table.Column<DateOnly>(type: "date", nullable: false),
                    updatedAt = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblLinkBoard",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: false),
                    createdAt = table.Column<DateOnly>(type: "date", nullable: false),
                    updatedAt = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLinkBoard", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblLinkBoard_tblUser_userId",
                        column: x => x.userId,
                        principalTable: "tblUser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblLink",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    url = table.Column<string>(type: "varchar", maxLength: 2083, nullable: false),
                    note = table.Column<string>(type: "text", nullable: true, comment: "Side notes for link; can be overview"),
                    createdAt = table.Column<DateOnly>(type: "date", nullable: false),
                    updatedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    linkBoardId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblLink_tblLinkBoard_linkBoardId",
                        column: x => x.linkBoardId,
                        principalTable: "tblLinkBoard",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "id", "createdAt", "email", "updatedAt", "username" },
                values: new object[,]
                {
                    { new Guid("02564334-530b-4998-b98c-36b891dea8da"), new DateOnly(2024, 3, 22), "Violet_Windler@yahoo.com", null, "Violet_Windler80" },
                    { new Guid("03fe2a11-7188-4495-8aaa-e4702dce79d8"), new DateOnly(2023, 6, 26), "Wendell_Rippin@yahoo.com", null, "Wendell_Rippin77" },
                    { new Guid("0b353653-f69b-4edd-9225-c9143532a1aa"), new DateOnly(2024, 3, 24), "Lillie_Kub@hotmail.com", new DateOnly(2024, 3, 22), "Lillie.Kub" },
                    { new Guid("0c8eb77c-a167-4be1-8d2e-c1ccb7a982d3"), new DateOnly(2024, 3, 6), "Alexis_Kertzmann81@yahoo.com", null, "Alexis20" },
                    { new Guid("0e7d7519-5d58-4e97-8e7b-5cf1e1d2adb0"), new DateOnly(2024, 3, 23), "Brandi_Gottlieb@yahoo.com", null, "Brandi_Gottlieb" },
                    { new Guid("0ecf1ffc-723d-479d-a449-9dd09439272f"), new DateOnly(2023, 10, 6), "Guillermo49@hotmail.com", null, "Guillermo_Deckow84" },
                    { new Guid("114cc3cb-2420-4662-84c9-92e19af1227a"), new DateOnly(2024, 2, 1), "Tiffany_Funk80@yahoo.com", new DateOnly(2023, 6, 29), "Tiffany_Funk66" },
                    { new Guid("13505570-5ab4-4af8-bf39-635dfe670dd7"), new DateOnly(2024, 3, 7), "Barry.Marks@gmail.com", null, "Barry0" },
                    { new Guid("199f9c26-3462-450a-8cad-a71707fce245"), new DateOnly(2023, 8, 21), "Becky_Glover10@gmail.com", null, "Becky.Glover" },
                    { new Guid("1d31ecca-78e1-4898-89a4-b016b8cda784"), new DateOnly(2024, 3, 26), "Kay2@yahoo.com", null, "Kay_Monahan37" },
                    { new Guid("1f280161-f561-427a-af92-c555059b443f"), new DateOnly(2023, 12, 18), "Cindy.Pagac@gmail.com", null, "Cindy_Pagac20" },
                    { new Guid("250b935b-8cac-44f8-a62c-d6cb66bc57d9"), new DateOnly(2023, 7, 29), "Kim.Lesch@gmail.com", null, "Kim_Lesch27" },
                    { new Guid("2af18278-35a0-4144-82b6-768dc7dc0316"), new DateOnly(2023, 7, 1), "Alejandro.Mraz79@yahoo.com", new DateOnly(2024, 5, 18), "Alejandro.Mraz" },
                    { new Guid("2b34fcb8-1063-49cb-8ce2-8c2ceb2f5694"), new DateOnly(2024, 1, 29), "Vickie_Skiles6@yahoo.com", null, "Vickie.Skiles" },
                    { new Guid("2b75f4ca-6496-44d0-948a-b68778dd910a"), new DateOnly(2024, 1, 16), "Kathy_Cassin17@gmail.com", null, "Kathy.Cassin" },
                    { new Guid("2c0352c9-70a2-43dc-86f2-010b6db22cb7"), new DateOnly(2023, 7, 31), "Veronica_Waelchi@hotmail.com", null, "Veronica_Waelchi" },
                    { new Guid("2c5b2903-dcde-4b50-8703-22b209db5bc8"), new DateOnly(2023, 11, 30), "Eunice76@hotmail.com", null, "Eunice.Hyatt60" },
                    { new Guid("332fc696-90ff-4e9c-8224-a56fa8647577"), new DateOnly(2023, 6, 19), "Rolando46@hotmail.com", null, "Rolando_Lueilwitz" },
                    { new Guid("376018d1-e70b-49b7-b8ca-e4903dc1e7f7"), new DateOnly(2024, 1, 6), "Jeanne60@hotmail.com", null, "Jeanne_Kozey" },
                    { new Guid("3e45a716-17e5-4611-bb83-68e6dcfc9da1"), new DateOnly(2024, 3, 27), "Kendra_OConner@yahoo.com", new DateOnly(2023, 11, 1), "Kendra88" },
                    { new Guid("3f4ae7c6-de0d-4baf-ac80-bb5b3b6f5f98"), new DateOnly(2024, 4, 22), "Sue_Beatty@gmail.com", null, "Sue_Beatty" },
                    { new Guid("3f8b7f04-0f9c-4f0f-b7a3-06edac452eba"), new DateOnly(2024, 1, 14), "Jimmie23@hotmail.com", null, "Jimmie.Hirthe8" },
                    { new Guid("45496e50-3b7f-484b-8eb2-6ae58717f050"), new DateOnly(2024, 4, 5), "Louise.Hessel@yahoo.com", null, "Louise81" },
                    { new Guid("49313c91-4737-4a4e-abdb-52ec64453e4f"), new DateOnly(2024, 2, 15), "Kevin.Koch32@hotmail.com", new DateOnly(2023, 11, 9), "Kevin.Koch17" },
                    { new Guid("4bbdc6ce-7ca2-4099-b2d4-aca52dba5938"), new DateOnly(2024, 5, 13), "Dallas1@yahoo.com", null, "Dallas71" },
                    { new Guid("4de06c0e-8689-41dd-a913-b5ef82208cfc"), new DateOnly(2024, 1, 2), "Ricky.Considine69@hotmail.com", null, "Ricky13" },
                    { new Guid("52545ac1-136a-469b-8ca8-9984679e7f48"), new DateOnly(2024, 4, 18), "Marilyn.Orn@hotmail.com", new DateOnly(2024, 5, 7), "Marilyn.Orn94" },
                    { new Guid("58465259-2b38-4a3a-88b1-65d250d7a4e7"), new DateOnly(2023, 6, 10), "Shawn_Turcotte@gmail.com", new DateOnly(2023, 12, 21), "Shawn.Turcotte" },
                    { new Guid("5a89332e-9c68-475a-9148-f34f143bb232"), new DateOnly(2023, 7, 8), "Jane.Flatley49@gmail.com", new DateOnly(2024, 1, 19), "Jane.Flatley40" },
                    { new Guid("5d7ac9cc-a7c9-4c89-a5b4-52500d935b3c"), new DateOnly(2023, 11, 17), "Jessica_Thompson@yahoo.com", null, "Jessica.Thompson71" },
                    { new Guid("5fbce03c-9b53-445d-b46b-83dcf6a385b0"), new DateOnly(2024, 2, 11), "Faith_Harber@hotmail.com", new DateOnly(2023, 11, 17), "Faith.Harber76" },
                    { new Guid("61ed684b-8833-4c2b-ad95-51b08af0b390"), new DateOnly(2023, 10, 27), "Tommie.Effertz@yahoo.com", new DateOnly(2023, 6, 23), "Tommie3" },
                    { new Guid("6227aee2-4937-48c2-85fd-f82b0167e52e"), new DateOnly(2024, 1, 18), "William_Braun@hotmail.com", null, "William.Braun74" },
                    { new Guid("6348f5ec-0c48-4802-b60d-652e529aae5d"), new DateOnly(2024, 1, 14), "Ernest8@gmail.com", new DateOnly(2023, 6, 9), "Ernest67" },
                    { new Guid("6392770f-b03f-4c71-9d04-43c9b58ea603"), new DateOnly(2023, 12, 26), "Rickey94@gmail.com", null, "Rickey56" },
                    { new Guid("647217d1-18a3-4616-90c2-6d4434a773a1"), new DateOnly(2024, 3, 9), "Billie_Rempel92@yahoo.com", null, "Billie26" },
                    { new Guid("6834c4ce-3254-42bd-8c95-34226f306410"), new DateOnly(2024, 2, 7), "Frederick80@yahoo.com", null, "Frederick_Barrows64" },
                    { new Guid("6c2b1e15-05fc-494a-aa87-5d73066f1b8c"), new DateOnly(2023, 9, 16), "Kent99@gmail.com", null, "Kent_Howe34" },
                    { new Guid("70516a3e-1157-4e9e-a2e9-f31ad1e9feea"), new DateOnly(2023, 9, 6), "Della.Rosenbaum@yahoo.com", new DateOnly(2023, 12, 14), "Della_Rosenbaum29" },
                    { new Guid("72e559ae-8ccd-464a-86e9-d3f6f2818b96"), new DateOnly(2023, 10, 8), "Sherry.Schimmel@yahoo.com", null, "Sherry16" },
                    { new Guid("741e41e5-df24-457a-8fc3-73855c476ac1"), new DateOnly(2024, 1, 11), "Dan56@hotmail.com", null, "Dan_Predovic" },
                    { new Guid("7524956d-932c-4963-a894-eaa9c55ea8fb"), new DateOnly(2023, 10, 9), "Jeanette50@gmail.com", new DateOnly(2023, 6, 26), "Jeanette45" },
                    { new Guid("77828e46-6fe7-492e-85d2-7bc235be102a"), new DateOnly(2023, 8, 9), "Elmer29@gmail.com", null, "Elmer_Senger13" },
                    { new Guid("78790e83-ad61-4bc3-a7a2-d059eeb3df49"), new DateOnly(2023, 7, 28), "Beatrice46@gmail.com", new DateOnly(2024, 1, 6), "Beatrice62" },
                    { new Guid("7b037bb0-92f4-4c81-8427-8f2c0ed73c50"), new DateOnly(2023, 10, 29), "Ervin22@gmail.com", null, "Ervin_Wisoky7" },
                    { new Guid("7b9b7ae6-05c1-4bb4-8622-fce2140f6df9"), new DateOnly(2023, 6, 25), "Amelia53@hotmail.com", null, "Amelia58" },
                    { new Guid("803e7cf6-a92d-4206-a32e-0f8fb2b525ff"), new DateOnly(2023, 7, 3), "Keith.Toy@hotmail.com", new DateOnly(2023, 6, 19), "Keith_Toy97" },
                    { new Guid("816fc8cd-8ffe-4c7f-839a-e5d458c4a189"), new DateOnly(2024, 3, 27), "Wilfred95@hotmail.com", null, "Wilfred36" },
                    { new Guid("83ceebe8-e01e-4bbb-acf8-1dc511f4df6a"), new DateOnly(2024, 5, 31), "Justin.Konopelski64@yahoo.com", new DateOnly(2024, 4, 16), "Justin_Konopelski43" },
                    { new Guid("8492a0c6-9904-43e0-b5bc-e3a43fd7845c"), new DateOnly(2024, 5, 1), "Martha52@gmail.com", new DateOnly(2024, 4, 10), "Martha_Buckridge" },
                    { new Guid("8593a4b0-2318-4e15-b900-51b7146d8ae5"), new DateOnly(2023, 6, 19), "Terri50@yahoo.com", null, "Terri_McLaughlin84" },
                    { new Guid("8b3e2472-8de5-42c7-a04c-a868e5f75bcb"), new DateOnly(2023, 10, 28), "Alicia4@yahoo.com", new DateOnly(2023, 7, 6), "Alicia64" },
                    { new Guid("8bf88dcb-0458-45fd-9419-f4bce3e6e94f"), new DateOnly(2023, 9, 4), "Grant.Rogahn@hotmail.com", null, "Grant.Rogahn3" },
                    { new Guid("8c7b7924-6507-4f66-932d-f43387f9dd38"), new DateOnly(2023, 9, 11), "Harriet_Steuber58@hotmail.com", null, "Harriet7" },
                    { new Guid("8d2cb0ae-dce9-406e-9777-348f383647a6"), new DateOnly(2023, 7, 25), "Leigh_Bogan@gmail.com", null, "Leigh22" },
                    { new Guid("8ef609fb-6eb8-44a5-a72c-fed3af3630ec"), new DateOnly(2023, 9, 3), "Christopher1@hotmail.com", null, "Christopher52" },
                    { new Guid("90b0abc8-1c9c-4160-b6b9-8bb6f7f782f8"), new DateOnly(2023, 7, 17), "Joann_Batz96@hotmail.com", null, "Joann.Batz90" },
                    { new Guid("98dfff64-a807-4702-aa94-9fbeaf9532a1"), new DateOnly(2024, 4, 9), "Jack.Ryan@hotmail.com", null, "Jack.Ryan" },
                    { new Guid("9d0c2f96-15c2-4e55-841c-058e1b00f00f"), new DateOnly(2023, 7, 17), "Moses_Boyer@gmail.com", null, "Moses_Boyer47" },
                    { new Guid("9faccef0-727f-4717-8c23-59427d460b15"), new DateOnly(2024, 5, 22), "Karla98@gmail.com", null, "Karla39" },
                    { new Guid("a099a9a1-6716-4bab-b1d8-5d2187a8647b"), new DateOnly(2023, 6, 23), "Ethel_Veum90@yahoo.com", null, "Ethel.Veum" },
                    { new Guid("a7bab0b0-fd65-4714-a73d-d0b2e097cd36"), new DateOnly(2024, 4, 1), "Minnie26@hotmail.com", new DateOnly(2023, 12, 26), "Minnie.Miller11" },
                    { new Guid("ac47d050-9a49-49e1-a9d3-1f48a2d3d3f3"), new DateOnly(2023, 11, 20), "Dwight_Wilderman@gmail.com", new DateOnly(2023, 12, 1), "Dwight.Wilderman54" },
                    { new Guid("ad172ab6-d794-4837-9833-94e0b4874dc2"), new DateOnly(2024, 2, 15), "Dean.McClure74@yahoo.com", null, "Dean48" },
                    { new Guid("b222c493-1e20-4dc2-b4d2-b5005bb67806"), new DateOnly(2023, 7, 31), "Courtney52@gmail.com", null, "Courtney78" },
                    { new Guid("b4fcca42-37d7-439b-b18d-8d9d8489a668"), new DateOnly(2023, 9, 27), "Freddie_Labadie@yahoo.com", null, "Freddie10" },
                    { new Guid("b57e1ea3-2cf6-41a5-8990-5c1dd216ecd3"), new DateOnly(2023, 7, 13), "Jeannette.Ledner@yahoo.com", null, "Jeannette.Ledner1" },
                    { new Guid("b7b173a5-8a75-4dd9-ae87-98329b1985fb"), new DateOnly(2023, 7, 17), "Gustavo.Hagenes@hotmail.com", new DateOnly(2023, 6, 22), "Gustavo.Hagenes24" },
                    { new Guid("b7b73667-f668-4986-98e4-0fd27c544dbe"), new DateOnly(2024, 2, 14), "Winifred7@yahoo.com", null, "Winifred_Yundt" },
                    { new Guid("b9447b6d-a0d0-4254-9855-4057528f89b6"), new DateOnly(2024, 4, 11), "Andres_Green62@hotmail.com", new DateOnly(2024, 2, 21), "Andres42" },
                    { new Guid("bddd4607-f0b2-4934-a1b9-b59bc6cab08c"), new DateOnly(2024, 5, 5), "Tara.Cummerata@hotmail.com", null, "Tara.Cummerata30" },
                    { new Guid("bfb9ca39-2ef5-41e7-89ba-00e3fb5fd2da"), new DateOnly(2024, 5, 26), "Roger.Heller20@gmail.com", new DateOnly(2023, 12, 25), "Roger.Heller" },
                    { new Guid("c16ac30e-b556-4b92-806a-5a10601afdd0"), new DateOnly(2023, 11, 19), "Lowell.Johns28@gmail.com", null, "Lowell.Johns" },
                    { new Guid("c2b4574c-68f7-4006-bb46-a4aaa886e30c"), new DateOnly(2023, 9, 7), "Felicia98@yahoo.com", null, "Felicia_Sporer" },
                    { new Guid("c5b9f877-a5de-45e6-a603-e609de89c228"), new DateOnly(2024, 5, 7), "Orville_Little@yahoo.com", null, "Orville.Little53" },
                    { new Guid("c952f3cc-2e5c-4ff2-852f-fde87d6e45ff"), new DateOnly(2024, 2, 19), "Mario95@hotmail.com", null, "Mario.Gislason" },
                    { new Guid("cc694069-0600-4511-95f1-5f0f842eda3f"), new DateOnly(2024, 3, 29), "Harold.Feest@gmail.com", null, "Harold0" },
                    { new Guid("ceb51fac-5058-43a5-996d-86e087e33ee3"), new DateOnly(2024, 1, 2), "Cecelia5@yahoo.com", null, "Cecelia_Douglas" },
                    { new Guid("d24b2490-e4de-4870-92f5-228507426198"), new DateOnly(2024, 3, 9), "Elena.Dicki@gmail.com", null, "Elena.Dicki" },
                    { new Guid("d43daa2e-d942-427b-aded-9377d23caee5"), new DateOnly(2024, 4, 3), "Luis49@yahoo.com", null, "Luis_Collins" },
                    { new Guid("d55f1915-ab74-4857-b5a1-483f6331d057"), new DateOnly(2024, 5, 26), "Gwen_Hammes@yahoo.com", null, "Gwen_Hammes50" },
                    { new Guid("d566b09e-a2f2-4ca0-9c5a-04fba8bce9bf"), new DateOnly(2023, 7, 5), "Rose.Adams@gmail.com", null, "Rose84" },
                    { new Guid("d6d99e16-ff80-42d0-86dd-c5272e6b35b4"), new DateOnly(2023, 12, 19), "Rodolfo_Gusikowski@hotmail.com", null, "Rodolfo90" },
                    { new Guid("d7d2bfef-1871-4194-8853-25f10dc82268"), new DateOnly(2023, 12, 12), "Tabitha.Maggio47@gmail.com", null, "Tabitha.Maggio" },
                    { new Guid("d8f9ca97-3f8b-4ae6-bc94-2d777a188e5b"), new DateOnly(2023, 10, 20), "Ben_Quigley40@hotmail.com", null, "Ben.Quigley" },
                    { new Guid("db277d2c-c9ae-4a64-aecf-db948ec76e76"), new DateOnly(2024, 5, 7), "Jamie_Pfannerstill87@yahoo.com", null, "Jamie.Pfannerstill" },
                    { new Guid("dda534a6-a33c-4e91-b35f-9f5295f5482f"), new DateOnly(2024, 3, 21), "Abraham73@yahoo.com", null, "Abraham.DAmore57" },
                    { new Guid("dec28f62-0d8a-480b-a7f1-e0a0d9545dfe"), new DateOnly(2023, 8, 26), "Neal.Murray@hotmail.com", null, "Neal_Murray" },
                    { new Guid("e0635c5f-9da7-4042-9a64-e3043a80df3d"), new DateOnly(2023, 6, 24), "Earl.Auer3@yahoo.com", new DateOnly(2023, 6, 11), "Earl32" },
                    { new Guid("e14b2ba8-def0-43cc-8bef-dc8ea00f2850"), new DateOnly(2023, 12, 15), "Melba_Strosin85@yahoo.com", null, "Melba54" },
                    { new Guid("e86760ab-192e-4067-84f7-788f7af836b3"), new DateOnly(2023, 11, 25), "Lola4@hotmail.com", null, "Lola_Jaskolski" },
                    { new Guid("e996fc47-c0c7-4135-b184-8409e42a830e"), new DateOnly(2023, 11, 13), "Amy.Zulauf51@hotmail.com", null, "Amy35" },
                    { new Guid("eab92261-cc25-4a9e-becb-853b50883aa8"), new DateOnly(2024, 5, 23), "Vernon53@yahoo.com", null, "Vernon.Schultz87" },
                    { new Guid("eb7f25be-8711-47d0-ab96-c86781cd67ef"), new DateOnly(2023, 8, 2), "Arnold.Weissnat@gmail.com", null, "Arnold94" },
                    { new Guid("ebbb2dab-8980-4755-b47a-1820d8b9cd08"), new DateOnly(2023, 6, 20), "Bob56@gmail.com", null, "Bob_Kunde" },
                    { new Guid("ee23074f-b01c-4574-9478-9e7efc4f9e31"), new DateOnly(2023, 12, 31), "Rachael59@hotmail.com", null, "Rachael74" },
                    { new Guid("ef28a175-6b2a-4237-bf75-20ac34126f0a"), new DateOnly(2023, 8, 15), "Kenneth.Hayes@gmail.com", null, "Kenneth_Hayes" },
                    { new Guid("f36c7b3b-fc72-4c76-8019-62f96d34b58a"), new DateOnly(2024, 4, 12), "Dexter.Wolff98@yahoo.com", null, "Dexter.Wolff" },
                    { new Guid("f4068b4d-eed9-4e7d-859e-8b6852d1ef1c"), new DateOnly(2024, 5, 15), "Claude_Beer9@yahoo.com", null, "Claude.Beer" },
                    { new Guid("fa15bb98-a587-4475-a6c8-a165aaa67c24"), new DateOnly(2024, 5, 3), "Shawna97@hotmail.com", null, "Shawna68" }
                });

            migrationBuilder.InsertData(
                table: "tblLinkBoard",
                columns: new[] { "id", "createdAt", "title", "updatedAt", "userId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 3, 9), "Brown and Sons", null, new Guid("7524956d-932c-4963-a894-eaa9c55ea8fb") },
                    { 2, new DateOnly(2023, 7, 10), "Jakubowski, Cummerata and Wyman", new DateOnly(2023, 9, 20), new Guid("8ef609fb-6eb8-44a5-a72c-fed3af3630ec") },
                    { 3, new DateOnly(2023, 8, 11), "Predovic Group", null, new Guid("eb7f25be-8711-47d0-ab96-c86781cd67ef") },
                    { 4, new DateOnly(2023, 6, 4), "Zboncak, Maggio and Jenkins", null, new Guid("8ef609fb-6eb8-44a5-a72c-fed3af3630ec") },
                    { 5, new DateOnly(2024, 1, 15), "Graham - Gislason", new DateOnly(2023, 11, 17), new Guid("114cc3cb-2420-4662-84c9-92e19af1227a") },
                    { 6, new DateOnly(2024, 4, 30), "Mayert, Windler and Smitham", null, new Guid("2c0352c9-70a2-43dc-86f2-010b6db22cb7") },
                    { 7, new DateOnly(2023, 6, 19), "Swaniawski - Olson", null, new Guid("c952f3cc-2e5c-4ff2-852f-fde87d6e45ff") },
                    { 8, new DateOnly(2024, 3, 26), "Cruickshank, Hessel and Gleason", null, new Guid("2c0352c9-70a2-43dc-86f2-010b6db22cb7") },
                    { 9, new DateOnly(2023, 11, 22), "Koch - Beer", null, new Guid("376018d1-e70b-49b7-b8ca-e4903dc1e7f7") },
                    { 10, new DateOnly(2024, 2, 19), "Rolfson, Rosenbaum and Pouros", null, new Guid("2c0352c9-70a2-43dc-86f2-010b6db22cb7") },
                    { 11, new DateOnly(2024, 4, 27), "Bayer - Koch", null, new Guid("0b353653-f69b-4edd-9225-c9143532a1aa") },
                    { 12, new DateOnly(2024, 1, 14), "Hayes, Crist and Carter", null, new Guid("2af18278-35a0-4144-82b6-768dc7dc0316") },
                    { 13, new DateOnly(2023, 9, 30), "Murray - Steuber", new DateOnly(2023, 6, 27), new Guid("ebbb2dab-8980-4755-b47a-1820d8b9cd08") },
                    { 14, new DateOnly(2023, 12, 17), "Walsh LLC", new DateOnly(2023, 12, 10), new Guid("bfb9ca39-2ef5-41e7-89ba-00e3fb5fd2da") },
                    { 15, new DateOnly(2024, 3, 4), "Erdman - Funk", null, new Guid("8b3e2472-8de5-42c7-a04c-a868e5f75bcb") },
                    { 16, new DateOnly(2024, 5, 22), "Langworth Group", null, new Guid("45496e50-3b7f-484b-8eb2-6ae58717f050") },
                    { 17, new DateOnly(2023, 8, 7), "Schneider - O'Conner", null, new Guid("eab92261-cc25-4a9e-becb-853b50883aa8") },
                    { 18, new DateOnly(2023, 10, 24), "Boyle and Sons", null, new Guid("199f9c26-3462-450a-8cad-a71707fce245") },
                    { 19, new DateOnly(2024, 1, 11), "Huel - Beatty", null, new Guid("2b75f4ca-6496-44d0-948a-b68778dd910a") },
                    { 20, new DateOnly(2024, 3, 29), "Pfannerstill LLC", null, new Guid("ad172ab6-d794-4837-9833-94e0b4874dc2") },
                    { 21, new DateOnly(2024, 2, 7), "Wuckert, King and Bauch", null, new Guid("199f9c26-3462-450a-8cad-a71707fce245") },
                    { 22, new DateOnly(2023, 9, 1), "Goldner Inc", new DateOnly(2023, 7, 20), new Guid("8593a4b0-2318-4e15-b900-51b7146d8ae5") },
                    { 23, new DateOnly(2024, 1, 2), "Mann, Sporer and Koss", null, new Guid("7b037bb0-92f4-4c81-8427-8f2c0ed73c50") },
                    { 24, new DateOnly(2024, 2, 4), "Stokes LLC", null, new Guid("58465259-2b38-4a3a-88b1-65d250d7a4e7") },
                    { 25, new DateOnly(2023, 11, 27), "Cremin, Flatley and Trantow", null, new Guid("7b037bb0-92f4-4c81-8427-8f2c0ed73c50") },
                    { 26, new DateOnly(2023, 7, 9), "King Group", null, new Guid("a099a9a1-6716-4bab-b1d8-5d2187a8647b") },
                    { 27, new DateOnly(2023, 10, 23), "Ritchie, Nitzsche and Hammes", null, new Guid("7b037bb0-92f4-4c81-8427-8f2c0ed73c50") },
                    { 28, new DateOnly(2023, 12, 13), "Bartoletti - Hayes", null, new Guid("2c0352c9-70a2-43dc-86f2-010b6db22cb7") },
                    { 29, new DateOnly(2023, 9, 17), "Hansen, Batz and Rogahn", new DateOnly(2024, 4, 26), new Guid("52545ac1-136a-469b-8ca8-9984679e7f48") },
                    { 30, new DateOnly(2024, 5, 17), "Mraz - Rippin", new DateOnly(2024, 3, 1), new Guid("cc694069-0600-4511-95f1-5f0f842eda3f") },
                    { 31, new DateOnly(2023, 8, 13), "Veum, Kertzmann and Daniel", new DateOnly(2024, 1, 24), new Guid("52545ac1-136a-469b-8ca8-9984679e7f48") },
                    { 32, new DateOnly(2023, 10, 20), "DuBuque - Collins", null, new Guid("5a89332e-9c68-475a-9148-f34f143bb232") },
                    { 33, new DateOnly(2023, 7, 8), "Kutch, Skiles and Mills", null, new Guid("52545ac1-136a-469b-8ca8-9984679e7f48") },
                    { 34, new DateOnly(2024, 3, 25), "Schimmel - Lesch", null, new Guid("332fc696-90ff-4e9c-8224-a56fa8647577") },
                    { 35, new DateOnly(2023, 6, 10), "Bogisich Inc", null, new Guid("d566b09e-a2f2-4ca0-9c5a-04fba8bce9bf") },
                    { 36, new DateOnly(2023, 8, 27), "Hoeger - Waters", null, new Guid("d7d2bfef-1871-4194-8853-25f10dc82268") },
                    { 37, new DateOnly(2023, 11, 14), "Pacocha LLC", new DateOnly(2024, 4, 29), new Guid("e0635c5f-9da7-4042-9a64-e3043a80df3d") },
                    { 38, new DateOnly(2024, 1, 31), "Wisoky - Harber", new DateOnly(2023, 10, 11), new Guid("376018d1-e70b-49b7-b8ca-e4903dc1e7f7") },
                    { 39, new DateOnly(2024, 4, 18), "Gibson Inc", null, new Guid("6834c4ce-3254-42bd-8c95-34226f306410") },
                    { 40, new DateOnly(2023, 7, 5), "Luettgen - Rempel", null, new Guid("6348f5ec-0c48-4802-b60d-652e529aae5d") },
                    { 41, new DateOnly(2023, 9, 21), "Stamm and Sons", null, new Guid("ef28a175-6b2a-4237-bf75-20ac34126f0a") },
                    { 42, new DateOnly(2023, 7, 31), "Connelly, Cassin and Ledner", new DateOnly(2023, 9, 4), new Guid("8492a0c6-9904-43e0-b5bc-e3a43fd7845c") },
                    { 43, new DateOnly(2024, 2, 25), "Kerluke Group", null, new Guid("bfb9ca39-2ef5-41e7-89ba-00e3fb5fd2da") },
                    { 44, new DateOnly(2023, 6, 26), "Rempel, Ledner and Wiegand", null, new Guid("8492a0c6-9904-43e0-b5bc-e3a43fd7845c") },
                    { 45, new DateOnly(2023, 7, 29), "Bahringer Inc", new DateOnly(2023, 12, 8), new Guid("816fc8cd-8ffe-4c7f-839a-e5d458c4a189") },
                    { 46, new DateOnly(2024, 5, 22), "Haley, Waelchi and Hodkiewicz", null, new Guid("8492a0c6-9904-43e0-b5bc-e3a43fd7845c") },
                    { 47, new DateOnly(2024, 1, 2), "Mohr LLC", null, new Guid("13505570-5ab4-4af8-bf39-635dfe670dd7") },
                    { 48, new DateOnly(2024, 4, 16), "Turcotte, Hammes and Schneider", null, new Guid("eab92261-cc25-4a9e-becb-853b50883aa8") },
                    { 49, new DateOnly(2023, 6, 6), "Dietrich Inc", null, new Guid("ad172ab6-d794-4837-9833-94e0b4874dc2") },
                    { 50, new DateOnly(2024, 3, 12), "Kuhlman, Raynor and Fay", null, new Guid("eab92261-cc25-4a9e-becb-853b50883aa8") },
                    { 51, new DateOnly(2023, 11, 9), "Sauer - Johns", null, new Guid("803e7cf6-a92d-4206-a32e-0f8fb2b525ff") },
                    { 52, new DateOnly(2024, 2, 5), "Blanda, Buckridge and O'Kon", null, new Guid("eab92261-cc25-4a9e-becb-853b50883aa8") },
                    { 53, new DateOnly(2024, 4, 14), "Hills - Schultz", new DateOnly(2023, 7, 19), new Guid("58465259-2b38-4a3a-88b1-65d250d7a4e7") },
                    { 54, new DateOnly(2024, 1, 1), "Ondricka, Langworth and Boehm", null, new Guid("7b9b7ae6-05c1-4bb4-8622-fce2140f6df9") },
                    { 55, new DateOnly(2023, 9, 17), "Wilkinson - Effertz", null, new Guid("61ed684b-8833-4c2b-ad95-51b08af0b390") },
                    { 56, new DateOnly(2023, 11, 26), "Friesen, Veum and Langosh", new DateOnly(2023, 11, 29), new Guid("7b9b7ae6-05c1-4bb4-8622-fce2140f6df9") },
                    { 57, new DateOnly(2024, 2, 20), "Littel - Monahan", null, new Guid("8ef609fb-6eb8-44a5-a72c-fed3af3630ec") },
                    { 58, new DateOnly(2024, 5, 9), "Smith and Sons", null, new Guid("1f280161-f561-427a-af92-c555059b443f") },
                    { 59, new DateOnly(2023, 7, 25), "Christiansen - Adams", null, new Guid("cc694069-0600-4511-95f1-5f0f842eda3f") },
                    { 60, new DateOnly(2023, 10, 11), "Jones LLC", new DateOnly(2023, 9, 16), new Guid("b7b73667-f668-4986-98e4-0fd27c544dbe") }
                });

            migrationBuilder.InsertData(
                table: "tblLink",
                columns: new[] { "Id", "createdAt", "linkBoardId", "note", "title", "updatedAt", "url" },
                values: new object[,]
                {
                    { 1L, new DateOnly(2023, 7, 7), 15, null, "enhance leading-edge supply-chains", null, "http://fidel.org" },
                    { 2L, new DateOnly(2023, 8, 21), 2, null, "drive best-of-breed initiatives", new DateOnly(2023, 6, 4), "http://princess.info" },
                    { 3L, new DateOnly(2023, 10, 5), 49, null, "empower cross-media metrics", null, "http://demarco.org" },
                    { 4L, new DateOnly(2023, 11, 20), 36, null, "engineer rich interfaces", null, "http://maxime.info" },
                    { 5L, new DateOnly(2024, 1, 4), 23, null, "harness B2B ROI", new DateOnly(2023, 7, 13), "https://cade.org" },
                    { 6L, new DateOnly(2024, 2, 19), 10, "Internal", "exploit front-end methodologies", new DateOnly(2023, 11, 25), "https://laurence.info" },
                    { 7L, new DateOnly(2024, 4, 4), 56, null, "seize user-centric bandwidth", null, "https://allison.org" },
                    { 8L, new DateOnly(2024, 5, 19), 43, "Future", "iterate strategic portals", null, "https://jennie.info" },
                    { 9L, new DateOnly(2023, 7, 3), 30, null, "strategize bleeding-edge paradigms", new DateOnly(2024, 1, 3), "http://trevion.org" },
                    { 10L, new DateOnly(2023, 8, 17), 17, null, "productize out-of-the-box users", null, "http://gerson.info" },
                    { 11L, new DateOnly(2023, 10, 2), 4, null, "grow vertical vortals", null, "http://roberta.org" },
                    { 12L, new DateOnly(2023, 11, 16), 51, null, "recontextualize frictionless initiatives", null, "http://easton.info" },
                    { 13L, new DateOnly(2024, 1, 1), 37, null, "synthesize turn-key metrics", new DateOnly(2023, 6, 24), "https://morris.org" },
                    { 14L, new DateOnly(2024, 2, 15), 24, null, "integrate plug-and-play architectures", null, "https://chaya.info" },
                    { 15L, new DateOnly(2024, 3, 31), 11, "Legacy", "mesh one-to-one ROI", null, "https://litzy.org" },
                    { 16L, new DateOnly(2024, 5, 16), 58, null, "evolve sexy web services", null, "https://aracely.info" },
                    { 17L, new DateOnly(2023, 6, 29), 45, "Dynamic", "maximize wireless bandwidth", new DateOnly(2023, 12, 16), "http://juana.org" },
                    { 18L, new DateOnly(2023, 8, 14), 32, null, "embrace scalable action-items", null, "http://wallace.info" },
                    { 19L, new DateOnly(2023, 9, 28), 19, null, "reintermediate 24/365 paradigms", null, "http://heather.org" },
                    { 20L, new DateOnly(2023, 11, 12), 5, null, "leverage cross-platform deliverables", null, "http://sandra.info" },
                    { 21L, new DateOnly(2023, 12, 28), 52, null, "visualize holistic vortals", new DateOnly(2023, 6, 6), "https://emerald.org" },
                    { 22L, new DateOnly(2024, 2, 11), 39, null, "architect global platforms", null, "https://norberto.info" },
                    { 23L, new DateOnly(2024, 3, 28), 26, null, "scale efficient metrics", null, "https://cory.org" },
                    { 24L, new DateOnly(2024, 5, 12), 13, null, "incentivize cutting-edge architectures", new DateOnly(2023, 7, 15), "https://magali.info" },
                    { 25L, new DateOnly(2023, 6, 25), 60, null, "extend intuitive communities", new DateOnly(2023, 11, 27), "http://berenice.org" },
                    { 26L, new DateOnly(2023, 8, 10), 46, "Direct", "envisioneer bleeding-edge web services", null, "http://kaylee.info" },
                    { 27L, new DateOnly(2023, 9, 24), 33, null, "revolutionize out-of-the-box systems", null, "http://abe.org" },
                    { 28L, new DateOnly(2023, 11, 9), 20, "Global", "facilitate vertical action-items", new DateOnly(2024, 1, 5), "http://ivory.info" },
                    { 29L, new DateOnly(2023, 12, 24), 7, null, "transition frictionless web-readiness", null, "https://stefanie.org" },
                    { 30L, new DateOnly(2024, 2, 7), 54, null, "disintermediate extensible deliverables", null, "https://fanny.info" },
                    { 31L, new DateOnly(2024, 3, 24), 41, null, "cultivate ubiquitous content", null, "https://pete.org" },
                    { 32L, new DateOnly(2024, 5, 8), 28, null, "deploy sticky platforms", new DateOnly(2023, 6, 27), "https://dee.info" },
                    { 33L, new DateOnly(2023, 6, 22), 14, null, "productize dot-com applications", null, "http://mathew.org" },
                    { 34L, new DateOnly(2023, 8, 6), 1, null, "target impactful architectures", null, "http://brook.info" },
                    { 35L, new DateOnly(2023, 9, 20), 48, null, "implement revolutionary communities", null, "http://lacy.com" },
                    { 36L, new DateOnly(2023, 11, 5), 35, null, "deliver dynamic experiences", new DateOnly(2023, 12, 18), "http://alfred.name" },
                    { 37L, new DateOnly(2023, 12, 20), 22, "Central", "streamline open-source systems", null, "https://jayson.com" },
                    { 38L, new DateOnly(2024, 2, 4), 9, null, "incubate compelling e-services", null, "https://tony.name" },
                    { 39L, new DateOnly(2024, 3, 20), 55, "Human", "transform end-to-end web-readiness", null, "https://genoveva.com" },
                    { 40L, new DateOnly(2024, 5, 4), 42, null, "benchmark efficient mindshare", new DateOnly(2023, 6, 8), "https://rhianna.name" },
                    { 41L, new DateOnly(2023, 6, 18), 29, null, "enable cutting-edge content", null, "http://douglas.com" },
                    { 42L, new DateOnly(2023, 8, 2), 16, null, "whiteboard intuitive infrastructures", null, "http://modesta.name" },
                    { 43L, new DateOnly(2023, 9, 17), 3, null, "reinvent magnetic applications", new DateOnly(2023, 7, 17), "http://celine.com" },
                    { 44L, new DateOnly(2023, 11, 1), 50, null, "repurpose bricks-and-clicks relationships", new DateOnly(2023, 11, 30), "http://liliane.name" },
                    { 45L, new DateOnly(2023, 12, 16), 36, null, "enhance value-added communities", null, "https://annette.com" },
                    { 46L, new DateOnly(2024, 1, 31), 23, "Regional", "unleash granular experiences", null, "https://jose.name" },
                    { 47L, new DateOnly(2024, 3, 16), 10, null, "morph seamless e-commerce", new DateOnly(2024, 1, 8), "https://violet.com" },
                    { 48L, new DateOnly(2024, 5, 1), 57, "Forward", "engineer customized e-services", null, "https://harley.name" },
                    { 49L, new DateOnly(2023, 6, 14), 44, null, "monetize mission-critical synergies", null, "http://sabrina.com" },
                    { 50L, new DateOnly(2023, 7, 29), 31, null, "generate interactive mindshare", null, "http://elroy.name" },
                    { 51L, new DateOnly(2023, 9, 13), 18, null, "seize integrated technologies", new DateOnly(2023, 6, 29), "http://nikki.com" },
                    { 52L, new DateOnly(2023, 10, 28), 4, null, "e-enable robust infrastructures", null, "http://conrad.name" },
                    { 53L, new DateOnly(2023, 12, 13), 51, null, "synergize viral networks", null, "https://macy.com" },
                    { 54L, new DateOnly(2024, 1, 27), 38, null, "matrix open-source relationships", null, "https://baron.name" },
                    { 55L, new DateOnly(2024, 3, 12), 25, null, "brand compelling eyeballs", new DateOnly(2023, 12, 20), "https://katharina.com" },
                    { 56L, new DateOnly(2024, 4, 27), 12, null, "redefine end-to-end experiences", null, "http://zion.name" },
                    { 57L, new DateOnly(2023, 6, 10), 59, "International", "syndicate real-time e-commerce", null, "http://irwin.com" },
                    { 58L, new DateOnly(2023, 7, 26), 45, null, "utilize next-generation e-tailers", null, "http://skye.name" },
                    { 59L, new DateOnly(2023, 9, 9), 32, "Corporate", "deliver innovative synergies", new DateOnly(2023, 6, 11), "http://evangeline.com" },
                    { 60L, new DateOnly(2023, 10, 25), 19, null, "optimize killer models", null, "https://patience.name" },
                    { 61L, new DateOnly(2023, 12, 9), 6, null, "engage synergistic technologies", null, "https://david.com" },
                    { 62L, new DateOnly(2024, 1, 23), 53, null, "transform clicks-and-mortar partnerships", new DateOnly(2023, 7, 20), "https://marley.name" },
                    { 63L, new DateOnly(2024, 3, 9), 40, null, "expedite B2C networks", new DateOnly(2023, 12, 2), "https://bret.com" },
                    { 64L, new DateOnly(2024, 4, 23), 26, null, "orchestrate distributed convergence", null, "http://kristin.name" },
                    { 65L, new DateOnly(2023, 6, 7), 13, null, "visualize visionary eyeballs", null, "http://alex.com" },
                    { 66L, new DateOnly(2023, 7, 22), 60, null, "aggregate e-business functionalities", new DateOnly(2024, 1, 10), "http://jason.name" },
                    { 67L, new DateOnly(2023, 9, 5), 47, null, "innovate web-enabled e-commerce", null, "http://tianna.com" },
                    { 68L, new DateOnly(2023, 10, 21), 34, "Senior", "incentivize integrated e-tailers", null, "https://garland.name" },
                    { 69L, new DateOnly(2023, 12, 5), 21, null, "drive robust blockchains", null, "https://reina.com" },
                    { 70L, new DateOnly(2024, 1, 20), 8, "Central", "empower viral models", new DateOnly(2023, 7, 1), "https://dominique.name" },
                    { 71L, new DateOnly(2024, 3, 5), 54, null, "revolutionize world-class niches", null, "https://milan.com" },
                    { 72L, new DateOnly(2024, 4, 19), 41, null, "harness collaborative partnerships", null, "http://cassidy.name" },
                    { 73L, new DateOnly(2023, 6, 3), 28, null, "exploit 24/7 schemas", null, "http://lessie.com" },
                    { 74L, new DateOnly(2023, 7, 18), 15, null, "disintermediate back-end convergence", new DateOnly(2023, 12, 22), "http://angelo.name" },
                    { 75L, new DateOnly(2023, 9, 2), 2, null, "iterate transparent channels", null, "http://johnathan.com" },
                    { 76L, new DateOnly(2023, 10, 17), 49, null, "strategize leading-edge functionalities", null, "https://vernon.name" },
                    { 77L, new DateOnly(2023, 12, 1), 35, "Principal", "productize best-of-breed e-markets", null, "https://gustave.com" },
                    { 78L, new DateOnly(2024, 1, 16), 22, null, "grow cross-media e-tailers", new DateOnly(2023, 6, 13), "https://rubye.name" },
                    { 79L, new DateOnly(2024, 3, 1), 9, "District", "recontextualize rich blockchains", null, "https://elizabeth.com" },
                    { 80L, new DateOnly(2024, 4, 16), 56, null, "synthesize B2B infomediaries", null, "http://neoma.name" },
                    { 81L, new DateOnly(2024, 5, 31), 43, null, "integrate front-end niches", new DateOnly(2023, 7, 22), "http://cloyd.com" },
                    { 82L, new DateOnly(2023, 7, 14), 30, null, "mesh visionary markets", new DateOnly(2023, 12, 4), "http://lura.name" },
                    { 83L, new DateOnly(2023, 8, 29), 16, null, "evolve e-business schemas", null, "http://aurelio.com" },
                    { 84L, new DateOnly(2023, 10, 13), 3, null, "maximize web-enabled supply-chains", null, "https://kari.name" },
                    { 85L, new DateOnly(2023, 11, 28), 50, null, "embrace enterprise channels", new DateOnly(2024, 1, 12), "https://yoshiko.com" },
                    { 86L, new DateOnly(2024, 1, 12), 37, null, "reintermediate proactive e-business", null, "https://ibrahim.name" },
                    { 87L, new DateOnly(2024, 2, 26), 24, null, "leverage virtual e-markets", null, "https://sherman.com" },
                    { 88L, new DateOnly(2024, 4, 12), 11, "National", "visualize turn-key solutions", null, "http://estrella.name" },
                    { 89L, new DateOnly(2024, 5, 27), 58, null, "architect plug-and-play blockchains", new DateOnly(2023, 7, 3), "http://otilia.com" },
                    { 90L, new DateOnly(2023, 7, 11), 44, "Legacy", "scale one-to-one infomediaries", null, "http://darien.name" },
                    { 91L, new DateOnly(2023, 8, 25), 31, null, "morph sexy portals", null, "http://marielle.com" },
                    { 92L, new DateOnly(2023, 10, 9), 18, null, "extend wireless markets", null, "https://brandy.name" },
                    { 93L, new DateOnly(2023, 11, 24), 5, null, "envisioneer scalable users", new DateOnly(2023, 12, 25), "https://kimberly.com" },
                    { 94L, new DateOnly(2024, 1, 8), 52, null, "generate 24/365 supply-chains", null, "https://albert.name" },
                    { 95L, new DateOnly(2024, 2, 23), 39, null, "facilitate cross-platform initiatives", null, "https://janis.com" },
                    { 96L, new DateOnly(2024, 4, 8), 25, null, "transition rich e-business", null, "http://tessie.name" },
                    { 97L, new DateOnly(2024, 5, 23), 12, null, "synergize B2B interfaces", new DateOnly(2023, 6, 15), "http://fredy.com" },
                    { 98L, new DateOnly(2023, 7, 7), 59, null, "cultivate front-end solutions", null, "http://raven.name" },
                    { 99L, new DateOnly(2023, 8, 21), 46, "International", "deploy user-centric methodologies", null, "http://diana.com" },
                    { 100L, new DateOnly(2023, 10, 6), 33, null, "redefine strategic infomediaries", new DateOnly(2023, 7, 24), "https://merlin.name" },
                    { 101L, new DateOnly(2023, 11, 20), 20, "Direct", "target bleeding-edge portals", new DateOnly(2023, 12, 6), "https://carol.com" },
                    { 102L, new DateOnly(2024, 1, 4), 7, null, "implement out-of-the-box paradigms", null, "https://lenora.name" },
                    { 103L, new DateOnly(2024, 2, 19), 53, null, "deliver vertical users", null, "https://ana.com" },
                    { 104L, new DateOnly(2024, 4, 4), 40, null, "streamline frictionless vortals", new DateOnly(2024, 1, 14), "http://joanie.name" },
                    { 105L, new DateOnly(2024, 5, 20), 27, null, "incubate extensible initiatives", null, "http://vance.com" },
                    { 106L, new DateOnly(2023, 7, 3), 14, null, "transform ubiquitous metrics", null, "http://greg.name" },
                    { 107L, new DateOnly(2023, 8, 17), 1, null, "benchmark sticky interfaces", null, "http://rosendo.com" },
                    { 108L, new DateOnly(2023, 10, 2), 48, "Investor", "enable dot-com ROI", new DateOnly(2023, 7, 6), "https://elenor.name" },
                    { 109L, new DateOnly(2023, 11, 16), 34, null, "whiteboard impactful methodologies", null, "https://natalie.com" },
                    { 110L, new DateOnly(2024, 1, 1), 21, "Lead", "reinvent scalable bandwidth", null, "https://claudine.name" },
                    { 111L, new DateOnly(2024, 2, 15), 8, null, "repurpose 24/365 portals", null, "https://lucienne.com" },
                    { 112L, new DateOnly(2024, 4, 1), 55, null, "enhance cross-platform paradigms", new DateOnly(2023, 12, 27), "http://ashlynn.name" },
                    { 113L, new DateOnly(2024, 5, 16), 42, null, "unleash holistic deliverables", null, "http://kailyn.com" },
                    { 114L, new DateOnly(2023, 6, 29), 29, null, "morph global vortals", null, "http://winfield.name" },
                    { 115L, new DateOnly(2023, 8, 14), 15, null, "engineer efficient platforms", null, "http://hollis.com" },
                    { 116L, new DateOnly(2023, 9, 28), 2, null, "monetize cutting-edge metrics", new DateOnly(2023, 6, 17), "https://shania.name" },
                    { 117L, new DateOnly(2023, 11, 13), 49, null, "exploit intuitive architectures", null, "https://ernest.com" },
                    { 118L, new DateOnly(2023, 12, 28), 36, null, "seize magnetic ROI", null, "https://oren.name" },
                    { 119L, new DateOnly(2024, 2, 11), 23, "Principal", "e-enable bricks-and-clicks web services", new DateOnly(2023, 7, 26), "https://dandre.com" },
                    { 120L, new DateOnly(2024, 3, 28), 10, null, "strategize value-added bandwidth", null, "http://margarette.name" },
                    { 121L, new DateOnly(2024, 5, 12), 57, "Regional", "matrix granular action-items", null, "http://bo.com" },
                    { 122L, new DateOnly(2023, 6, 26), 43, null, "brand seamless paradigms", null, "http://keshaun.name" },
                    { 123L, new DateOnly(2023, 8, 10), 30, null, "recontextualize ubiquitous deliverables", new DateOnly(2024, 1, 17), "http://agustina.com" },
                    { 124L, new DateOnly(2023, 9, 24), 17, null, "syndicate sticky content", null, "https://jamarcus.name" },
                    { 125L, new DateOnly(2023, 11, 9), 4, null, "utilize dot-com platforms", null, "https://taryn.com" },
                    { 126L, new DateOnly(2023, 12, 24), 51, null, "mesh impactful applications", null, "https://frances.name" },
                    { 127L, new DateOnly(2024, 2, 8), 38, null, "optimize revolutionary architectures", new DateOnly(2023, 7, 8), "https://raina.com" },
                    { 128L, new DateOnly(2024, 3, 24), 24, "Human", "engage dynamic communities", null, "http://desmond.name" },
                    { 129L, new DateOnly(2024, 5, 8), 11, null, "embrace open-source web services", null, "http://meaghan.com" },
                    { 130L, new DateOnly(2023, 6, 22), 58, "Product", "expedite compelling systems", null, "http://candida.name" },
                    { 131L, new DateOnly(2023, 8, 6), 45, null, "orchestrate end-to-end action-items", new DateOnly(2023, 12, 29), "http://lea.com" },
                    { 132L, new DateOnly(2023, 9, 21), 32, "Legacy", "visualize real-time web-readiness", null, "https://amara.name" },
                    { 133L, new DateOnly(2023, 11, 5), 19, null, "aggregate next-generation deliverables", null, "https://jess.com" },
                    { 134L, new DateOnly(2023, 12, 20), 5, null, "innovate innovative content", null, "https://tyrique.net" },
                    { 135L, new DateOnly(2024, 2, 4), 52, null, "incentivize killer infrastructures", new DateOnly(2023, 6, 20), "https://glenda.biz" },
                    { 136L, new DateOnly(2024, 3, 20), 39, null, "drive synergistic applications", null, "http://ronaldo.net" },
                    { 137L, new DateOnly(2024, 5, 5), 26, null, "empower value-added relationships", null, "http://effie.biz" },
                    { 138L, new DateOnly(2023, 6, 18), 13, null, "revolutionize granular communities", new DateOnly(2023, 7, 29), "http://myrl.net" },
                    { 139L, new DateOnly(2023, 8, 2), 60, "Dynamic", "harness seamless experiences", null, "http://christy.biz" },
                    { 140L, new DateOnly(2023, 9, 17), 47, null, "exploit customized systems", null, "https://lorenz.net" },
                    { 141L, new DateOnly(2023, 11, 1), 33, "Dynamic", "disintermediate mission-critical e-services", null, "https://arne.biz" },
                    { 142L, new DateOnly(2023, 12, 17), 20, null, "iterate interactive web-readiness", new DateOnly(2024, 1, 19), "https://justen.net" },
                    { 143L, new DateOnly(2024, 1, 31), 7, null, "strategize integrated mindshare", null, "https://wiley.biz" },
                    { 144L, new DateOnly(2024, 3, 16), 54, null, "productize robust content", null, "http://herminio.net" },
                    { 145L, new DateOnly(2024, 5, 1), 41, null, "grow viral infrastructures", null, "http://scottie.biz" },
                    { 146L, new DateOnly(2023, 6, 14), 28, null, "implement world-class networks", new DateOnly(2023, 7, 10), "http://enid.net" },
                    { 147L, new DateOnly(2023, 7, 30), 14, null, "synthesize collaborative relationships", null, "http://ola.biz" },
                    { 148L, new DateOnly(2023, 9, 13), 1, null, "integrate 24/7 eyeballs", null, "https://cyrus.net" },
                    { 149L, new DateOnly(2023, 10, 28), 48, null, "incubate back-end experiences", null, "https://manuel.biz" },
                    { 150L, new DateOnly(2023, 12, 13), 35, "Customer", "evolve transparent e-commerce", new DateOnly(2024, 1, 1), "https://bethel.net" },
                    { 151L, new DateOnly(2024, 1, 27), 22, null, "maximize innovative e-services", null, "https://kelsi.biz" },
                    { 152L, new DateOnly(2024, 3, 13), 9, "Lead", "enable killer synergies", null, "http://adella.net" },
                    { 153L, new DateOnly(2024, 4, 27), 55, null, "reintermediate synergistic mindshare", null, "http://jaden.biz" },
                    { 154L, new DateOnly(2023, 6, 10), 42, null, "leverage clicks-and-mortar technologies", new DateOnly(2023, 6, 22), "http://sven.net" },
                    { 155L, new DateOnly(2023, 7, 26), 29, null, "repurpose B2C infrastructures", null, "http://filomena.biz" },
                    { 156L, new DateOnly(2023, 9, 9), 16, null, "architect distributed networks", null, "https://providenci.net" },
                    { 157L, new DateOnly(2023, 10, 25), 3, null, "scale visionary convergence", new DateOnly(2023, 7, 31), "https://demario.biz" },
                    { 158L, new DateOnly(2023, 12, 9), 50, null, "morph e-business eyeballs", null, "https://maximillia.net" },
                    { 159L, new DateOnly(2024, 1, 24), 37, "Central", "extend web-enabled functionalities", null, "https://caitlyn.biz" },
                    { 160L, new DateOnly(2024, 3, 9), 23, null, "envisioneer enterprise e-commerce", null, "http://lauriane.net" },
                    { 161L, new DateOnly(2024, 4, 23), 10, "Chief", "generate proactive e-tailers", new DateOnly(2024, 1, 21), "http://alphonso.biz" },
                    { 162L, new DateOnly(2023, 6, 7), 57, null, "facilitate virtual synergies", null, "http://jennyfer.net" },
                    { 163L, new DateOnly(2023, 7, 22), 44, null, "transition turn-key models", null, "http://trey.biz" },
                    { 164L, new DateOnly(2023, 9, 6), 31, null, "synergize plug-and-play technologies", null, "https://gia.net" },
                    { 165L, new DateOnly(2023, 10, 21), 18, null, "cultivate 24/7 partnerships", new DateOnly(2023, 7, 13), "https://robin.biz" },
                    { 166L, new DateOnly(2023, 12, 5), 4, null, "deploy back-end networks", null, "https://ebony.net" },
                    { 167L, new DateOnly(2024, 1, 20), 51, null, "redefine transparent convergence", null, "http://morton.biz" },
                    { 168L, new DateOnly(2024, 3, 5), 38, null, "target leading-edge channels", null, "http://chelsea.net" },
                    { 169L, new DateOnly(2024, 4, 20), 25, null, "implement best-of-breed functionalities", new DateOnly(2024, 1, 3), "http://lizeth.biz" },
                    { 170L, new DateOnly(2023, 6, 3), 12, "Internal", "deliver cross-media e-markets", null, "http://archibald.net" },
                    { 171L, new DateOnly(2023, 7, 18), 59, null, "streamline rich e-tailers", null, "https://judah.biz" },
                    { 172L, new DateOnly(2023, 9, 2), 46, "Future", "engage B2B blockchains", null, "https://wanda.net" },
                    { 173L, new DateOnly(2023, 10, 17), 32, null, "transform front-end models", new DateOnly(2023, 6, 24), "https://heber.biz" },
                    { 174L, new DateOnly(2023, 12, 2), 19, null, "benchmark user-centric niches", null, "https://sandy.net" },
                    { 175L, new DateOnly(2024, 1, 16), 6, null, "orchestrate strategic partnerships", null, "http://emie.biz" },
                    { 176L, new DateOnly(2024, 3, 1), 53, null, "whiteboard bleeding-edge schemas", new DateOnly(2023, 8, 2), "http://norma.net" },
                    { 177L, new DateOnly(2024, 4, 16), 40, null, "reinvent out-of-the-box convergence", null, "http://courtney.biz" },
                    { 178L, new DateOnly(2024, 5, 31), 27, null, "innovate vertical channels", null, "http://magdalena.net" },
                    { 179L, new DateOnly(2023, 7, 15), 13, null, "enhance virtual e-business", null, "https://bernadine.biz" },
                    { 180L, new DateOnly(2023, 8, 29), 60, null, "unleash turn-key e-markets", new DateOnly(2024, 1, 24), "https://kayley.net" },
                    { 181L, new DateOnly(2023, 10, 13), 47, "Dynamic", "empower plug-and-play solutions", null, "https://abelardo.biz" },
                    { 182L, new DateOnly(2023, 11, 28), 34, null, "engineer one-to-one blockchains", null, "https://izabella.net" },
                    { 183L, new DateOnly(2024, 1, 12), 21, "Investor", "monetize sexy infomediaries", null, "http://stephan.biz" },
                    { 184L, new DateOnly(2024, 2, 27), 8, null, "exploit wireless niches", new DateOnly(2023, 7, 15), "http://faustino.net" },
                    { 185L, new DateOnly(2024, 4, 12), 54, null, "seize scalable markets", null, "http://peyton.biz" },
                    { 186L, new DateOnly(2024, 5, 27), 41, null, "e-enable 24/365 schemas", null, "http://deja.net" },
                    { 187L, new DateOnly(2023, 7, 11), 28, null, "strategize cross-platform supply-chains", null, "https://mathilde.biz" },
                    { 188L, new DateOnly(2023, 8, 25), 15, null, "matrix holistic initiatives", new DateOnly(2024, 1, 5), "https://brooks.net" },
                    { 189L, new DateOnly(2023, 10, 10), 2, null, "brand global e-business", null, "https://lafayette.biz" },
                    { 190L, new DateOnly(2023, 11, 24), 49, "Direct", "recontextualize efficient interfaces", null, "https://alfredo.net" },
                    { 191L, new DateOnly(2024, 1, 8), 36, null, "syndicate cutting-edge solutions", null, "http://jazmin.biz" },
                    { 192L, new DateOnly(2024, 2, 23), 22, "Global", "utilize intuitive methodologies", new DateOnly(2023, 6, 27), "http://torrance.net" },
                    { 193L, new DateOnly(2024, 4, 8), 9, null, "mesh bleeding-edge infomediaries", null, "http://geoffrey.biz" },
                    { 194L, new DateOnly(2024, 5, 24), 56, null, "optimize out-of-the-box portals", null, "http://rhoda.net" },
                    { 195L, new DateOnly(2023, 7, 7), 43, null, "engage vertical markets", new DateOnly(2023, 8, 5), "https://drake.biz" },
                    { 196L, new DateOnly(2023, 8, 21), 30, null, "embrace frictionless users", null, "https://mohamed.net" },
                    { 197L, new DateOnly(2023, 10, 6), 17, null, "expedite extensible supply-chains", null, "https://chad.biz" },
                    { 198L, new DateOnly(2023, 11, 20), 3, null, "orchestrate ubiquitous initiatives", null, "https://lilliana.net" },
                    { 199L, new DateOnly(2024, 1, 5), 50, null, "visualize sticky metrics", new DateOnly(2024, 1, 26), "http://ansel.biz" },
                    { 200L, new DateOnly(2024, 2, 19), 37, null, "aggregate dot-com interfaces", null, "http://josefina.net" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblLink_linkBoardId",
                table: "tblLink",
                column: "linkBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLink_title_url",
                table: "tblLink",
                columns: new[] { "title", "url" })
                .Annotation("Npgsql:IndexMethod", "gin")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_tblLinkBoard_title",
                table: "tblLinkBoard",
                column: "title")
                .Annotation("Npgsql:IndexMethod", "gin")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_tblLinkBoard_userId",
                table: "tblLinkBoard",
                column: "userId");

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
                name: "tblLink");

            migrationBuilder.DropTable(
                name: "tblLinkBoard");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
