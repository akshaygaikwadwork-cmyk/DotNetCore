<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Two_Step_Verification.aspx.cs" Inherits="OTP_Generate_SMS.Two_Step_Verification" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>OTP Generation</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</head>
<body>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-center">OTP Generation</h3>
                    </div>
                    <div class="card-body">
                        <form method="post" runat="server">
                            <div class="form-group">
                                <asp:Label for="phoneNumber" runat="server">Phone Number:</asp:Label>
                                <asp:TextBox ID="txtPhoneNumber" runat="server" class="form-control" name="phoneNumber" placeholder="Enter your phone number"></asp:TextBox>
                            </div>
                            <asp:Button class="btn btn-primary btn-block" ID="btnGenOTP" runat="server" Text="Generate OTP" OnClick="btnGenOTP_Click"></asp:Button>
                        </form>


                        <asp:Label ID="lblMsg" runat="server"></asp:Label>


                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

