
namespace FinalProjectSVGEditor
{
    public enum ShapeType
    {
        Ellipse,
        Rect,
        Circle,
        Square,
        Line,
    }

    [Serializable]
    public class Shape
    {
        public Color StrokeColor;
        public float StrokeThickness;
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public Color FillColor;
        public bool Filled;
        public ShapeType Type;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Shape shape = (Shape)obj;
            return X == shape.X &&
                   Y == shape.Y &&
                   Width == shape.Width &&
                   Height == shape.Height &&
                   StrokeColor == shape.StrokeColor &&
                   FillColor == shape.FillColor &&
                   Type == shape.Type;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 17;
                hashCode = hashCode * 23 + X.GetHashCode();
                hashCode = hashCode * 23 + Y.GetHashCode();
                hashCode = hashCode * 23 + Width.GetHashCode();
                hashCode = hashCode * 23 + Height.GetHashCode();
                hashCode = hashCode * 23 + StrokeColor.GetHashCode();
                hashCode = hashCode * 23 + FillColor.GetHashCode();
                hashCode = hashCode * 23 + Type.GetHashCode();
                return hashCode;
            }
        }
    }
}
