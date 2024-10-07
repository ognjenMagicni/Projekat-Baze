using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takmicenje.Repository;

namespace Takmicenje.AdditionalClasses
{
    public class ChekingTasks
    {
 
        public static double Do(string Username, int ID_Task, int ID_Room, string solution)
        {
            DataTable dt = RepositoryForAll.getAllById(new[] { "ID_IO","Input", "Output" }, new[] { "InputOutput" }, null, new[] { "FK_Task" }, new object[] { ID_Task });
            if (dt == null || dt.Rows.Count==0)
            {
                MessageBox.Show("Can not retrieve tests, check with administrator");
                return -1.0;
            }
            int ID_Submit1 = Convert.ToInt32(RepositoryForAll.insert(new[] { "FK_Student", "FK_Task", "FK_Room", "[File]" }, "Submit", new object[] { Username, ID_Task, ID_Room, solution }, 5,true));
            
            

            ProcessStartInfo pSI = new ProcessStartInfo();
            pSI.FileName = @"C:\Users\Asus\AppData\Local\Programs\Python\Python311\python.exe";
            pSI.Arguments = $"-c \"{solution}\"";
            pSI.UseShellExecute = false;
            pSI.RedirectStandardInput = true;
            pSI.RedirectStandardOutput = true;

            int numOfIO = dt.Rows.Count;
            int correct = 0;

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ID_IO = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                    string input = Convert.ToString(dt.Rows[i].ItemArray[1]);
                    string output = Convert.ToString(dt.Rows[i].ItemArray[2]);
                    using (Process start = Process.Start(pSI))
                    {
                        start.StandardInput.WriteLine(input);
                        using (System.IO.StreamReader reader = start.StandardOutput)
                        {
                            string solutionOutput = reader.ReadToEnd();
                            string fullSolution = solutionOutput;
                            MessageBox.Show(output + ". ." + fullSolution+".");
                            try
                            {
                                solutionOutput = solutionOutput.Substring(0, solutionOutput.Length - 2);
                            }
                            catch(Exception ex)
                            {
                                solutionOutput = fullSolution;
                            }
                            if (output == solutionOutput)
                            {
                                RepositoryForAll.insert(new[] { "FK_Submit", "FK_Task", "FK_IO","UserOutput", "Correct" }, "SubmitIO", new object[] { ID_Submit1, ID_Task, ID_IO,solutionOutput ,true }, 5);
                                correct++;
                            }
                            else
                            {
                                RepositoryForAll.insert(new[] { "FK_Submit", "FK_Task", "FK_IO", "UserOutput", "Correct" }, "SubmitIO", new object[] { ID_Submit1, ID_Task, ID_IO, solutionOutput,false }, 5);
                            }
                        }
                    }
                }
                RepositoryForAll.update1(  (float)correct / (float)numOfIO ,ID_Submit1 );
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return (double)correct / (double)numOfIO;
        }
    }
}
