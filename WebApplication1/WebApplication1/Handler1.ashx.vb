Imports System.IO
Imports System.Web
Imports System.Web.Services

Public Class Handler1
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.Write("Hello World! Start")

        context.Response.ContentType = "text/plain"
        Dim flImages As HttpFileCollection = context.Request.Files
        For i As Integer = 0 To flImages.Count - 1
            Dim flfile As HttpPostedFile = flImages(i)
            flfile.SaveAs("C:\Upload_test\test" & "\" & Path.GetFileName(flfile.FileName))
        Next i
        context.Response.Write("Hello World! Start")



        'context.Response.Write("Hello World!")

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class