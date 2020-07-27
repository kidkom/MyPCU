Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Text
Imports System.IO
Imports System.Security
Imports Microsoft.Win32
Public Class frmGoogleMaps
    Private Const InternetExplorerRootKey As String = "Software\Microsoft\Internet Explorer"
    Private Const BrowserEmulationKey As String = InternetExplorerRootKey & "\Main\FeatureControl\FEATURE_BROWSER_EMULATION"

    Private _webBrowser As WebBrowser
    Dim tmpROWID As String = ""
    Dim tmpAPI_KEY As String = ""
    Dim cLatitude As String = ""
    Dim cLongitude As String = ""
    Dim Col As HtmlElementCollection
    Dim Ele As HtmlElement

    Private Sub frmGoogleMaps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckRegisKey()
        GetBrowserEmulationVersion()
        Map()
    End Sub
    Private Sub CheckRegisKey()
        Dim key As RegistryKey
        key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, True)

        If key Is Nothing Then
            Dim programName As String
            programName = Path.GetFileName(Environment.GetCommandLineArgs()(0))
            My.Computer.Registry.CurrentUser.CreateSubKey(key.ToString)
        End If

    End Sub
    Private Sub GetBrowserEmulationVersion()

        Dim key As RegistryKey
        key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, True)
        Dim ieVer As Integer = GetBrowserVersion()

        Dim programName As String
        Dim value As Object
        programName = Path.GetFileName(Environment.GetCommandLineArgs()(0))
        value = key.GetValue(programName, Nothing)
        If value Is Nothing Then
            My.Computer.Registry.SetValue(key.ToString, programName, ieVer, RegistryValueKind.DWord)

        End If

    End Sub
    Function GetBrowserVersion() As Integer
        Dim strKeyPath As String = "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer"
        Dim ls As String() = New String() {"svcVersion", "svcUpdateVersion", "Version", "W2kVersion"}

        Dim maxVer As Integer = 0
        For i As Integer = 0 To ls.Length - 1
            Dim objVal As Object = Microsoft.Win32.Registry.GetValue(strKeyPath, ls(i), "0")
            Dim strVal As String = System.Convert.ToString(objVal)
            If strVal IsNot Nothing Then
                Dim iPos As Integer = strVal.IndexOf("."c)
                If iPos > 0 Then
                    strVal = strVal.Substring(0, iPos)
                End If

                Dim res As Integer = 0
                If Integer.TryParse(strVal, res) Then
                    maxVer = Math.Max(maxVer, res)
                End If
                ' End if (strVal != null)
            End If
        Next

        If maxVer > 9 Then
            maxVer = maxVer * 1000 + 1
        ElseIf maxVer > 7 Then
            maxVer = maxVer * 1111
        End If

        Return maxVer
    End Function
    Private Sub Map()

        Set_API_KEY()

        If File.Exists(Application.StartupPath & "\GIS\WEB.txt") = True Then
            File.Delete(Application.StartupPath & "\GIS\WEB.txt")
        End If
        If File.Exists(Application.StartupPath & "\GIS\WEB.html") = True Then
            File.Delete(Application.StartupPath & "\GIS\WEB.html")
        End If
        Using sw As New IO.StreamWriter(Application.StartupPath & "\GIS\WEB.txt", False)

            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<meta name='viewport' content='initial-scale=1.0, user-scalable=no' />")
            sw.WriteLine("<meta http-equiv='content-type' content='text/html; charset=UTF-8'/>")
            sw.WriteLine("<meta http-equiv='X-UA-Compatible' content='IE=edge'>")
            sw.WriteLine("<meta http-equiv='X-UA-Compatible' content='IE=11'>")
            sw.WriteLine("<title>Google Maps JavaScript API v3 Example: Markers, Info Window and StreetView</title> ")
            sw.WriteLine("<link href='http://code.google.com/apis/maps/documentation/javascript/examples/default.css' rel='stylesheet' type='text/css' /> ")
            sw.WriteLine("<script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?key=" & tmpAPI_KEY & "&callback=initMap'></script>")
            sw.WriteLine("<script type='text/javascript' src='" & Application.StartupPath.ToString.Replace("\", "/") & "/GIS/js/infobox.js'></script>")
            sw.WriteLine("<script type='text/javascript'>")
            sw.WriteLine("  function initialize() {")
            sw.WriteLine("      var map = new google.maps.Map(document.getElementById('map-canvas'), {")
            sw.WriteLine(" mapTypeId: google.maps.MapTypeId.HYBRID,draggableCursor: 'default',")
            sw.WriteLine("streetViewControl: true")
            sw.WriteLine(" });")
            sw.WriteLine("  var iconBase = '" & Application.StartupPath.ToString.Replace("\", "/") & "/GIS/images/';")
            sw.WriteLine("  var newarkcoords = [")
            sw.WriteLine(" ];")
            sw.WriteLine("var NewarkHighlight;")
            sw.WriteLine(" var mNewarkCoords = new Array;")
            sw.WriteLine("  for (var i = 0; i < newarkcoords.length; i++) {")
            sw.WriteLine(" mNewarkCoords[i] = new google.maps.LatLng(newarkcoords[i].Latitude, newarkcoords[i].Longitude);")
            sw.WriteLine(" }")
            sw.WriteLine(" NewarkHighlight = new google.maps.Polygon({")
            sw.WriteLine(" paths: mNewarkCoords,")
            sw.WriteLine(" strokeColor: '#99cc33',")
            sw.WriteLine("  strokeOpacity: 0.8,")
            sw.WriteLine(" strokeWeight: 2,")
            sw.WriteLine("  fillColor: '#99cc33',")
            sw.WriteLine("  fillOpacity: 0.25")
            sw.WriteLine("   });")
            sw.WriteLine("  NewarkHighlight.setMap(map);")
            sw.WriteLine("  var markers = [")

            If hLatitude <> "" And hLongitude <> "" Then
                sw.WriteLine(" { lat: " & CDbl(hLatitude).ToString("##0.000000") & ", lng: " & CDbl(hLongitude).ToString("##0.000000") & ", name: '" & hHouseName & "', iconss: iconBase + 'red-dot.png' },")
            Else
                If pLatitude <> "" And pLongitude <> "" Then
                    sw.WriteLine(" { lat: " & CDbl(pLatitude).ToString("##0.000000") & ", lng: " & CDbl(pLongitude).ToString("##0.000000") & ", name: '" & vHname & "', iconss: iconBase + 'hospitals.png' },")
                End If
            End If



            sw.WriteLine(" ];")
            sw.WriteLine(" for (index in markers) addMarker(markers[index]);")
            sw.WriteLine(" function addMarker(data) {")
            sw.WriteLine(" var marker = new google.maps.Marker({")
            sw.WriteLine(" position: new google.maps.LatLng(data.lat, data.lng),")
            sw.WriteLine(" map: map,")
            sw.WriteLine(" title: data.name,")
            sw.WriteLine(" animation: google.maps.Animation.DROP,")
            sw.WriteLine(" icon: data.iconss")
            sw.WriteLine(" });")
            sw.WriteLine(" var myOptions = {content: data.name,boxStyle: {border: '0px solid black',textAlign: 'left',fontSize: '10pt',width: '500px' }")
            sw.WriteLine(" ,disableAutoPan: true,pixelOffset: new google.maps.Size(-25, 0),position: new google.maps.LatLng(data.lat, data.lng),closeBoxURL: '',isHidden: false,pane: 'mapPane',enableEventPropagation: true};")
            sw.WriteLine(" var ibLabel = new InfoBox(myOptions);")
            sw.WriteLine(" ibLabel.open(map);")
            sw.WriteLine("  var content = document.createElement('DIV');")
            sw.WriteLine(" var title = document.createElement('DIV');")
            sw.WriteLine(" title.innerHTML = data.name;")
            sw.WriteLine(" content.appendChild(title);")
            sw.WriteLine(" var streetview = document.createElement('DIV');")
            sw.WriteLine(" streetview.style.width = '20px';")
            sw.WriteLine("  streetview.style.height = '10px';")
            'sw.WriteLine("  content.appendChild(streetview);")
            sw.WriteLine(" var infowindow = new google.maps.InfoWindow({")
            sw.WriteLine("  content: content")
            sw.WriteLine(" });")
            sw.WriteLine("  google.maps.event.addListener(marker, 'click', function() {")
            sw.WriteLine("  infowindow.open(map, marker);")
            sw.WriteLine(" });")
            sw.WriteLine("   google.maps.event.addListenerOnce(infowindow, 'domready', function() {")
            sw.WriteLine("  var panorama = new google.maps.StreetViewPanorama(streetview, {")
            sw.WriteLine(" navigationControl: false,")
            sw.WriteLine(" enableCloseButton: false,")
            sw.WriteLine(" addressControl: false,")
            sw.WriteLine(" linksControl: false,")
            sw.WriteLine(" visible: true,")
            sw.WriteLine(" position: marker.getPosition()")
            sw.WriteLine("  });")
            sw.WriteLine(" });")
            sw.WriteLine("  google.maps.event.addListener(map, 'click', function(event){")
            sw.WriteLine(" document.getElementById('searchTextField1').value = event.latLng.lat();")
            sw.WriteLine(" document.getElementById('searchTextField2').value = event.latLng.lng();")
            sw.WriteLine(" });")
            sw.WriteLine(" }")
            sw.WriteLine("  var bounds = new google.maps.LatLngBounds();")
            sw.WriteLine("  for (index in markers) {")
            sw.WriteLine(" var data = markers[index];")
            sw.WriteLine(" bounds.extend(new google.maps.LatLng(data.lat, data.lng));")
            sw.WriteLine(" }")
            sw.WriteLine(" map.fitBounds(bounds);")
            sw.WriteLine(" }")

            sw.WriteLine(" </script> ")
            sw.WriteLine(" </head> ")
            sw.WriteLine(" <body onload='initialize()'> ")
            sw.WriteLine("   <div> ละติจูด : <input id='searchTextField1' type='text' size='20'> ")
            sw.WriteLine("   ลองจิจูด : <input id='searchTextField2' type='text' size='20'> </div>")
            sw.WriteLine("   <div id='map-canvas'></div> ")
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")



        End Using
        File.Copy(Application.StartupPath & "\GIS\WEB.txt", Application.StartupPath & "\GIS\WEB.html")


        Try
            Dim AddrToSearch As New StringBuilder()
            AddrToSearch.Append(Application.StartupPath & "\GIS\WEB.html")
            ' if there is latitude
            WebBrowser1.Navigate(AddrToSearch.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), _
                            "Problem encountered please check internet connection!")
        End Try

    End Sub
    Private Sub Set_API_KEY()
        Dim ds As DataSet
        Dim ds2 As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("API_KEY", "l_api_key", " WHERE STATUS = '0' LIMIT 1")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpAPI_KEY = ds.Tables(0).Rows(0).Item("API_KEY")
            clsbusent.Lc_BusinessEntity.Updatem_table("l_api_key", "STATUS = '1'", " API_KEY = '" & tmpAPI_KEY & "'")
        Else
            clsbusent.Lc_BusinessEntity.UpdateALL("l_api_key", "STATUS = '0'")
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("API_KEY", "l_api_key", " WHERE STATUS = '0' LIMIT 1")
            If ds2.Tables(0).Rows.Count > 0 Then
                tmpAPI_KEY = ds2.Tables(0).Rows(0).Item("API_KEY")
                clsbusent.Lc_BusinessEntity.Updatem_table("l_api_key", "STATUS = '1'", " API_KEY = '" & tmpAPI_KEY & "'")
            End If
        End If

    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim document As System.Windows.Forms.HtmlDocument = WebBrowser1.Document
        Dim D_UPDATE As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)

        If document IsNot Nothing And document.All("searchTextField1") IsNot Nothing Then
            ' MessageBox.Show("You must enter your name before you can navigate to ")
            txtLATITUDE.Text = document.All("searchTextField1").GetAttribute("value")
            txtLONGITUDE.Text = document.All("searchTextField2").GetAttribute("value")
        End If
        If txtLATITUDE.Text = "" Or txtLONGITUDE.Text = "" Then
            MessageBox.Show("กรุณากำหนดพิกัดก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        vLatitude = CDbl(Trim(txtLATITUDE.Text)).ToString("000.000000")
        vLongitude = CDbl(Trim(txtLONGITUDE.Text)).ToString("000.000000")
        If vLatitude <> "" And vLongitude <> "" Then
            clsbusent.Lc_BusinessEntity.Updatem_table("m_home", " LATITUDE = '" & CDbl(Trim(txtLATITUDE.Text)).ToString("000.000000") & "',LONGITUDE = '" & CDbl(Trim(txtLONGITUDE.Text)).ToString("000.000000") & "',D_UPDATE = '" & D_UPDATE & "',USER_REC = '" & vUSERID & "',STATUS_AF = '2',MYDATA = '2'", " HID = '" & hHID & "'")
            Me.Close()
        End If
    End Sub
End Class