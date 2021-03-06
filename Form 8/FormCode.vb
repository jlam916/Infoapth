Imports Microsoft.Office.InfoPath
Imports Microsoft.Office.Interop.Outlook
Imports Microsoft.VisualBasic
Imports System
Imports System.Xml
Imports System.Xml.XPath
Imports System.Windows.Forms
Imports mshtml



Namespace Form5
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
            AddHandler DirectCast(EventManager.ControlEvents("CTRL114"), ButtonEvent).Clicked, AddressOf CTRL114_Clicked
            AddHandler DirectCast(EventManager.ControlEvents("CTRL98"), ButtonEvent).Clicked, AddressOf CTRL98_Clicked
        End Sub

        Public Sub CTRL114_Clicked(ByVal sender As Object, ByVal e As ClickedEventArgs)


            Dim olApp As Microsoft.Office.Interop.Outlook.Application
            Dim olApt As AppointmentItem

            olApp = CreateObject("Outlook.Application")
            olApt = olApp.CreateItem(OlItemType.olAppointmentItem)

            Dim dateString As String = MainDataSource.CreateNavigator().SelectSingleNode( _
            "/my:myFields/my:FromDate", NamespaceManager).Value
            Dim dateNode As Date = Format(Date.ParseExact(dateString, "yyyy-mm-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo), "mm,dd,yyyy")

            Dim EndDateNodeString As String = MainDataSource.CreateNavigator().SelectSingleNode( _
            "/my:myFields/my:ToDate", NamespaceManager).Value
            Dim EndDateNode As Date = Format(Date.ParseExact(EndDateNodeString, "yyyy-mm-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo), "mm,dd,yyyy")

            Dim TimeNode As String = MainDataSource.CreateNavigator().SelectSingleNode( _
            "/my:myFields/my:FromTime", NamespaceManager).Value

            Dim EndTimeNode As String = MainDataSource.CreateNavigator().SelectSingleNode( _
            "/my:myFields/my:ToTime", NamespaceManager).Value


            
            With olApt
                .Subject = "AbsenceRequest"
                .Start = dateString
                .End = EndDateNodeString
                .Body = "This is an Absence Test"
                .AllDayEvent = True
                .AllDayEvent = False
                .ReminderSet = True
                .ReminderMinutesBeforeStart = 5
                .Save()
            End With

            MsgBox("Your Approval Decision Has Been Successfully Sent")
            Me.Application.ActiveWindow.Close()


        End Sub

        Public Sub CTRL98_Clicked(ByVal sender As Object, ByVal e As ClickedEventArgs)
            'Type Code Here
        End Sub
    End Class
End Namespace
