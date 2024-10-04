//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace InterviewManagement.Models
//{
//	public class sideprectice
//	{



// insert Metrhod 
//public List<InterviewMaster> GetAllCandidate()
//{
//    List<InterviewMaster> lstCandidate = new List<InterviewMaster>();

//    using (SqlConnection con = new SqlConnection(cs))
//    {
//        SqlCommand cmd = new SqlCommand("UspGetCandidateData", con);
//        cmd.CommandType = CommandType.StoredProcedure;

//        SqlDataAdapter da = new SqlDataAdapter(cmd);
//        DataTable dt = new DataTable();

//        con.Open();
//        da.Fill(dt);
//        con.Close();

//        foreach (DataRow row in dt.Rows)
//        {
//            InterviewMaster IM = new InterviewMaster();
//            IM.CompanyId = (long)row["CompanyId"];
//            IM.CompanyName = row["CompanyName"].ToString();
//            IM.CandidateId = (long)row["CandidateId"];
//            IM.FirstName = row["FirstName"].ToString();
//            IM.LastName = row["LastName"].ToString();
//            IM.Email = row["EmailId"].ToString();
//            IM.MobailNumber = row["MobileNo"].ToString();
//            IM.Address = row["AddressName"].ToString();
//            IM.DOB = (DateTime)row["DateOfBirth"];
//            IM.Age = row["Age"].ToString();
//            IM.Qualification = row["Qualification"].ToString();
//            IM.Skill = row["MasterSkills"].ToString();
//            IM.Experience = row["WorkExperience"].ToString();
//            IM.City = row["City"].ToString();
//            IM.Country = row["Country"].ToString();
//            IM.State = row["State"].ToString();

//            lstCandidate.Add(IM);
//        }
//    }
//    return lstCandidate;
//}

////////////////////////////////////////////////////////////////

//		public static InterviewMaster GetCandidateRow(int? id)
//		{
//			InterviewMaster Candidate = new InterviewMaster();

//			using (SqlConnection con = new SqlConnection(cs))
//			{
//				SqlCommand cmd = new SqlCommand("UspGetCandidateData", con);
//				cmd.CommandType = CommandType.StoredProcedure;
//				cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);

//				con.Open();
//				SqlDataReader row = cmd.ExecuteReader();

//				while (row.Read())
//				{
//					Candidate.CompanyId = (long)row["CompanyId"];
//					Candidate.CompanyName = row["CompanyName"].ToString();
//					Candidate.CandidateId = (long)row["CandidateId"];
//					Candidate.FirstName = row["FirstName"].ToString();
//					Candidate.LastName = row["LastName"].ToString();
//					Candidate.Email = row["EmailId"].ToString();
//					Candidate.MobailNumber = row["MobileNo"].ToString();
//					Candidate.Address = row["AddressName"].ToString();
//					Candidate.DOB = (DateTime)row["DateOfBirth"];
//					Candidate.Age = row["Age"].ToString();
//					Candidate.Qualification = row["Qualification"].ToString();
//					Candidate.Skill = row["MasterSkills"].ToString();
//					Candidate.Experience = row["WorkExperience"].ToString();
//					Candidate.City = row["City"].ToString();
//					Candidate.Country = row["Country"].ToString();
//					Candidate.State = row["State"].ToString();

//				}
//			}
//			return Candidate;
//		}
//	}
//}