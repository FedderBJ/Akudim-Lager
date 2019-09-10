using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    using WSWarehouseEmployee;
    class EmployeeTool
    {
        public void GetEmployeeSettings(string l_username)
        {
            WarehouseEmployee_Service warehouseemployeeservice = new WarehouseEmployee_Service();
            warehouseemployeeservice.UseDefaultCredentials = true;
            //warehouseemployeeservice.Credentials = Globals.myCredential;

            List<WarehouseEmployee_Filter> WarehouseEmployeeFilterArray = new List<WarehouseEmployee_Filter>();

            WarehouseEmployee_Filter UserNameFilter = new WarehouseEmployee_Filter();
            UserNameFilter.Field = WarehouseEmployee_Fields.User_ID;
            UserNameFilter.Criteria = l_username;
            WarehouseEmployeeFilterArray.Add(UserNameFilter);

            WarehouseEmployee_Filter DefaultLocationFilter = new WarehouseEmployee_Filter();
            DefaultLocationFilter.Field = WarehouseEmployee_Fields.Default;
            DefaultLocationFilter.Criteria = true.ToString();
            WarehouseEmployeeFilterArray.Add(DefaultLocationFilter);

            WarehouseEmployee[] employees = warehouseemployeeservice.ReadMultiple(WarehouseEmployeeFilterArray.ToArray(), "", 1000);

            if (employees.Count() > 0)
            {
                foreach (var employee in employees)
                {
                    Globals.theLanguageCode = employee.Terminal_Language_Text;
                    Globals.theLanguageID = employee.Terminal_Language_No;
                    Globals.theLanguageCodeNav = employee.Terminal_Language_Code;
                    Globals.theConsumptionTemplateName = employee.Consumption_Template_Name;
                    Globals.theConsumptionBatchName = employee.Consumption_Batch_Name;
                    Globals.theOutputTemplateName = employee.Output_Template_Name;
                    Globals.theOutputBatchName = employee.Output_Batch_Name;
                    Globals.thePhysInvTemplateName = employee.Phys_Inv_Template_Name;
                    Globals.thePhysInvBatchName = employee.Phys_Inv_Batch_Name;
                    Globals.theTransferTemplateName = employee.Transfer_Template_Name;
                    Globals.theTransferBatchName = employee.Transfer_Batch_Name;
                    if (employee.PICP_Procedure_Batch_Name != null)
                    {
                        Globals.thePhysCountMode = (!employee.PICP_Procedure_Batch_Name.Equals(""));
                        
                    }
                    
                    Globals.theLocation = employee.Location_Code;
                    Globals.thePrintInvPid = employee.Inventory_Print_Pid_Counting;
                    Globals.thePrintNewPid = employee.Inventory_Print_New_Pid;
                }
            }
            else
                MessageBoxExample.MyMessageBox.ShowBox(string.Format("Lagermedarbejder opsætning for {0} blev ikke fundet", l_username));

        }
    }
}
