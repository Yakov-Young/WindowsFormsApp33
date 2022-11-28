using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp33
{

    class Point
    {
        internal List<double> point = new List<double>();

        public Point(double x, double y, double z)
        {
            this.point.Add(x);
            this.point.Add(y);
            this.point.Add(z);
        }

        internal Point() { }

        public void Get(Label label)
        {
            label.Text = point[0] + ", " + point[1] + ", " + point[2];
            //Console.WriteLine(point[0] + ", " + point[1] + ", " + point[2]);
        }
        public static bool operator ==(Point item1, Point item2)
        {
            bool temp;
            for (int i = 0; i < 3; i++)
            {
                temp = item1.point[i] == item2.point[i];
                if (!temp)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Point item1, Point item2)
        {
            bool temp1;
            bool temp2 = true;
            for (int i = 0; i < 3; i++)
            {
                temp1 = item1.point[i] == item2.point[i];
                temp2 = temp1 && temp2;
                if (!temp2)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Points : Point
    {
        public List<Point> points = new List<Point>();

        public Points() {}
        public Points(int id)
        {
            points = null;
        }

        public static void Get(Points points ,RichTextBox richTextBox)
        {
                if (points is null || points.points is null || points.points.Count == 0)
                {
                    return;
                }
            for (int i = 0; i < points.points.Count; i++)
            {
                //Console.WriteLine(points[i].point[0] + ", " + points[i].point[1] + ", " + points[i].point[2]);
                richTextBox.AppendText("{ " + points.points[i].point[0] + ", " + points.points[i].point[1] + ", " + points.points[i].point[2] + " }\n");
            }
        }

        public static Points operator +(Points array, Point item)
        {
            if (array is null)
            {
                return null;
            }
            if (array.points.Count == 0)
            {
                array.points.Add(item);
                return array;
            }

            double temp1, temp2, temp3;
            bool a, b;
            int i = 0;

            for (; i < array.points.Count; i++)
            {
                temp1 = array.points[i].point[0];
                a = temp1 > item.point[0];
                b = temp1 == item.point[0];

                if (a)
                {
                    break;
                }
                else if (b)
                {
                    temp2 = array.points[i].point[1];
                    a = temp2 > item.point[1];
                    b = temp2 == item.point[1];
                    if (a)
                    {
                        break;
                    }
                    else if (b)
                    {
                        temp3 = array.points[i].point[2];
                        a = temp3 > item.point[2];
                        if (a)
                        {
                            break;
                        }
                    }
                }
            }

            array.points.Insert(i, item);


            return array;
        }

        public static Points operator -(Points array, Point item)
        {
            try
            {
                if (array is null || array.points is null || array.points.Count == 0)
                {
                    throw new Exception();
                }

                if (array.points.Contains(item))
                {
                    return array;
                }
                for (int i = 0; i < array.points.Count; i++)
                {
                    if (array.points[i] == item)
                    {
                        array.points.RemoveAt(i);
                        return array;
                    }

                }

                return array;
            }
            catch (Exception)
            {
                
                MessageBox.Show("Массив пуст","Ошибка");
                return array;
            }
            
        }

        public static Points operator +(Points array1, Points array2)
        {
            Points result = new Points(2);

            for (int i = 0; i < array2.points.Count; i++)
            {
                result = array1 + array2.points[i];
            }

            return result;
        }

        public static Points operator -(Points array1, Points array2)
        {
            for (int i = 0; i < array2.points.Count; i++)
            {
                    Point item = array2.points[i];
                    array1 = array1 - item;
            }

            return array1;
        }

        public static bool operator ==(Points array1, Points array2)
        {

            try
            {
                if (array1.points.Count != array2.points.Count)
                {
                    throw new Exception();
                }

                bool temp;
                for (int i = 0; i < array2.points.Count; i++)
                {
                    temp = array1.points[i] == array2.points[i];
                    if (!temp)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Массивы разной размерности", "Ошибка");
                return false;
            }
            
        }

        public static bool operator !=(Points array1, Points array2)
        {

            try
            {
                if (array1.points.Count != array2.points.Count)
                {
                    throw new Exception();
                }

                bool temp1;
                bool temp2 = true;
                for (int i = 0; i < array2.points.Count; i++)
                {
                    temp1 = array1.points[i] == array2.points[i];
                    temp2 = temp1 && temp2;
                    if (!temp2)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Массивы разной размерности", "Ошибка");
                return false;
            }
            
        }
    }
}
