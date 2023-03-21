namespace StackOverflowAPI.EmailServices
{
    public class EmailTemplate
    {
        private string template { get; set; }

        public EmailTemplate(string Name , string message)
        {
            template =$@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Document</title>
</head>

<body>
    <table class=""container"">
      <tr>
          <td>
              <table width=""200"" style=""margin: auto;"">
                 <tr>
                     <td style=""background-color: white; align:center;"">
                        <p style=""color: #000000;font-size:45px; font-weight:bold"">
                            The Jitu International Airport</p>
                     </td>
                 </tr>
               </table>
          </td>
      </tr>
      <tr>
          <td style=""padding: 20px;"">
            <table width=""600"" style=""margin: auto;"">
                <tr>
                    <td>
                        
                        <img src=""https://imgs.search.brave.com/T1OMaY6k4oBZolBQMQY3T_6O4K9a9V_f_Dj6uoV7_7M/rs:fit:1200:1200:1/g:ce/aHR0cDovL3VwbG9h/ZC53aWtpbWVkaWEu/b3JnL3dpa2lwZWRp/YS9jb21tb25zL2Iv/YmEvSE1TX1N1cnBy/aXNlX2F0X3N1bnNl/dF93aXRoX2FpcnBs/YW5lLmpwZw""
                         alt=""image""/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p> Hello {Name}</p>
                        <h2 style=""font-size: 35px;"">Welcome to the Jitu International Airport</h2>
                        <p style=""color: black;font-size: 30px; margin: 10px 0px;font-weight: 400;"">
                          {message} </p>
                        <p style=""color: black;font-size: 20px;Margin: 10px 0px;font-weight: 400; max-width: 500px;"">
                            </p>
                       
                        
                    </td>
                </tr>
            </table>
        </td>
      </tr>
      <tr>
          <td>
              <table width=""600"" style=""margin: auto;"">
                
            </table>
          </td>
      </tr>
    </table>
</body>
</html>
";
        }

       public string getTemplate()
        {
            return template;    
        }

    }
}
