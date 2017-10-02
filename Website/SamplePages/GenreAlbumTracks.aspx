<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GenreAlbumTracks.aspx.cs" Inherits="SamplePages_GenreAlbumTracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Genre Albums and Tracks</h1>
    <!-- Inside a repeater you need a minimum of a ItemTemplate
        other templates include HeaderTemplate FooterTemplate,
        AlternatingItemTemplate, SeparatorTemplate
        
        Outer repeater will display the first fields from the DTO Class
        which do not repeat.
        
        The outer repeater gets its data from an ODS
        
        The nested repeater will display the collection of the DTO file
        Nested repeater will get its datasource from the collection of the 
        DTO class(either a POCO or another DTO
        
        This pattern repeats for all levels of your data set -->

    <asp:Repeater ID="GenreAlbumTrackList" runat="server" DataSourceID="GenreAlbumTrackListODS" ItemType="Chinook.Data.DTOs.GenreDto">
        <ItemTemplate>
            <h2>Genre: <%# Eval("genre") %></h2>
            <asp:Repeater ID="GenreAlbums" runat="server" DataSource='<%# Eval("albums") %>' ItemType="Chinook.Data.DTOs.AlbumDto">
                <ItemTemplate>
                    <h4>Album: <%# string.Format("{0} ({1}) Tracks: {2}" , Eval("title"), Eval("releaseYear"), Eval("numberOfTracks")) %></h4><br />
                    <!-- This repeater uses object mapping instead of Eval() -->
                    <asp:Repeater ID="AlbumTracks" runat="server" DataSource="<%# Item.tracks %>" ItemType="Chinook.Data.POCOs.TrackPoco">
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <th>Song</th>
                                    <th>Length</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width:600px">
                                    <%# Item.song %>
                                </td>
                                <td>
                                    <%# Item.length %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <SeparatorTemplate>
                    <hr style="height: 3px;color:#000;" />
                </SeparatorTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="GenreAlbumTrackListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Genre_GenreAlbumTracks" TypeName="ChinookSystem.BLL.GenreController"></asp:ObjectDataSource>

</asp:Content>

