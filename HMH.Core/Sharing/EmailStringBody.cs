using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.Sharing
{
    public class EmailStringBody
    {
        public static string Send(string email, string token, string redirectTo, string message)
        {
            var encodedToken = Uri.EscapeDataString(token);
            var encodedEmail = Uri.EscapeDataString(email);
            var encodedRedirect = Uri.EscapeDataString(redirectTo);

            var link = $"https://yourfrontenddomain.com/redirect-handler?email={encodedEmail}&code={encodedToken}&redirectTo={encodedRedirect}";

            return $@"
            <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f9f9f9;
                            padding: 40px;
                        }}
                        .container {{
                            background-color: #fff;
                            padding: 20px;
                            border-radius: 8px;
                            box-shadow: 0 0 10px rgba(0,0,0,0.05);
                            max-width: 600px;
                            margin: auto;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 10px 20px;
                            background-color: #007bff;
                            color: white;
                            text-decoration: none;
                            border-radius: 5px;
                            margin-top: 20px;
                        }}
                        .small-text {{
                            font-size: 12px;
                            color: #666;
                            margin-top: 10px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h2>{message}</h2>
                        <p>اضغط على الزر التالي لإكمال العملية:</p>
                        <a class='button' href='{link}'>متابعة</a>
                        <p class='small-text'>إذا لم يعمل الزر، انسخ الرابط التالي وافتحه في المتصفح:</p>
                        <p class='small-text'>{link}</p>
                    </div>
                </body>
            </html>
        ";
        }

    }
}
