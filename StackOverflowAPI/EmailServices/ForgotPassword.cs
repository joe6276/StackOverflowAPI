namespace StackOverflowAPI.EmailServices
{
    public class ForgotPassword
    {
        private string template { get; set; }

        public ForgotPassword (string Name , string message)
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
                            StackOverflow Lite</p>
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
                        
                      
                    </td>
                </tr>
                <tr>
                    <td>
                        <p> Hello {Name} Wlecome to stackOverflowLite</p></h2>
                        <p style=""color: black;font-size: 30px; margin: 10px 0px;font-weight: 400;"">
                            Follow the Following  Verify your Account
                           </p>
                        <a style=""color: black;font-size: 20px;Margin: 10px 0px;font-weight: 400; max-width: 500px;"" href=""https://localhost:7247/api/Auth/login/{message}"">
                                Verify
                            </a>
                       
                        
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
