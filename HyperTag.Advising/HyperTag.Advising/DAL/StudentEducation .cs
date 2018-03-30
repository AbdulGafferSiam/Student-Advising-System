using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class StudentEducation : MyBase, IDatabase
    {


        public int StudentId { get; set; }
        public int EducationId  { get; set; }
        public int EducationBoardId { get; set; }

        public int Year { get; set; }
        public string Result { get; set; }
        public string Roll { get; set; }
        public string Registration { get; set; }
        public string Remarks { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }


        public bool Insert()
        {
            Command = MyCommand("insert into StudentEducation (StudentId, EducationId,EducationBoardId,Year,Result,Roll,Registration,Remarks,DocumentType,Document) values(@StudentId, @EducationId,@EducationBoardId,@Year,@Result,@Roll,@Registration,@Remarks,@DocumentType,@Document)");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            Command.Parameters.AddWithValue("@EducationId", EducationId);
            Command.Parameters.AddWithValue("@EducationBoardId", EducationBoardId);
            Command.Parameters.AddWithValue("@Year", Year);
            Command.Parameters.AddWithValue("@Result", Result);
            Command.Parameters.AddWithValue("@Roll", Roll);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            Command.Parameters.AddWithValue("@DocumentType", DocumentType);
            Command.Parameters.AddWithValue("@Document", Document);
           
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand(@"update StudentEducation  set StudentId = @StudentId, 
                                                               EducationId = @EducationId,
                                                               EducationBoardId=@EducationBoardId,
                                                               Year = @Year,
                                                               Result = @Result,
                                                               Roll = @Roll,
                                                               Remarks = @Remarks,
                                                               DocumentType = @DocumentType,
                                                               Document = @Document
                                              where StudentId = @StudentId and EducationId = @EducationId");

            Command.Parameters.AddWithValue("@StudentId", StudentId);
            Command.Parameters.AddWithValue("@EducationId", EducationId);
            Command.Parameters.AddWithValue("@EducationBoardId", EducationBoardId);
            Command.Parameters.AddWithValue("@Year", Year);
            Command.Parameters.AddWithValue("@Result", Result);
            Command.Parameters.AddWithValue("@Roll", Roll);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            Command.Parameters.AddWithValue("@DocumentType", DocumentType);
            Command.Parameters.AddWithValue("@Document", Document);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from StudentEducation  where StudentId = @StudentId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select StudentId, EducationId, EducationBoardId,Year,Result,Roll,Remarks,DocumentType,Document from StudentEducation  where StudentId = @StudentId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);

            MyReader = ExecuteReader(Command);
           
            while(MyReader.Read())
            {
                StudentId = Convert.ToInt32(MyReader["StudentId"]);
                EducationId = Convert.ToInt32(MyReader["EducationId"]);
                EducationBoardId = Convert.ToInt32(MyReader["EducationBoardId"]);
                Year = Convert.ToInt32(MyReader["Year"]);
                Result = MyReader["Result"].ToString();
                Roll = MyReader["Roll"].ToString();
                Remarks = MyReader["Remarks"].ToString();
                DocumentType = MyReader["DocumentType"].ToString();
                Document = MyReader["Document"].ToString();


                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select StudentId, EducationId, EducationBoardId,Year,Result,Roll,Remarks,DocumentType,Document from StudentEducation where StudentId > 0 ");

            if ( StudentId ==0)
            {
                Command.CommandText += " and StudentId like @search ";
                Command.Parameters.AddWithValue("@search", "%" + StudentId + "%");
            }

            if (StudentId > 0)
            {
                Command.CommandText += " and StudentId = @countryId";
                
            }

            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand(@"create table StudentEducation (
            StudentId int,
            EducationId int,
            EducationBoardId int,
            Year int,
            Result nvarchar(5),
            Roll nvarchar(50),
            Registration nvarchar(10),
            Remarks nvarchar(500),
            DocumentType nvarchar(50),
            Document image,
            foreign key(EducationBoardId) references educationboard(id),
            foreign key(StudentId) references student(id),
            foreign key(EducationId) references education(id),
            primary key(StudentId,EducationId,EducationBoardId),
)");
            return Execute(Command);
        }
    }
}
