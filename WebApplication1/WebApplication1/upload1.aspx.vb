Public Class upload1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim filePath As String = "uploads/"

        Dim data As String = Request.Form("imageData")

        If Request.Files.Count <= 0 Then
            'Response.Write("No file uploaded")
            Console.Write("No file uploaded")
        Else
            For i As Integer = 0 To Request.Files.Count - 1
                Dim file As HttpPostedFile = Request.Files(i)
                'file.SaveAs(Server.MapPath(filePath + file.FileName))
                Response.Write("File uploaded")
            Next
        End If
    End Sub

End Class