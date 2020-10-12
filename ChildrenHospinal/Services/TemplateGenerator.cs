using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Patients;
using ChildrenHospinal.Models.Vaccinations;
using ChildrenHospinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenHospinal.Services
{
    public static class TemplateGenerator
    {
        public static string GetHTMLStringForPatients(List<Patient> patients)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Информация о пациентах</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Имя</th>
                                        <th>Дата Рождения</th>
                                        <th>Детское заведение</th>
                                        <th>Доктор</th>
                                    </tr>");

            foreach (var emp in patients)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", emp.FullName, emp.DOB.ToShortDateString(), emp.Institution.Name, emp.Doctor.FullName);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }

        public static string GetHTMLStringForVaccinations(List<VaccinationList> vaccinations)
        {
            var name = vaccinations[0].FullName;
            var doctor = vaccinations[0].DoctorName;
            var address = vaccinations[0].Address;

            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Справка о прививках</h1></div>
                                <div class='header'><h2>Имя: </h2><h3>{0}</h3></div>
                                <div class='header'><h2>Адрес: </h2><h3>{1}</h3></div>
                                <table align='center'>
                                    <tr>
                                        <th>Прививка</th>
                                        <th>Дата</th>
                                        <th>Сделано</th>
                                    </tr>", name, address);

            foreach (var vac in vaccinations)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                  </tr>", vac.VaccinationName, vac.ProcedureDate.ToShortDateString(), vac.ProcedureStatus);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
