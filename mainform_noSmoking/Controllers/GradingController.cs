using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.Grading;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace mainform_noSmoking.Controllers
{
    public class GradingController : Controller
    {
        public static List<WorkViewModel> ViewModels { get; set; }
        public GradingModel Model { get; set; }
        public GradingController()
        {
            Model ??= new GradingModel();
            Model.ShareModel ??= new Models.ShareModel();
        }
        public async Task<IActionResult> Grading(int grade = 0, int status = 0)
        {
            Model.GetAllWork(grade, status);

            ViewModels = Model.ShareModel.ViewModels;

            return await Task.Run(() => View(Model));
        }

        [HttpGet]
        public async Task<IActionResult> GetWork(int id)
        {
            //show work by modal
            Model.GetImage(id);

            return await Task.Run(() => PartialView("_GradingModalPartial", Model));
        }

        [HttpGet]
        [Route("[controller]/[action]/{student_id}/{pass_status}")]
        public IActionResult Pass(int student_id, int pass_status)
        {
            Model.SetPassStatus(student_id, pass_status);

            return Json("");
        }

        [HttpGet]
        [Route("[controller]/[action]/{grade}/{status}")]
        public async Task<IActionResult> GetGradeWorks(int grade, int status)
        {
            Model.GetWorksByGrade(grade, status);

            ViewModels = Model.ShareModel.ViewModels;

            return await Task.Run(() => PartialView("_GradingPartial", Model));
        }
        
        [HttpPost]
        [Route("[controller]/[action]")]
        public IActionResult GetReport(IFormCollection data)
        {
            string[] headers = { "審核結果", "學生姓名", "學校區域", "學校名稱", "年級", "班級", "導師姓名", "聯絡方式", "學生Email", "檔案名稱", "上傳時間", "作品理念" };

            if(ViewModels.Count > 0)
            {
                CreateExcel(headers);
                byte[] fileBytes = System.IO.File.ReadAllBytes(FileName);
                string fileName = FileName;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);  //下載Excel
            }
            else
            {
                return RedirectToAction("Grading", new { grade = data["Student_grade"], status = data["Status"] });
            }
        }

        readonly string FileName = "學生資料統計報表.xlsx";
        public void CreateExcel(string[] headers)
        {
            IWorkbook workbook = new XSSFWorkbook();//init workbook
            ISheet workSheet = workbook.CreateSheet("SheetEins");//init worksheet

            //set header style and font
            ICellStyle headerStyle = workbook.CreateCellStyle();
            IFont headerFont = workbook.CreateFont();
            headerStyle.Alignment = HorizontalAlignment.Center;
            headerStyle.VerticalAlignment = VerticalAlignment.Center;
            headerFont.FontName = "標楷體";
            headerFont.IsBold = true;
            headerFont.FontHeightInPoints = 12;
            headerStyle.SetFont(headerFont);

            ICellStyle contentStyle = workbook.CreateCellStyle();
            IFont contentFont = workbook.CreateFont();
            contentStyle.Alignment = HorizontalAlignment.Center;
            contentStyle.VerticalAlignment = VerticalAlignment.Center;
            contentFont.FontName = "標楷體";
            contentFont.IsBold = false;
            contentFont.FontHeightInPoints = 12;
            contentStyle.SetFont(contentFont);

            workSheet.SetColumnWidth(0, Convert.ToInt16(16) * 256);
            workSheet.SetColumnWidth(1, Convert.ToInt16(16) * 256);
            workSheet.SetColumnWidth(2, Convert.ToInt16(16) * 256);
            workSheet.SetColumnWidth(3, Convert.ToInt16(24) * 256);
            workSheet.SetColumnWidth(4, Convert.ToInt16(8) * 256);
            workSheet.SetColumnWidth(5, Convert.ToInt16(8) * 256);
            workSheet.SetColumnWidth(6, Convert.ToInt16(16) * 256);
            workSheet.SetColumnWidth(7, Convert.ToInt16(16) * 256);
            workSheet.SetColumnWidth(8, Convert.ToInt16(20) * 256);
            workSheet.SetColumnWidth(9, Convert.ToInt16(25) * 256);
            workSheet.SetColumnWidth(10, Convert.ToInt16(30) * 256);
            workSheet.SetColumnWidth(11, Convert.ToInt16(50) * 256);

            IRow titleRow = workSheet.CreateRow(0);
            for (int i = 0; i < headers.Length; i++)
            {
                ICell cell = titleRow.CreateCell(i);
                cell.SetCellValue(headers[i]);
                cell.CellStyle = headerStyle;
            }

            string[,] content = new string[ViewModels.Count, headers.Length];

            for (int i = 0; i < ViewModels.Count; i++)
            {
                content[i, 0] = (ViewModels[i].StudentInfo.Pass_or_Not == 0 ? "未審核" : string.Empty) + (ViewModels[i].StudentInfo.Pass_or_Not == 1 ? "已通過" : string.Empty) + (ViewModels[i].StudentInfo.Pass_or_Not == 2 ? "未通過" : string.Empty) + (ViewModels[i].StudentInfo.Pass_or_Not == 4 ? "佳作作品" : string.Empty);
                content[i, 1] = ViewModels[i].StudentInfo.Student_name;
                content[i, 2] = ViewModels[i].SchuleInfo.Location_name;
                content[i, 3] = ViewModels[i].SchuleInfo.Schule_name;
                content[i, 4] = ViewModels[i].StudentInfo.Student_grade.ToString();
                content[i, 5] = ViewModels[i].StudentInfo.Student_class;
                content[i, 6] = ViewModels[i].StudentInfo.Teacher_name;
                content[i, 7] = ViewModels[i].StudentInfo.Teacher_phone;
                content[i, 8] = ViewModels[i].StudentInfo.Email_address;
                content[i, 9] = ViewModels[i].FileInfo.Original_name;
                content[i, 10] = ViewModels[i].FileInfo.Upload_time;
                content[i, 11] = ViewModels[i].FileInfo.Work_concept;
            }

            IRow row = workSheet.CreateRow(1);
            for (int i = 0; i < content.Length; i++)
            {
                if (i % 12 == 0 && i != 0)
                {
                    row = workSheet.CreateRow((i / 12) + 1);
                }
                ICell cell = row.CreateCell(i % 12);

                string _ = content[i / 12, i % 12];
                cell.SetCellValue(_);
                cell.CellStyle = contentStyle;
            }


            string FilePath = FileName;
            FileStream parFile = new(FilePath, FileMode.Create, FileAccess.Write);
            workbook.Write(parFile);
            parFile.Close();
        }//POI https://www.cnblogs.com/dubhlinn/p/10901442.html
    }
}
