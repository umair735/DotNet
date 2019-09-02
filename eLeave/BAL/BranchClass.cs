using System.Data.SqlClient;
using eLeave.DAL;
namespace eLeave.BAL
{
    public class BranchClass
    {
        public static string GetBranchName { get; set; }

        public static bool GetIsActive { get { return true; } }

        public static int DID { get; set; }

        public static void InsertBracnh()
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("BranchName", GetBranchName);
            prm[1] = new SqlParameter("IsActive", GetIsActive);
            Helper.ExecuteQuery("sp_InsertBranch", prm);
        }

        public static void UpdateBracnh()
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("BranchName", GetBranchName);
            prm[1] = new SqlParameter("BranchID", DID);
            Helper.ExecuteQuery("sp_UpdateBranch", prm);
        }

        public static void DeleteBracnh()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("BranchID", DID);
            Helper.ExecuteQuery("sp_DeleteBranch", prm);
        }

    }
}