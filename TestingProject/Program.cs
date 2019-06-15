using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {

        Student[] students = {
                new Student { Id=1, Name="Александр Ерохин"},
                new Student { Id=5, Name="Елена Волкова"},
                new Student { Id=9, Name="Дмитрий Моисеенко"},
                new Student { Id=16, Name="Андрей Мухамедшин"}
                                 };

        DataTable dt1 = GetDataTable(students);
        IEnumerable<DataRow> seq1 = dt1.AsEnumerable();

        int id;

        //  Prototype 1.
        id = (from s in seq1
              where s.Field<string>("Name") == "Александр Ерохин"
              select s.Field<int>(dt1.Columns[0], DataRowVersion.Current)).
             Single<int>();
        Console.WriteLine("ID номер Ерохина Александра, полученный с помощью прототипа 1: {0}", id);

        //  Prototype 2.
        id = (from s in seq1
              where s.Field<string>("Name") == "Александр Ерохин"
              select s.Field<int>("Id", DataRowVersion.Current)).
             Single<int>();
        Console.WriteLine("ID номер Ерохина Александра, полученный с помощью прототипа 2: {0}", id);

        //  Prototype 3.
        id = (from s in seq1
              where s.Field<string>("Name") == "Александр Ерохин"
              select s.Field<int>(0, DataRowVersion.Current)).
             Single<int>();
        Console.WriteLine("ID номер Ерохина Александра, полученный с помощью прототипа 3: {0}", id);

        //  Prototype 4.
        id = (from s in seq1
              where s.Field<string>("Name") == "Александр Ерохин"
              select s.Field<int>(dt1.Columns[0])).
             Single<int>();
        Console.WriteLine("ID номер Ерохина Александра, полученный с помощью прототипа 4: {0}", id);

        //  Prototype 5.
        id = (from s in seq1
              where s.Field<string>("Name") == "Александр Ерохин"
              select s.Field<int>("Id")).
             Single<int>();
        Console.WriteLine("ID номер Ерохина Александра, полученный с помощью прототипа 5: {0}", id);

        //  Prototype 6.
        id = (from s in seq1
              where s.Field<string>("Name") == "Александр Ерохин"
              select s.Field<int>(0)).
             Single<int>();
        Console.WriteLine("ID номер Ерохина Александра, полученный с помощью прототипа 6: {0}", id);
        Console.ReadLine();
    }

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

