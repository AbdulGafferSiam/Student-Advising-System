using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class course : MyBase, IDatabase
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string code { get; set; }
        public int credit { get; set; }
        public int programId { get; set; }
        public string Description { get; set; }

        

        public bool Insert()
        {
            Command = MyCommand("insert into course(name,code,credit,programId, Description) values( @name, @code, @credit, @programId, @Description)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@code", code);
            Command.Parameters.AddWithValue("@credit", credit);
            Command.Parameters.AddWithValue("@programId", programId);
            Command.Parameters.AddWithValue("@Description", Description);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update course set  name = @name,code= @code, credit = @credit, programId = @programId, Description = @Description where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@code", code);
            Command.Parameters.AddWithValue("@credit", credit);
            Command.Parameters.AddWithValue("@programId", programId);
            Command.Parameters.AddWithValue("@Description", Description);

            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from course  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name, code, credit, program, Descriotion from course  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                code = MyReader["code"].ToString();
                credit = Convert.ToInt32(MyReader["credit"]);
                programId = (int)MyReader["program"];
                Description = MyReader["Description"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select course.id, course.name, course.code, course.credit, course.program, course.Description  from course where course.id > 0 ");

            if (Name != null && Name != "")
            {
                Command.CommandText += " and course.name like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            if (code != null && code != "")
            {
                Command.CommandText += "and course.code like @search";
                Command.Parameters.AddWithValue("@seach", "%" + code + "%");
            }

            if (programId > 0)
            {
                Command.CommandText += "and course.program like @search";
                Command.Parameters.AddWithValue("@search", "%" + programId + "%");
            }
            if (Description != null && Description != "")
            {
                Command.CommandText += " and course.description like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Description + "%");
            }
            if (credit > 0)
            {
                Command.CommandText += "and course.credite = @credite";
                Command.Parameters.AddWithValue("@credite", credit);
            }
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand("create table teacher(Id int identity(1, 1) primary key, Code varchar(30),Name varchar(200) not null,Creadit int, ProgramId varchar(200),[Description] varchar(500))");

            return Execute(Command);
        }
    }
}