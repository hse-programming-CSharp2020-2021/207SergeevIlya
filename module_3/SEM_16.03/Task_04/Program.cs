using System;

namespace Task_04
{
    struct Rectangle : IComparable
    {
        public int a, b;

        public int CompareTo(object obj)
        {
            if (obj is Rectangle)
            {
                return (this.a * this.b).CompareTo(((Rectangle)obj).a * ((Rectangle)obj).b);
            }
            else
                throw new NotImplementedException("Сорян((");
        }

        public new string ToString ()
        {
            return ($"a:{a}, b:{b}");
        }
    }
    
    class Block3D : IComparable
    {
        public Rectangle b;
        public int h;

        public int CompareTo(object obj)
        {
            if (obj is Block3D)
            {
                return b.CompareTo(((Block3D)obj).b);
            }
            else
                throw new NotImplementedException();
        }

        public new string ToString ()
        {
            return ("Основание: " + b.ToString() + ", Высота: " + h.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Block3D[] blocks = new Block3D[69];

            for (int i = 0; i < 69; ++i)
            {
                Random rand = new Random();

                blocks[i] = new Block3D()
                {
                    h = rand.Next(1, 100),
                    b = new Rectangle()
                    {
                        a = rand.Next(13, 77),
                        b = rand.Next(5, 6)
                    }
                };
            }

            Array.Sort(blocks);

            foreach (Block3D block in blocks)
            {
                Console.WriteLine(block.ToString());
            }
        }
    }
}
