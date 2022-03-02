namespace L1_Rekursija.Methods
{
    public class TaskUtils
    {
        /// <summary>
        /// Checks if given char from TextBox is an integar and is > 1 and < 16
        /// </summary>
        /// <param name="dataFromTexbox"></param>
        /// <returns></returns>
        public static int NumberValidation(string dataFromTexbox)
        {
            int data;
            bool isNumeric = int.TryParse(dataFromTexbox, out data);

            if (!isNumeric || data < 1 || data > 16)
            {
                return -1;
            }

            return data;
        }
        /// <summary>
        /// Calculates coorinate distance to the circle center
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="centerX">center x cord</param>
        /// <param name="centerY">center y cord</param>
        /// <returns></returns>
        public static double CalculateDistance(int x, int y, double centerX, double centerY) =>
            ((x - centerX) * (x - centerX)) + ((y - centerY) * (y - centerY));

        /// <summary>
        /// Calculates radius squared
        /// </summary>
        /// <param name="radius">circle radius</param>
        /// <param name="offset">erorr offset</param>
        /// <returns>Radius squared value</returns>
        public static double RadiusSquared(int radius,double offset) => (radius - offset) * (radius- offset);
    }
}