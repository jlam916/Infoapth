Imports Microsoft.Office.InfoPath
Imports System
Imports System.Xml
Imports System.Xml.XPath

Namespace Form1
    Public Class FormCode
        ' Member variables are not supported in browser-enabled forms.
        ' Instead, write and read these values from the FormState
        ' dictionary using code such as the following:
        '
        ' Private Property _memberVariable() As Object
        '     Get
        '         _memberVariable = FormState("_memberVariable")
        '     End Get
        '     Set
        '         FormState("_memberVariable") = value
        '     End Set
        ' End Property

        ' NOTE: The following procedure is required by Microsoft InfoPath.
        ' It can be modified using Microsoft InfoPath.
        Private Sub InternalStartup(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Startup
            AddHandler EventManager.XmlEvents("/my:myFields/my:NoDayRequest").Changed, AddressOf DayRequest_Changed
            AddHandler EventManager.XmlEvents("/my:myFields/my:FromTime").Changed, AddressOf FromTime_Changed
            AddHandler EventManager.XmlEvents("/my:myFields/my:Manager/pc:Person/pc:DisplayName").Validating, AddressOf Manager_Person_DisplayName_Validating
            AddHandler DirectCast(EventManager.ControlEvents("CTRL55_5"), ButtonEvent).Clicked, AddressOf CTRL55_5_Clicked
            AddHandler DirectCast(EventManager.ControlEvents("CTRL70_5"), ButtonEvent).Clicked, AddressOf CTRL70_5_Clicked
            AddHandler DirectCast(EventManager.ControlEvents("CTRL114"), ButtonEvent).Clicked, AddressOf CTRL114_Clicked
        End Sub

        Public Sub DayRequest_Changed(ByVal sender As Object, ByVal e As XmlEventArgs)
            ' Write your code here to change the main data source.
        End Sub

        Public Sub FromTime_Changed(ByVal sender As Object, ByVal e As XmlEventArgs)
            ' Write your code here to change the main data source.
        End Sub

        Public Sub Manager_Person_DisplayName_Validating(ByVal sender As Object, ByVal e As XmlValidatingEventArgs)
            ' Write your code here.
        End Sub

        Public Sub CTRL55_5_Clicked(ByVal sender As Object, ByVal e As ClickedEventArgs)
            ' Write your code here.
        End Sub

        Public Sub CTRL70_5_Clicked(ByVal sender As Object, ByVal e As ClickedEventArgs)
            ' Write your code here.
        End Sub

        Public Sub CTRL114_Clicked(ByVal sender As Object, ByVal e As ClickedEventArgs)
            ' Write your code here.
        End Sub
    End Class
End Namespace
