namespace KnockKnock.Web.Services.TriangleType
{
    public interface ITriangleTypeService
    {
        /// <summary>
        /// Determines the type of triangle based on the length of the triangles sides.
        /// </summary>
        /// <param name="a">Length of side a, should be > 1.</param>
        /// <param name="b">Length of side b, should be > 1.</param>
        /// <param name="c">Length of side c, should be > 1.</param>
        /// <returns>The name of the triangle type.</returns>
        string CalculateTriangleType(int a, int b, int c);
    }
}