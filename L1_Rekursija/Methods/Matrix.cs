namespace L1_Rekursija.Methods
{
    public class Matrix
    {
        /// <summary>
        /// 2d array
        /// </summary>
        private int[,] matrix { get; set; }

        /// <summary>
        /// 2d array size
        /// Row size is the same as Collum size
        /// </summary>
        private int Size { get; set; }

        /// <summary>
        /// Matrix class containing radius
        /// </summary>
        /// <param name="radius">Circle Radius</param>
        public Matrix(int radius)
        {
            Size = radius*2;
            matrix = new int[Size, Size];
        }

        /// <summary>
        /// Matrix already calculated
        /// </summary>
        /// <param name="data"></param>
        /// <param name="radius">Circle radius</param>
        public Matrix(int[,] data, int radius)
        {
            Size = radius * 2;
            matrix = new int[Size, Size];
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size;j++)
                {
                    matrix[i, j] = data[i, j];
                }
            }
        }
        /// <summary>
        /// Returns Size of the 2d array
        /// Row size is the same as collumn size
        /// </summary>
        public int GetArraySize() => Size;


        /// <summary>
        /// 
        /// Returns [x,y] element of the "matrix" 2d array using indexer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get
            {
                return matrix[x, y];
            }
        }
        /// <summary>
        /// Changes [x,y] element of matrix into num value
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="num">new number</param>
        public void Add(int x, int y, int num)
        {
            matrix[x, y] = num;
        }

        /// <summary>
        /// Recursion method to get array containing cells that are in a circle
        /// 
        /// </summary>
        /// <param name="radius">Circle radius</param>
        /// <param name="n">Filled square count</param>
        /// <param name="centerX">Center circle x coordinate</param>
        /// <param name="centerY">Center circle y coordinate</param>
        /// <param name="x">collum iteration</param>
        /// <param name="y">row iteration</param>
        /// 
        public void UpdateMatrix(int radius, int n, double centerX, double centerY, int x, int y, double errorOffSet)
        {
            //if over array size
            if (x >= GetArraySize() || y >= GetArraySize() || x < 0 || y < 0)
            {
                return;
            }
            double distance = TaskUtils.CalculateDistance(x, y, centerX, centerY);

            // radius squared
            double r2 = TaskUtils.RadiusSquared(radius,errorOffSet);

            // Based on formula x^2 + y^2 < radius^2
            if (distance < r2)
            {
                n += 1; // Count
                matrix[x, y] = n;
            }
            else
            {
                matrix[x, y] = 0;
            }

            if (y >= 2 * radius - 1)
            {
                UpdateMatrix(radius, n, centerX, centerY, x += 1, 0, errorOffSet);
            }
            else
            {
                UpdateMatrix(radius, n, centerX, centerY, x, y += 1, errorOffSet);
            }
        }
    }
}