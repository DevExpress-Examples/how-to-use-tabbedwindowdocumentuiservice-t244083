﻿Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Mvvm.DataAnnotations
Imports System
Imports System.Linq

Namespace DXSample.ViewModel
    <POCOViewModel> _
    Public Class MainViewModel
        Protected ReadOnly Property DocumentManagerService() As IDocumentManagerService
            Get
                Return Me.GetService(Of IDocumentManagerService)()
            End Get
        End Property

        Public Sub CreateDocument()
            Dim doc As IDocument = DocumentManagerService.CreateDocument("TabView", ViewModelSource.Create(Function() New TabViewModel()))
            doc.Id = String.Format("DocId_{0}", DocumentManagerService.Documents.Count())
            doc.Title = String.Format("Item {0}", DocumentManagerService.Documents.Count())
            doc.Show()
        End Sub

        Public Sub CloseDocument()
            DocumentManagerService.ActiveDocument.Close()
        End Sub
    End Class
End Namespace
