<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Inicio.Master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Operacion>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Se ha producido un error al procesar su solicitud!!
    </h2>
    <p>
        Detalles:<br />
        <%: Html.DisplayFor(model => model.Message) %>
    </p>
     <%: Html.ActionLink("Regresar",Model.Action,Model.Controller) %>
</asp:Content>
