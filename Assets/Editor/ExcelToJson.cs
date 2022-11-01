using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Excel;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System;

public class ExcelToJson {
    private static string excelPath;
    private static string fileName;

    [MenuItem("Tools/ExcelToJson")]
    public static void LoadExcel() {
        var selection = Selection.activeObject;
        if (selection == null) {
            return;
        }
        fileName = selection.name;
        excelPath = AssetDatabase.GetAssetPath(selection);
        ConvertJson();
    }

    public static void ConvertJson() {
        FileStream stream = File.Open(excelPath, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet dataSet = excelDataReader.AsDataSet();
        if (dataSet.Tables.Count == 0) {
            return;
        }
        DataTable sheet = dataSet.Tables[0];
        if (sheet.Rows.Count == 0) {
            return;
        }
        int rowCount = sheet.Rows.Count;
        int colCount = sheet.Columns.Count;
        var dataTable = new List<Dictionary<string, object>>();
        for (int i = 2; i < rowCount; i++) {
            var row = new Dictionary<string, object>();
            for (int j = 0; j < colCount; j++) {
                string field = sheet.Rows[1][j].ToString();
                string title = sheet.Rows[0][j].ToString();
                if (string.Equals(title, "int")) {
                    row[field] = Convert.ToInt32(sheet.Rows[i][j]);
                } else {
                    row[field] = sheet.Rows[i][j];
                }
            }
            dataTable.Add(row);
        }
        string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
        json = json.Replace("\"[", "[").Replace("]\"", "]");
        string filePath = Application.dataPath + "/Resources/JsonConfigs/" + fileName + ".json";
        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
            using (TextWriter textWriter = new StreamWriter(fileStream, System.Text.Encoding.UTF8)) {
                textWriter.Write(json);
            }
        }
        AssetDatabase.Refresh();
    }
}
