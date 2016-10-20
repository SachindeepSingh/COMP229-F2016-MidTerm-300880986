<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP229_F2016_MidTerm_300880986.TodoList" %>
<%--Name: Sachindeep Singh--%>
<%--Student ID: 300880986 --%>
<%-- Date Modofied: 19-oct-2016 --%>
<%-- file:Site.master --%>
<%-- version 1.0.0.1 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">

                <h1>To-do List</h1>
                <a href="TodoDetails.aspx" class="btn btn-success btn-sm">
                    <i class="fa fa-plus"></i> Add Todo
                </a>
                             <asp:GridView ID="TodoListGridView" runat="server"  AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover" DataKeyNames="TodoID"
         OnRowDeleting="TodoGridView_RowDeleting">

                    <Columns>
                      
                        <asp:BoundField DataField="TodoDescription" HeaderText="Todo Description" Visible="true" />
                        <asp:BoundField DataField="TodoNotes" HeaderText="Todo Notes" Visible="true" />
                        <asp:BoundField DataField="Completed" HeaderText="Completed" Visible="true" SortExpression="Completed" />

                        
            <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                NavigateUrl="TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm"
                runat="server" DataNavigateUrlFields="TodoID"
                DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />

                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                           </Columns>
                </asp:GridView>

                    </div>
        </div>

    </div>

                        
</asp:Content>
