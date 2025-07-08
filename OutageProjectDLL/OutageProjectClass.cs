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

        UpdateOutageProjectDIDEntryTableAdapters.QueriesTableAdapter aUpdateOutageProjectDIDTableAdapter;

        UpdateOutageProjectStatusEntryTableAdapters.QueriesTableAdapter aUpdateOutageProjectStatusTableAdapter;

        OutageProjectStatusDataSet aOutageProjectStatusDataSet;
        OutageProjectStatusDataSetTableAdapters.outageprojectstatusTableAdapter aOutageProjectStatusTableAdapter;

        InsertOutageProjectStatusEntryTableAdapters.QueriesTableAdapter aInsertOutageProjectStatusTableAdapter;

        UpdateOutageProjectWorkStatusTableEntryTableAdapters.QueriesTableAdapter aUpdateOutageProjectWorkStatusTableTableAdapter;

        FindSortedOutageProjectWorkStatusDataSet aFindSortedOutageProjectWorkStatusDataSet;
        FindSortedOutageProjectWorkStatusDataSetTableAdapters.FindSortedOutageProjectWorkStatusTableAdapter aFindSortedOutageProjectWorkStatusTableAdapter;

        FindOutageProjectByWorkStatusDataSet aFindOutageProjectByWorkStatusDataSet;
        FindOutageProjectByWorkStatusDataSetTableAdapters.FindOutageProjectbyWorkStatusTableAdapter aFindOutageProjectByWorkStatusTableAdapter;

        FindOutageStatusByKeywordDataSet aFindOutageStatusByKeywordDataSet;
        FindOutageStatusByKeywordDataSetTableAdapters.FindOutageWorkStatusByKeywordTableAdapter aFindOutageStatusByKeywordTableAdapter;

        FindOutageProjectsDataSet aFindOutageProjectsDataSet;
        FindOutageProjectsDataSetTableAdapters.FindOutageProjectsTableAdapter aFindOutageProjectsTableAdapter;

        public FindOutageProjectsDataSet FindOutageProjects()
        {
            try
            {
                aFindOutageProjectsDataSet = new FindOutageProjectsDataSet();
                aFindOutageProjectsTableAdapter = new FindOutageProjectsDataSetTableAdapters.FindOutageProjectsTableAdapter();
                aFindOutageProjectsTableAdapter.Fill(aFindOutageProjectsDataSet.FindOutageProjects);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Find Outage Projects " + Ex.ToString());
            }
            return aFindOutageProjectsDataSet;
        }
        public FindOutageStatusByKeywordDataSet FindOutageStatusByKeyword(string strOutageProjectStatus)
        {
            try
            {
                aFindOutageStatusByKeywordDataSet = new FindOutageStatusByKeywordDataSet();
                aFindOutageStatusByKeywordTableAdapter = new FindOutageStatusByKeywordDataSetTableAdapters.FindOutageWorkStatusByKeywordTableAdapter();
                aFindOutageStatusByKeywordTableAdapter.Fill(aFindOutageStatusByKeywordDataSet.FindOutageWorkStatusByKeyword, strOutageProjectStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Find Outage Status By Keyword " + Ex.ToString());
            }

            return aFindOutageStatusByKeywordDataSet;
        }
        public FindOutageProjectByWorkStatusDataSet FindOutageProjectByWorkStatus(string strOutageProjectWorkStatus)
        {
            try
            {
                aFindOutageProjectByWorkStatusDataSet = new FindOutageProjectByWorkStatusDataSet();
                aFindOutageProjectByWorkStatusTableAdapter = new FindOutageProjectByWorkStatusDataSetTableAdapters.FindOutageProjectbyWorkStatusTableAdapter();
                aFindOutageProjectByWorkStatusTableAdapter.Fill(aFindOutageProjectByWorkStatusDataSet.FindOutageProjectbyWorkStatus, strOutageProjectWorkStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Find Outage Project By Work Status " + Ex.ToString());
            }

            return aFindOutageProjectByWorkStatusDataSet;
        }
        public FindSortedOutageProjectWorkStatusDataSet FindSortedOutageProjectWorkStatus()
        {
            try
            {
                aFindSortedOutageProjectWorkStatusDataSet = new FindSortedOutageProjectWorkStatusDataSet();
                aFindSortedOutageProjectWorkStatusTableAdapter = new FindSortedOutageProjectWorkStatusDataSetTableAdapters.FindSortedOutageProjectWorkStatusTableAdapter();
                aFindSortedOutageProjectWorkStatusTableAdapter.Fill(aFindSortedOutageProjectWorkStatusDataSet.FindSortedOutageProjectWorkStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Find Sorted Outage Project Work Status " + Ex.ToString());
            }

            return aFindSortedOutageProjectWorkStatusDataSet;
        }
        public bool UpdateOutageProjectWorkStatusTable(int intTransactionID, string strModifiedUser, string strOutageWorkStatus)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateOutageProjectWorkStatusTableTableAdapter = new UpdateOutageProjectWorkStatusTableEntryTableAdapters.QueriesTableAdapter();
                aUpdateOutageProjectWorkStatusTableTableAdapter.UpdateOutageWorkStatusTable(intTransactionID, strModifiedUser, strOutageWorkStatus);
            }
            catch (Exception Ex)
            {
                blnFatalError = true;

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Update Outage Project Work Status Table " + Ex.ToString());
            }

            return blnFatalError;
        }
        public bool InsertOutageProjectStatus(string strCreatedUser, string strOutageWorkStatus)
        {
            bool blnFatalError = false;

            try
            {
                aInsertOutageProjectStatusTableAdapter = new InsertOutageProjectStatusEntryTableAdapters.QueriesTableAdapter();
                aInsertOutageProjectStatusTableAdapter.InsertOutageProjectStatus(strCreatedUser, strOutageWorkStatus);
            }
            catch (Exception Ex)
            {
                blnFatalError = true;

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Insert Outage Project Status " + Ex.ToString());
            }

            return blnFatalError;
        }
        public OutageProjectStatusDataSet GetOutageProjectStatusInfo()
        {
            try
            {
                aOutageProjectStatusDataSet = new OutageProjectStatusDataSet();
                aOutageProjectStatusTableAdapter = new OutageProjectStatusDataSetTableAdapters.outageprojectstatusTableAdapter();
                aOutageProjectStatusTableAdapter.Fill(aOutageProjectStatusDataSet.outageprojectstatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Get Outage Project Status Info " + Ex.ToString());
            }

            return aOutageProjectStatusDataSet;
        }
        public bool UpdateOutageProjectStatus(int intProjectID, string strOutageStatus)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateOutageProjectStatusTableAdapter = new UpdateOutageProjectStatusEntryTableAdapters.QueriesTableAdapter();
                aUpdateOutageProjectStatusTableAdapter.UpdateOutageProjectStatus(intProjectID, strOutageStatus);
            }
            catch (Exception Ex)
            {
                blnFatalError = true;

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Update Outage Project Status " + Ex.ToString());
            }

            return blnFatalError;
        }
        public bool UpdateOutageProjectDID(int intProjectID, string strTempDID, string strModifiedUser, string strOutageStatus)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateOutageProjectDIDTableAdapter = new UpdateOutageProjectDIDEntryTableAdapters.QueriesTableAdapter();
                aUpdateOutageProjectDIDTableAdapter.UpdateOutageProjectDID(intProjectID, strTempDID, strModifiedUser, strOutageStatus);
            }
            catch (Exception Ex)
            {
                blnFatalError = true;

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Outage Project Class // Update Outage Project DID " + Ex.ToString());
            }

            return blnFatalError;
        }
        public bool InsertOutageProject(string strCreatedUser, DateTime datOutageDate, string strTempDID, int intProjectID, string strOutageAddress1, string strOutageAddress2, string strOutageCity, string strOutageState, string strOutagePostalCode, string strOutageStatus)
        {
            bool blnFatalError = false;

            try
            {
                aInsertOutageProjectTableAdapter = new InsertOutageProjectEntryTableAdapters.QueriesTableAdapter();
                aInsertOutageProjectTableAdapter.InsertOutageProject(strCreatedUser, datOutageDate, strTempDID, intProjectID, strOutageAddress1, strOutageAddress2, strOutageCity, strOutageState, strOutagePostalCode, strOutageStatus);
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
