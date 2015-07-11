<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DistanceCalculatorWebClinet.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Distance Calculator</title>
    <style>
        input {
            display: block;
            margin-bottom: 20px;
        }
        #wrapper {
            width: 500px;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <div id="wrapper">
        <form id="DistanceCalculator" runat="server">
            <label for="AX">Point AX:</label>
            <input type="number" runat="server" id="AX" />

            <label for="AY">Point AY:</label>
            <input type="number" runat="server" id="AY" />

            <label for="BX">Point BX:</label>
            <input type="number" runat="server" id="BX" />

            <label for="BY">Point BY:</label>
            <input type="number" runat="server" id="BY" />
            
            <asp:Button ID="Calculate"
                Text="Calculate"
                OnClick="Calculate_Click"
                runat="server" />
            
            <asp:Label ID="Result" runat="server" 
                 Visible="false"/>
        </form>
    </div>
</body>
</html>