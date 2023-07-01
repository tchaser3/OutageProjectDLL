using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace OutageProjectDLL
{
    public class OutageProjectClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        OutageProjectsDataSet aOutageProjectsDataSet;
        OutageProjectsDataSetTableAdapters.outageprojectsTableAdapter aOutageProjectsTableAdapter;

        InsertOutageProjectEntryTableAdapters.QueriesTableAdapter aInsertOutageProjectTableAdapter;

        public bool InsertOutageProject(string strCreatedUser, DateTime datOutageDate, string strTempDID, int intProjectID, string strOutageAddress1, string strOutageAddress2, string strOutageCity, string strOutageState, string strOutagePostalCode)
        {
            bool blnFatalError = false;

            try
            {
                aInsertOutageProjectTableAdapter = new InsertOutageProjectEntryTableAdapters.QueriesTableAdapter();
                aInsertOutageProjectTableAdapter.InsertOutageProject(strCreatedUser, datOutageDate, strTempDID, intProjectID, strOutageAddress1, strOutageAddress2, strOutageCity, strOutageState, strOutagePostalCode);
            }
            catch (Exception Ex)
            {
                blnFatalError = true;

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Insert Outage Project " + Ex.ToString());
            }

            return blnFatalError;
        }
        public OutageProjectsDataSet GetOutageProjectsInfo()
        {
            try
            {
                aOutageProjectsDataSet = new OutageProjectsDataSet();
                aOutageProjectsTableAdapter = new OutageProjectsDataSetTableAdapters.outageprojectsTableAdapter();
                aOutageProjectsTableAdapter.Fill(aOutageProjectsDataSet.outageprojects);
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Get Outage Project Info " + ex.ToString());
            }

            return aOutageProjectsDataSet;
        }
        public void UpdateOutageProjectsDB(OutageProjectsDataSet aOutageProjectsDataSet)
        {
            try
            {
                aOutageProjectsTableAdapter = new OutageProjectsDataSetTableAdapters.outageprojectsTableAdapter();
                aOutageProjectsTableAdapter.Update(aOutageProjectsDataSet.outageprojects);
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Update Outage Project DB " + ex.ToString());
            }
        }
    }
}
