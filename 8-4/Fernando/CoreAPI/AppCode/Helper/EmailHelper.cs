using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CoreAPI.AppCode.Helper
{
    public static class EmailHelper
    {
        private static string API_KEY = "SG.AhpBZmi9S3OrHBvllt1Jsg.SLHLKZno3nlsB0Ln4WnssQMlLevWmum6sXLLMmQ5o04";
        public static async Task Execute(string email, string nombreUsuario, string asunto, string html)
        {
            var apiKey = API_KEY;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("grupobejuco@outlook.com", "Grupo Bejuco");
            var subject = asunto;
            var to = new EmailAddress(email, nombreUsuario);
            var plainTextContent = "";
            var htmlContent = html;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public static string AcessoPlataforma(Usuario usuario)
        {
            return $"<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
                    $"    <table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +

                    $"        <tbody><tr>" +
                    $"            <td align='center'>" +
                    $"                <table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +

                    $"                    <tbody><tr>" +
                    $"                        <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
                    $"                    </tr>" +

                    $"                    <tr>" +
                    $"                        <td align='center'>" +

                    $"                            <table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +

                    $"                                <tbody><tr>" +
                    $"                                    <td align='center' height='70' style='height:70px;'>" +
                    $"                                        <a href='' style='display: block; border-style: none !important; border: 0 !important;'><img width='100' border='0' style='display: block; width: 100px;' src='https://res.cloudinary.com/grupo-bejuco/image/upload/v1585727023/Bejuco.jpg' alt=''></a>" +
                    $"                                    </td>" +
                    $"                                </tr>" +
                    $"                            </tbody></table>" +
                    $"                        </td>" +
                    $"                    </tr>" +

                    $"                    <tr>" +
                    $"                        <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
                    $"                    </tr>" +

                    $"                </tbody></table>" +
                    $"            </td>" +
                    $"        </tr>" +
                    $"    </tbody></table>" +
                    $"    <!-- end header -->" +

                    $"    <!-- big image section -->" +
                    $"    <table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff' class='bg_color'>" +

                    $"        <tbody><tr>" +
                    $"            <td align='center'>" +
                    $"                <table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
                    $"                    <tbody><tr>" +

                    $"                        <td align='center' class='section-img'>" +
                    $"                            <a href='' style=' border-style: none !important; display: block; border: 0 !important;'><img src='https://res.cloudinary.com/grupo-bejuco/image/upload/v1585727251/wood1.jpg' style='display: block; width: 590px;' width='590' border='0' alt=''></a>" +




                    $"                        </td>" +
                    $"                    </tr>" +
                    $"                    <tr>" +
                    $"                        <td height='20' style='font-size: 20px; line-height: 20px;'>&nbsp;</td>" +
                    $"                    </tr>" +
                    $"                    <tr>" +
                    $"                        <td align='center' style='color: #343434; font-size: 24px; font-family: Quicksand, Calibri, sans-serif; font-weight:700;letter-spacing: 3px; line-height: 35px;' class='main-header'>" +


                    $"                            <div style='line-height: 35px'>" +

                    $"                                WELCOME TO MASTER <span style='color: #5caad2;'>{usuario.Nombre} {usuario.PrimerApellido}</span>" +

                    $"                            </div>" +
                    $"                        </td>" +
                    $"                    </tr>" +

                    $"                    <tr>" +
                    $"                        <td height='10' style='font-size: 10px; line-height: 10px;'>&nbsp;</td>" +
                    $"                    </tr>" +

                    $"                    <tr>" +
                    $"                        <td align='center'>" +
                    $"                            <table border='0' width='40' align='center' cellpadding='0' cellspacing='0' bgcolor='eeeeee'>" +
                    $"                                <tbody><tr>" +
                    $"                                    <td height='2' style='font-size: 2px; line-height: 2px;'>&nbsp;</td>" +
                    $"                                </tr>" +
                    $"                            </tbody></table>" +
                    $"                        </td>" +
                    $"                    </tr>" +

                    $"                    <tr>" +
                    $"                        <td height='20' style='font-size: 20px; line-height: 20px;'>&nbsp;</td>" +
                    $"                    </tr>" +

                    $"                    <tr>" +
                    $"                        <td align='center'>" +
                    $"                            <table border='0' width='400' align='center' cellpadding='0' cellspacing='0' class='container590'>" +
                    $"                                <tbody><tr>" +
                    $"                                    <td align='center' style='color: #888888; font-size: 16px; font-family: 'Work Sans', Calibri, sans-serif; line-height: 24px;'>" +


                    $"                                        <div style='line-height: 24px'>" +

                    $"                                            Use the code sent in your phone number." +
                    $"                                        </div>" +
                    $"                                    </td>" +
                    $"                                </tr>" +
                    $"                            </tbody></table>" +
                    $"                        </td>" +
                    $"                    </tr>" +

                    $"                    <tr>" +
                    $"                        <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
                    $"                    </tr>" +

                    $"                    <tr>" +
                    $"                        <td align='center'>" +
                    $"                            <table border='0' align='center' width='160' cellpadding='0' cellspacing='0' bgcolor='5caad2' style=''>" +

                    $"                                <tbody><tr>" +
                    $"                                    <td height='10' style='font-size: 10px; line-height: 10px;'>&nbsp;</td>" +
                    $"                                </tr>" +

                    $"                                <tr>" +
                    $"                                    <td align='center' style='color: #ffffff; font-size: 14px; font-family: 'Work Sans', Calibri, sans-serif; line-height: 26px;'>" +


                    $"                                        <div style='line-height: 26px;'>" +
                    $"                                            <a style='color: #ffffff; text-decoration: none;' href='https://localhost:44306/Home/Login?email={usuario.Email}'>LOGIN</a>" +
                    $"                                        </div>" +
                    $"                                    </td>" +
                    $"                                </tr>" +

                    $"                                <tr>" +
                    $"                                    <td height='10' style='font-size: 10px; line-height: 10px;'>&nbsp;</td>" +
                    $"                                </tr>" +

                    $"                            </tbody></table>" +
                    $"                        </td>" +
                    $"                    </tr>" +


                    $"                </tbody></table>" +

                    $"            </td>" +
                    $"        </tr>" +

                    $"    </tbody></table>" +
                    $"    <!-- end section -->" +

                    $"    <!-- contact section -->" +
                    $"    <table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff' class='bg_color'>" +

                    $"        <tbody><tr class='hide'>" +
                    $"            <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
                    $"        </tr>" +
                    $"        <tr>" +
                    $"            <td height='40' style='font-size: 40px; line-height: 40px;'>&nbsp;</td>" +
                    $"        </tr>" +

                    $"        <tr>" +
                    $"            <td height='60' style='border-top: 1px solid #e0e0e0;font-size: 60px; line-height: 60px;'>&nbsp;</td>" +
                    $"        </tr>" +

                    $"        <tr>" +
                    $"            <td align='center'>" +
                    $"                <table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590 bg_color'>" +

                    $"                    <tbody><tr>" +
                    $"                        <td>" +
                    $"                            <table border='0' width='300' align='left' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590'>" +

                    $"                                <tbody><tr>" +
                    $"                                    <!-- logo -->" +
                    $"                                    <td align='left'>" +
                    $"                                        <a href='' style='display: block; border-style: none !important; border: 0 !important;'><img width='80' border='0' style='display: block; width: 80px;' src='https://res.cloudinary.com/grupo-bejuco/image/upload/v1585727023/Bejuco.jpg' alt=''></a>" +
                    $"                                    </td>" +
                    $"                                </tr>" +

                    $"                                <tr>" +
                    $"                                    <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
                    $"                                </tr>" +

                    $"                                <tr>" +
                    $"                                    <td align='left' style='color: #888888; font-size: 14px; font-family: 'Work Sans', Calibri, sans-serif; line-height: 23px;' class='text_color'>" +
                    $"                                        <div style='color: #333333; font-size: 14px; font-family: 'Work Sans', Calibri, sans-serif; font-weight: 600; mso-line-height-rule: exactly; line-height: 23px;'>" +

                    $"                                            Email us: <br> <a href='mailto:' style='color: #888888; font-size: 14px; font-family: 'Hind Siliguri', Calibri, Sans-serif; font-weight: 400;'>grupobejuco@outlook.com</a>" +

                    $"                                        </div>" +
                    $"                                    </td>" +
                    $"                                </tr>" +

                    $"                            </tbody></table>" +

                    $"                            <table border='0' width='2' align='left' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590'>" +
                    $"                                <tbody><tr>" +
                    $"                                    <td width='2' height='10' style='font-size: 10px; line-height: 10px;'></td>" +
                    $"                                </tr>" +
                    $"                            </tbody></table>" +

                    $"                            <table border='0' width='200' align='right' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590'>" +

                    $"                                <tbody><tr>" +
                    $"                                    <td class='hide' height='45' style='font-size: 45px; line-height: 45px;'>&nbsp;</td>" +
                    $"                                </tr>" +



                    $"                                <tr>" +
                    $"                                    <td height='15' style='font-size: 15px; line-height: 15px;'>&nbsp;</td>" +
                    $"                                </tr>" +
                    $"                            </tbody></table>" +
                    $"                        </td>" +
                    $"                    </tr>" +
                    $"                </tbody></table>" +
                    $"            </td>" +
                    $"        </tr>" +

                    $"        <tr>" +
                    $"            <td height='60' style='font-size: 60px; line-height: 60px;'>&nbsp;</td>" +
                    $"        </tr>" +

                    $"    </tbody></table>" +
                    $"    <!-- end section -->" +

                    $"    <!-- footer ====== -->" +
                    $"    <table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='f4f4f4'>" +

                    $"        <tbody><tr>" +
                    $"            <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
                    $"        </tr>" +

                    $"        <tr>" +
                    $"            <td align='center'>" +

                    $"                <table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +

                    $"                    <tbody><tr>" +
                    $"                        <td>" +
                    $"                            <table border='0' align='left' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590'>" +
                    $"                                <tbody><tr>" +
                    $"                                    <td align='left' style='color: #aaaaaa; font-size: 14px; font-family: 'Work Sans', Calibri, sans-serif; line-height: 24px;'>" +
                    $"                                        <div style='line-height: 24px;'>" +

                    $"                                            <span style='color: #333333;'>Grupo Bejuco</span>" +

                    $"                                        </div>" +
                    $"                                    </td>" +
                    $"                                </tr>" +
                    $"                            </tbody></table>" +

                    $"                            <table border='0' align='left' width='5' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590'>" +
                    $"                                <tbody><tr>" +
                    $"                                    <td height='20' width='5' style='font-size: 20px; line-height: 20px;'>&nbsp;</td>" +
                    $"                                </tr>" +
                    $"                            </tbody></table>" +
                    $"                        </td>" +
                    $"                    </tr>" +

                    $"                </tbody></table>" +
                    $"            </td>" +
                    $"        </tr>" +

                    $"        <tr>" +
                    $"            <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
                    $"        </tr>" +

                    $"    </tbody></table>" +
                    $"</body>";


        }
    }
}
