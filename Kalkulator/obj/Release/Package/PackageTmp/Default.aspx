<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kalkulator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(function () {
            var handle = $("#custom-handle");
            var num1 = $("#MainContent_prvoStevilo")
            $("#slider").slider({
                create: function () {
                    handle.text($(this).slider("value"));
                },
                slide: function (event, ui) {
                    handle.text(ui.value);
                    num1.val(ui.value);
                },
                max: <%=this.Max%>,
                min: <%=this.Min%>
            });
        });
        $(function () {
            var handle = $("#customHandler");
            var num2 = $("#MainContent_drugoStevilo");
            $("#slider2").slider({
                create: function () {
                    handle.text($(this).slider("value"));

                },
                slide: function (event, ui) {
                    handle.text(ui.value);
                    num2.val(ui.value);
                },
                max:<%=this.Max%>,
                min:<%=this.Min%>

            });
        })
        
        $(function () {
            $(":input").change(function () {
                console.log("Deluje");
                var prvaSprememba = $("#MainContent_prvoStevilo").val();
                var drugaSprememba = $("#MainContent_drugoStevilo").val();
                var handle = $("#custom-handle");
                var handle2 = $("#customHandler");
                $("#slider").slider('value', prvaSprememba);
                handle.text(prvaSprememba);
                $("#slider2").slider('value', drugaSprememba);
                handle2.text(drugaSprememba);
            })
        });

        $(function () {
            $(".opcija").checkboxradio();
        });

        /*
        $(function () {

            function runEffect() {

                var options = { to: "#MainContent_gumb", className: "ui-effects-transfer" };

                $("#MainContent_rezultat").effect("transfer", options, 500, callback);
            };


            function callback() {
                setTimeout(function () {
                    $("#MainContent_rezultat").removeAttr("style").hide().fadeIn();
                }, 1000);
            };


            $("#MainContent_gumb").on("click", function () {
                runEffect();
                return false;
            });
        });

        $(function () {
            $("#MainContent_gumb").button();
        });
        */

    </script>
    <div class="jumbotron">
        <h1>Calculator</h1>
        <p class="lead">You can use this calculator for simple operations such as + - * and /</p>
        <asp:Label Text="First Number" runat="server" />
        <div id="slider" class="drsljajek">
            <div id="custom-handle" class="ui-slider-handle"></div>
        </div>
        
        <input type="number" id="prvoStevilo" class="target" runat="server" value="0"/>
        <br/>
        <asp:Label Text="Second Number" runat="server" />
        <div id="slider2" class="drsljajek">
            <div id="customHandler" class="ui-slider-handle"></div>
        </div>
        <input type="number" id="drugoStevilo" class="target" runat="server" value="0" />
        <div class="widget">
            <h2>Operations</h2>
            
            <fieldset>
                <legend>Choose an operation: </legend>
                <label for="MainContent_radio1">Addition</label>
                <input type="radio" name="radio1" id="radio1" class="opcija" runat="server">
                <label for="MainContent_radio2">Deduction</label>
                <input type="radio" name="radio1" id="radio2" class="opcija" runat="server">
                <label for="MainContent_radio3">Multiplication</label>
                <input type="radio" name="radio1" id="radio3" class="opcija" runat="server">
                <label for="MainContent_radio4">Devision</label>
                <input type="radio" name="radio1" id="radio4" class="opcija" runat="server">
            </fieldset>
            <br />
            <label runat="server" class="opozorilo" id="prisloDoNapake"/> 
        </div>
        
        <div class="widget">
            <asp:button ID="gumb" class="btn btn-danger" runat="server" OnClick="Calculate_click" Text="Calculate" />
            <asp:Button ID="gumbReset" class="btn btn-warning" runat="server" OnClick="Reset_click" Text="Reset" />
        </div>
        <label runat="server" id="rezultat"></label>
    </div>

    

    

</asp:Content>
