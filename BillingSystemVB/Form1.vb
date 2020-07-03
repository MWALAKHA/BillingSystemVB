Public Class Form1
    'calculator variable declaration
    Dim firstvalue As Decimal
    Dim secondvalue As Decimal
    Dim answer As Decimal
    Dim operation As String

    'online system variables
    Dim mcsubtotal As Double
    Dim mctotal As Double
    Const ccarpets_price = 2
    Const cfabric_price = 3
    Const cblinds_price = 4
    Const cdelivery_price = 40
    Const cmileage_price = 1
    Const mctax_rate = 0.2
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "1"
        Else
            txtinput.Text = txtinput.Text + " 1 "
        End If
    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btncalculate_Click(sender As Object, e As EventArgs) Handles btncalculate.Click
        'calculate user input
        Dim cprice As Double
        Dim itemprice As Double
        Dim itemcost As Double
        Dim itemlengthc As Double
        Dim itemlengthf As Double
        Dim itemlengthb As Double
        Dim itemdelivery As Double
        Dim itemmileage As Double
        Dim amountcostc As Double
        Dim amountcostf As Double
        Dim amountcostb As Double
        Dim amountcostt As Double
        Dim idelivery As Double
        Dim totalmileage As Double
        Dim ctax As Double

        'checkbox initialization
        If chkcarpets.Checked = True Then
            cprice = ccarpets_price
        End If
        If chkfabric.Checked = True Then
            itemprice = cfabric_price
        End If
        If chkblinds.Checked = True Then
            itemcost = cblinds_price
        End If

        'textbox values pick
        If IsNumeric(txtlengthc.Text) Then
            itemlengthc = Val(txtlengthc.Text)
            amountcostf = cprice * itemlengthc
            amountcostc = amountcostf + amountcostb + amountcostt
        End If
        If IsNumeric(txtlengthf.Text) Then
            itemlengthf = Val(txtlengthf.Text)
            amountcostb = itemprice * itemlengthf
            amountcostc = amountcostf + amountcostb + amountcostt
        End If
        If IsNumeric(txtlengthb.Text) Then
            itemlengthb = Val(txtlengthb.Text)
            itemcost = itemcost * itemlengthb

            amountcostc = amountcostf + amountcostb + amountcostt
        End If

        If chkcarpets.Checked = True Then
        ElseIf chkfabric.Checked = True Then
        ElseIf chkblinds.Checked = True Then
        Else : MsgBox("Select an item", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "opps")
        End If

        If IsNumeric(txtdelivery.Text) Then
            itemdelivery = Val(txtdelivery.Text)
            idelivery = cdelivery_price * itemdelivery
        Else
            MsgBox("Please Enter Required Hours of Labour", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Opps")
            txtdelivery.Focus()
        End If

        If chktax.Checked = True Then
            ctax = cfindtax(amountcostc) ' call a function procedure
        End If

        'calculate keyboard input from textbox
        mcsubtotal = amountcostc + idelivery + totalmileage
        mctotal = mcsubtotal + ctax
        lblitemamount.Text = FormatCurrency$(amountcostc + ctax)
        lbltotallabour.Text = FormatCurrency$(idelivery)
        lbltotaltravel.Text = FormatCurrency$(totalmileage)
        lblsubtotal.Text = FormatCurrency$(mcsubtotal)
        lbltax.Text = FormatCurrency$(ctax)
        lbltotal.Text = FormatCurrency$(mctotal)

        'For my receipt
        Dim hours As String
        Dim miles As String
        Dim carpets As Double
        Dim fabric As Double
        Dim blinds As Double
        Dim name(10) As String
        Dim x As Integer
        Dim itemnumber(10) As String

        'Receipt calculation
        txtreceipt.AppendText(" " + vbNewLine)
        name(1) = txtlengthc.Text
        name(2) = txtlengthf.Text
        name(3) = txtlengthb.Text
        name(4) = txtdelivery.Text
        name(5) = txtmileage.Text
        '------------------------------------
        itemnumber(1) = chkcarpets.Text
        itemnumber(2) = chkfabric.Text
        itemnumber(3) = chkblinds.Text
        itemnumber(4) = txtdelivery.Text
        itemnumber(5) = txtmileage.Text
        '-------------------------------------
        carpets = Val(txtlengthc.Text) * cprice
        fabric = Val(txtlengthf.Text) * itemprice
        blinds = Val(txtlengthb.Text) * itemcost
        hours = Val(txtdelivery.Text) * cdelivery_price
        miles = Val(txtmileage.Text) * cmileage_price
        '-------------------------------------------

        'Receipt print
        txtreceipt.AppendText(" " + vbNewLine)
        txtreceipt.AppendText("                ONLINE SHOPPING SYSTEM                    " + vbNewLine)
        txtreceipt.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = =  " + vbNewLine)
        txtreceipt.AppendText("Welcome to Gibson's Plumbing :Offering proffessional plumbing services." + vbNewLine)
        txtreceipt.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = =" + vbNewLine)
        txtreceipt.AppendText(" " + vbNewLine)

        'Loop
        For x = 1 To 5
            txtreceipt.AppendText(vbTab + itemnumber(x) + vbTab + name(x) + vbTab + vbNewLine)

        Next x

        'print
        txtreceipt.AppendText(" " + vbNewLine)
        txtreceipt.AppendText(vbTab & "SubTotal : " + lblsubtotal.Text + vbNewLine)
        txtreceipt.AppendText(vbTab & "Tax : " + lbltax.Text + vbNewLine)
        txtreceipt.AppendText(vbTab & "Total Amount: " + lbltotal.Text + vbNewLine)
        txtreceipt.AppendText("" & vbNewLine)
        txtreceipt.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = =  " + vbNewLine)
        'txtreceipt.AppendText(txtnote.Text + vbNewLine)
        txtreceipt.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = =  " + vbNewLine)
        txtreceipt.AppendText("  " + vbNewLine)
        txtreceipt.AppendText(vbTab & Today & vbTab & TimeOfDay + vbNewLine)
        txtreceipt.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = " + vbNewLine)
        txtreceipt.AppendText("                 THANK'S FOR SHOPPING ONLINE              " + vbNewLine)
        txtreceipt.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = " + vbNewLine)

    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        With txtlengthc
            .Text = ""
            .Focus()
        End With

        txtlengthc.Text = ""
        txtlengthb.Text = ""
        txtdelivery.Text = ""
        txtmileage.Text = ""
        txtreceipt.Text = ""
        txtlengthf.Text = ""
        lblitemamount.Text = ""
        lbltotallabour.Text = ""
        lbltotaltravel.Text = ""
        lblsubtotal.Text = ""
        lbltax.Text = ""
        lbltotal.Text = ""

        chkblinds.Checked = False
        chkcarpets.Checked = False
        chkfabric.Checked = False
        chktax.Checked = False

    End Sub
    'Function to calcualate tax
    Private Function cfindtax(ByVal bitemamount As Double) As Double
        cfindtax = bitemamount * mctax_rate
    End Function

    Private Sub txtlengthc_TextChanged(sender As Object, e As EventArgs) Handles txtlengthc.TextChanged

    End Sub

    Private Sub txtlengthc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtlengthc.KeyPress
        'validate the textbox to only allow numerics
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
            MsgBox("Please enter valid number")
        End If
    End Sub

    Private Sub txtlengthf_TextChanged(sender As Object, e As EventArgs) Handles txtlengthf.TextChanged

    End Sub

    Private Sub txtlengthf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtlengthf.KeyPress
        'validate the textbox to only allow numerics
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
            MsgBox("Please enter valid number")
        End If
    End Sub

    Private Sub txtlengthb_TextChanged(sender As Object, e As EventArgs) Handles txtlengthb.TextChanged

    End Sub

    Private Sub txtlengthb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtlengthb.KeyPress
        'validate the textbox to only allow numerics
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
            MsgBox("Please enter valid number")
        End If
    End Sub
    'calculator buttons initialization
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        firstvalue = txtinput.Text
        txtdisplay.Text = firstvalue & " *"
        txtinput.Text = " "
        operation = " * "
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "2"
        Else
            txtinput.Text = txtinput.Text + " 2 "
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "3"
        Else
            txtinput.Text = txtinput.Text + " 3 "
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "4"
        Else
            txtinput.Text = txtinput.Text + " 4 "
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "5"
        Else
            txtinput.Text = txtinput.Text + " 5 "
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "6"
        Else
            txtinput.Text = txtinput.Text + " 6 "
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "7"
        Else
            txtinput.Text = txtinput.Text + " 7 "
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "8"
        Else
            txtinput.Text = txtinput.Text + " 8 "
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "9"
        Else
            txtinput.Text = txtinput.Text + " 9 "
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If txtinput.Text = "0" Then
            txtinput.Text = "0"
        Else
            txtinput.Text = txtinput.Text + " 0 "
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        firstvalue = txtinput.Text
        txtdisplay.Text = firstvalue & " +"
        txtinput.Text = " "
        operation = " + "
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If Not (txtinput.Text.Contains(".")) Then
            txtinput.Text += " ."
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        firstvalue = txtinput.Text
        txtdisplay.Text = firstvalue & " -"
        txtinput.Text = " "
        operation = " - "
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        firstvalue = txtinput.Text
        txtdisplay.Text = firstvalue & " /"
        txtinput.Text = " "
        operation = " / "
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        secondvalue = txtinput.Text
        If operation = " +" Then
            answer = firstvalue + secondvalue
            txtinput.Text = answer
            txtdisplay.Text = ""
        ElseIf operation = "-" Then
            answer = firstvalue - secondvalue
            txtinput.Text = answer
            txtdisplay.Text = ""
        ElseIf operation = "/" Then
            answer = firstvalue / secondvalue
            txtinput.Text = answer
            txtdisplay.Text = ""
        ElseIf operation = " *" Then
            answer = firstvalue * secondvalue
            txtinput.Text = answer
            txtdisplay.Text = ""
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        txtinput.Text = ""
        txtdisplay.Text = ""
        txtinput.Text = "0"
    End Sub
End Class
