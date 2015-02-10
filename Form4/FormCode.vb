Imports Microsoft.Office.InfoPath
Imports Microsoft.Office.Interop.Outlook
Imports System
Imports System.Reflection
Imports System.Xml
Imports System.Xml.XPath
Imports Microsoft.VisualBasic



Namespace Form3
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

            Dim oApp As Microsoft.Office.Interop.Outlook.Application = New Microsoft.Office.Interop.Outlook.Application()

            ' Get NameSpace and Logon.
            Dim oNS As Microsoft.Office.Interop.Outlook.Application = oApp.GetNamespace("mapi")
            oNS.Logon("dds", Missing.Value, False, True) ' TODO:

            ' Create a new AppointmentItem.
            Dim oAppt As Microsoft.Office.Interop.Outlook.AppointmentItem = oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem)
            'oAppt.Display(true)  'Modal	

            ' Set some common properties.
            oAppt.Subject = "Created using OOM in C#"
            oAppt.Body = "Hello World"
            oAppt.Location = "Samm E"

            oAppt.Start = Convert.ToDateTime("02/09/2015 4:00:00 PM")
            oAppt.End = Convert.ToDateTime("02/09/2005 5:00:00 PM")

            oAppt.ReminderSet = True
            oAppt.ReminderMinutesBeforeStart = 5
            oAppt.BusyStatus = Microsoft.Office.Interop.Outlook.OlBusyStatus.olBusy  '  olBusy
            oAppt.IsOnlineMeeting = False

            ' Save to Calendar.
            oAppt.Save()

            ' Display.
            'oAppt.Display(true)






        End Sub

        Public Sub CTRL98_Clicked(ByVal sender As Object, ByVal e As ClickedEventArgs)
            ' Write your code here.
        End Sub
    End Class
End Namespace
