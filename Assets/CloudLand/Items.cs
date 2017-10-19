using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudLand
{
    public class Items
    {

        private static Dictionary<int, string> itemsMap_Name = new Dictionary<int, string>();
        private static Dictionary<string, int> itemsMap_Id = new Dictionary<string, int>();

        public static void InitializeBuiltInItems() {
            register(32768, "cloudland:wood_stick");
            register(32769, "cloudland:wood_axe");
        }

        public static void register(int id, string name)
        {
            itemsMap_Name.Add(id, name);
            itemsMap_Id.Add(name, id);
        }

        public static int toId(string name)
        {
            int s = -1;
            itemsMap_Id.TryGetValue(name, out s);
            return s;
        }

        public static string toName(int id)
        {
            string name = null;
            itemsMap_Name.TryGetValue(id, out name);
            return name;
        }

    }
}
