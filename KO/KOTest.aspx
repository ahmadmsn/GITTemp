<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KOTest.aspx.vb"  MasterPageFile="~/CASYDef.Master" Inherits=".KOTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/knockout-3.2.0.js"></script>
    <script src="js/jquery-2.1.0.min.js"></script>
    <script type="text/javascript" src="js/knockout.validation.js"></script>
   <link href="css/CASYMinimal.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="row">
        <div class="small-2 columns" >Purchaser Id:</div>
        <div class="small-2 columns"><input type="text" maxlength="3" data-bind="value: PurchaserId" /></div>
        <div class="small-8 columns"><a class="tiny button" data-bind="click: addUser">Find Purchaser</a></div>
        
    </div>
    <div class="row">
        <table border="1">
            <thead>
                <tr>
                    <th>Full Name</th>
                    <th>Address</th>                    
                    <th>DS From</th>
                    <th>Remove User</th>
                </tr>

            </thead>
            <tbody data-bind="foreach: friends">
                <tr>
                    <td data-bind="text: fullName"></td>
                    <td data-bind="text: address"></td>
                                        <td>
                        <input type="text"></input></td>
                    <td>
                        <input type="button" data-bind="click: deleteRow" value="Delete"></input></td>
                </tr>
            </tbody>
        </table>
        <%--<button data-bind="click: addUser">Add User</button>--%>

    </div>

     <script type="text/javascript">
         var viewModel;
         var friends;
         function Friend(a, b) {
            
             this.fullName = a;
             this.address = b;
             this.graduate = ko.observable(false);
             this.subjects = ko.observable('');           

             //Remove Row from Table
             this.deleteRow = function () {
                 friends.remove(this);
             };
         }

         function functionViewModel() {
             var self = this;
             self.PurchaserId = ko.observable("");

             friends = ko.observableArray();
            
             addUser = function () {
               
                 $.ajax({
                     url: "Services/PurchaserInfo.asmx/OpenPurchaserInfo",
                     type: "POST",
                     async: true,
                     contentType: "application/json; charset=utf-8",
                     data: JSON.stringify({
                         "PurchaserId": self.PurchaserId()
                     }),
                     success: function (data) {
                         if (!data.d.SuccessFlag) {
                             SetFeedBackMSG(data.d.ErrorMessage, "error");
                             self.AllowEdit(false);
                         }
                         else {
                             friends.push(new Friend(data.d.Name, data.d.CASYUserId));
                         }
                     },
                     error: function (data) {
                         SetFeedBackMSG("Failed to get Locked Cases", "info");
                         self.AllowEdit(false);
                     }

                 });

                 
             };             
         };
         viewModel = new functionViewModel();
         ko.applyBindings(viewModel);

    </script>

</asp:Content>