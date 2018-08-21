namespace KnockKnock.Web.Models
{
    public class Triangle
    {
        public int A { get; }
        public int B { get; }
        public int C { get; }

        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public bool IsValid => A > 1 && B > 1 && C > 1;

        public bool AllSidesAreEqual => A == B && A == C && B == C;

        public bool TwoSidesAreEqual => A == B && A != C && B != C 
            || A == C && B != C && A != B 
            || B == C && A != C && A != B;

        // A = B
        // A = C
        // B = C
       
    }
}