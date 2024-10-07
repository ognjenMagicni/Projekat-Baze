using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Takmicenje.AdditionalClasses
{
    public class CellClick
    {
        //Function gets grid, data, column - where id is located, obj what type of id is, VRACA
        public static Object CellClickExecute(object o, DataGridViewCellEventArgs e,DataGridView grid , DataTable data ,int column, object obj)
        {
            int index = e.RowIndex;
            if(index!=-1 && index< grid.RowCount-1)
            {
                return data.Rows[index].ItemArray[column];
            }
            else
            {
                if (typeof(string) == obj.GetType()){
                    return "FFFFFFF";
                }else if (typeof(int) == obj.GetType())
                {
                    return -1;
                }
            }
            return null;
        }
    }
}
