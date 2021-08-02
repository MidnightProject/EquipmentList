using EquipmentList.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EquipmentList.Converters
{
    public class ListToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[0] == DependencyProperty.UnsetValue)
            {
                return String.Empty;
            }

            int row = (int)values[1];

            if (row == -1)
            {
                return String.Empty;
            }

            string value = String.Empty;

            if (values[2].ToString() == "Employee")
            {
                var list = (IList<DataEmployee>)values[0];

                switch (parameter.ToString())
                {
                    case "ADDRESS":
                        value = list[row].Address;
                        break;
                    case "POSTCODE":
                        value = list[row].Postcode;
                        break;
                    case "CITY":
                        value = list[row].City;
                        break;
                    case "COUNTRY":
                        value = list[row].Country;
                        break;
                }

                return value.ToString();
            }

            if (values[2].ToString() == "Equipment")
            {
                var list = (IList<DataEquipment>)values[0];

                switch (parameter.ToString())
                {
                    case "DESCRIPTION":
                        value = list[row].Description;
                        break;
                    case "COMMENTS":
                        value = list[row].Comments;
                        break;
                    case "Room":
                        value = list[row].Room;
                        break;
                    case "PRODUCTION_DATE":
                        if (list[row].ProductionDate == new DateTime())
                        {
                            break;
                        }
                        value = "Production date: " + list[row].ProductionDate;
                        break;
                    case "WARRANTY_DATE":
                        if (list[row].WarrantyDate == new DateTime())
                        {
                            break;
                        }
                        value = "Warranty expiration date: " + list[row].WarrantyDate.ToShortDateString();
                        break;
                    case "REVIEW_DATE":
                        if (list[row].ReviewDate == new DateTime())
                        {
                            break;
                        }
                        value = "Date of next review: " + list[row].ReviewDate.ToShortDateString();
                        break;
                    case "LEGALIZATION_DATE":
                        if (list[row].LegalizationDate == new DateTime())
                        {
                            break;
                        }
                        value = "Date of next legalization: " + list[row].LegalizationDate.ToShortDateString();
                        break;
                    case "EMPLOYEE_NAME":
                        value = list[row].EmployeeName;
                        break;
                    case "BUILDING":
                        value = list[row].Building;
                        break;
                    case "COUNTRY":
                        value = list[row].Country;
                        break;
                    case "CITY":
                        value = list[row].City;
                        break;
                    case "ADDRESS":
                        value = list[row].Address;
                        break;
                    case "POSTCODE":
                        value = list[row].Postcode;
                        break;
                    case "EMPLOYEE_ROOM":
                        if (String.IsNullOrEmpty(list[row].EmployeeRoom))
                        {
                            break;
                        }
                        value = "[ " + list[row].EmployeeRoom + " ]";
                        break;
                    case "EMPLOYEE_PHONE":
                        value = list[row].EmployeePhone;
                        break;
                    case "EMPLOYEE_EMAIL":
                        value = list[row].EmployeeEmail;
                        break;
                    case "EMPLOYEE_BUILDING":
                        value = list[row].EmployeeBuilding;
                        break;
                    case "EMPLOYEE_BUILDING_COUNTRY":
                        value = list[row].EmployeeBuildingCountry;
                        break;
                    case "EMPLOYEE_BUILDING_CITY":
                        value = list[row].EmployeeBuildingCity;
                        break;
                    case "EMPLOYEE_BUILDING_ADDRESS":
                        value = list[row].EmployeeBuildingAddress;
                        break;
                    case "EMPLOYEE_BUILDING_POSTCODE":
                        value = list[row].EmployeeBuildingPostcode;
                        break;
                    case "PRODUCER_NAME":
                        value = list[row].ProducerName;
                        break;
                    case "PRODUCER_POSTCODE":
                        value = list[row].ProducerPostcode;
                        break;
                    case "PRODUCER_CITY":
                        value = list[row].ProducerCity;
                        break;
                    case "PRODUCER_ADDRESS":
                        value = list[row].ProducerAddress;
                        break;
                    case "PRODUCER_COUNTRY":
                        value = list[row].ProducerCountry;
                        break;
                    case "PRODUCER_PERSON":
                        value = list[row].ProducerPerson;
                        break;
                    case "PRODUCER_WWW":
                        value = list[row].ProducerWWW;
                        break;
                    case "PRODUCER_PHONE":
                        value = list[row].ProducerPhone;
                        break;
                    case "PRODUCER_EMAIL":
                        value = list[row].ProducerEmail;
                        break;
                    case "PROVIDER_NAME":
                        value = list[row].ProviderName;
                        break;
                    case "PROVIDER_POSTCODE":
                        value = list[row].ProviderPostcode;
                        break;
                    case "PROVIDER_CITY":
                        value = list[row].ProviderCity;
                        break;
                    case "PROVIDER_ADDRESS":
                        value = list[row].ProviderAddress;
                        break;
                    case "PROVIDER_COUNTRY":
                        value = list[row].ProviderCountry;
                        break;
                    case "PROVIDER_PERSON":
                        value = list[row].ProviderPerson;
                        break;
                    case "PROVIDER_WWW":
                        value = list[row].ProviderWWW;
                        break;
                    case "PROVIDER_PHONE":
                        value = list[row].ProviderPhone;
                        break;
                    case "PROVIDER_EMAIL":
                        value = list[row].ProviderEmail;
                        break;
                    case "SERVICE_NAME":
                        value = list[row].ServiceName;
                        break;
                    case "SERVICE_POSTCODE":
                        value = list[row].ServicePostcode;
                        break;
                    case "SERVICE_CITY":
                        value = list[row].ServiceCity;
                        break;
                    case "SERVICE_ADDRESS":
                        value = list[row].ServiceAddress;
                        break;
                    case "SERVICE_COUNTRY":
                        value = list[row].ServiceCountry;
                        break;
                    case "SERVICE_PERSON":
                        value = list[row].ServicePerson;
                        break;
                    case "SERVICE_WWW":
                        value = list[row].ServiceWWW;
                        break;
                    case "SERVICE_PHONE":
                        value = list[row].ServicePhone;
                        break;
                    case "SERVICE_EMAIL":
                        value = list[row].ServiceEmail;
                        break;
                    case "ATTESTATION_NAME":
                        value = list[row].AttestationName;
                        break;
                    case "ATTESTATION_POSTCODE":
                        value = list[row].AttestationPostcode;
                        break;
                    case "ATTESTATION_CITY":
                        value = list[row].AttestationCity;
                        break;
                    case "ATTESTATION_ADDRESS":
                        value = list[row].AttestationAddress;
                        break;
                    case "ATTESTATION_COUNTRY":
                        value = list[row].AttestationCountry;
                        break;
                    case "ATTESTATION_PERSON":
                        value = list[row].AttestationPerson;
                        break;
                    case "ATTESTATION_WWW":
                        value = list[row].AttestationWWW;
                        break;
                    case "ATTESTATION_PHONE":
                        value = list[row].AttestationPhone;
                        break;
                    case "ATTESTATION_EMAIL":
                        value = list[row].AttestationEmail;
                        break;
                    case "CERTIFICATE_NUMBER":
                        value = list[row].CertificationNumber;
                        break;
                }

                return value.ToString();
            }

            return value.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
