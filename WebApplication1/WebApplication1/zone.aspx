<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zone.aspx.vb" Inherits="WebApplication1.zone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/dropzone.js"></script>
    <title></title>
</head>
<body>
    <form action="/file-upload"
      class="dropzone"
      id="my-awesome-dropzone"><form action="/file-upload" class="dropzone">
  <div class="fallback">
    <input name="file" type="file" multiple />
  </div>
</form>
    </form>
</body>
</html>
