Imports System.IO

Public Class lblTitle
    Private Sub lblTitle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Imports System.IO

    Public Class Form1

        Private filePath As String = "cookiesales.txt"

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            lblTitle.Text = "Cookie Sales"

            If File.Exists(filePath) Then
                LoadFromFile(dgvSales)
            End If
        End Sub

        Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
            dgvSales.Rows.Clear()

            dgvSales.Rows.Add("1", "200", "110", "75")
            dgvSales.Rows.Add("2", "180", "105", "80")
            dgvSales.Rows.Add("3", "190", "115", "70")
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs, dgvSales As DataGridView) Handles btnSave.Click
            Try
                Dim writer As New StreamWriter(filePath, False)

                For Each row As DataGridViewRow In dgvSales.Rows
                    If Not row.IsNewRow Then
                        writer.WriteLine(row.Cells(0).Value & "," &
                                     row.Cells(1).Value & "," &
                                     row.Cells(2).Value & "," &
                                     row.Cells(3).Value)
                    End If
                Next

                writer.Close()

                MessageBox.Show("Changes saved successfully.", "Save",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Unable to save changes: " & ex.Message,
                            "Save Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadFromFile(dgvSales As DataGridView)
            Try
                dgvSales.Rows.Clear()

                Dim lines() As String = File.ReadAllLines(filePath)

                For Each line As String In lines
                    Dim parts() As String = line.Split(","c)
                    Dim value = dgvSales.Rows.Add(parts(0), parts(1), parts(2), parts(3))
                Next

            Catch ex As Exception
                MessageBox.Show("Unable to load data: " & ex.Message,
                            "Load Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Class
