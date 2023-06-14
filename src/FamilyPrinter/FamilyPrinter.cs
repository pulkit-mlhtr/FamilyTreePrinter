using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamilyPrinter {
    public class FamilyPrinter {
        /// <summary>
        /// Change this method any way you want.
        /// The code should also work for children of great great granddad.
        /// </summary>
        public static string Print(Ancestor a)
        {            
            StringBuilder str = new StringBuilder();
            int parentDepth = 1;
            str.AppendLine("*" + a.Name);

            GetFamilyTree(a.Children, parentDepth, str);            

            return str.ToString();           
        }

        private static bool IsParent(Person child)
        {
            return child.GetType() == typeof(Parent);
        } 
        
        private static bool HasChildern(Person child)
        {
            return (child as Parent).Children != null && (child as Parent).Children.Any();
        }

        private static void GetFamilyTree(List<Person> c, int parentDepth, StringBuilder str)
        {
            if (c != null && c.Any())
            {
                foreach (var child in c)
                {
                    if (IsParent(child))
                    {                        
                        str = GetIndentationSpace(parentDepth, str);

                        str.AppendLine("*" + child.Name);

                        if (HasChildern(child))
                        {
                            int childDepth = parentDepth + 1;
                            GetFamilyTree((child as Parent).Children, childDepth, str);
                        }
                    }
                    else
                    {
                        str = GetIndentationSpace(parentDepth, str);
                        str.AppendLine("-" + child.Name);
                    }
                }
            }
        }

        private static StringBuilder GetIndentationSpace(int depth, StringBuilder str)
        {
            int count = depth + depth;

            str.Append(new string(' ', count));

            return str;
        }
    }
}
