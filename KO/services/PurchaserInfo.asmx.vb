Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports IKEA.Supply.CASY.usCASYNet.Facade.BusinessUnits
Imports System.Web.Script.Services
Imports IKEA.Supply.CasyWeb.Components

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
<ScriptService()> _
Public Class PurchaserInfo1
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function OpenPurchaserInfo(PurchaserId As String) As ClientModels.PurchaserInfoModel
        Dim sPurchaserNo As String
        Dim ReturnVal As New ClientModels.PurchaserInfoModel
        Dim oPurchaser As Purchaser
        Dim vErrMsg As Object = Nothing
        Dim sPurchaserId As String = ""
        ReturnVal.ErrorMessage = ""

        If PurchaserId <> "" Then
            sPurchaserId = PurchaserId
        End If

        If IsNumeric(PurchaserId) And PurchaserId.Length() = 3 And PurchaserId <> "" Then
            sPurchaserNo = PurchaserId
            oPurchaser = New Purchaser(ConfigurationManager.AppSettings.Item("WebServiceURL"))
            If Not oPurchaser.OpenObject(sPurchaserId) Then
                ReturnVal.SuccessFlag = False
                ReturnVal.ErrorMessage = String.Format("Could not find Purchaser")
                Return ReturnVal
            Else
                If oPurchaser.IsEOF Then
                    If Trim(sPurchaserId) = "" Then
                        ReturnVal.SuccessFlag = False
                        ReturnVal.ErrorMessage = String.Format("Click on Find Purchaser to select a purchaser")
                        Return ReturnVal
                    Else
                        ReturnVal.SuccessFlag = False
                        ReturnVal.ErrorMessage = String.Format("Purchaser {0}  was not found", sPurchaserId)
                        Return ReturnVal
                    End If
                Else
                    ReturnVal.PurchaserId = sPurchaserId
                    ReturnVal.Name = oPurchaser.Name
                    ReturnVal.CASYUserId = oPurchaser.UserId
                    ReturnVal.MISGroup = oPurchaser.Group
                    If oPurchaser.MemoReceiver Then 'MemoReceiver
                        ReturnVal.RecieveMail = True
                    Else
                        ReturnVal.RecieveMail = False
                    End If
                End If
                ReturnVal.SuccessFlag = True
                Return ReturnVal
            End If 'Open Purchaser	
        Else
            ReturnVal.SuccessFlag = False
            ReturnVal.ErrorMessage = String.Format("Please fill in Purchaser number")
            Return ReturnVal
        End If
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function SavePurchaserInfo(data As ClientModels.PurchaserInfoModel) As ClientModels.OperationResultMessage
        Dim returnVal As New ClientModels.OperationResultMessage()
        Dim oPurchaser As Purchaser
        Dim vErrMsg As Object = Nothing
        Dim sPurchaser As String
        Dim bOKtoSave As Boolean

        bOKtoSave = True

        If IsNumeric(data.PurchaserId) Then
            If data.PurchaserId <> "" Then
                If data.PurchaserId.Length() = 3 Then
                    sPurchaser = data.PurchaserId
                Else
                    returnVal.SuccessFlag = False
                    returnVal.ErrorMessage = String.Format("Purchaser numbers are three characters long")
                    Return returnVal
                End If
            Else
                returnVal.SuccessFlag = False
                returnVal.ErrorMessage = String.Format("Do not leave PurchaserId field blank")
                Return returnVal
            End If
        Else
            returnVal.SuccessFlag = False
            returnVal.ErrorMessage = String.Format("Purchaser numbers cannot contain characters")
            Return returnVal
        End If

        oPurchaser = New Purchaser(ConfigurationManager.AppSettings.Item("WebServiceURL"))
        If oPurchaser.OpenObject(sPurchaser) Then

            If Not oPurchaser.IsEOF Then
                oPurchaser.Name = data.Name.ToUpper()
                oPurchaser.UserId = data.CASYUserId.ToUpper()

                oPurchaser.MemoReceiver = data.RecieveMail

                If oPurchaser.PrepareForUpdate() Then
                    'Nothing
                Else
                    'Prepare for update failed
                End If
            Else
                'Purchaser not found
                bOKtoSave = False
                returnVal.SuccessFlag = False
                returnVal.ErrorMessage = String.Format("Purchaser not found")
                Return returnVal
            End If

            If bOKtoSave Then
                If Not oPurchaser.SaveObject(Session.Item(CasyConstants.SESSION_USER_ID)) Then
                    bOKtoSave = False
                End If
            End If
        Else
            'OpenObject failed
        End If

        'Save ok
        If bOKtoSave Then
            returnVal.SuccessFlag = True
            returnVal.ErrorMessage = String.Format("Purchaser settings saved")
            Return returnVal
        Else
            returnVal.SuccessFlag = False
            returnVal.ErrorMessage = String.Format("Save purchaser failed. Error:" & vErrMsg)
            Return returnVal
        End If
    End Function
End Class