using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class Tile
    {
        #region Static Variables and Functions
        // The padding in pixels for the jigsaw tile.
        // As explained above in the diagram, we are 
        // having each tile of 140 by 140 pixels with
        // 20 pixels padding.
        public static int Padding = 20;

        // The actual size of the tile (minus the padding).
        public static int TileSize = 100;

        // These are the control points for our Bezier curve.
        // These control points do not change and are marked readonly.
        public static readonly List<Vector2> ControlPoints = new List<Vector2>()
        {
            new Vector2(0, 0),
            new Vector2(35, 15),
            new Vector2(47, 13),
            new Vector2(45, 5),
            new Vector2(48, 0),
            new Vector2(25, -5),
            new Vector2(15, -18),
            new Vector2(36, -20),
            new Vector2(64, -20),
            new Vector2(85, -18),
            new Vector2(75, -5),
            new Vector2(52, 0),
            new Vector2(55, 5),
            new Vector2(53, 13),
            new Vector2(65, 15),
            new Vector2(100, 0)                
        };

        // The template Bezier curve.
        public static List<Vector2> BezCurve = BezierCurve.PointList2(ControlPoints, 0.001f);
        #endregion
    }
}
