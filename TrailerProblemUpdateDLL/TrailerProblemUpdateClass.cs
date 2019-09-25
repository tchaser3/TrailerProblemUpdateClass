/* Title:           Trailer Problem Update Class
 * Date:            8-30-18
 * Author:          Terry Holmes
 * 
 * Description:     This is the class that will work with the upates */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace TrailerProblemUpdateDLL
{
    public class TrailerProblemUpdateClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        TrailerProblemUpdateDataSet aTrailerProblemUdateDataSet;
        TrailerProblemUpdateDataSetTableAdapters.trailerproblemupdateTableAdapter aTrailerProblemUpdateTableAdapter;

        InsertTrailerProblemUpdateEntryTableAdapters.QueriesTableAdapter aInsertTrailerProblemUpdateTableAdapter;

        FindTrailerProblemUpdateByProblemIDDataSet aFindTrailerProblemUpdateByProblemIDDataSet;
        FindTrailerProblemUpdateByProblemIDDataSetTableAdapters.FindTrailerProblemUpdateByProblemIDTableAdapter aFindTrailerProblemUpdateByProblemIDTableAdapter;

        public FindTrailerProblemUpdateByProblemIDDataSet FindTrailerProblemUpdateByProblemID(int intProblemID)
        {
            try
            {
                aFindTrailerProblemUpdateByProblemIDDataSet = new FindTrailerProblemUpdateByProblemIDDataSet();
                aFindTrailerProblemUpdateByProblemIDTableAdapter = new FindTrailerProblemUpdateByProblemIDDataSetTableAdapters.FindTrailerProblemUpdateByProblemIDTableAdapter();
                aFindTrailerProblemUpdateByProblemIDTableAdapter.Fill(aFindTrailerProblemUpdateByProblemIDDataSet.FindTrailerProblemUpdateByProblemID, intProblemID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Update Class // Find Trailer Problem Update By Problem ID " + Ex.Message);
            }

            return aFindTrailerProblemUpdateByProblemIDDataSet;
        }
        public bool InsertTrailerProblemUpdate(int intProblemID, int intEmployeeID, string strProblemUpdate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertTrailerProblemUpdateTableAdapter = new InsertTrailerProblemUpdateEntryTableAdapters.QueriesTableAdapter();
                aInsertTrailerProblemUpdateTableAdapter.InsertTrailerProblemUpdate(intProblemID, intEmployeeID, strProblemUpdate, DateTime.Now);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Update Class // Insert Trailer Problem Update " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public TrailerProblemUpdateDataSet GetTrailerProblemUpdateInfo()
        {
            try
            {
                aTrailerProblemUdateDataSet = new TrailerProblemUpdateDataSet();
                aTrailerProblemUpdateTableAdapter = new TrailerProblemUpdateDataSetTableAdapters.trailerproblemupdateTableAdapter();
                aTrailerProblemUpdateTableAdapter.Fill(aTrailerProblemUdateDataSet.trailerproblemupdate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Update Class // Get Trailer Problem Update Info " + Ex.Message);
            }

            return aTrailerProblemUdateDataSet;
        }
        public void UpdateTrailerProblemUpdateDB(TrailerProblemUpdateDataSet aTrailerProblemUdateDataSet)
        {
            try
            {
                aTrailerProblemUpdateTableAdapter = new TrailerProblemUpdateDataSetTableAdapters.trailerproblemupdateTableAdapter();
                aTrailerProblemUpdateTableAdapter.Update(aTrailerProblemUdateDataSet.trailerproblemupdate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Update Class // Update Trailer Problem Update DB " + Ex.Message);
            }
        }
    }
}
