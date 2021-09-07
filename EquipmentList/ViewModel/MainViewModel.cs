using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Dsafa.WpfColorPicker;
using EquipmentList.Messages;
using EquipmentList.Model;
using FirebirdSql.Data.FirebirdClient;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfMessageBoxLibrary;
using static EquipmentList.View.Views;
using EquipmentList.Windows;
using System.Collections.ObjectModel;
using EquipmentList.Helpers;
using Clipboard = EquipmentList.Model.Clipboard;
using System.Text;

namespace EquipmentList.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private FbConnection connection;

        private ViewModelBase viewModel;
        public ViewModelBase ViewModel
        {
            get
            {
                return viewModel;
            }

            set
            {
                viewModel = value;
                RaisePropertyChanged("ViewModel");
            }
        }

        private DefinedViews view;
        public DefinedViews View
        {
            get
            {
                return view;
            }

            set
            {
                view = value;
                RaisePropertyChanged("View");

                switch (value)
                {
                    case DefinedViews.EquipmentView:
                        equipmentTable = new DataTable();
                        equipmentAdapter.Fill(equipmentTable);
                        ViewModel = new EquipmentViewModel(EmployeesStatus, equipmentTable, AlarmColor, PostedWorkerColor, ActiveEmployeeColor, NullEmployeeColor, IncorrectReviewDateColor, IncorrectLegalizationDateColor);
                        break;
                    case DefinedViews.EmployeeView:
                        employeeTable = new DataTable();
                        employeeAdapter.Fill(employeeTable);
                        ViewModel = new EmployeeViewModel(employeeTable);
                        ((EmployeeViewModel)ViewModel).ColumnStatusFilter = "Enabled";
                        break;
                    case DefinedViews.BuildingView:
                        buildingTable = new DataTable();
                        buildingAdapter.Fill(buildingTable);
                        ViewModel = new BuildingViewModel(buildingTable);
                        break;
                }

                RaisePropertyChanged("Group");
                GroupIndex = GroupIndex;

                HiddenUserSystem = HiddenUserSystem;
            }
        }

        private RelayCommand<string> viewCommand;
        public RelayCommand<string> ViewCommand
        {
            get
            {
                return viewCommand = new RelayCommand<string>((pararameters) => ChangeView(pararameters));
            }
        }
        private void ChangeView(string pararameters)
        {
            switch (pararameters)
            {
                case "EquipmentView":
                    View = DefinedViews.EquipmentView;
                    break;
                case "EmployeeView":
                    View = DefinedViews.EmployeeView;
                    break;
                case "BuildingView":
                    View = DefinedViews.BuildingView;
                    break;
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand = new RelayCommand(() => Remove());
            }
        }
        private void Remove()
        {
            switch (View)
            {
                case DefinedViews.BuildingView:
                    RemoveBuilding();
                    break;
                case DefinedViews.EmployeeView:
                    RemoveEmployee();
                    break;
                case DefinedViews.EquipmentView:
                    break;
            }
        }
        private void RemoveBuilding()
        {
            string deleteBuildingSql = "DELETE FROM BUILDING WHERE NAME = @Name";
            string name = ((BuildingViewModel)ViewModel).SelectedBuilding.Name;

            WpfMessageBox messageBox;

            messageBox = new WpfMessageBox("Information", "Warning: this cannot be undone.", MessageBoxButton.YesNo, MessageBoxImage.Information, new WpfMessageBoxProperties()
            {
                Header = "Remove '" + name + "' building ?",
                ButtonYesText = "Yes, remove building",
                ButtonNoText = "Cancel, keep building",
            });
            messageBox.ShowDialog();

            if (messageBox.Result == WpfMessageBoxResult.Yes)
            {
                try
                {
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand command = new FbCommand(deleteBuildingSql, connection, transaction);
                    command.Parameters.Add("@Name", FbDbType.VarChar).Value = name;
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    ((BuildingViewModel)ViewModel).RemoveBuilding(name);
                }
                catch (Exception e)
                {
                    messageBox = new WpfMessageBox("Error #0001", "Error removing building from list.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                    {
                        Details = "Error #0001" + '\n' + '\n' + e.ToString(),
                    });
                    messageBox.ShowDialog();
                }
            }
        }
        private void RemoveEmployee()
        {
            string deleteEmployeeSql = "DELETE FROM EMPLOYEE WHERE ID = @ID";
            string id = ((EmployeeViewModel)ViewModel).SelectedEmployee.ID;
            string name = ((EmployeeViewModel) ViewModel).SelectedEmployee.Name;

            WpfMessageBox messageBox;

            if (((EmployeeViewModel)ViewModel).SelectedIndexes == 1)
            {
                if (name == "Guest" || name == "Admin")
                {
                    messageBox = new WpfMessageBox("Information", "The system user cannot be removed.", MessageBoxButton.OK, MessageBoxImage.Information);
                    messageBox.ShowDialog();
                }
                else
                {
                    messageBox = new WpfMessageBox("Information", "Warning: this cannot be undone.", MessageBoxButton.YesNo, MessageBoxImage.Information, new WpfMessageBoxProperties()
                    {
                        Header = "Remove '" + name + "' employee ?",
                        ButtonYesText = "Yes, remove employee",
                        ButtonNoText = "Cancel, keep employee",
                    });
                    messageBox.ShowDialog();

                    if (messageBox.Result == WpfMessageBoxResult.Yes)
                    {
                        try
                        {
                            FbTransaction transaction = connection.BeginTransaction();
                            FbCommand command = new FbCommand(deleteEmployeeSql, connection, transaction);
                            command.Parameters.Add("@ID", FbDbType.VarChar).Value = id;
                            command.ExecuteNonQuery();
                            transaction.Commit();

                            ((EmployeeViewModel)ViewModel).RemoveEmployee(id);
                        }
                        catch (Exception e)
                        {
                            messageBox = new WpfMessageBox("Error #0003", "Error removing employee from list.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                            {
                                Details = "Error #0004" + '\n' + '\n' + e.ToString(),
                            });
                            messageBox.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                messageBox = new WpfMessageBox("Information", "Warning: this cannot be undone.", MessageBoxButton.YesNo, MessageBoxImage.Information, new WpfMessageBoxProperties()
                {
                    Header = "Remove employees ?",
                    ButtonYesText = "Yes, remove employees",
                    ButtonNoText = "Cancel, keep employees",
                });
                messageBox.ShowDialog();

                if (messageBox.Result == WpfMessageBoxResult.Yes)
                {
                    foreach (DataEmployee employee in ((EmployeeViewModel)ViewModel).SelectedEmployees)
                    {
                        id = employee.ID;
                        name = employee.Name;

                        if (name == "Guest" || name == "Admin")
                        {

                        }
                        else
                        {
                            try
                            {
                                FbTransaction transaction = connection.BeginTransaction();
                                FbCommand command = new FbCommand(deleteEmployeeSql, connection, transaction);
                                command.Parameters.Add("@ID", FbDbType.VarChar).Value = id;
                                command.ExecuteNonQuery();
                                transaction.Commit();

                                ((EmployeeViewModel)ViewModel).RemoveEmployee(id);
                            }
                            catch (Exception e)
                            {
                                messageBox = new WpfMessageBox("Error #0003", "Error removing employee from list.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                                {
                                    Details = "Error #0004" + '\n' + '\n' + e.ToString(),
                                });
                                messageBox.ShowDialog();
                            }
                        }
                    }
                }
            }            
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand = new RelayCommand(() => Add());
            }
        }
        private void Add()
        {
            switch (View)
            {
                case DefinedViews.BuildingView:
                    AddBuilding();
                    break;
                case DefinedViews.EmployeeView:
                    AddEmployee();
                    break;
            }
        }
        private void AddBuilding()
        {
            BuildingWindow buildingWindow = new BuildingWindow(new DataBuilding(), GetBuildingsNames(), Clipboard, "Add new building", "Add");
            buildingWindow.ShowDialog();

            if (buildingWindow.Result == MessageBoxResult.OK)
            {
                string addBuildingSql = "INSERT INTO BUILDING(NAME, ADDRESS, CITY, POSTCODE, COUNTRY) VALUES(@Name, @Address, @City, @Postcode, @Country)";

                try
                {
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand command = new FbCommand(addBuildingSql, connection, transaction);
                    command.Parameters.Add("@Name", FbDbType.VarChar).Value = buildingWindow.Building.Name.TrimEndString();
                    command.Parameters.Add("@Address", FbDbType.VarChar).Value = buildingWindow.Building.Address.TrimEndString();
                    command.Parameters.Add("@City", FbDbType.VarChar).Value = buildingWindow.Building.City.TrimEndString();
                    command.Parameters.Add("@Postcode", FbDbType.VarChar).Value = buildingWindow.Building.Postcode.TrimEndString();
                    command.Parameters.Add("@Country", FbDbType.VarChar).Value = buildingWindow.Building.Country.TrimEndString();
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    WpfMessageBox messageBox = new WpfMessageBox("Error #0002", "Error adding building to list.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                    {
                        Details = "Error #0002" + '\n' + '\n' + e.ToString(),
                    });
                    messageBox.ShowDialog();

                    return;
                }

                ((BuildingViewModel)ViewModel).AddBuilding(buildingWindow.Building);
            }
        }
        private void AddEmployee()
        {
            EmployeeWindow employeeWindow = new EmployeeWindow(new DataEmployee(), GetEmployeesNames(), GetJobTitles(), GetBuildingsNames(), Clipboard, "Add employee", "Add");
            employeeWindow.ShowDialog();

            if (employeeWindow.Result == MessageBoxResult.OK)
            {
                string addEmployeeSql = "INSERT INTO EMPLOYEE(ID, NAME, JOB, BUILDING, ROOM, PHONE, EMAIL) VALUES(@Id, @Name, @Job, @Building, @Room, @Phone, @Email)";
                string addEmployeePermissionsSql = "INSERT INTO PERMISSIONS(ID, ACTIVE, ADD_USER, DELETE_USER, EDIT_USER, PRINT_USER, ADD_OWN_EQUIPMENT, DELETE_OWN_EQUIPMENT, ADD_OTHER_EQUIPMENT, DELETE_OTHER_EQUIPMENT, EDIT_OTHER_EQUIPMENT, VIEW_OTHER_EQUIPMENT, PRINT_OTHER_EQUIPMENT) VALUES(@Id, @Active, @AddUser, @DeleteUser, @EditUser, @PrintUser, @AddOwnEquipment, @DeleteOwnEquipment, @AddOtherEquipment, @DeleteOtherEquipment, @EditOtherEquipment, @ViewOtherEquipment, @PrintOtherEquipment)";

                employeeWindow.Employee.ID = Guid.NewGuid().ToString("D");

                try
                {
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand command = new FbCommand(addEmployeeSql, connection, transaction);
                    command.Parameters.Add("@Id", FbDbType.VarChar).Value = employeeWindow.Employee.ID;
                    command.Parameters.Add("@Name", FbDbType.VarChar).Value = employeeWindow.Employee.Name.TrimEndString();
                    command.Parameters.Add("@Job", FbDbType.VarChar).Value = employeeWindow.Employee.Job.TrimEndString();
                    command.Parameters.Add("@Building", FbDbType.VarChar).Value = employeeWindow.Employee.Building.TrimEndString();
                    command.Parameters.Add("@Room", FbDbType.VarChar).Value = employeeWindow.Employee.Room.TrimEndString();
                    command.Parameters.Add("@Phone", FbDbType.VarChar).Value = employeeWindow.Employee.Phone.TrimEndString();
                    command.Parameters.Add("@Email", FbDbType.VarChar).Value = employeeWindow.Employee.Email.TrimEndString();
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    WpfMessageBox messageBox = new WpfMessageBox("Error #0006", "Error adding employee to list.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                    {
                        Details = "Error #0006" + '\n' + '\n' + e.ToString(),
                    });
                    messageBox.ShowDialog();

                    return;
                }

                try
                {
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand command = new FbCommand(addEmployeePermissionsSql, connection, transaction);
                    command.Parameters.Add("@Id", FbDbType.VarChar).Value = employeeWindow.Employee.ID;
                    command.Parameters.Add("@Active", FbDbType.Boolean).Value = employeeWindow.Employee.Active;
                    command.Parameters.Add("@AddUser", FbDbType.Boolean).Value = employeeWindow.Employee.AddUser;
                    command.Parameters.Add("@EditUser", FbDbType.Boolean).Value = employeeWindow.Employee.EditUser;
                    command.Parameters.Add("@DeleteUser", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteUser;
                    command.Parameters.Add("@PrintUser", FbDbType.Boolean).Value = employeeWindow.Employee.PrintUser;
                    command.Parameters.Add("@AddOwnEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.AddOwnEquipment;
                    command.Parameters.Add("@DeleteOwnEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteOwnEquipment;
                    command.Parameters.Add("@AddOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.AddOtherEquipment;
                    command.Parameters.Add("@DeleteOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteOtherEquipment;
                    command.Parameters.Add("@EditOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.EditOtherEquipment;
                    command.Parameters.Add("@ViewOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.ViewOtherEquipment;
                    command.Parameters.Add("@PrintOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.PrintOtherEquipment;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    WpfMessageBox messageBox = new WpfMessageBox("Error #0006", "Error adding employee to list.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                    {
                        Details = "Error #0006" + '\n' + '\n' + e.ToString(),
                    });
                    messageBox.ShowDialog();

                    return;
                }

                ((EmployeeViewModel)ViewModel).AddEmployee(employeeWindow.Employee);
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand = new RelayCommand(() => Edit());
            }
        }
        private void Edit()
        {
            switch (View)
            {
                case DefinedViews.BuildingView:
                    EditBuilding();
                    break;
                case DefinedViews.EmployeeView:
                    EditEmployee();
                    break;
            }
        }
        private void EditBuilding()
        {
            DataBuilding editedBuilding = ((BuildingViewModel)ViewModel).SelectedBuilding;
            DataBuilding building = new DataBuilding()
            {
                Name = editedBuilding.Name,
                Address = editedBuilding.Address,
                City = editedBuilding.City,
                Country = editedBuilding.Country,
                Postcode = editedBuilding.Postcode
            };
            
            BuildingWindow buildingWindow = new BuildingWindow(building, GetBuildingsNames(), Clipboard, "Edit building", "Edit");
            buildingWindow.ShowDialog();

            if (buildingWindow.Result == MessageBoxResult.OK)
            {
                try
                {
                    if (building.Name == buildingWindow.OldName)
                    {
                        string updateBuildingSql = "UPDATE BUILDING SET ADDRESS=@Address, CITY=@City, POSTCODE=@Postcode, COUNTRY=@Country WHERE NAME=@Name";

                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand command = new FbCommand(updateBuildingSql, connection, transaction);
                        command.Parameters.Add("@Name", FbDbType.VarChar).Value = buildingWindow.Building.Name.TrimEndString();
                        command.Parameters.Add("@Address", FbDbType.VarChar).Value = buildingWindow.Building.Address.TrimEndString();
                        command.Parameters.Add("@City", FbDbType.VarChar).Value = buildingWindow.Building.City.TrimEndString();
                        command.Parameters.Add("@Postcode", FbDbType.VarChar).Value = buildingWindow.Building.Postcode.TrimEndString();
                        command.Parameters.Add("@Country", FbDbType.VarChar).Value = buildingWindow.Building.Country.TrimEndString();
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    else
                    {
                        string updateBuildingSql = "UPDATE BUILDING SET NAME=@Name, ADDRESS=@Address, CITY=@City, POSTCODE=@Postcode, COUNTRY=@Country WHERE NAME=@OldName";

                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand command = new FbCommand(updateBuildingSql, connection, transaction);
                        command.Parameters.Add("@OldName", FbDbType.VarChar).Value = buildingWindow.OldName;
                        command.Parameters.Add("@Name", FbDbType.VarChar).Value = buildingWindow.Building.Name.TrimEndString();
                        command.Parameters.Add("@Address", FbDbType.VarChar).Value = buildingWindow.Building.Address.TrimEndString();
                        command.Parameters.Add("@City", FbDbType.VarChar).Value = buildingWindow.Building.City.TrimEndString();
                        command.Parameters.Add("@Postcode", FbDbType.VarChar).Value = buildingWindow.Building.Postcode.TrimEndString();
                        command.Parameters.Add("@Country", FbDbType.VarChar).Value = buildingWindow.Building.Country.TrimEndString();
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }

                    ((BuildingViewModel)ViewModel).UpdateBuilding(buildingWindow.Building);
                }
                catch (Exception e)
                {
                    WpfMessageBox messageBox = new WpfMessageBox("Error #0002", "Error editing building.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                    {
                        Details = "Error #0003" + '\n' + '\n' + e.ToString(),
                    });
                    messageBox.ShowDialog();
                }
            }
        }
        private void EditEmployee()
        {
            string id = ((EmployeeViewModel)ViewModel).SelectedEmployee.ID;
            string name = ((EmployeeViewModel)ViewModel).SelectedEmployee.Name;
            string updateEmployeeSql = "UPDATE EMPLOYEE SET NAME=@Name, JOB=@Job, BUILDING=@Building, ROOM=@Room, PHONE=@Phone, EMAIL=@Email WHERE ID = @Id";
            string updateEmployeePermissionsSql = "UPDATE PERMISSIONS SET ADD_USER=@AddUser, DELETE_USER=@DeleteUser, EDIT_USER=@EditUser, PRINT_USER=@PrintUser, ADD_OWN_EQUIPMENT=@AddOwnEquipment, DELETE_OWN_EQUIPMENT=@DeleteOwnEquipment, ADD_OTHER_EQUIPMENT=@AddOtherEquipment, DELETE_OTHER_EQUIPMENT=@DeleteOtherEquipment, EDIT_OTHER_EQUIPMENT=@EditOtherEquipment, VIEW_OTHER_EQUIPMENT=@ViewOtherEquipment, PRINT_OTHER_EQUIPMENT=@PrintOtherEquipment WHERE ID = @Id";

            DataEmployee employeeToEdit = (((EmployeeViewModel)ViewModel).SelectedEmployees).Values();

            EmployeeWindow employeeWindow = new EmployeeWindow(employeeToEdit, GetEmployeesNames(), GetJobTitles(), GetBuildingsNames(), Clipboard, "Edit employee", "Edit");
            employeeWindow.ShowDialog();

            if (employeeWindow.Result == MessageBoxResult.OK)
            {
                if (((EmployeeViewModel)ViewModel).SelectedIndexes == 1)
                {
                    employeeWindow.Employee.ID = id;

                    try
                    {
                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand command = new FbCommand(updateEmployeeSql, connection, transaction);
                        command.Parameters.Add("@Id", FbDbType.VarChar).Value = id;
                        command.Parameters.Add("@Name", FbDbType.VarChar).Value = employeeWindow.Employee.Name.TrimEndString();
                        command.Parameters.Add("@Job", FbDbType.VarChar).Value = employeeWindow.Employee.Job.TrimEndString();
                        command.Parameters.Add("@Building", FbDbType.VarChar).Value = employeeWindow.Employee.Building.TrimEndString();
                        command.Parameters.Add("@Room", FbDbType.VarChar).Value = employeeWindow.Employee.Room.TrimEndString();
                        command.Parameters.Add("@Phone", FbDbType.VarChar).Value = employeeWindow.Employee.Phone.TrimEndString();
                        command.Parameters.Add("@Email", FbDbType.VarChar).Value = employeeWindow.Employee.Email.TrimEndString();
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        WpfMessageBox messageBox = new WpfMessageBox("Error #0005", "Error editing employee.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                        {
                            Details = "Error #0005" + '\n' + '\n' + e.ToString(),
                        });
                        messageBox.ShowDialog();

                        return;
                    }

                    try
                    {
                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand command = new FbCommand(updateEmployeePermissionsSql, connection, transaction);
                        command.Parameters.Add("@Id", FbDbType.VarChar).Value = id;
                        command.Parameters.Add("@Active", FbDbType.Boolean).Value = employeeWindow.Employee.Active;
                        command.Parameters.Add("@AddUser", FbDbType.Boolean).Value = employeeWindow.Employee.AddUser;
                        command.Parameters.Add("@EditUser", FbDbType.Boolean).Value = employeeWindow.Employee.EditUser;
                        command.Parameters.Add("@DeleteUser", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteUser;
                        command.Parameters.Add("@PrintUser", FbDbType.Boolean).Value = employeeWindow.Employee.PrintUser;
                        command.Parameters.Add("@AddOwnEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.AddOwnEquipment;
                        command.Parameters.Add("@DeleteOwnEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteOwnEquipment;
                        command.Parameters.Add("@AddOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.AddOtherEquipment;
                        command.Parameters.Add("@DeleteOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteOtherEquipment;
                        command.Parameters.Add("@EditOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.EditOtherEquipment;
                        command.Parameters.Add("@ViewOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.ViewOtherEquipment;
                        command.Parameters.Add("@PrintOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.PrintOtherEquipment;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        WpfMessageBox messageBox = new WpfMessageBox("Error #0005", "Error editing employee.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                        {
                            Details = "Error #0005" + '\n' + '\n' + e.ToString(),
                        });
                        messageBox.ShowDialog();

                        return;
                    }

                    ((EmployeeViewModel)ViewModel).UpdateEmployee(employeeWindow.Employee);
                }
                else
                {
                    foreach (DataEmployee employee in ((EmployeeViewModel)ViewModel).SelectedEmployees)
                    {
                        name = employee.Name;
                        id = employee.ID;

                        StringBuilder sbEmployee = new StringBuilder("UPDATE EMPLOYEE SET ");

                        if (employeeWindow.Employee.Name != "[...]" && name != "Guest" && name != "Admin")
                        {
                            sbEmployee.Append("NAME=@Name, ");
                            employee.Name = employeeWindow.Employee.Name;
                        }

                        if (employeeWindow.Employee.Job != "[...]")
                        {
                            sbEmployee.Append("JOB=@Job, ");
                            employee.Job = employeeWindow.Employee.Job;
                        }

                        if (employeeWindow.Employee.Building != "[...]")
                        {
                            sbEmployee.Append("BUILDING=@Building, ");
                            employee.Building = employeeWindow.Employee.Building;
                        }

                        if (employeeWindow.Employee.Room != "[...]")
                        {
                            sbEmployee.Append("ROOM=@Room, ");
                            employee.Room = employeeWindow.Employee.Room;
                        }

                        if (employeeWindow.Employee.Phone != "[...]")
                        {
                            sbEmployee.Append("PHONE=@Phone, ");
                            employee.Phone = employeeWindow.Employee.Phone;
                        }

                        if (employeeWindow.Employee.Email != "[...]")
                        {
                            sbEmployee.Append("EMAIL=@Email, ");
                            employee.Email = employeeWindow.Employee.Email;
                        }

                        if (sbEmployee.ToString() != "UPDATE EMPLOYEE SET ")
                        {
                            sbEmployee.Remove(sbEmployee.Length - 2, 1);
                            sbEmployee.Append("WHERE ID = @Id");

                            updateEmployeeSql = sbEmployee.ToString();

                            try
                            {
                                FbTransaction transaction = connection.BeginTransaction();
                                FbCommand command = new FbCommand(updateEmployeeSql, connection, transaction);
                                command.Parameters.Add("@Id", FbDbType.VarChar).Value = id;
                                command.Parameters.Add("@Name", FbDbType.VarChar).Value = employeeWindow.Employee.Name.TrimEndString();
                                command.Parameters.Add("@Job", FbDbType.VarChar).Value = employeeWindow.Employee.Job.TrimEndString();
                                command.Parameters.Add("@Building", FbDbType.VarChar).Value = employeeWindow.Employee.Building.TrimEndString();
                                command.Parameters.Add("@Room", FbDbType.VarChar).Value = employeeWindow.Employee.Room.TrimEndString();
                                command.Parameters.Add("@Phone", FbDbType.VarChar).Value = employeeWindow.Employee.Phone.TrimEndString();
                                command.Parameters.Add("@Email", FbDbType.VarChar).Value = employeeWindow.Employee.Email.TrimEndString();
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                            catch (Exception e)
                            {
                                WpfMessageBox messageBox = new WpfMessageBox("Error #0005", "Error editing employee.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                                {
                                    Details = "Error #0005" + '\n' + '\n' + e.ToString(),
                                });
                                messageBox.ShowDialog();

                                return;
                            }
                        }

                        StringBuilder sbEmployeePermissions = new StringBuilder("UPDATE PERMISSIONS SET ");

                        if (employeeWindow.Employee.Status != "[...]")
                        {
                            sbEmployeePermissions.Append("ACTIVE=@Active, ");
                            if (employeeWindow.Employee.Active)
                            {
                                employee.Status = "Enabled";
                            }
                            else
                            {
                                employee.Status = "Disabled";
                            }
                        }

                        if (employeeWindow.Employee.AddUser != null)
                        {
                            sbEmployeePermissions.Append("ADD_USER=@AddUser, ");
                            employee.AddUser = employeeWindow.Employee.AddUser;
                        }

                        if (employeeWindow.Employee.EditUser != null)
                        {
                            sbEmployeePermissions.Append("EDIT_USER=@EditUser, ");
                            employee.EditUser = employeeWindow.Employee.EditUser;
                        }

                        if (employeeWindow.Employee.DeleteUser != null)
                        {
                            sbEmployeePermissions.Append("DELETE_USER=@DeleteUser, ");
                            employee.DeleteUser = employeeWindow.Employee.DeleteUser;
                        }

                        if (employeeWindow.Employee.PrintUser != null)
                        {
                            sbEmployeePermissions.Append("PRINT_USER=@PrintUser, ");
                            employee.PrintUser = employeeWindow.Employee.PrintUser;
                        }

                        if (employeeWindow.Employee.AddOwnEquipment != null)
                        {
                            sbEmployeePermissions.Append("ADD_OWN_EQUIPMENT=@AddOwnEquipment, ");
                            employee.AddOwnEquipment = employeeWindow.Employee.AddOwnEquipment;
                        }

                        if (employeeWindow.Employee.DeleteOwnEquipment != null)
                        {
                            sbEmployeePermissions.Append("DELETE_OWN_EQUIPMENT=@DeleteOwnEquipment, ");
                            employee.DeleteOwnEquipment = employeeWindow.Employee.DeleteOwnEquipment;
                        }

                        if (employeeWindow.Employee.AddOtherEquipment != null)
                        {
                            sbEmployeePermissions.Append("ADD_OTHER_EQUIPMENT=@AddOtherEquipment, ");
                            employee.AddOtherEquipment = employeeWindow.Employee.AddOtherEquipment;
                        }

                        if (employeeWindow.Employee.DeleteOtherEquipment != null)
                        {
                            sbEmployeePermissions.Append("DELETE_OTHER_EQUIPMENT=@DeleteOtherEquipment, ");
                            employee.DeleteOtherEquipment = employeeWindow.Employee.DeleteOtherEquipment;
                        }

                        if (employeeWindow.Employee.EditOtherEquipment != null)
                        {
                            sbEmployeePermissions.Append("EDIT_OTHER_EQUIPMENT=@EditOtherEquipment, ");
                            employee.EditOtherEquipment = employeeWindow.Employee.EditOtherEquipment;
                        }

                        if (employeeWindow.Employee.ViewOtherEquipment != null)
                        {
                            sbEmployeePermissions.Append("VIEW_OTHER_EQUIPMENT=@ViewOtherEquipment, ");
                            employee.ViewOtherEquipment = employeeWindow.Employee.ViewOtherEquipment;
                        }

                        if (employeeWindow.Employee.PrintOtherEquipment != null)
                        {
                            sbEmployeePermissions.Append("PRINT_OTHER_EQUIPMENT=@PrintOtherEquipment, ");
                            employee.PrintOtherEquipment = employeeWindow.Employee.PrintOtherEquipment;
                        }

                        if (sbEmployeePermissions.ToString() != "UPDATE PERMISSIONS SET ")
                        {
                            sbEmployeePermissions.Remove(sbEmployeePermissions.Length - 2, 1);
                            sbEmployeePermissions.Append("WHERE ID = @Id");

                            updateEmployeePermissionsSql = sbEmployeePermissions.ToString();

                            try
                            {
                                FbTransaction transaction = connection.BeginTransaction();
                                FbCommand command = new FbCommand(updateEmployeePermissionsSql, connection, transaction);
                                command.Parameters.Add("@Id", FbDbType.VarChar).Value = id;
                                command.Parameters.Add("@Active", FbDbType.Boolean).Value = employeeWindow.Employee.Active;
                                command.Parameters.Add("@AddUser", FbDbType.Boolean).Value = employeeWindow.Employee.AddUser;
                                command.Parameters.Add("@EditUser", FbDbType.Boolean).Value = employeeWindow.Employee.EditUser;
                                command.Parameters.Add("@DeleteUser", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteUser;
                                command.Parameters.Add("@PrintUser", FbDbType.Boolean).Value = employeeWindow.Employee.PrintUser;
                                command.Parameters.Add("@AddOwnEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.AddOwnEquipment;
                                command.Parameters.Add("@DeleteOwnEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteOwnEquipment;
                                command.Parameters.Add("@AddOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.AddOtherEquipment;
                                command.Parameters.Add("@DeleteOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.DeleteOtherEquipment;
                                command.Parameters.Add("@EditOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.EditOtherEquipment;
                                command.Parameters.Add("@ViewOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.ViewOtherEquipment;
                                command.Parameters.Add("@PrintOtherEquipment", FbDbType.Boolean).Value = employeeWindow.Employee.PrintOtherEquipment;
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                            catch (Exception e)
                            {
                                WpfMessageBox messageBox = new WpfMessageBox("Error #0005", "Error editing employee.", MessageBoxButton.OK, MessageBoxImage.Error, new WpfMessageBoxProperties()
                                {
                                    Details = "Error #0005" + '\n' + '\n' + e.ToString(),
                                });
                                messageBox.ShowDialog();
                            }
                        }

                        ((EmployeeViewModel)ViewModel).UpdateEmployee(employee);
                    }
                }

            }
        }

        private RelayCommand<string> colorOfWarningCommand;
        public RelayCommand<string> ColorOfWarningCommand
        {
            get
            {
                return colorOfWarningCommand = new RelayCommand<string>((pararameters) => SetColorOfWarning(pararameters));
            }
        }
        private void SetColorOfWarning(string pararameters)
        {
            Color initialColor = Colors.Transparent;

            switch (pararameters)
            {
                case "NullEmployee":
                    initialColor = NullEmployeeColor.Color;
                    break;
                case "ActiveEmployee":
                    initialColor = ActiveEmployeeColor.Color;
                    break;
                case "IncorrectReviewDate":
                    initialColor = IncorrectReviewDateColor.Color;
                    break;
                case "IncorrectLegalizationDate":
                    initialColor = IncorrectLegalizationDateColor.Color;
                    break;
                case "PostedWorker":
                    initialColor = PostedWorkerColor.Color;
                    break;
                case "Alarm":
                    initialColor = AlarmColor.Color;
                    break;
            }

            ColorPickerDialog dialog = new ColorPickerDialog(initialColor);

            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                switch (pararameters)
                {
                    case "NullEmployee":
                        NullEmployeeColor = new SolidColorBrush(dialog.Color);
                        break;
                    case "ActiveEmployee":
                        ActiveEmployeeColor = new SolidColorBrush(dialog.Color);
                        break;
                    case "IncorrectReviewDate":
                        IncorrectReviewDateColor = new SolidColorBrush(dialog.Color);
                        break;
                    case "IncorrectLegalizationDate":
                        IncorrectLegalizationDateColor = new SolidColorBrush(dialog.Color);
                        break;
                    case "PostedWorker":
                        PostedWorkerColor = new SolidColorBrush(dialog.Color);
                        break;
                    case "Alarm":
                        AlarmColor = new SolidColorBrush(dialog.Color);
                        break;

                }
            }
        }

        private Visibility databseToolBar;
        public Visibility DatabseToolBar
        {
            get
            {
                return databseToolBar;
            }

            set
            {
                databseToolBar = value;
                RaisePropertyChanged("DatabseToolBar");
            }
        }

        private Visibility editToolBar;
        public Visibility EditToolBar
        {
            get
            {
                return editToolBar;
            }

            set
            {
                editToolBar = value;
                RaisePropertyChanged("EditToolBar");
            }
        }

        private Boolean hiddenUserSystem;
        public Boolean HiddenUserSystem
        {
            get
            {
                return hiddenUserSystem;
            }

            set
            {
                hiddenUserSystem = value;
                RaisePropertyChanged("HiddenUserSystem");

                if (hiddenUserSystem)
                {
                    EmployeesStatus.Remove("Admin");
                    EmployeesStatus.Remove("Guest");
                }
                else
                {
                    EmployeesStatus.Add("Admin");
                    EmployeesStatus.Add("Guest");
                }

                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        ((EmployeeViewModel)ViewModel).HiddenSystemUser = value;
                        break;
                    case DefinedViews.EquipmentView:
                        ((EquipmentViewModel)ViewModel).EmployeesStatus = EmployeesStatus;
                        break;
                }
            }
        }

        private List<EmployeeStatus> EmployeesStatus { get; set; }

        private readonly String[] groupEmployee = new String[] {  String.Empty,
                                                                "Job title",
                                                                "Building",
                                                                "Status", };

        private readonly String[] groupBuilding = new String[] {  String.Empty,
                                                                "Country",
                                                                "City", };

        private readonly String[] groupEquipment = new String[] {  String.Empty,
                                                                "Employee",
                                                                "Producer",
                                                                "Norm",
                                                                "Group",
                                                                "Condition",
                                                                "Building",
                                                                "Review Date",
                                                                "Legalization Date", };

        public String[] Group
        {
            get
            {
                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        return groupEmployee;
                    case DefinedViews.BuildingView:
                        return groupBuilding;
                    case DefinedViews.EquipmentView:
                        return groupEquipment;
                    default:
                        return new string[] { };
                }
            }
        }

        private int groupEmployeeIndex;
        private int groupBuildingIndex;
        private int groupEquipmentIndex;
        public int GroupIndex
        {
            get
            {
                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        return groupEmployeeIndex;
                    case DefinedViews.BuildingView:
                        return groupBuildingIndex;
                    case DefinedViews.EquipmentView:
                        return groupEquipmentIndex;
                    default:
                        return 0;
                }
            }

            set
            {
                if (value == -1)
                {
                    return;
                }

                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        groupEmployeeIndex = value;
                        ((EmployeeViewModel)ViewModel).Group = groupEmployee[groupEmployeeIndex];
                        ((EmployeeViewModel)ViewModel).SelectedIndex = -1;
                        break;
                    case DefinedViews.BuildingView:
                        groupBuildingIndex = value;
                        ((BuildingViewModel)ViewModel).Group = groupBuilding[groupBuildingIndex];
                        ((BuildingViewModel)ViewModel).SelectedIndex = -1;
                        break;
                    case DefinedViews.EquipmentView:
                        groupEquipmentIndex = value;
                        ((EquipmentViewModel)ViewModel).Group = groupEquipment[groupEquipmentIndex];
                        ((EquipmentViewModel)ViewModel).SelectedIndex = -1;
                        break;
                }

                RaisePropertyChanged("GroupIndex");
            }
        }

        private SolidColorBrush activeEmployeeColor;
        public SolidColorBrush ActiveEmployeeColor
        {
            get
            {
                return activeEmployeeColor;
            }

            set
            {
                activeEmployeeColor = value;
                RaisePropertyChanged("ActiveEmployeeColor");

                switch (View)
                {
                    case DefinedViews.EquipmentView:
                        ((EquipmentViewModel)ViewModel).ActiveEmployeeColor = value;
                        break;
                }
            }
        }

        private SolidColorBrush nullEmployeeColor;
        public SolidColorBrush NullEmployeeColor
        {
            get
            {
                return nullEmployeeColor;
            }

            set
            {
                nullEmployeeColor = value;
                RaisePropertyChanged("NullEmployeeColor");

                switch (View)
                {
                    case DefinedViews.EquipmentView:
                        ((EquipmentViewModel)ViewModel).NullEmployeeColor = value;
                        break;
                }
            }
        }

        private SolidColorBrush incorrectReviewDateColor;
        public SolidColorBrush IncorrectReviewDateColor
        {
            get
            {
                return incorrectReviewDateColor;
            }

            set
            {
                incorrectReviewDateColor = value;
                RaisePropertyChanged("IncorrectReviewDateColor");

                switch (View)
                {
                    case DefinedViews.EquipmentView:
                        ((EquipmentViewModel)ViewModel).IncorrectReviewDateColor = value;
                        break;
                }
            }
        }

        private SolidColorBrush incorrectLegalizationDateColor;
        public SolidColorBrush IncorrectLegalizationDateColor
        {
            get
            {
                return incorrectLegalizationDateColor;
            }

            set
            {
                incorrectLegalizationDateColor = value;
                RaisePropertyChanged("IncorrectLegalizationDateColor");

                switch (View)
                {
                    case DefinedViews.EquipmentView:
                        ((EquipmentViewModel)ViewModel).IncorrectLegalizationDateColor = value;
                        break;
                }
            }
        }

        private SolidColorBrush postedWorkerColor;
        public SolidColorBrush PostedWorkerColor
        {
            get
            {
                return postedWorkerColor;
            }

            set
            {
                postedWorkerColor = value;
                RaisePropertyChanged("PostedWorkerColor");

                switch (View)
                {
                    case DefinedViews.EquipmentView:
                        ((EquipmentViewModel)ViewModel).PostedWorkerColor = value;
                        break;
                }
            }
        }

        private SolidColorBrush alarmColor;
        public SolidColorBrush AlarmColor
        {
            get
            {
                return alarmColor;
            }

            set
            {
                alarmColor = value;
                RaisePropertyChanged("AlarmColor");

                switch (View)
                {
                    case DefinedViews.EquipmentView:
                        ((EquipmentViewModel)ViewModel).AlarmColor = value;
                        break;
                }
            }
        }

        private void SetSelectedIndex(SelectedIndexMessage message)
        {
            if (message.View == View)
            {
                SelectedIndex = message.Index;
            }
        }
        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    RaisePropertyChanged("SelectedIndex");
                }
            }
        }

        private Clipboard Clipboard { get; set; }

        private FbDataAdapter buildingAdapter;
        private DataTable buildingTable;

        private FbDataAdapter equipmentAdapter;
        private DataTable equipmentTable;

        private FbDataAdapter employeeAdapter;
        private DataTable employeeTable;

        private FbDataAdapter employeeNameAdapter;
        private DataTable employeeNameTable;

        private FbDataAdapter employeeJobAdapter;
        private DataTable employeeJobTable;

        private FbDataAdapter buildingNameAdapter;
        private DataTable buildingNameTable;

        public MainViewModel()
        {
            DatabseToolBar = Visibility.Visible;
            EditToolBar = Visibility.Visible;

            string databaseName = Path.Combine(Environment.CurrentDirectory, @"DB\", "EQUIPMENT.FDB");

            FbConnectionStringBuilder stringConnection = new FbConnectionStringBuilder()
            {
                UserID = "SYSDBA",
                Password = "masterkey",
                //UserID = "Admin",
                //Password = "0f8fad5b-d9cb-469f-a165-70867728950e",
                Database = databaseName,
                DataSource = "localhost",
                Port = 3050,
                Charset = "WIN1250",
            };

            connection = new FbConnection(stringConnection.ToString());
            connection.Open();

            equipmentAdapter = new FbDataAdapter("SELECT * FROM EQUIPMENTVIEW", connection);
            employeeAdapter = new FbDataAdapter("SELECT * FROM EMPLOYEEVIEW", connection);
            employeeNameAdapter = new FbDataAdapter("SELECT NAME FROM EMPLOYEE", connection);
            employeeJobAdapter = new FbDataAdapter("SELECT TITLE FROM JOB", connection);

            buildingAdapter = new FbDataAdapter("SELECT * FROM BUILDING", connection);
            buildingNameAdapter = new FbDataAdapter("SELECT NAME FROM BUILDING", connection);

            employeeNameTable = new DataTable();
            employeeAdapter.Fill(employeeNameTable);

            employeeTable = new DataTable();
            employeeAdapter.Fill(employeeTable);
            EmployeesStatus = new List<EmployeeStatus>();
            foreach (DataRow row in employeeTable.Rows)
            {
                EmployeesStatus.Add(new EmployeeStatus()
                {
                    Name = row["Name"].ToString(),
                    Active = row["ACTIVE"].ToBoolean(),
                });
            }


            View = DefinedViews.EquipmentView;
            //View = DefinedViews.EmployeeView;

            ActiveEmployeeColor = Brushes.Transparent;
            NullEmployeeColor = Brushes.Transparent;
            IncorrectReviewDateColor = Brushes.Red;
            IncorrectLegalizationDateColor = Brushes.Red;
            PostedWorkerColor = Brushes.Transparent;
            AlarmColor = Brushes.MistyRose;

            Messenger.Default.Register<SelectedIndexMessage>(this, MessageType.PropertyChangedMessage, SetSelectedIndex);

            Clipboard = new Clipboard();
        }

        ObservableCollection<string> GetBuildingsNames()
        {
            ObservableCollection<string> BuildingsNames = new ObservableCollection<string>();

            buildingNameTable = new DataTable();
            buildingAdapter.Fill(buildingNameTable);
            
            foreach (DataRow row in buildingNameTable.Rows)
            {
                BuildingsNames.Add(row["Name"].ToString());
            }

            return BuildingsNames;
        }

        ObservableCollection<string> GetJobTitles()
        {
            ObservableCollection<string> JobTitles = new ObservableCollection<string>();

            employeeJobTable = new DataTable();
            employeeJobAdapter.Fill(employeeJobTable);
            
            foreach (DataRow row in employeeJobTable.Rows)
            {
                JobTitles.Add(row["Title"].ToString());
            }

            return JobTitles;
        }

        ObservableCollection<string> GetEmployeesNames()
        {
            ObservableCollection<string> EmployeesNames = new ObservableCollection<string>();

            employeeNameTable = new DataTable();
            employeeNameAdapter.Fill(employeeNameTable);

            foreach (DataRow row in employeeNameTable.Rows)
            {
                EmployeesNames.Add(row["Name"].ToString());
            }

            return EmployeesNames;
        }
    }
}
 