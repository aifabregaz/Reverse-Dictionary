using System;
using System.Collections.Generic;
using System.IO;
using NPOI.HSSF.UserModel;

namespace TextLoader.FileSaver
{
    public class XlsTextSaver : ITextSaver
    {
        #region Implementation of ITextSaver

        public void SaveFile(string path, List<string> text)
        {
            var wb = new HSSFWorkbook();
            var sheet = wb.CreateSheet("Dictionary");

            int rowIndex = 0;
            var row = sheet.CreateRow(rowIndex);
            row.CreateCell(0).SetCellValue("Word");
            row.CreateCell(1).SetCellValue("Count");
            rowIndex++;

            foreach(var str in text)
            {
                var first = str.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)[0];
                var second = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

                row = sheet.CreateRow(rowIndex);
                row.CreateCell(0).SetCellValue(first);
                row.CreateCell(1).SetCellValue(second);
                rowIndex++;
            }

            using(var fileStr = new FileStream(path, FileMode.Create))
            {
                wb.Write(fileStr);
            }
        }

        #endregion
    }
}