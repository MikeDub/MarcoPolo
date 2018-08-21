using KnockKnock.Web.Models;

namespace KnockKnock.Web.Services.TriangleType
{
    public class TriangleTypeService : ITriangleTypeService
    {
        /// <inheritdoc />
        public string CalculateTriangleType(int a, int b, int c)
        {
            Triangle triangle = new Triangle(a, b, c);
            if (triangle.IsValid)
            {
                // Equal side variants
                if (triangle.AllSidesAreEqual)
                {
                    return "Equilateral";
                }
                // If two sides are equal return iso, else scalene for no sides are equal
                return triangle.TwoSidesAreEqual ? "Isosceles" : "Scalene";
            }
            return "Error";
        }
    }
}