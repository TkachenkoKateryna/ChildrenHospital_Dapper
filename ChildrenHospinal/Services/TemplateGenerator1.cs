using ChildrenHospinal.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenHospinal.Services
{
    public class TemplateGenerator1
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
    }
}
