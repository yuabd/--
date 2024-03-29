﻿<%@ CodePage=65001 Language="VBScript"%>
<%
Option Explicit
Response.Buffer = True
%>
<!--#include file="config.asp"-->
<!--#include file="util.asp"-->
<!--#include file="io.asp"-->
<!--#include file="commands.asp"-->
<!--#include file="class_upload.asp"-->
<%

' Check if this uploader has been enabled.
If ( ConfigIsEnabled = False ) Then
	SendUploadResults "1", "", "", "This file uploader is disabled. Please check the ""editor/filemanager/connectors/asp/config.asp"" file"
End If

	Dim sCommand, sResourceType, sCurrentFolder

	sCommand = "QuickUpload"

	sResourceType = Request.QueryString("Type")
	If ( sResourceType = "" ) Then sResourceType = "File"

	sCurrentFolder = GetCurrentFolder()

	' Is Upload enabled?
	if ( Not IsAllowedCommand( sCommand ) ) then
		SendUploadResults "1", "", "", "The """ & sCommand & """ command isn't allowed"
	end if

	' Check if it is an allowed resource type.
	if ( Not IsAllowedType( sResourceType ) ) Then
		SendUploadResults "1", "", "", "The " & sResourceType & " resource type isn't allowed"
	end if

	FileUpload sResourceType, sCurrentFolder, sCommand

%>
