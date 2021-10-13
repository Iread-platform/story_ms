using Microsoft.EntityFrameworkCore.Migrations;

namespace iread_story.Migrations
{
    public partial class initlanguagestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Active", "Code", "Name" },
                values: new object[,]
                {
                    { 1, false, "iv", "Invariant Language (Invariant Country)" },
                    { 143, false, "nn", "Norwegian Nynorsk" },
                    { 144, false, "nnh", "Ngiemboon" },
                    { 145, false, "nus", "Nuer" },
                    { 146, false, "nyn", "Nyankole" },
                    { 147, false, "om", "Oromo" },
                    { 148, false, "or", "Odia" },
                    { 149, false, "os", "Ossetic" },
                    { 150, false, "pa", "Punjabi" },
                    { 151, false, "pa", "Punjabi" },
                    { 152, false, "pa", "Punjabi" },
                    { 153, false, "pl", "Polish" },
                    { 142, false, "nmg", "Kwasio" },
                    { 154, false, "ps", "Pashto" },
                    { 156, false, "qu", "Quechua" },
                    { 157, false, "rm", "Romansh" },
                    { 158, false, "rn", "Rundi" },
                    { 159, false, "ro", "Romanian" },
                    { 160, false, "rof", "Rombo" },
                    { 161, false, "ru", "Russian" },
                    { 162, false, "rw", "Kinyarwanda" },
                    { 163, false, "rwk", "Rwa" },
                    { 164, false, "sah", "Sakha" },
                    { 165, false, "saq", "Samburu" },
                    { 166, false, "sbp", "Sangu" },
                    { 155, false, "pt", "Portuguese" },
                    { 167, false, "sd", "Sindhi" },
                    { 141, false, "nl", "Dutch" },
                    { 139, false, "nds", "Low German" },
                    { 115, false, "lt", "Lithuanian" },
                    { 116, false, "lu", "Luba-Katanga" },
                    { 117, false, "luo", "Luo" },
                    { 118, false, "luy", "Luyia" },
                    { 119, false, "lv", "Latvian" },
                    { 120, false, "mas", "Masai" },
                    { 121, false, "mer", "Meru" },
                    { 122, false, "mfe", "Morisyen" },
                    { 123, false, "mg", "Malagasy" },
                    { 124, false, "mgh", "Makhuwa-Meetto" },
                    { 125, false, "mgo", "Metaʼ" },
                    { 140, false, "ne", "Nepali" },
                    { 126, false, "mi", "Maori" },
                    { 128, false, "ml", "Malayalam" },
                    { 129, false, "mn", "Mongolian" },
                    { 130, false, "mr", "Marathi" },
                    { 131, false, "ms", "Malay" },
                    { 132, false, "mt", "Maltese" },
                    { 133, false, "mua", "Mundang" },
                    { 134, false, "my", "Burmese" },
                    { 135, false, "mzn", "Mazanderani" },
                    { 136, false, "naq", "Nama" },
                    { 137, false, "nb", "Norwegian Bokmål" },
                    { 138, false, "nd", "North Ndebele" },
                    { 127, false, "mk", "Macedonian" },
                    { 168, false, "se", "Northern Sami" },
                    { 169, false, "seh", "Sena" },
                    { 170, false, "ses", "Koyraboro Senni" },
                    { 200, false, "uk", "Ukrainian" },
                    { 201, false, "ur", "Urdu" },
                    { 202, false, "uz", "Uzbek" },
                    { 203, false, "uz", "Uzbek" },
                    { 204, false, "uz", "Uzbek" },
                    { 205, false, "uz", "Uzbek" },
                    { 206, false, "vai", "Vai" },
                    { 207, false, "vai", "Vai" },
                    { 208, false, "vai", "Vai" },
                    { 209, false, "vi", "Vietnamese" },
                    { 210, false, "vun", "Vunjo" },
                    { 199, false, "ug", "Uyghur" },
                    { 211, false, "wae", "Walser" },
                    { 213, false, "xh", "Xhosa" },
                    { 214, false, "xog", "Soga" },
                    { 215, false, "yav", "Yangben" },
                    { 216, false, "yi", "Yiddish" },
                    { 217, false, "yo", "Yoruba" },
                    { 218, false, "yue", "Cantonese" },
                    { 219, false, "yue", "Cantonese" },
                    { 220, false, "yue", "Cantonese" },
                    { 221, false, "zgh", "Standard Moroccan Tamazight" },
                    { 222, false, "zh", "Chinese" },
                    { 223, false, "zh", "Chinese" },
                    { 212, false, "wo", "Wolof" },
                    { 198, false, "tzm", "Central Atlas Tamazight" },
                    { 197, false, "twq", "Tasawaq" },
                    { 196, false, "tt", "Tatar" },
                    { 171, false, "sg", "Sango" },
                    { 172, false, "shi", "Tachelhit" },
                    { 173, false, "shi", "Tachelhit" },
                    { 174, false, "shi", "Tachelhit" },
                    { 175, false, "si", "Sinhala" },
                    { 176, false, "sk", "Slovak" },
                    { 177, false, "sl", "Slovenian" },
                    { 178, false, "smn", "Inari Sami" },
                    { 179, false, "sn", "Shona" },
                    { 180, false, "so", "Somali" },
                    { 181, false, "sq", "Albanian" },
                    { 182, false, "sr", "Serbian" },
                    { 183, false, "sr", "Serbian" },
                    { 184, false, "sr", "Serbian" },
                    { 185, false, "sv", "Swedish" },
                    { 186, false, "sw", "Swahili" },
                    { 187, false, "ta", "Tamil" },
                    { 188, false, "te", "Telugu" },
                    { 189, false, "teo", "Teso" },
                    { 190, false, "tg", "Tajik" },
                    { 191, false, "th", "Thai" },
                    { 192, false, "ti", "Tigrinya" },
                    { 193, false, "tk", "Turkmen" },
                    { 194, false, "to", "Tongan" },
                    { 195, false, "tr", "Turkish" },
                    { 114, false, "lrc", "Northern Luri" },
                    { 224, false, "zh", "Chinese" },
                    { 113, false, "lo", "Lao" },
                    { 111, false, "lkt", "Lakota" },
                    { 30, false, "cgg", "Chiga" },
                    { 31, false, "chr", "Cherokee" },
                    { 32, false, "ckb", "Central Kurdish" },
                    { 33, false, "cs", "Czech" },
                    { 34, false, "cy", "Welsh" },
                    { 35, false, "da", "Danish" },
                    { 36, false, "dav", "Taita" },
                    { 37, false, "de", "German" },
                    { 38, false, "dje", "Zarma" },
                    { 39, false, "dsb", "Lower Sorbian" },
                    { 40, false, "dua", "Duala" },
                    { 29, false, "ceb", "Cebuano" },
                    { 41, false, "dyo", "Jola-Fonyi" },
                    { 43, false, "ebu", "Embu" },
                    { 44, false, "ee", "Ewe" },
                    { 45, false, "el", "Greek" },
                    { 46, false, "en", "English" },
                    { 47, false, "eo", "Esperanto" },
                    { 48, false, "es", "Spanish" },
                    { 49, false, "et", "Estonian" },
                    { 50, false, "eu", "Basque" },
                    { 51, false, "ewo", "Ewondo" },
                    { 52, false, "fa", "Persian" },
                    { 53, false, "ff", "Fulah" },
                    { 42, false, "dz", "Dzongkha" },
                    { 54, false, "ff", "Fulah" },
                    { 28, false, "ce", "Chechen" },
                    { 26, false, "ca", "Catalan" },
                    { 2, false, "af", "Afrikaans" },
                    { 3, false, "agq", "Aghem" },
                    { 4, false, "ak", "Akan" },
                    { 5, false, "am", "Amharic" },
                    { 6, false, "ar", "Arabic" },
                    { 7, false, "as", "Assamese" },
                    { 8, false, "asa", "Asu" },
                    { 9, false, "ast", "Asturian" },
                    { 10, false, "az", "Azerbaijani" },
                    { 11, false, "az", "Azerbaijani" },
                    { 12, false, "az", "Azerbaijani" },
                    { 27, false, "ccp", "Chakma" },
                    { 13, false, "bas", "Basaa" },
                    { 15, false, "bem", "Bemba" },
                    { 16, false, "bez", "Bena" },
                    { 17, false, "bg", "Bulgarian" },
                    { 18, false, "bm", "Bambara" },
                    { 19, false, "bn", "Bangla" },
                    { 20, false, "bo", "Tibetan" },
                    { 21, false, "br", "Breton" },
                    { 22, false, "brx", "Bodo" },
                    { 23, false, "bs", "Bosnian" },
                    { 24, false, "bs", "Bosnian" },
                    { 25, false, "bs", "Bosnian" },
                    { 14, false, "be", "Belarusian" },
                    { 55, false, "fi", "Finnish" },
                    { 56, false, "fil", "Filipino" },
                    { 57, false, "fo", "Faroese" },
                    { 87, false, "kab", "Kabyle" },
                    { 88, false, "kam", "Kamba" },
                    { 89, false, "kde", "Makonde" },
                    { 90, false, "kea", "Kabuverdianu" },
                    { 91, false, "khq", "Koyra Chiini" },
                    { 92, false, "ki", "Kikuyu" },
                    { 93, false, "kk", "Kazakh" },
                    { 94, false, "kkj", "Kako" },
                    { 95, false, "kl", "Kalaallisut" },
                    { 96, false, "kln", "Kalenjin" },
                    { 97, false, "km", "Khmer" },
                    { 86, false, "ka", "Georgian" },
                    { 98, false, "kn", "Kannada" },
                    { 100, false, "kok", "Konkani" },
                    { 101, false, "ks", "Kashmiri" },
                    { 102, false, "ksb", "Shambala" },
                    { 103, false, "ksf", "Bafia" },
                    { 104, false, "ksh", "Colognian" },
                    { 105, false, "ku", "Kurdish" },
                    { 106, false, "kw", "Cornish" },
                    { 107, false, "ky", "Kyrgyz" },
                    { 108, false, "lag", "Langi" },
                    { 109, false, "lb", "Luxembourgish" },
                    { 110, false, "lg", "Ganda" },
                    { 99, false, "ko", "Korean" },
                    { 85, false, "jv", "Javanese" },
                    { 84, false, "jmc", "Machame" },
                    { 83, false, "jgo", "Ngomba" },
                    { 58, false, "fr", "French" },
                    { 59, false, "fur", "Friulian" },
                    { 60, false, "fy", "Western Frisian" },
                    { 61, false, "ga", "Irish" },
                    { 62, false, "gd", "Scottish Gaelic" },
                    { 63, false, "gl", "Galician" },
                    { 64, false, "gsw", "Swiss German" },
                    { 65, false, "gu", "Gujarati" },
                    { 66, false, "guz", "Gusii" },
                    { 67, false, "gv", "Manx" },
                    { 68, false, "ha", "Hausa" },
                    { 69, false, "haw", "Hawaiian" },
                    { 70, false, "he", "Hebrew" },
                    { 71, false, "hi", "Hindi" },
                    { 72, false, "hr", "Croatian" },
                    { 73, false, "hsb", "Upper Sorbian" },
                    { 74, false, "hu", "Hungarian" },
                    { 75, false, "hy", "Armenian" },
                    { 76, false, "ia", "Interlingua" },
                    { 77, false, "id", "Indonesian" },
                    { 78, false, "ig", "Igbo" },
                    { 79, false, "ii", "Sichuan Yi" },
                    { 80, false, "is", "Icelandic" },
                    { 81, false, "it", "Italian" },
                    { 82, false, "ja", "Japanese" },
                    { 112, false, "ln", "Lingala" },
                    { 225, false, "zu", "Zulu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 225);
        }
    }
}
