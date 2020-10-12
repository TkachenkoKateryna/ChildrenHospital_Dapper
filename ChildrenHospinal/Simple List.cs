using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using FastReport;
using FastReport.Data;
using FastReport.Dialog;
using FastReport.Barcode;
using FastReport.Table;
using FastReport.Utils;

namespace FastReport
{
  public class SimpleList : Report
  {
    public FastReport.Report Report;
    public FastReport.Engine.ReportEngine Engine;
    public FastReport.ChildBand Child1;
    public FastReport.ChildBand Child2;
    public FastReport.DataBand Data1;
    public FastReport.ReportPage Page1;
    public FastReport.PageFooterBand PageFooter1;
    public FastReport.ReportTitleBand ReportTitle1;
    public FastReport.TextObject Text1;
    public FastReport.TextObject Text10;
    public FastReport.TextObject Text14;
    public FastReport.TextObject Text16;
    public FastReport.TextObject Text2;
    public FastReport.TextObject Text3;
    public FastReport.TextObject Text4;
    public FastReport.TextObject Text5;
    public FastReport.TextObject Text6;
    public FastReport.TextObject Text7;
    public FastReport.TextObject Text8;
    protected override object CalcExpression(string expression, Variant Value)
    {
      return null;
    }

    private SByte Abs(SByte value)
    {
      return System.Math.Abs(value);
    }

    private Int16 Abs(Int16 value)
    {
      return System.Math.Abs(value);
    }

    private Int32 Abs(Int32 value)
    {
      return System.Math.Abs(value);
    }

    private Int64 Abs(Int64 value)
    {
      return System.Math.Abs(value);
    }

    private Single Abs(Single value)
    {
      return System.Math.Abs(value);
    }

    private Double Abs(Double value)
    {
      return System.Math.Abs(value);
    }

    private Decimal Abs(Decimal value)
    {
      return System.Math.Abs(value);
    }

    private Double Acos(Double d)
    {
      return System.Math.Acos(d);
    }

    private Double Asin(Double d)
    {
      return System.Math.Asin(d);
    }

    private Double Atan(Double d)
    {
      return System.Math.Atan(d);
    }

    private Double Ceiling(Double a)
    {
      return System.Math.Ceiling(a);
    }

    private Decimal Ceiling(Decimal d)
    {
      return System.Math.Ceiling(d);
    }

    private Double Cos(Double d)
    {
      return System.Math.Cos(d);
    }

    private Double Exp(Double d)
    {
      return System.Math.Exp(d);
    }

    private Double Floor(Double d)
    {
      return System.Math.Floor(d);
    }

    private Decimal Floor(Decimal d)
    {
      return System.Math.Floor(d);
    }

    private Double Log(Double d)
    {
      return System.Math.Log(d);
    }

    private Int32 Maximum(Int32 val1, Int32 val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Int64 Maximum(Int64 val1, Int64 val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Single Maximum(Single val1, Single val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Double Maximum(Double val1, Double val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Decimal Maximum(Decimal val1, Decimal val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Int32 Minimum(Int32 val1, Int32 val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Int64 Minimum(Int64 val1, Int64 val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Single Minimum(Single val1, Single val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Double Minimum(Double val1, Double val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Decimal Minimum(Decimal val1, Decimal val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Double Round(Double a)
    {
      return System.Math.Round(a);
    }

    private Decimal Round(Decimal d)
    {
      return System.Math.Round(d);
    }

    private Double Round(Double value, Int32 digits)
    {
      return System.Math.Round(value, digits);
    }

    private Decimal Round(Decimal d, Int32 decimals)
    {
      return System.Math.Round(d, decimals);
    }

    private Double Sin(Double a)
    {
      return System.Math.Sin(a);
    }

    private Double Sqrt(Double d)
    {
      return System.Math.Sqrt(d);
    }

    private Double Tan(Double a)
    {
      return System.Math.Tan(a);
    }

    private Double Truncate(Double d)
    {
      return System.Math.Truncate(d);
    }

    private Decimal Truncate(Decimal d)
    {
      return System.Math.Truncate(d);
    }

    private Int32 Asc(Char c)
    {
      return FastReport.Functions.StdFunctions.Asc(c);
    }

    private Char Chr(Int32 i)
    {
      return FastReport.Functions.StdFunctions.Chr(i);
    }

    private String Insert(String s, Int32 startIndex, String value)
    {
      return FastReport.Functions.StdFunctions.Insert(s, startIndex, value);
    }

    private Int32 Length(String s)
    {
      return FastReport.Functions.StdFunctions.Length(s);
    }

    private String LowerCase(String s)
    {
      return FastReport.Functions.StdFunctions.LowerCase(s);
    }

    private String PadLeft(String s, Int32 totalWidth)
    {
      return FastReport.Functions.StdFunctions.PadLeft(s, totalWidth);
    }

    private String PadLeft(String s, Int32 totalWidth, Char paddingChar)
    {
      return FastReport.Functions.StdFunctions.PadLeft(s, totalWidth, paddingChar);
    }

    private String PadRight(String s, Int32 totalWidth)
    {
      return FastReport.Functions.StdFunctions.PadRight(s, totalWidth);
    }

    private String PadRight(String s, Int32 totalWidth, Char paddingChar)
    {
      return FastReport.Functions.StdFunctions.PadRight(s, totalWidth, paddingChar);
    }

    private String Remove(String s, Int32 startIndex)
    {
      return FastReport.Functions.StdFunctions.Remove(s, startIndex);
    }

    private String Remove(String s, Int32 startIndex, Int32 count)
    {
      return FastReport.Functions.StdFunctions.Remove(s, startIndex, count);
    }

    private String Replace(String s, String oldValue, String newValue)
    {
      return FastReport.Functions.StdFunctions.Replace(s, oldValue, newValue);
    }

    private String Substring(String s, Int32 startIndex)
    {
      return FastReport.Functions.StdFunctions.Substring(s, startIndex);
    }

    private String Substring(String s, Int32 startIndex, Int32 length)
    {
      return FastReport.Functions.StdFunctions.Substring(s, startIndex, length);
    }

    private String TitleCase(String s)
    {
      return FastReport.Functions.StdFunctions.TitleCase(s);
    }

    private String Trim(String s)
    {
      return FastReport.Functions.StdFunctions.Trim(s);
    }

    private String UpperCase(String s)
    {
      return FastReport.Functions.StdFunctions.UpperCase(s);
    }

    private DateTime AddDays(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddDays(date, value);
    }

    private DateTime AddHours(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddHours(date, value);
    }

    private DateTime AddMinutes(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddMinutes(date, value);
    }

    private DateTime AddMonths(DateTime date, Int32 value)
    {
      return FastReport.Functions.StdFunctions.AddMonths(date, value);
    }

    private DateTime AddSeconds(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddSeconds(date, value);
    }

    private DateTime AddYears(DateTime date, Int32 value)
    {
      return FastReport.Functions.StdFunctions.AddYears(date, value);
    }

    private TimeSpan DateDiff(DateTime date1, DateTime date2)
    {
      return FastReport.Functions.StdFunctions.DateDiff(date1, date2);
    }

    private DateTime DateSerial(Int32 year, Int32 month, Int32 day)
    {
      return FastReport.Functions.StdFunctions.DateSerial(year, month, day);
    }

    private Int32 Day(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Day(date);
    }

    private String DayOfWeek(DateTime date)
    {
      return FastReport.Functions.StdFunctions.DayOfWeek(date);
    }

    private Int32 DayOfYear(DateTime date)
    {
      return FastReport.Functions.StdFunctions.DayOfYear(date);
    }

    private Int32 DaysInMonth(Int32 year, Int32 month)
    {
      return FastReport.Functions.StdFunctions.DaysInMonth(year, month);
    }

    private Int32 Hour(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Hour(date);
    }

    private Int32 Minute(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Minute(date);
    }

    private Int32 Month(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Month(date);
    }

    private String MonthName(Int32 month)
    {
      return FastReport.Functions.StdFunctions.MonthName(month);
    }

    private Int32 Second(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Second(date);
    }

    private Int32 WeekOfYear(DateTime date)
    {
      return FastReport.Functions.StdFunctions.WeekOfYear(date);
    }

    private Int32 Year(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Year(date);
    }

    private String Format(String format, params Object[] args)
    {
      return FastReport.Functions.StdFunctions.Format(format, args);
    }

    private String FormatCurrency(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatCurrency(value);
    }

    private String FormatCurrency(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatCurrency(value, decimalDigits);
    }

    private String FormatDateTime(DateTime value)
    {
      return FastReport.Functions.StdFunctions.FormatDateTime(value);
    }

    private String FormatDateTime(DateTime value, String format)
    {
      return FastReport.Functions.StdFunctions.FormatDateTime(value, format);
    }

    private String FormatNumber(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatNumber(value);
    }

    private String FormatNumber(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatNumber(value, decimalDigits);
    }

    private String FormatPercent(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatPercent(value);
    }

    private String FormatPercent(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatPercent(value, decimalDigits);
    }

    private Boolean ToBoolean(Object value)
    {
      return System.Convert.ToBoolean(value);
    }

    private Byte ToByte(Object value)
    {
      return System.Convert.ToByte(value);
    }

    private Char ToChar(Object value)
    {
      return System.Convert.ToChar(value);
    }

    private DateTime ToDateTime(Object value)
    {
      return System.Convert.ToDateTime(value);
    }

    private Decimal ToDecimal(Object value)
    {
      return System.Convert.ToDecimal(value);
    }

    private Double ToDouble(Object value)
    {
      return System.Convert.ToDouble(value);
    }

    private Int32 ToInt32(Object value)
    {
      return System.Convert.ToInt32(value);
    }

    private String ToRoman(Object value)
    {
      return FastReport.Functions.StdFunctions.ToRoman(value);
    }

    private Single ToSingle(Object value)
    {
      return System.Convert.ToSingle(value);
    }

    private String ToString(Object value)
    {
      return System.Convert.ToString(value);
    }

    private String ToWords(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWords(value);
    }

    private String ToWords(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWords(value, currencyName);
    }

    private String ToWords(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWords(value, one, many);
    }

    private String ToWordsEnGb(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value);
    }

    private String ToWordsEnGb(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value, currencyName);
    }

    private String ToWordsEnGb(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value, one, many);
    }

    private String ToWordsEs(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value);
    }

    private String ToWordsEs(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value, currencyName);
    }

    private String ToWordsEs(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value, one, many);
    }

    private String ToWordsRu(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value);
    }

    private String ToWordsRu(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value, currencyName);
    }

    private String ToWordsRu(Object value, Boolean male, String one, String two, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value, male, one, two, many);
    }

    private Object Choose(Double index, params Object[] choice)
    {
      return FastReport.Functions.StdFunctions.Choose(index, choice);
    }

    private Object IIf(Boolean expression, Object truePart, Object falsePart)
    {
      return FastReport.Functions.StdFunctions.IIf(expression, truePart, falsePart);
    }

    private Object Switch(params Object[] expressions)
    {
      return FastReport.Functions.StdFunctions.Switch(expressions);
    }

    private Boolean IsNull(String name)
    {
      return FastReport.Functions.StdFunctions.IsNull(Report, name);
    }

    private void InitializeComponent()
    {
      string reportString = 
        "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Report ScriptLanguage=\"CSharp\" TextQua" +
        "lity=\"Regular\" ReportInfo.Name=\"Simple List\" ReportInfo.Author=\"Fast Reports Inc" +
        "\" ReportInfo.Description=\"Demonstrates a simple list report. To create it:&#13;&" +
        "#10;- go to &quot;Data&quot; menu and select &quot;Choose Report Data...&quot; i" +
        "tem to select a datasource;&#13;&#10;- go to &quot;Report|Configure Bands...&quo" +
        "t; menu to create the band structure;&#13;&#10;- return to the report page, doub" +
        "leclick the data band to show its editor;&#13;&#10;- choose the datasource;&#13;" +
        "&#10;- drag data from the Data Dictionary window to the band.\" ReportInfo.Create" +
        "d=\"01/17/2008 03:05:57\" ReportInfo.Modified=\"11/29/2019 17:31:44\" ReportInfo.Cre" +
        "atorVersion=\"2019.4.15.0\">\r\n  <Dictionary>\r\n    <MsSqlDataConnection Name=\"Conne" +
        "ction\" ConnectionString=\"rijcmlqM7gJFg/iaLrqMhRfGy5lGii1ec+FTBlaXNgpHF5iF7LK8YxI" +
        "Htclf79dSd/cyQdT9gBShyftKBIbFAw8DX0w4XopUgr4Ft/i48ae3pmydqFSs6qHFC1XSp2l4pAQPEyU" +
        "Oyi0wq3iMIsmWlbvX9iuiNfoAsUDHrOcodbjjPNezVtCThsE7pN8BM5YMCirO4IB8H6oHBycty4zDOA+" +
        "nPlhYpHMcWu0jOQWgJtBywCAX58=\">\r\n      <TableDataSource Name=\"Patients\" DataType=";
      reportString += "\"System.Int32\" Enabled=\"true\" TableName=\"Patients\">\r\n        <Column Name=\"Patie" +
        "ntId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"Full name\" DataType=\"Syst" +
        "em.String\"/>\r\n        <Column Name=\"DOB\" DataType=\"System.DateTime\"/>\r\n        <" +
        "Column Name=\"Address\" DataType=\"System.String\"/>\r\n        <Column Name=\"Institut" +
        "ionId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"DoctorId\" DataType=\"Syst" +
        "em.Int32\"/>\r\n      </TableDataSource>\r\n      <TableDataSource Name=\"DoctorSpecia" +
        "lity\" DataType=\"System.Int32\" Enabled=\"true\" TableName=\"DoctorSpeciality\">\r\n    " +
        "    <Column Name=\"SpecialityId\" DataType=\"System.Int32\"/>\r\n        <Column Name=" +
        "\"DoctorId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"DoctorSpecialityId\" " +
        "DataType=\"System.Int32\"/>\r\n        <Column Name=\"Practice\" DataType=\"System.Int3" +
        "2\"/>\r\n      </TableDataSource>\r\n      <TableDataSource Name=\"VaccinationPlan\" Da" +
        "taType=\"System.Int32\" Enabled=\"true\" TableName=\"VaccinationPlan\">\r\n        <Colu";
      reportString += "mn Name=\"VaccinationId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"Name\" D" +
        "ataType=\"System.String\"/>\r\n        <Column Name=\"Age\" DataType=\"System.String\"/>" +
        "\r\n      </TableDataSource>\r\n      <TableDataSource Name=\"VaccinationProcedure\" D" +
        "ataType=\"System.Int32\" Enabled=\"true\" TableName=\"VaccinationProcedure\">\r\n       " +
        " <Column Name=\"VaccinationProcedureId\" DataType=\"System.Int32\"/>\r\n        <Colum" +
        "n Name=\"PatientId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"VaccinationI" +
        "d\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"Date\" DataType=\"System.DateT" +
        "ime\"/>\r\n        <Column Name=\"Done\" DataType=\"System.Boolean\" BindableControl=\"C" +
        "heckBox\"/>\r\n        <Column Name=\"Information\" DataType=\"System.String\"/>\r\n     " +
        " </TableDataSource>\r\n      <TableDataSource Name=\"DiseaseVaccination\" DataType=\"" +
        "System.Int32\" Enabled=\"true\" TableName=\"DiseaseVaccination\">\r\n        <Column Na" +
        "me=\"VaccinationId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"DiseaseId\" D";
      reportString += "ataType=\"System.Int32\"/>\r\n        <Column Name=\"DiseaseVaccinationId\" DataType=\"" +
        "System.Int32\"/>\r\n      </TableDataSource>\r\n      <TableDataSource Name=\"Speciali" +
        "ties\" DataType=\"System.Int32\" Enabled=\"true\" TableName=\"Specialities\">\r\n        " +
        "<Column Name=\"SpecialityId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"Nam" +
        "e\" DataType=\"System.String\"/>\r\n        <Column Name=\"Information\" DataType=\"Syst" +
        "em.String\"/>\r\n      </TableDataSource>\r\n      <TableDataSource Name=\"Diseases\" D" +
        "ataType=\"System.Int32\" Enabled=\"true\" TableName=\"Diseases\">\r\n        <Column Nam" +
        "e=\"DiseaseId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"Name\" DataType=\"S" +
        "ystem.String\"/>\r\n        <Column Name=\"Code\" DataType=\"System.String\"/>\r\n       " +
        " <Column Name=\"Information\" DataType=\"System.String\"/>\r\n        <Column Name=\"In" +
        "fectivity\" DataType=\"System.Boolean\" BindableControl=\"CheckBox\"/>\r\n        <Colu" +
        "mn Name=\"Deleted\" DataType=\"System.Boolean\" BindableControl=\"CheckBox\"/>\r\n      ";
      reportString += "</TableDataSource>\r\n      <TableDataSource Name=\"Institutions\" DataType=\"System." +
        "Int32\" Enabled=\"true\" TableName=\"Institutions\">\r\n        <Column Name=\"Instituti" +
        "onId\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"Name\" DataType=\"System.St" +
        "ring\"/>\r\n        <Column Name=\"Address\" DataType=\"System.String\"/>\r\n        <Col" +
        "umn Name=\"Phone number\" DataType=\"System.String\"/>\r\n        <Column Name=\"Direct" +
        "or\" DataType=\"System.String\"/>\r\n        <Column Name=\"Deleted\" DataType=\"System." +
        "Boolean\" BindableControl=\"CheckBox\"/>\r\n      </TableDataSource>\r\n      <TableDat" +
        "aSource Name=\"Doctors\" DataType=\"System.Int32\" Enabled=\"true\" TableName=\"Doctors" +
        "\">\r\n        <Column Name=\"DoctorId\" DataType=\"System.Int32\"/>\r\n        <Column N" +
        "ame=\"Full name\" DataType=\"System.String\"/>\r\n        <Column Name=\"Phone number\" " +
        "DataType=\"System.String\"/>\r\n        <Column Name=\"Degree\" DataType=\"System.Strin" +
        "g\"/>\r\n        <Column Name=\"Deleted\" DataType=\"System.Boolean\" BindableControl=\"";
      reportString += "CheckBox\"/>\r\n      </TableDataSource>\r\n      <TableDataSource Name=\"Table\" Alias" +
        "=\"DoctorsReport\" DataType=\"System.Int32\" Enabled=\"true\" SelectCommand=\"SELECT Do" +
        "ctors.DoctorId, Doctors.[Full name] AS FullName, Doctors.[Phone number] AS Phone" +
        "Number, Doctors.Degree, STRING_AGG(Specialities.Name, ',') AS Result&#13;&#10;  " +
        "                                        FROM Doctors, Specialities, DoctorSpecia" +
        "lity&#13;&#10;                                          WHERE Doctors.DoctorId =" +
        " DoctorSpeciality.DoctorId AND Specialities.SpecialityId = DoctorSpeciality.Spec" +
        "ialityId&#13;&#10;										  Group By Doctors.DoctorId, Doctors.[Full name], Do" +
        "ctors.[Phone number], Doctors.Degree;\">\r\n        <Column Name=\"DoctorId\" DataTyp" +
        "e=\"System.Int32\"/>\r\n        <Column Name=\"FullName\" DataType=\"System.String\"/>\r\n" +
        "        <Column Name=\"PhoneNumber\" DataType=\"System.String\"/>\r\n        <Column N" +
        "ame=\"Degree\" DataType=\"System.String\"/>\r\n        <Column Name=\"Result\" DataType=" +
        "\"System.String\"/>\r\n      </TableDataSource>\r\n    </MsSqlDataConnection>\r\n    <Ta";
      reportString += "bleDataSource Name=\"Employees\" ReferenceName=\"NorthWind.Employees\" DataType=\"Sys" +
        "tem.Int32\" Enabled=\"true\">\r\n      <Column Name=\"EmployeeID\" DataType=\"System.Int" +
        "32\"/>\r\n      <Column Name=\"LastName\" DataType=\"System.String\"/>\r\n      <Column N" +
        "ame=\"FirstName\" DataType=\"System.String\"/>\r\n      <Column Name=\"Title\" DataType=" +
        "\"System.String\"/>\r\n      <Column Name=\"TitleOfCourtesy\" DataType=\"System.String\"" +
        "/>\r\n      <Column Name=\"BirthDate\" DataType=\"System.DateTime\"/>\r\n      <Column N" +
        "ame=\"HireDate\" DataType=\"System.DateTime\"/>\r\n      <Column Name=\"Address\" DataTy" +
        "pe=\"System.String\"/>\r\n      <Column Name=\"City\" DataType=\"System.String\"/>\r\n    " +
        "  <Column Name=\"Region\" DataType=\"System.String\"/>\r\n      <Column Name=\"PostalCo" +
        "de\" DataType=\"System.String\"/>\r\n      <Column Name=\"Country\" DataType=\"System.St" +
        "ring\"/>\r\n      <Column Name=\"HomePhone\" DataType=\"System.String\"/>\r\n      <Colum" +
        "n Name=\"Extension\" DataType=\"System.String\"/>\r\n      <Column Name=\"Photo\" DataTy";
      reportString += "pe=\"System.Byte[]\" BindableControl=\"Picture\"/>\r\n      <Column Name=\"Notes\" DataT" +
        "ype=\"System.String\"/>\r\n      <Column Name=\"ReportsTo\" DataType=\"System.Int32\"/>\r" +
        "\n    </TableDataSource>\r\n  </Dictionary>\r\n  <ReportPage Name=\"Page1\" Watermark.F" +
        "ont=\"Arial, 60pt\">\r\n    <ReportTitleBand Name=\"ReportTitle1\" Width=\"718.2\" Heigh" +
        "t=\"66.15\" CanGrow=\"true\">\r\n      <TextObject Name=\"Text1\" Left=\"-37.8\" Top=\"18.9" +
        "\" Width=\"718.2\" Height=\"28.35\" Text=\"DOCTORS\" HorzAlign=\"Center\" VertAlign=\"Cent" +
        "er\" Font=\"Tahoma, 14pt, style=Bold\"/>\r\n      <ChildBand Name=\"Child2\" Top=\"70.15" +
        "\" Width=\"718.2\" Height=\"18.9\"/>\r\n    </ReportTitleBand>\r\n    <DataBand Name=\"Dat" +
        "a1\" Top=\"93.05\" Width=\"718.2\" Height=\"219.24\" Border.Lines=\"All\" Border.Color=\"M" +
        "aroon\" CanGrow=\"true\" DataSource=\"Employees\">\r\n      <TextObject Name=\"Text3\" Le" +
        "ft=\"9.45\" Top=\"66.15\" Width=\"103.95\" Height=\"18.9\" Text=\"Speciality:\" VertAlign=" +
        "\"Center\" Font=\"Tahoma, 9pt, style=Bold\"/>\r\n      <TextObject Name=\"Text4\" Left=\"";
      reportString += "113.4\" Top=\"66.15\" Width=\"453.6\" Height=\"18.9\" Text=\"[DoctorsReport.Result]\" For" +
        "mat=\"Date\" Format.Format=\"D\" VertAlign=\"Center\" Font=\"Tahoma, 9pt\"/>\r\n      <Tex" +
        "tObject Name=\"Text5\" Left=\"9.45\" Top=\"103.95\" Width=\"103.95\" Height=\"18.9\" Text=" +
        "\"Degree:\" VertAlign=\"Center\" Font=\"Tahoma, 9pt, style=Bold\"/>\r\n      <TextObject" +
        " Name=\"Text6\" Left=\"113.4\" Top=\"103.95\" Width=\"453.6\" Height=\"18.9\" CanGrow=\"tru" +
        "e\" Text=\"[DoctorsReport.Degree]\" VertAlign=\"Center\" Font=\"Tahoma, 9pt\"/>\r\n      " +
        "<TextObject Name=\"Text7\" Left=\"9.45\" Top=\"122.85\" Width=\"103.95\" Height=\"18.9\" T" +
        "ext=\"Phone:\" VertAlign=\"Center\" Font=\"Tahoma, 9pt, style=Bold\"/>\r\n      <TextObj" +
        "ect Name=\"Text8\" Left=\"113.4\" Top=\"122.85\" Width=\"453.6\" Height=\"18.9\" Text=\"[Do" +
        "ctorsReport.PhoneNumber]\" VertAlign=\"Center\" Font=\"Tahoma, 9pt\"/>\r\n      <TextOb" +
        "ject Name=\"Text14\" Left=\"113.4\" Top=\"85.05\" Width=\"453.6\" Height=\"18.9\" Text=\"[E" +
        "mployees.City]\" VertAlign=\"Center\" Font=\"Tahoma, 9pt\"/>\r\n      <TextObject Name=";
      reportString += "\"Text16\" Left=\"9.45\" Top=\"85.05\" Width=\"103.95\" Height=\"18.9\" Text=\"City:\" VertA" +
        "lign=\"Center\" Font=\"Tahoma, 9pt, style=Bold\"/>\r\n      <TextObject Name=\"Text2\" W" +
        "idth=\"718.2\" Height=\"37.8\" Border.Lines=\"All\" Border.Color=\"Maroon\" Fill=\"Linear" +
        "Gradient\" Fill.StartColor=\"IndianRed\" Fill.EndColor=\"Maroon\" Fill.Angle=\"90\" Fil" +
        "l.Focus=\"0.52\" Fill.Contrast=\"1\" Text=\"[DoctorsReport.FullName]\" Padding=\"10, 0," +
        " 2, 0\" VertAlign=\"Center\" Font=\"Tahoma, 12pt, style=Bold\" TextFill.Color=\"White\"" +
        "/>\r\n      <ChildBand Name=\"Child1\" Top=\"316.29\" Width=\"718.2\" Height=\"18.9\"/>\r\n " +
        "     <Sort>\r\n        <Sort Expression=\"[Employees.FirstName]\"/>\r\n        <Sort E" +
        "xpression=\"[Employees.LastName]\"/>\r\n      </Sort>\r\n    </DataBand>\r\n    <PageFoo" +
        "terBand Name=\"PageFooter1\" Top=\"339.19\" Width=\"718.2\" Height=\"28.35\" Fill.Color=" +
        "\"WhiteSmoke\" CanGrow=\"true\">\r\n      <TextObject Name=\"Text10\" Left=\"614.25\" Widt" +
        "h=\"94.5\" Height=\"28.35\" Text=\"[PageN]\" HorzAlign=\"Right\" VertAlign=\"Center\" Font";
      reportString += "=\"Tahoma, 8pt\"/>\r\n    </PageFooterBand>\r\n  </ReportPage>\r\n</Report>\r\n";
      LoadFromString(reportString);
      InternalInit();
      
    }

    public SimpleList()
    {
      InitializeComponent();
    }
  }
}
