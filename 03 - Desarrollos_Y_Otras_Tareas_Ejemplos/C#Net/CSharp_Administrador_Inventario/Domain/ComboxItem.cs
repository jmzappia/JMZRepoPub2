/*
 * Autor: Julián Marcelo Zappia
 * User: ?
 * Date: 16/07/2019
 * Time: 10:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Domain
{
    public class ComboboxItem
    {

     
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
