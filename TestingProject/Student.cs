using System;
using System.Data;
using System.Linq;


public class Student
{
    public int Id;
    public string Name;

    public static DataTable GetDataTable(Student[] students)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Id", typeof(Int32));
        table.Columns.Add("Name", typeof(string));
        foreach (Student student in students)
        {
            table.Rows.Add(student.Id, student.Name);
        }

        return (table);
    }
    public static void OutputDataTableHeader(DataTable dt, int columnWidth)
    {
        string format = string.Format("{0}0,-{1}{2}", "{", columnWidth, "}");

        // Отображение заголовков столбцов.
        foreach (DataColumn column in dt.Columns)
        {
            Console.Write(format, column.ColumnName);
        }
        Console.WriteLine();
        foreach (DataColumn column in dt.Columns)
        {
            for (int i = 0; i < columnWidth; i++)
            {
                Console.Write("=");
            }

        }
        Console.WriteLine();
    }
}
